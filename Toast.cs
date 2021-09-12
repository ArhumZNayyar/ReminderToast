using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Win32;
using Windows.Foundation.Metadata;
using Windows.Media.Playback;
using Windows.System.Profile;

namespace ReminderToast
{
    public partial class Toast : Form
    {
        AlarmCollection alarmList = new AlarmCollection();
        DateTimePicker newClock = new DateTimePicker();
        DateTime reminderTime;
        MediaPlayer WinMediaPlayer = new MediaPlayer();
        string format = "MM/dd/yyyy hh:mm:ss tt"; //USA
        string dateFormat = "MM/dd/yyyy"; //USA
        string audioFileName = "";
        string modifyName = "";
        int modifyIndex = 0;
        int wmpVolume = 10;

        public Toast()
        {
            InitializeComponent();
        }

        private void clearFields()
        {
            //Clear all fields
            toastNameBox.Clear();
            descriptionBox.Clear();
            timeControl.ResetText();
            repeatCheckBox.Checked = false;
            everyLabel.Visible = false;
            numericBox.Value = 1;
            numericBox.Visible = false;
            repeatBox.Text = "Hour(s)";
            repeatBox.Visible = false;
            repeatTimesBox.Visible = false;
            repeatTimesBox.Value = 0;
            AmountTimesLabel.Visible = false;
            timesHelpLabel.Visible = false;
            enableAudioBox.Checked = false;
            browseButton.Enabled = false;
            audioTextBox.ResetText();
            trackBar1.Value = 10;
            trackBar1.Enabled = false;
            playButton.Enabled = false;
            stopButton.Enabled = false;
            monthCalendar.SelectionRange.Start = DateTime.Today;
            selectedDateBox.Text = monthCalendar.SelectionRange.Start.Date.ToString(dateFormat);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           /*
            * Ensure that the config file exist, then check if the task list is empty or not (null)
            * Otherwise there will be an error due to attempting to set the object to a null object
            */
           if (File.Exists(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile))
            {
                if (Properties.Settings.Default.TaskList != null)
                {
                    //Set Time Format
                    menu12Hour.CheckState = Properties.Settings.Default.USATime;
                    menu24Hour.CheckState = Properties.Settings.Default.WorldTime;
                    if (menu12Hour.Checked == true)
                    {
                        format = "MM/dd/yyyy hh:mm:ss tt";
                        dateFormat = "MM/dd/yyyy";
                    }
                    else
                    {
                        format = "dd/MM/yyyy HH:mm:ss";
                        dateFormat = "dd/MM/yyyy";
                    }
                    //Load reminders
                    alarmList = Properties.Settings.Default.TaskList;
                    for (int i = 0; i < alarmList.tasks.Count(); i++)
                    {
                        toastBox.Items.Add(Properties.Settings.Default.TaskList.tasks[i].alarmName);
                        if (Properties.Settings.Default.TaskList.tasks[i].enabled)
                        {
                            toastBox.SetItemChecked(i, true);
                        }
                    }
                    toastBox.Update();
                    toastBox.Refresh();
                }
            }
            // Set selected date to today's date
            selectedDateBox.Text = monthCalendar.SelectionRange.Start.Date.ToString(dateFormat);
        }

