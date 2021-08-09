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
            toastBox.Items.Add(toastName);
            alarmTime = timeControl.Value.ToString("HHmmss");
            aTime = long.Parse(alarmTime);

            alarmList.Add(new Alarms
            {
                alarmName = toastNameBox.Text,
                alarmTime = alarmTime
            });
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
                             .AddText(alarmList[i].alarmTime)
                             .Show();
                            toastTimer.Stop();
                        }
                    }
                }
            }
        }

    } //End of Toast class

    public class Alarms
    {
        public string alarmName { get; set; }
        public string alarmTime { get; set; }
    }
}
