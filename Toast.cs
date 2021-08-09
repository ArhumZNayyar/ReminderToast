using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;

namespace ReminderToast
{
    public partial class Toast : Form
    {
        DateTimePicker newClock = new DateTimePicker();
        string currentTime = DateTime.Now.ToString("HH:mm:ss");
        string alarmTime;
        long aTime = 0; //alarm time
        long nTime = 0; //current time
        List<Alarms> alarmList = new List<Alarms>();

        public Toast()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: Load task from save file
        }

        private void addToastButton_Click(object sender, EventArgs e)
        {
            string toastName = "NULL";
            if (!String.IsNullOrEmpty(toastNameBox.Text))
            {
                toastName = toastNameBox.Text;
            }
            toastBox.Items.Add(toastName + " ["  + timeControl.Value.ToString("HH:mm:ss tt") + "]");
            //Set entry to a checked state
            toastBox.SetItemChecked(toastBox.Items.Count - 1, true);
            //Get the time and other details
            alarmTime = timeControl.Value.ToString("HHmmss");
            aTime = long.Parse(alarmTime);
            bool isRepeated = true;
            if (String.IsNullOrEmpty(repeatBox.Text) || repeatBox.Text == "Never")
            {
                isRepeated = false;
            }
            alarmList.Add(new Alarms
            {
                alarmName = toastNameBox.Text + " [" + timeControl.Value.ToString("HH:mm:ss tt") + "]",
                alarmTime = alarmTime,
                alarmDesc = descriptionBox.Text,
                repeat = isRepeated,
                repeatTime = repeatBox.Text
            });
            //Clear all fields
            toastNameBox.Clear();
            descriptionBox.Clear();
            timeControl.ResetText();
            repeatBox.ResetText();
        }

        private void toastTimer_Tick(object sender, EventArgs e)
        {
            nTime = long.Parse(DateTime.Now.ToString("HHmmss"));
            for (int i = 0; i < toastBox.Items.Count; i++)
            {
                if (toastBox.GetItemChecked(i) == true)
                {
                    if (alarmList[i].alarmName == toastBox.Items[i].ToString())
                    {
                        aTime = long.Parse(alarmList[i].alarmTime);
                        if (nTime >= aTime && (nTime < (aTime + 60)))
                        {
                            new ToastContentBuilder()
                             .AddText(alarmList[i].alarmName)
                             .AddText(alarmList[i].alarmDesc)
                             .Show();
                            if (alarmList[i].repeat == true)
                            {
                                if (alarmList[i].repeatTime == "Every Hour")
                                {
                                    alarmList[i].alarmTime = DateTime.Now.AddHours(1).ToString("HHmmss");
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + " [" + DateTime.Now.AddHours(1).ToString("HH:mm:ss tt") + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList[i].alarmName = splice;
                                }
                                else if (alarmList[i].repeatTime == "Every Four Hours")
                                {
                                    alarmList[i].alarmTime = DateTime.Now.AddHours(4).ToString("HHmmss");
                                    string splice = toastBox.Items[i].ToString();
                                    int spliceIndex = splice.IndexOf("[");
                                    if (spliceIndex >= 0)
                                        splice = splice.Substring(0, spliceIndex);
                                    splice = splice + " [" + DateTime.Now.AddHours(4).ToString("HH:mm:ss tt") + "]";
                                    toastBox.Items[i] = splice;
                                    alarmList[i].alarmName = splice;
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
            alarmList.RemoveAt(index);
            toastBox.Items.Remove(toastBox.SelectedItem);
        }
    } //End of Toast class

    public class Alarms
    {
        public string alarmName { get; set; }
        public string alarmTime { get; set; }
        public string alarmDesc { get; set; }
        public bool repeat { get; set; }
        public string repeatTime { get; set; }
    }
}