        private void addToastButton_Click(object sender, EventArgs e)
        {
            if (monthCalendar.SelectionRange.Start < DateTime.Today)
            {
                MessageBox.Show("You cannot set a reminder for the past!", "Error");
                clearFields();
                return;
            }

            if (monthCalendar.SelectionRange.Start == DateTime.Today && timeControl.Value.TimeOfDay < DateTime.Now.TimeOfDay)
            {
                MessageBox.Show("You cannot set a reminder for the past!", "Error");
                clearFields();
                return;
            }

            string toastName = "NULL";
            string internalName = "NULL";
            if (!String.IsNullOrEmpty(toastNameBox.Text))
            {
                toastName = toastNameBox.Text;
                internalName = toastNameBox.Text;
            }
            toastBox.Items.Add(toastName + " ["  + monthCalendar.SelectionRange.Start.ToString(dateFormat) + timeControl.Value.ToString(format.Substring(10)) + "]");
            //Set entry to a checked state
            toastBox.SetItemChecked(toastBox.Items.Count - 1, true);
            //Get the time and other details
            reminderTime = timeControl.Value;
            long duration = Convert.ToInt64(Math.Round(numericBox.Value, 0));
            long amount = Convert.ToInt64(Math.Round(repeatTimesBox.Value, 0));
            // Check if default sound was changed
            string toastAudio = "NULL";
            if (enableAudioBox.Checked)
            {
                if (!String.IsNullOrEmpty(audioTextBox.Text))
                {
                    toastAudio = audioTextBox.Text;
                }
            }
            alarmList.tasks.Add(new Alarms
            {
                alarmName = toastName + " [" + monthCalendar.SelectionRange.Start.ToString(dateFormat) + timeControl.Value.ToString(format.Substring(10)) + "]",
                origName = internalName,
                alarmTime = reminderTime,
                alarmDate = monthCalendar.SelectionRange.Start,
                alarmDesc = descriptionBox.Text,
                alarmSound = toastAudio,
                alarmVolume = wmpVolume,
                repeat = repeatCheckBox.Checked,
                repeatTime = repeatBox.Text,
                repeatDuration = duration,
                repeatAmount = amount,
                currentRepeatAmount = 0,
                enabled = true
            });
            clearFields();
        }

