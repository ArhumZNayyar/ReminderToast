namespace ReminderToast
{
    partial class Toast
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toast));
            this.toastBox = new System.Windows.Forms.CheckedListBox();
            this.timeControl = new System.Windows.Forms.DateTimePicker();
            this.addToastButton = new System.Windows.Forms.Button();
            this.removeToastButton = new System.Windows.Forms.Button();
            this.toastNameBox = new System.Windows.Forms.TextBox();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.repeatBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu12Hour = new System.Windows.Forms.ToolStripMenuItem();
            this.menu24Hour = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.toastTimer = new System.Windows.Forms.Timer(this.components);
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.repeatCheckBox = new System.Windows.Forms.CheckBox();
            this.everyLabel = new System.Windows.Forms.Label();
            this.numericBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.audioDialog = new System.Windows.Forms.OpenFileDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.enableAudioBox = new System.Windows.Forms.CheckBox();
            this.audioTextBox = new System.Windows.Forms.RichTextBox();
            this.modifyButton = new System.Windows.Forms.Button();
            this.confirmChangeButton = new System.Windows.Forms.Button();
            this.discardChangeButton = new System.Windows.Forms.Button();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.selectedDateBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.dividerLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toastBox
            // 
            this.toastBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toastBox.FormattingEnabled = true;
            this.toastBox.HorizontalScrollbar = true;
            this.toastBox.Location = new System.Drawing.Point(12, 38);
            this.toastBox.Name = "toastBox";
            this.toastBox.Size = new System.Drawing.Size(319, 412);
            this.toastBox.TabIndex = 0;
            // 
            // timeControl
            // 
            this.timeControl.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeControl.Location = new System.Drawing.Point(337, 132);
            this.timeControl.Name = "timeControl";
            this.timeControl.ShowUpDown = true;
            this.timeControl.Size = new System.Drawing.Size(88, 20);
            this.timeControl.TabIndex = 3;
            // 
            // addToastButton
            // 
            this.addToastButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.addToastButton.Location = new System.Drawing.Point(337, 425);
            this.addToastButton.Name = "addToastButton";
            this.addToastButton.Size = new System.Drawing.Size(75, 23);
            this.addToastButton.TabIndex = 5;
            this.addToastButton.Text = "Add";
            this.addToastButton.UseVisualStyleBackColor = true;
            this.addToastButton.Click += new System.EventHandler(this.addToastButton_Click);
            // 
            // removeToastButton
            // 
            this.removeToastButton.Location = new System.Drawing.Point(454, 425);
            this.removeToastButton.Name = "removeToastButton";
            this.removeToastButton.Size = new System.Drawing.Size(75, 23);
            this.removeToastButton.TabIndex = 6;
            this.removeToastButton.Text = "Remove";
            this.removeToastButton.UseVisualStyleBackColor = true;
            this.removeToastButton.Click += new System.EventHandler(this.removeToastButton_Click);
            // 
            // toastNameBox
            // 
            this.toastNameBox.Location = new System.Drawing.Point(337, 54);
            this.toastNameBox.Name = "toastNameBox";
            this.toastNameBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.toastNameBox.Size = new System.Drawing.Size(325, 20);
            this.toastNameBox.TabIndex = 1;
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(334, 256);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(42, 13);
            this.repeatLabel.TabIndex = 12;
            this.repeatLabel.Text = "Repeat";
            // 
            // repeatBox
            // 
            this.repeatBox.FormattingEnabled = true;
            this.repeatBox.Items.AddRange(new object[] {
            "Second(s)",
            "Minute(s)",
            "Hour(s)",
            "Day(s)",
            "Month(s)",
            "Year(s)"});
            this.repeatBox.Location = new System.Drawing.Point(437, 300);
            this.repeatBox.Name = "repeatBox";
            this.repeatBox.Size = new System.Drawing.Size(92, 21);
            this.repeatBox.TabIndex = 4;
            this.repeatBox.Text = "Hour(s)";
            this.repeatBox.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(668, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu12Hour,
            this.menu24Hour});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // menu12Hour
            // 
            this.menu12Hour.Checked = true;
            this.menu12Hour.CheckState = global::ReminderToast.Properties.Settings.Default.USATime;
            this.menu12Hour.Name = "menu12Hour";
            this.menu12Hour.Size = new System.Drawing.Size(118, 22);
            this.menu12Hour.Text = "12-Hour";
            this.menu12Hour.Click += new System.EventHandler(this.menu12Hour_Click);
            // 
            // menu24Hour
            // 
            this.menu24Hour.CheckState = global::ReminderToast.Properties.Settings.Default.WorldTime;
            this.menu24Hour.Name = "menu24Hour";
            this.menu24Hour.Size = new System.Drawing.Size(118, 22);
            this.menu24Hour.Text = "24-Hour";
            this.menu24Hour.Click += new System.EventHandler(this.menu24Hour_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // taskLabel
            // 
            this.taskLabel.AutoSize = true;
            this.taskLabel.Location = new System.Drawing.Point(334, 38);
            this.taskLabel.Name = "taskLabel";
            this.taskLabel.Size = new System.Drawing.Size(62, 13);
            this.taskLabel.TabIndex = 15;
            this.taskLabel.Text = "Task Name";
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(334, 116);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(30, 13);
            this.timeLabel.TabIndex = 9;
            this.timeLabel.Text = "Time";
            // 
            // toastTimer
            // 
            this.toastTimer.Enabled = true;
            this.toastTimer.Interval = 1000;
            this.toastTimer.Tick += new System.EventHandler(this.toastTimer_Tick);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(334, 77);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 10;
            this.descriptionLabel.Text = "Description";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(337, 93);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(325, 20);
            this.descriptionBox.TabIndex = 2;
            // 
            // repeatCheckBox
            // 
            this.repeatCheckBox.AutoSize = true;
            this.repeatCheckBox.Location = new System.Drawing.Point(382, 256);
            this.repeatCheckBox.Name = "repeatCheckBox";
            this.repeatCheckBox.Size = new System.Drawing.Size(15, 14);
            this.repeatCheckBox.TabIndex = 16;
            this.repeatCheckBox.UseVisualStyleBackColor = true;
            this.repeatCheckBox.Click += new System.EventHandler(this.repeatCheckBox_Click);
            // 
            // everyLabel
            // 
            this.everyLabel.AutoSize = true;
            this.everyLabel.Location = new System.Drawing.Point(334, 281);
            this.everyLabel.Name = "everyLabel";
            this.everyLabel.Size = new System.Drawing.Size(75, 13);
            this.everyLabel.TabIndex = 18;
            this.everyLabel.Text = "Repeat Every:";
            this.everyLabel.Visible = false;
            // 
            // numericBox
            // 
            this.numericBox.Location = new System.Drawing.Point(337, 300);
            this.numericBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericBox.Name = "numericBox";
            this.numericBox.Size = new System.Drawing.Size(91, 20);
            this.numericBox.TabIndex = 19;
            this.numericBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Sound";
            // 
            // audioDialog
            // 
            this.audioDialog.DefaultExt = "wav";
            this.audioDialog.Filter = "*wav file|*.wav|*mp3 file|*mp3";
            this.audioDialog.Title = "Browse Audio Files";
            // 
            // browseButton
            // 
            this.browseButton.Enabled = false;
            this.browseButton.Location = new System.Drawing.Point(337, 379);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 21;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 363);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Audio File";
            // 
            // enableAudioBox
            // 
            this.enableAudioBox.AutoSize = true;
            this.enableAudioBox.Checked = global::ReminderToast.Properties.Settings.Default.customAudio;
            this.enableAudioBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ReminderToast.Properties.Settings.Default, "customAudio", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.enableAudioBox.Location = new System.Drawing.Point(337, 339);
            this.enableAudioBox.Name = "enableAudioBox";
            this.enableAudioBox.Size = new System.Drawing.Size(137, 17);
            this.enableAudioBox.TabIndex = 23;
            this.enableAudioBox.Text = "Replace Default Sound";
            this.enableAudioBox.UseVisualStyleBackColor = true;
            this.enableAudioBox.Click += new System.EventHandler(this.enableAudioBox_Click);
            // 
            // audioTextBox
            // 
            this.audioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ReminderToast.Properties.Settings.Default, "AudioFilePath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.audioTextBox.Enabled = false;
            this.audioTextBox.Location = new System.Drawing.Point(426, 379);
            this.audioTextBox.Name = "audioTextBox";
            this.audioTextBox.Size = new System.Drawing.Size(206, 23);
            this.audioTextBox.TabIndex = 22;
            this.audioTextBox.Text = global::ReminderToast.Properties.Settings.Default.AudioFilePath;
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(557, 425);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(75, 23);
            this.modifyButton.TabIndex = 25;
            this.modifyButton.Text = "Modify";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // confirmChangeButton
            // 
            this.confirmChangeButton.Enabled = false;
            this.confirmChangeButton.Location = new System.Drawing.Point(337, 425);
            this.confirmChangeButton.Name = "confirmChangeButton";
            this.confirmChangeButton.Size = new System.Drawing.Size(75, 23);
            this.confirmChangeButton.TabIndex = 26;
            this.confirmChangeButton.Text = "Confirm";
            this.confirmChangeButton.UseVisualStyleBackColor = true;
            this.confirmChangeButton.Visible = false;
            this.confirmChangeButton.Click += new System.EventHandler(this.confirmChangeButton_Click);
            // 
            // discardChangeButton
            // 
            this.discardChangeButton.Enabled = false;
            this.discardChangeButton.Location = new System.Drawing.Point(454, 425);
            this.discardChangeButton.Name = "discardChangeButton";
            this.discardChangeButton.Size = new System.Drawing.Size(75, 23);
            this.discardChangeButton.TabIndex = 27;
            this.discardChangeButton.Text = "Discard";
            this.discardChangeButton.UseVisualStyleBackColor = true;
            this.discardChangeButton.Visible = false;
            this.discardChangeButton.Click += new System.EventHandler(this.discardChangeButton_Click);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(434, 132);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 28;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Date";
            // 
            // selectedDateBox
            // 
            this.selectedDateBox.Location = new System.Drawing.Point(337, 216);
            this.selectedDateBox.Name = "selectedDateBox";
            this.selectedDateBox.Size = new System.Drawing.Size(88, 20);
            this.selectedDateBox.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Selected Date";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(337, 158);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 32;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // dividerLabel
            // 
            this.dividerLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dividerLabel.Location = new System.Drawing.Point(337, 412);
            this.dividerLabel.Name = "dividerLabel";
            this.dividerLabel.Size = new System.Drawing.Size(323, 2);
            this.dividerLabel.TabIndex = 33;
            // 
            // Toast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(668, 456);
            this.Controls.Add(this.dividerLabel);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectedDateBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.discardChangeButton);
            this.Controls.Add(this.confirmChangeButton);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.enableAudioBox);
            this.Controls.Add(this.audioTextBox);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericBox);
            this.Controls.Add(this.everyLabel);
            this.Controls.Add(this.repeatCheckBox);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.taskLabel);
            this.Controls.Add(this.repeatBox);
            this.Controls.Add(this.repeatLabel);
            this.Controls.Add(this.toastNameBox);
            this.Controls.Add(this.removeToastButton);
            this.Controls.Add(this.addToastButton);
            this.Controls.Add(this.timeControl);
            this.Controls.Add(this.toastBox);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Toast";
            this.Text = "Reminder Toast";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Toast_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox toastBox;
        private System.Windows.Forms.DateTimePicker timeControl;
        private System.Windows.Forms.Button addToastButton;
        private System.Windows.Forms.Button removeToastButton;
        private System.Windows.Forms.TextBox toastNameBox;
        private System.Windows.Forms.Label repeatLabel;
        private System.Windows.Forms.ComboBox repeatBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label taskLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Timer toastTimer;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.CheckBox repeatCheckBox;
        private System.Windows.Forms.Label everyLabel;
        private System.Windows.Forms.NumericUpDown numericBox;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu12Hour;
        private System.Windows.Forms.ToolStripMenuItem menu24Hour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog audioDialog;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.RichTextBox audioTextBox;
        private System.Windows.Forms.CheckBox enableAudioBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Button confirmChangeButton;
        private System.Windows.Forms.Button discardChangeButton;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox selectedDateBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label dividerLabel;
    }
}

