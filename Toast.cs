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
        MediaPlayer WinMediaPlayer = new MediaPlayer();
        string currentTime = DateTime.Now.ToString("HH:mm:ss");
        string alarmTime;
        string format = "hh:mm:ss tt";
        string audioFileName = "";
        string modifyName = "";
        int modifyIndex = 0;
        long aTime = 0; //alarm time
        long nTime = 0; //current time
        bool isModifying = false;

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
                        format = "hh:mm:ss tt";
                    }
                    else
                    {
                        format = "HH:mm:ss";
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
            string toastName = "NULL";
            if (!String.IsNullOrEmpty(toastNameBox.Text))
            {
                toastName = toastNameBox.Text;
            }
            toastBox.Items.Add(toastName + " ["  + timeControl.Value.ToString(format) + "]");
            //Set entry to a checked state
            toastBox.SetItemChecked(toastBox.Items.Count - 1, true);
            //Get the time and other details
            alarmTime = timeControl.Value.ToString("HHmmss");
            aTime = long.Parse(alarmTime);
            long duration = Convert.ToInt64(Math.Round(numericBox.Value, 0));
            alarmList.tasks.Add(new Alarms
            {
                alarmName = toastNameBox.Text + " [" + timeControl.Value.ToString(format) + "]",
                alarmTime = alarmTime,
                alarmDate = DateTime.Today,
                alarmDesc = descriptionBox.Text,
                repeat = repeatCheckBox.Checked,
                repeatTime = repeatBox.Text,
                repeatDuration = duration,
                enabled = true
            });
            clearFields();
        }

        private void toastTimer_Tick(object sender, EventArgs e)
        {
            nTime = long.Parse(DateTime.Now.ToString("HHmmss"));
            for (int i = 0; i < toastBox.Items.Count; i++)
            {
                //Toast will only be sent if the entry is enabled (checked)
                if (toastBox.GetItemChecked(i) == true)
                {
                    if (alarmList.tasks[i].alarmName == toastBox.Items[i].ToString())
                    {
                        aTime = long.Parse(alarmList.tasks[i].alarmTime);
                        //Check today's date matches with the reminder's set date and check if its time to send a toast
                        if (DateTime.Today == alarmList.tasks[i].alarmDate && nTime >= aTime && (nTime < (aTime + 60)))
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
                                    alarmList.tasks[i].alarmTime = DateTime.Now.AddSeconds(alarmList.tasks[i].repeatDuration).ToString("HHmmss");
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
                                    alarmList.tasks[i].alarmTime = DateTime.Now.AddMinutes(alarmList.tasks[i].repeatDuration).ToString("HHmmss");
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
                                    alarmList.tasks[i].alarmTime = DateTime.Now.AddHours(alarmList.tasks[i].repeatDuration).ToString("HHmmss");
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
            format = "hh:mm:ss tt";
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
                splice = splice + "[" + dt.ToString("hh:mm:ss tt") + "]";
                toastBox.Items[i] = splice;
                alarmList.tasks[i].alarmName = splice;
            }
        }

        private void menu24Hour_Click(object sender, EventArgs e)
        {
            format = "HH:mm:ss";
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
                splice = splice + "[" + dt.ToString("HH:mm:ss") + "]";
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

            isModifying = true;
        }

        private void discardChangeButton_Click(object sender, EventArgs e)
        {
            isModifying = false;
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
            toastBox.Items[modifyIndex] = toastNameBox.Text + " [" + timeControl.Value.ToString(format) + "]";
            alarmList.tasks[modifyIndex].alarmName = toastNameBox.Text + " [" + timeControl.Value.ToString(format) + "]";
            alarmList.tasks[modifyIndex].alarmDesc = descriptionBox.Text;
            alarmList.tasks[modifyIndex].alarmTime = timeControl.Value.ToString("HHmmss");
            alarmList.tasks[modifyIndex].alarmDate = DateTime.Today;
            aTime = long.Parse(timeControl.Value.ToString("HHmmss"));
            long duration = Convert.ToInt64(Math.Round(numericBox.Value, 0));
            alarmList.tasks[modifyIndex].repeat = repeatCheckBox.Checked;
            alarmList.tasks[modifyIndex].repeatTime = repeatBox.Text;
            alarmList.tasks[modifyIndex].repeatDuration = duration;
            alarmList.tasks[modifyIndex].enabled = true;
            toastBox.SetItemChecked(modifyIndex, true);

            isModifying = false;
            confirmChangeButton.Visible = false;
            discardChangeButton.Visible = false;
            confirmChangeButton.Enabled = false;
            discardChangeButton.Enabled = false;
            modifyButton.Enabled = true;
            addToastButton.Enabled = true;
            removeToastButton.Enabled = true;
            clearFields();
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
        public string alarmTime { get; set; }
        public DateTime alarmDate { get; set; }
        public string alarmDesc { get; set; }
        public bool repeat { get; set; }
        public string repeatTime { get; set; }
        public long repeatDuration { get; set; }
        public bool enabled { get; set; }
    }
}