        private void toastTimer_Tick(object sender, EventArgs e)
        {
            var yesterday = DateTime.Today.AddDays(-1);
            for (int i = 0; i < toastBox.Items.Count; i++)
            {
                //Toast will only be sent if the entry is enabled (checked)
                if (toastBox.GetItemChecked(i) == true)
                {
                    if (alarmList.tasks[i].alarmName == toastBox.Items[i].ToString())
                    {
                        //Check today's date matches with the reminder's set date and check if its time to send a toast
                        if (DateTime.Today == alarmList.tasks[i].alarmDate && DateTime.Now.TimeOfDay >= alarmList.tasks[i].alarmTime.TimeOfDay && DateTime.Now.TimeOfDay < alarmList.tasks[i].alarmTime.AddSeconds(60).TimeOfDay)
                        {
                            var location = new Uri(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\logo.png");
                            var toast = new ToastContentBuilder().AddText(alarmList.tasks[i].alarmName)
                                .AddText(alarmList.tasks[i].alarmDesc);//.AddAppLogoOverride(location, ToastGenericAppLogoCrop.Circle);
                            bool supportsCustomAudio = true;
                            // Check if Windows Version is above build 1511. If not, do not play custom audio.
                            if (AnalyticsInfo.VersionInfo.DeviceFamily.Equals("Windows.Desktop")
                                && !ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 2))
                            {
                                supportsCustomAudio = false;
                            }
                            if (supportsCustomAudio && alarmList.tasks[i].alarmSound != "NULL")
                            {
                                try
                                {
                                    audioFileName = "file:///" + alarmList.tasks[i].alarmSound;
                                    audioFileName = audioFileName.Replace(@"\", "/");
                                    ToastAudio audio = new ToastAudio()
                                    {
                                        Src = new Uri(audioFileName),
                                        Loop = false,
                                        Silent = true
                                    };
                                    toast.AddAudio(audio);
                                    Uri soundUri = new Uri(audioFileName);
                                    #pragma warning disable CS0618 // Type or member is obsolete
                                    WinMediaPlayer.SetUriSource(soundUri);
                                    #pragma warning restore CS0618 // Type or member is obsolete
                                    WinMediaPlayer.Volume = alarmList.tasks[i].alarmVolume / 100.0f;
                                    WinMediaPlayer.Play();
                                }
                                catch (Exception except)
                                {
                                    MessageBox.Show("Exception: Could not find/play audio file.\n\nDetails:\n" + except, "Exception caught");
                                }
                               
                            }
                            toast.Show();
                            if (alarmList.tasks[i].repeat == true)
                            {
                                //If its a recurring reminder update the time and splice the display text to match the new time
                                if (alarmList.tasks[i].repeatTime == "Second(s)")
                                {
                                    alarmList.tasks[i].alarmTime = DateTime.Now.AddSeconds(alarmList.tasks[i].repeatDuration);
                                    // Update the alarm date just in case the alarm time is set to a new date
                                    alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmTime.Date;
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + "[" + DateTime.Now.AddSeconds(alarmList.tasks[i].repeatDuration).ToString(format) + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList.tasks[i].alarmName = splice;
                                }
                                else if (alarmList.tasks[i].repeatTime == "Minute(s)")
                                {
                                    alarmList.tasks[i].alarmTime = DateTime.Now.AddMinutes(alarmList.tasks[i].repeatDuration);
                                    // Update the alarm date just in case the alarm time is set to a new date
                                    alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmTime.Date;
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + "[" + DateTime.Now.AddMinutes(alarmList.tasks[i].repeatDuration).ToString(format) + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList.tasks[i].alarmName = splice;
                                }
                                else if (alarmList.tasks[i].repeatTime == "Hour(s)")
                                {
                                    alarmList.tasks[i].alarmTime = DateTime.Now.AddHours(alarmList.tasks[i].repeatDuration);
                                    // Update the alarm date just in case the alarm time is set to a new date
                                    alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmTime.Date;
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + "[" + DateTime.Now.AddHours(alarmList.tasks[i].repeatDuration).ToString(format) + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList.tasks[i].alarmName = splice;
                                }
                                else if (alarmList.tasks[i].repeatTime == "Day(s)")
                                {
                                    alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmDate.AddDays(alarmList.tasks[i].repeatDuration);
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + "[" + DateTime.Now.AddDays(alarmList.tasks[i].repeatDuration).ToString() + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList.tasks[i].alarmName = splice;
                                }
                                else if (alarmList.tasks[i].repeatTime == "Month(s)")
                                {
                                    alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmDate.AddMonths(Convert.ToInt32(alarmList.tasks[i].repeatDuration));
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + "[" + DateTime.Now.AddMonths(Convert.ToInt32(alarmList.tasks[i].repeatDuration)).ToString() + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList.tasks[i].alarmName = splice;
                                }
                                else if (alarmList.tasks[i].repeatTime == "Year(s)")
                                {
                                    alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmDate.AddYears(Convert.ToInt32(alarmList.tasks[i].repeatDuration));
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + "[" + DateTime.Now.AddYears(Convert.ToInt32(alarmList.tasks[i].repeatDuration)).ToString() + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList.tasks[i].alarmName = splice;
                                }
                            }
                            else
                            {
                                toastBox.SetItemChecked(i, false); //Does not repeat so uncheck the entry
                            }
                            //Increment the current repeat amount value if it's not infinite (0)
                            //The count will still increment even if it was due to missing the reminder
                            if (alarmList.tasks[i].repeatAmount != 0)
                            {
                                alarmList.tasks[i].currentRepeatAmount++;
                                //If the amount has reached it's desired value, disable the reminder
                                if (alarmList.tasks[i].currentRepeatAmount >= alarmList.tasks[i].repeatAmount)
                                    toastBox.SetItemChecked(i, false);
                            }
                        }
                        //If the reminder was missed due to some reason (I.E: User's computer is off)
                        else if (DateTime.Today.Date > alarmList.tasks[i].alarmDate.Date || DateTime.Today.Date == alarmList.tasks[i].alarmDate.Date && DateTime.Now.TimeOfDay > alarmList.tasks[i].alarmTime.AddSeconds(60).TimeOfDay)
                        {
                            var toast = new ToastContentBuilder().AddText("You missed your reminder!")
                                .AddText(alarmList.tasks[i].alarmName)
                                .AddText("Reminder will be pushed forward if it is a recurring (Hour+) reminder, otherwise it will be disabled but modifiable!");
                            toast.Show();

                            if (alarmList.tasks[i].repeat == true)
                            {
                                if (alarmList.tasks[i].repeatTime == "Hour(s)")
                                {
                                    var newTime = alarmList.tasks[i].alarmTime;
                                    //Keep incrementing the time by its specified value until it is past the current time
                                    while (newTime < DateTime.Now)
                                    {
                                        newTime = newTime.AddHours(alarmList.tasks[i].repeatDuration);
                                    }
                                    //Handle the time first then the date
                                    while (alarmList.tasks[i].alarmDate.Date != newTime.Date)
                                    {
                                        alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmDate.AddDays(1);
                                    }
                                    alarmList.tasks[i].alarmTime = newTime;
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + "[" + newTime.ToString(format) + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList.tasks[i].alarmName = splice;
                                }
                                else if (alarmList.tasks[i].repeatTime == "Day(s)")
                                {
                                    var newTime = alarmList.tasks[i].alarmTime;
                                    while (newTime < DateTime.Now)
                                    {
                                        newTime = newTime.AddDays(alarmList.tasks[i].repeatDuration);
                                        alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmDate.AddDays(alarmList.tasks[i].repeatDuration);
                                    }
                                    alarmList.tasks[i].alarmTime = newTime;
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + "[" + newTime.ToString(format) + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList.tasks[i].alarmName = splice;
                                }
                                else if (alarmList.tasks[i].repeatTime == "Month(s)")
                                {
                                    var newTime = alarmList.tasks[i].alarmTime;
                                    newTime = newTime.AddMonths(Convert.ToInt32(alarmList.tasks[i].repeatDuration));
                                    alarmList.tasks[i].alarmTime = newTime;
                                    alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmDate.AddMonths(Convert.ToInt32(alarmList.tasks[i].repeatDuration));
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + "[" + newTime.ToString(format) + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList.tasks[i].alarmName = splice;
                                }
                                else if (alarmList.tasks[i].repeatTime == "Year(s)")
                                {
                                    var newTime = alarmList.tasks[i].alarmTime;
                                    newTime = newTime.AddYears(Convert.ToInt32(alarmList.tasks[i].repeatDuration));
                                    alarmList.tasks[i].alarmTime = newTime;
                                    alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmDate.AddYears(Convert.ToInt32(alarmList.tasks[i].repeatDuration));
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + "[" + newTime.ToString(format) + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList.tasks[i].alarmName = splice;
                                }
                                else
                                {
                                    toastBox.SetItemChecked(i, false); //Recurrence is not above an hour so disable/uncheck it.
                                }
                            }
                            else
                            {
                                toastBox.SetItemChecked(i, false); //Does not repeat so uncheck the entry
                            }
                            //Increment the current repeat amount value if it's not infinite (0)
                            //The count will still increment even if it was due to missing the reminder
                            if (alarmList.tasks[i].repeatAmount != 0)
                            {
                                alarmList.tasks[i].currentRepeatAmount++;
                                //If the amount has reached it's desired value, disable the reminder
                                if (alarmList.tasks[i].currentRepeatAmount >= alarmList.tasks[i].repeatAmount)
                                    toastBox.SetItemChecked(i, false);
                            }
                        }
                    }
                }
            }
        }

        private void removeToastButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = toastBox.SelectedIndex;
                alarmList.tasks.RemoveAt(index);
                toastBox.Items.Remove(toastBox.SelectedItem);
                //Save after removing so it does not persist after restarting the application
                Properties.Settings.Default.TaskList = alarmList;
                Properties.Settings.Default.Save();
            }
            catch (Exception except)
            {
                MessageBox.Show("Exception: No entry was selected to remove.\n\nDetails:\n" + except, "Exception caught");
            }

        }

