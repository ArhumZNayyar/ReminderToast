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
                    //Load Audio Settings
                    enableAudioBox.Checked = Properties.Settings.Default.customAudio;
                    audioTextBox.Text = Properties.Settings.Default.AudioFilePath;
                    if (enableAudioBox.Checked == true)
                    {
                        browseButton.Enabled = true;
                        audioTextBox.Enabled = true;
                        audioFileName = "file:///" + Properties.Settings.Default.AudioFilePath;
                        audioFileName = audioFileName.Replace(@"\", "/");
                        Uri soundUri = new Uri(audioFileName);
                        #pragma warning disable CS0618 // Type or member is obsolete
                        WinMediaPlayer.SetUriSource(soundUri);
                        #pragma warning restore CS0618 // Type or member is obsolete
                        WinMediaPlayer.Volume = 3 / 100.0f;
                    }
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
        }

        private void addToastButton_Click(object sender, EventArgs e)
        {
            if (monthCalendar.SelectionRange.Start < DateTime.Today)
            {
                MessageBox.Show("You cannot set a reminder for the past!", "Error");
                clearFields();
                return;
            }

            if (timeControl.Value.TimeOfDay < DateTime.Now.TimeOfDay)
            {
                MessageBox.Show("You cannot set a reminder for the past!", "Error");
                clearFields();
                return;
            }

            string toastName = "NULL";
            if (!String.IsNullOrEmpty(toastNameBox.Text))
            {
                toastName = toastNameBox.Text;
            }
            toastBox.Items.Add(toastName + " ["  + monthCalendar.SelectionRange.Start.ToString(dateFormat) + timeControl.Value.ToString(format.Substring(10)) + "]");
            //Set entry to a checked state
            toastBox.SetItemChecked(toastBox.Items.Count - 1, true);
            //Get the time and other details
            reminderTime = timeControl.Value;
            long duration = Convert.ToInt64(Math.Round(numericBox.Value, 0));
            long amount = Convert.ToInt64(Math.Round(repeatTimesBox.Value, 0));
            alarmList.tasks.Add(new Alarms
            {
                alarmName = toastNameBox.Text + " [" + timeControl.Value.ToString(format) + "]",
                alarmTime = reminderTime,
                alarmDate = monthCalendar.SelectionRange.Start,
                alarmDesc = descriptionBox.Text,
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
                        if (DateTime.Today == alarmList.tasks[i].alarmDate && DateTime.Now >= alarmList.tasks[i].alarmTime && (DateTime.Now < (alarmList.tasks[i].alarmTime.AddSeconds(60))))
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
                            if (supportsCustomAudio && enableAudioBox.Checked == true)
                            {
                                ToastAudio audio = new ToastAudio()
                                {
                                    Src = new Uri(audioFileName),
                                    Loop = false,
                                    Silent = true
                                };
                                toast.AddAudio(audio);
                                WinMediaPlayer.Play();
                            }
                            toast.Show();
                            if (alarmList.tasks[i].repeat == true)
                            {
                                //If its a recurring reminder update the time and splice the display text to match the new time
                                if (alarmList.tasks[i].repeatTime == "Second(s)")
                                {
                                    alarmList.tasks[i].alarmTime = DateTime.Now.AddSeconds(alarmList.tasks[i].repeatDuration);
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
                        //If the reminder was missed due to some reason (I.E: User's computer is off) and its the next day
                        //else if (alarmList.tasks[i].alarmDate.Day < DateTime.Today.Day) {
                        //    var newDate = alarmList.tasks[i].alarmDate;
                        //    if (alarmList.tasks[i].repeatTime == "Day(s)")
                        //    {
                        //        alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmDate.AddDays(alarmList.tasks[i].repeatDuration);
                        //    }
                        //    else if (ala)
                        //    {

                        //    }
                        //    else
                        //    { 
                        //        alarmList.tasks[i].alarmDate = alarmList.tasks[i].alarmDate.AddDays(1);
                        //    }
                        //    string splice = toastBox.Items[i].ToString();
                        //    int spliceIndex = splice.IndexOf("[");
                        //    if (spliceIndex >= 0)
                        //        splice = splice.Substring(0, spliceIndex);
                        //    splice = splice + "[" + alarmList.tasks[i].alarmTime.ToString(format) + "]";
                        //    toastBox.Items[i] = splice;
                        //    alarmList.tasks[i].alarmName = splice;
                        //    var toast = new ToastContentBuilder().AddText("You missed your reminder!")
                        //        .AddText(alarmList.tasks[i].alarmName)
                        //        .AddText("The day of the reminder was pushed forward to it's next scheduled day.");
                        //    toast.Show();
                        //}

                        //If the reminder was missed due to some reason (I.E: User's computer is off)
                        else if (DateTime.Today >= alarmList.tasks[i].alarmDate && DateTime.Now > alarmList.tasks[i].alarmTime && (DateTime.Now > (alarmList.tasks[i].alarmTime.AddSeconds(60))))
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
                                    while (alarmList.tasks[i].alarmDate < DateTime.Today)
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
            int index = toastBox.SelectedIndex;
            alarmList.tasks.RemoveAt(index);
            toastBox.Items.Remove(toastBox.SelectedItem);
            //Save after removing so it does not persist after restarting the application
            Properties.Settings.Default.TaskList = alarmList;
            Properties.Settings.Default.Save();
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
                Properties.Settings.Default.customAudio = enableAudioBox.Checked;
                Properties.Settings.Default.AudioFilePath = audioTextBox.Text;
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
                WinMediaPlayer.Volume = 3 / 100.0f;
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
            }
            else
            {
                browseButton.Enabled = true;
                audioTextBox.Enabled = true;
            }
        }

        private void modifyButton_Click(object sender, EventArgs e)
        {
            clearFields();
            modifyIndex = toastBox.SelectedIndex;
            modifyName = toastBox.Items[modifyIndex].ToString();
            toastNameBox.Text = toastBox.Items[modifyIndex].ToString();
            descriptionBox.Text = alarmList.tasks[modifyIndex].alarmDesc;

            modifyButton.Enabled = false;
            addToastButton.Enabled = false;
            removeToastButton.Enabled = false;
            confirmChangeButton.Visible = true;
            discardChangeButton.Visible = true;
            confirmChangeButton.Enabled = true;
            discardChangeButton.Enabled = true;
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
            toastBox.Items[modifyIndex] = toastNameBox.Text + " [" + monthCalendar.SelectionRange.Start.ToString(dateFormat) 
                + timeControl.Value.ToString(format.Substring(10)) + "]";
            alarmList.tasks[modifyIndex].alarmName = toastNameBox.Text + " [" + 
                monthCalendar.SelectionRange.Start.ToString(dateFormat) + timeControl.Value.ToString(format.Substring(10)) + "]";
            alarmList.tasks[modifyIndex].alarmDesc = descriptionBox.Text;
            alarmList.tasks[modifyIndex].alarmTime = timeControl.Value;
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
    }
}