        private void repeatCheckBox_Click(object sender, EventArgs e)
        {
            everyLabel.Visible = !everyLabel.Visible;
            numericBox.Visible = !numericBox.Visible;
            repeatBox.Visible = !repeatBox.Visible;
            repeatTimesBox.Visible = !repeatTimesBox.Visible;
            AmountTimesLabel.Visible = !AmountTimesLabel.Visible;
            timesHelpLabel.Visible = !timesHelpLabel.Visible;
        }

        private void Toast_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alarmList.tasks.Count != 0)
            {
                for (int i = 0; i < alarmList.tasks.Count; i++)
                {
                    alarmList.tasks[i].enabled = toastBox.GetItemChecked(i);
                }
                Properties.Settings.Default.TaskList = alarmList;
                Properties.Settings.Default.USATime = menu12Hour.CheckState;
                Properties.Settings.Default.WorldTime = menu24Hour.CheckState;
                Properties.Settings.Default.AudioFilePath = audioTextBox.Text;
                Properties.Settings.Default.autoRun = startOnSystemBootToolStripMenuItem.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void menu12Hour_Click(object sender, EventArgs e)
        {
            format = "MM/dd/yyyy hh:mm:ss tt";
            dateFormat = "MM/dd/yyyy";
            menu12Hour.Checked = true;
            menu24Hour.Checked = false;

            for (int i = 0; i < toastBox.Items.Count; i++)
            {
                string time = toastBox.Items[i].ToString().Substring(toastBox.Items[i].ToString().IndexOf('[') + 1);
                int timeIndex = time.IndexOf("]");
                if (timeIndex >= 0)
                    time = time.Substring(0, timeIndex);
                DateTime dt = DateTime.Parse(time);
                string splice = toastBox.Items[i].ToString();
                int spliceIndex = splice.IndexOf("[");
                if (spliceIndex >= 0)
                    splice = splice.Substring(0, spliceIndex);
                splice = splice + "[" + dt.ToString(format) + "]";
                toastBox.Items[i] = splice;
                alarmList.tasks[i].alarmName = splice;
            }
        }

        private void menu24Hour_Click(object sender, EventArgs e)
        {
            format = "dd/MM/yyyy HH:mm:ss";
            dateFormat = "dd/MM/yyyy";
            menu24Hour.Checked = true;
            menu12Hour.Checked = false;

            for (int i = 0; i < toastBox.Items.Count; i++)
            {
                string time = toastBox.Items[i].ToString().Substring(toastBox.Items[i].ToString().IndexOf('[') + 1);
                int timeIndex = time.IndexOf("]");
                if (timeIndex >= 0)
                    time = time.Substring(0, timeIndex);
                DateTime dt = DateTime.Parse(time);
                string splice = toastBox.Items[i].ToString();
                int spliceIndex = splice.IndexOf("[");
                if (spliceIndex >= 0)
                    splice = splice.Substring(0, spliceIndex);
                splice = splice + "[" + dt.ToString(format) + "]";
                toastBox.Items[i] = splice;
                alarmList.tasks[i].alarmName = splice;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutMenu = new About();
            aboutMenu.Show();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var audioResult = audioDialog.ShowDialog();
            if (audioResult == DialogResult.OK)
            {
                audioFileName = "file:///" + audioDialog.FileName;
                audioFileName = audioFileName.Replace(@"\", "/");
                audioTextBox.Text = audioDialog.FileName;
                Uri soundUri = new Uri(audioFileName);
                #pragma warning disable CS0618 // Type or member is obsolete
                WinMediaPlayer.SetUriSource(soundUri);
                #pragma warning restore CS0618 // Type or member is obsolete
                WinMediaPlayer.Volume = wmpVolume / 100.0f;
            }
            else
            {
                audioDialog.Dispose();
            }
        }

        private void enableAudioBox_Click(object sender, EventArgs e)
        {
            if (enableAudioBox.Checked == false)
            {
                browseButton.Enabled = false;
                audioTextBox.Enabled = false;
                trackBar1.Enabled = false;
                trackBar1.Value = 10;
                playButton.Enabled = false;
                stopButton.Enabled = false;
                audioTextBox.ResetText();
            }
            else
            {
                browseButton.Enabled = true;
                audioTextBox.Enabled = true;
                trackBar1.Enabled = true;
                playButton.Enabled = true;
                stopButton.Enabled = true;
            }
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            try
            {
                //if (toastBox.SelectedIndex > 0)
                clearFields();
                modifyIndex = toastBox.SelectedIndex;
                modifyName = toastBox.Items[modifyIndex].ToString();
                toastNameBox.Text = alarmList.tasks[modifyIndex].origName;
                descriptionBox.Text = alarmList.tasks[modifyIndex].alarmDesc;
                // Check if this reminder has a custom audio
                if (alarmList.tasks[modifyIndex].alarmSound != "NULL")
                {
                    audioTextBox.Text = alarmList.tasks[modifyIndex].alarmSound;
                    audioTextBox.Enabled = true;
                    enableAudioBox.Checked = true;
                    browseButton.Enabled = true;
                    trackBar1.Enabled = true;
                    playButton.Enabled = true;
                    trackBar1.Value = alarmList.tasks[modifyIndex].alarmVolume;
                }
                if (alarmList.tasks[modifyIndex].repeat)
                {
                    repeatCheckBox.Checked = true;
                    everyLabel.Visible = !everyLabel.Visible;
                    numericBox.Visible = !numericBox.Visible;
                    repeatBox.Visible = !repeatBox.Visible;
                    repeatTimesBox.Visible = !repeatTimesBox.Visible;
                    AmountTimesLabel.Visible = !AmountTimesLabel.Visible;
                    timesHelpLabel.Visible = !timesHelpLabel.Visible;

                    numericBox.Value = alarmList.tasks[modifyIndex].repeatDuration;
                    repeatBox.Text = alarmList.tasks[modifyIndex].repeatTime;
                    repeatTimesBox.Value = alarmList.tasks[modifyIndex].repeatAmount;
                }
                modifyButton.Enabled = false;
                addToastButton.Enabled = false;
                removeToastButton.Enabled = false;
                confirmChangeButton.Visible = true;
                discardChangeButton.Visible = true;
                confirmChangeButton.Enabled = true;
                discardChangeButton.Enabled = true;
            }

            catch (Exception except)
            {
                MessageBox.Show("Exception: No entry was selected to modify.\n\nDetails:\n" + except , "Exception caught");
            }
            
        }

        private void discardChangeButton_Click(object sender, EventArgs e)
        {
            //Discard changes simply just resets the input fields
            confirmChangeButton.Visible = false;
            discardChangeButton.Visible = false;
            confirmChangeButton.Enabled = false;
            discardChangeButton.Enabled = false;
            modifyButton.Enabled = true;
            addToastButton.Enabled = true;
            removeToastButton.Enabled = true;

            clearFields();
        }

        private void confirmChangeButton_Click(object sender, EventArgs e)
        {
            //Post the modifications to the selected reminder
            try
            {
                alarmList.tasks[modifyIndex].origName = toastNameBox.Text;
                toastBox.Items[modifyIndex] = toastNameBox.Text + " [" + monthCalendar.SelectionRange.Start.ToString(dateFormat)
               + timeControl.Value.ToString(format.Substring(10)) + "]";
                alarmList.tasks[modifyIndex].alarmName = toastNameBox.Text + " [" +
                    monthCalendar.SelectionRange.Start.ToString(dateFormat) + timeControl.Value.ToString(format.Substring(10)) + "]";
                alarmList.tasks[modifyIndex].alarmDesc = descriptionBox.Text;
                alarmList.tasks[modifyIndex].alarmTime = timeControl.Value;
                if (enableAudioBox.Checked)
                {
                    if (!String.IsNullOrEmpty(audioTextBox.Text))
                    {
                        alarmList.tasks[modifyIndex].alarmSound = audioTextBox.Text;
                        alarmList.tasks[modifyIndex].alarmVolume = trackBar1.Value;
                    }
                    else
                    {
                        alarmList.tasks[modifyIndex].alarmSound = "NULL";
                    }

                }
                else
                {
                    alarmList.tasks[modifyIndex].alarmSound = "NULL";
                }
                alarmList.tasks[modifyIndex].alarmDate = monthCalendar.SelectionRange.Start;
                long duration = Convert.ToInt64(Math.Round(numericBox.Value, 0));
                long amount = Convert.ToInt64(Math.Round(repeatTimesBox.Value, 0));
                alarmList.tasks[modifyIndex].repeat = repeatCheckBox.Checked;
                alarmList.tasks[modifyIndex].repeatTime = repeatBox.Text;
                alarmList.tasks[modifyIndex].repeatDuration = duration;
                alarmList.tasks[modifyIndex].repeatAmount = amount;
                alarmList.tasks[modifyIndex].currentRepeatAmount = 0;
                alarmList.tasks[modifyIndex].enabled = true;
                toastBox.SetItemChecked(modifyIndex, true);
                //Reset the fields to their original state
                confirmChangeButton.Visible = false;
                discardChangeButton.Visible = false;
                confirmChangeButton.Enabled = false;
                discardChangeButton.Enabled = false;
                modifyButton.Enabled = true;
                addToastButton.Enabled = true;
                removeToastButton.Enabled = true;
                clearFields();
            }
            catch (Exception except)
            {
                MessageBox.Show("Exception: Invalid modifications.\n\nDetails:\n" + except, "Exception caught");
            }
           
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDateBox.Text = e.Start.Date.ToString(dateFormat);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            timeControl.ResetText();
        }

        private void Toast_Resize(object sender, EventArgs e)
        {
            //If the form was minimized, set it to the System Tray.  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
                if (Properties.Settings.Default.showBalloonMinimize == true)
                {
                    notifyIcon.ShowBalloonTip(3500);
                    Properties.Settings.Default.showBalloonMinimize = false;
                }
                Properties.Settings.Default.Save();
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startOnSystemBootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set the check state
            startOnSystemBootToolStripMenuItem.Checked = !startOnSystemBootToolStripMenuItem.Checked;
            if (startOnSystemBootToolStripMenuItem.Checked)
            {
                // Configure for current user only
                string subKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
                string subValue = "ReminderToast";
                try
                {   // Apply the registry key to Window's "Run on start-up" registry
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(subKey, true);
                    key.SetValue(subValue, Application.ExecutablePath.ToString());
                }
                catch(Exception except)
                {
                    MessageBox.Show("Exception: " + except, "Exception caught");
                }
            }
            else
            {
                string subKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
                try
                {
                    // Delete the value by name. DO NOT DELETE SUBTREE / SUBKEY
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(subKey, true);
                    key.DeleteValue("ReminderToast");
                }
                catch (Exception except)
                {
                    MessageBox.Show("Exception: " + except, "Exception caught");
                }
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            volumeValueLabel.Text = (trackBar1.Value * 10).ToString() + "%";
            wmpVolume = trackBar1.Value;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(audioTextBox.Text)) {
                try
                {
                    Uri soundUri = new Uri(audioFileName);
                    #pragma warning disable CS0618 // Type or member is obsolete
                    WinMediaPlayer.SetUriSource(soundUri);
                    #pragma warning restore CS0618 // Type or member is obsolete
                    WinMediaPlayer.Volume = wmpVolume / 100.0f;
                    WinMediaPlayer.Play();
                }
                catch (Exception except)
                {
                    MessageBox.Show("Exception: Could not find/play audio file.\n\nDetails:\n" + except, "Exception caught");
                }
            }
            else
            {
                MessageBox.Show("Exception: No audio file has been selected.", "Exception caught");
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(audioTextBox.Text))
            {
                try
                {
                    WinMediaPlayer.Pause();
                }
                catch (Exception except)
                {
                    MessageBox.Show("Exception: Could not stop the audio file.\n\nDetails:\n" + except, "Exception caught");
                }
            }
            else
            {
                MessageBox.Show("Exception: No audio file has been selected.", "Exception caught");
            }
        }
    } //End of Toast class

    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class AlarmCollection : Alarms
    {
        public List<Alarms> tasks = new List<Alarms>();
    }

    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public class Alarms
    {
        public string alarmName { get; set; }
        public DateTime alarmTime { get; set; }
        public DateTime alarmDate { get; set; }
        public string alarmDesc { get; set; }
        public bool repeat { get; set; }
        public string repeatTime { get; set; }
        public long repeatDuration { get; set; }
        public long repeatAmount { get; set; }
        public long currentRepeatAmount { get; set; }
        public bool enabled { get; set; }
        public string alarmSound { get; set; }
        public int alarmVolume { get; set; }
        public string origName { get; set; }
    }
}
