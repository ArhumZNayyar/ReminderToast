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
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu12Hour = new System.Windows.Forms.ToolStripMenuItem();
            this.menu24Hour = new System.Windows.Forms.ToolStripMenuItem();
            this.startOnSystemBootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.repeatTimesBox = new System.Windows.Forms.NumericUpDown();
            this.AmountTimesLabel = new System.Windows.Forms.Label();
            this.timesHelpLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.volumeValueLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.startTimerButton = new System.Windows.Forms.Button();
            this.editTimerButton = new System.Windows.Forms.Button();
            this.resetTimerButton = new System.Windows.Forms.Button();
            this.timersTimer = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.timerGroupBox = new System.Windows.Forms.GroupBox();
            this.discardTimerButton = new System.Windows.Forms.Button();
            this.confirmTimerButton = new System.Windows.Forms.Button();
            this.timerInfoLabel = new System.Windows.Forms.Label();
            this.timerNameBox = new System.Windows.Forms.TextBox();
            this.timerNumericS = new System.Windows.Forms.NumericUpDown();
            this.timerNumericM = new System.Windows.Forms.NumericUpDown();
            this.timerNumericH = new System.Windows.Forms.NumericUpDown();
            this.stopTimerButton = new System.Windows.Forms.Button();
            this.recurTimer = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatTimesBox)).BeginInit();
            this.notifyContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.timerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericH)).BeginInit();
            this.SuspendLayout();
            // 
            // toastBox
            // 
            this.toastBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toastBox.FormattingEnabled = true;
            this.toastBox.HorizontalScrollbar = true;
            this.toastBox.Location = new System.Drawing.Point(12, 38);
            this.toastBox.Name = "toastBox";
            this.toastBox.Size = new System.Drawing.Size(319, 446);
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
            this.addToastButton.Location = new System.Drawing.Point(334, 461);
            this.addToastButton.Name = "addToastButton";
            this.addToastButton.Size = new System.Drawing.Size(75, 23);
            this.addToastButton.TabIndex = 5;
            this.addToastButton.Text = "Add";
            this.addToastButton.UseVisualStyleBackColor = true;
            this.addToastButton.Click += new System.EventHandler(this.addToastButton_Click);
            // 
            // removeToastButton
            // 
            this.removeToastButton.Location = new System.Drawing.Point(454, 461);
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
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatToolStripMenuItem,
            this.startOnSystemBootToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu12Hour,
            this.menu24Hour});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
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
            // startOnSystemBootToolStripMenuItem
            // 
            this.startOnSystemBootToolStripMenuItem.Checked = global::ReminderToast.Properties.Settings.Default.autoRun;
            this.startOnSystemBootToolStripMenuItem.Name = "startOnSystemBootToolStripMenuItem";
            this.startOnSystemBootToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.startOnSystemBootToolStripMenuItem.Text = "Start on System Boot";
            this.startOnSystemBootToolStripMenuItem.Click += new System.EventHandler(this.startOnSystemBootToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            this.label2.Location = new System.Drawing.Point(512, 363);
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
            this.audioTextBox.Size = new System.Drawing.Size(236, 23);
            this.audioTextBox.TabIndex = 22;
            this.audioTextBox.Text = global::ReminderToast.Properties.Settings.Default.AudioFilePath;
            // 
            // modifyButton
            // 
            this.modifyButton.Location = new System.Drawing.Point(572, 461);
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
            this.confirmChangeButton.Location = new System.Drawing.Point(334, 461);
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
            this.discardChangeButton.Location = new System.Drawing.Point(454, 461);
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
            this.dividerLabel.Location = new System.Drawing.Point(337, 447);
            this.dividerLabel.Name = "dividerLabel";
            this.dividerLabel.Size = new System.Drawing.Size(323, 2);
            this.dividerLabel.TabIndex = 33;
            // 
            // repeatTimesBox
            // 
            this.repeatTimesBox.Location = new System.Drawing.Point(538, 300);
            this.repeatTimesBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.repeatTimesBox.Name = "repeatTimesBox";
            this.repeatTimesBox.Size = new System.Drawing.Size(91, 20);
            this.repeatTimesBox.TabIndex = 34;
            this.repeatTimesBox.Visible = false;
            // 
            // AmountTimesLabel
            // 
            this.AmountTimesLabel.AutoSize = true;
            this.AmountTimesLabel.Location = new System.Drawing.Point(627, 302);
            this.AmountTimesLabel.Name = "AmountTimesLabel";
            this.AmountTimesLabel.Size = new System.Drawing.Size(35, 13);
            this.AmountTimesLabel.TabIndex = 35;
            this.AmountTimesLabel.Text = "Times";
            this.AmountTimesLabel.Visible = false;
            // 
            // timesHelpLabel
            // 
            this.timesHelpLabel.AutoSize = true;
            this.timesHelpLabel.Location = new System.Drawing.Point(538, 323);
            this.timesHelpLabel.Name = "timesHelpLabel";
            this.timesHelpLabel.Size = new System.Drawing.Size(56, 13);
            this.timesHelpLabel.TabIndex = 36;
            this.timesHelpLabel.Text = "0 = Infinite";
            this.timesHelpLabel.Visible = false;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Minimized to System Tray";
            this.notifyIcon.BalloonTipTitle = "Reminder Toast";
            this.notifyIcon.ContextMenuStrip = this.notifyContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Reminder Toast";
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyContextMenu
            // 
            this.notifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
            this.notifyContextMenu.Name = "notifyContextMenu";
            this.notifyContextMenu.Size = new System.Drawing.Size(94, 26);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(334, 424);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(120, 20);
            this.trackBar1.TabIndex = 37;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Value = 10;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Volume";
            // 
            // playButton
            // 
            this.playButton.Enabled = false;
            this.playButton.Location = new System.Drawing.Point(500, 419);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 39;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // volumeValueLabel
            // 
            this.volumeValueLabel.AutoSize = true;
            this.volumeValueLabel.Location = new System.Drawing.Point(451, 424);
            this.volumeValueLabel.Name = "volumeValueLabel";
            this.volumeValueLabel.Size = new System.Drawing.Size(33, 13);
            this.volumeValueLabel.TabIndex = 40;
            this.volumeValueLabel.Text = "100%";
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(586, 419);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 41;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(12, 496);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(648, 2);
            this.label6.TabIndex = 42;
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circularProgressBar1.InnerColor = System.Drawing.SystemColors.Control;
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(223, 515);
            this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar1.Maximum = 250;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.Color.Gray;
            this.circularProgressBar1.OuterMargin = -25;
            this.circularProgressBar1.OuterWidth = 25;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.circularProgressBar1.ProgressWidth = 12;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar1.Size = new System.Drawing.Size(261, 216);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 43;
            this.circularProgressBar1.Text = "HH:MM:SS";
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(2, 8, 0, 0);
            // 
            // startTimerButton
            // 
            this.startTimerButton.BackColor = System.Drawing.Color.Transparent;
            this.startTimerButton.BackgroundImage = global::ReminderToast.Properties.Resources.play;
            this.startTimerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startTimerButton.FlatAppearance.BorderSize = 0;
            this.startTimerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startTimerButton.Location = new System.Drawing.Point(295, 658);
            this.startTimerButton.Name = "startTimerButton";
            this.startTimerButton.Size = new System.Drawing.Size(50, 40);
            this.startTimerButton.TabIndex = 44;
            this.startTimerButton.UseVisualStyleBackColor = false;
            this.startTimerButton.Click += new System.EventHandler(this.startTimerButton_Click);
            // 
            // editTimerButton
            // 
            this.editTimerButton.BackColor = System.Drawing.Color.Transparent;
            this.editTimerButton.BackgroundImage = global::ReminderToast.Properties.Resources.circle_edit_pen_pencil_glyph_512;
            this.editTimerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editTimerButton.FlatAppearance.BorderSize = 0;
            this.editTimerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editTimerButton.Location = new System.Drawing.Point(334, 557);
            this.editTimerButton.Name = "editTimerButton";
            this.editTimerButton.Size = new System.Drawing.Size(50, 40);
            this.editTimerButton.TabIndex = 45;
            this.editTimerButton.UseVisualStyleBackColor = false;
            this.editTimerButton.Click += new System.EventHandler(this.editTimerButton_Click);
            // 
            // resetTimerButton
            // 
            this.resetTimerButton.BackColor = System.Drawing.Color.Transparent;
            this.resetTimerButton.BackgroundImage = global::ReminderToast.Properties.Resources.reset;
            this.resetTimerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.resetTimerButton.FlatAppearance.BorderSize = 0;
            this.resetTimerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetTimerButton.Location = new System.Drawing.Point(375, 658);
            this.resetTimerButton.Name = "resetTimerButton";
            this.resetTimerButton.Size = new System.Drawing.Size(50, 40);
            this.resetTimerButton.TabIndex = 46;
            this.resetTimerButton.UseVisualStyleBackColor = false;
            this.resetTimerButton.Click += new System.EventHandler(this.resetTimerButton_Click);
            // 
            // timersTimer
            // 
            this.timersTimer.Interval = 1000;
            this.timersTimer.Tick += new System.EventHandler(this.timersTimer_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(339, 498);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Timer";
            // 
            // timerGroupBox
            // 
            this.timerGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.timerGroupBox.Controls.Add(this.recurTimer);
            this.timerGroupBox.Controls.Add(this.discardTimerButton);
            this.timerGroupBox.Controls.Add(this.confirmTimerButton);
            this.timerGroupBox.Controls.Add(this.timerInfoLabel);
            this.timerGroupBox.Controls.Add(this.timerNameBox);
            this.timerGroupBox.Controls.Add(this.timerNumericS);
            this.timerGroupBox.Controls.Add(this.timerNumericM);
            this.timerGroupBox.Controls.Add(this.timerNumericH);
            this.timerGroupBox.Enabled = false;
            this.timerGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timerGroupBox.Location = new System.Drawing.Point(223, 515);
            this.timerGroupBox.Name = "timerGroupBox";
            this.timerGroupBox.Size = new System.Drawing.Size(287, 216);
            this.timerGroupBox.TabIndex = 48;
            this.timerGroupBox.TabStop = false;
            this.timerGroupBox.Text = "Edit Timer";
            this.timerGroupBox.Visible = false;
            // 
            // discardTimerButton
            // 
            this.discardTimerButton.Location = new System.Drawing.Point(159, 143);
            this.discardTimerButton.Name = "discardTimerButton";
            this.discardTimerButton.Size = new System.Drawing.Size(74, 31);
            this.discardTimerButton.TabIndex = 51;
            this.discardTimerButton.Text = "Discard";
            this.discardTimerButton.UseVisualStyleBackColor = true;
            this.discardTimerButton.Click += new System.EventHandler(this.discardTimerButton_Click);
            // 
            // confirmTimerButton
            // 
            this.confirmTimerButton.Location = new System.Drawing.Point(57, 143);
            this.confirmTimerButton.Name = "confirmTimerButton";
            this.confirmTimerButton.Size = new System.Drawing.Size(74, 31);
            this.confirmTimerButton.TabIndex = 50;
            this.confirmTimerButton.Text = "Confirm";
            this.confirmTimerButton.UseVisualStyleBackColor = true;
            this.confirmTimerButton.Click += new System.EventHandler(this.confirmTimerButton_Click);
            // 
            // timerInfoLabel
            // 
            this.timerInfoLabel.AutoSize = true;
            this.timerInfoLabel.Location = new System.Drawing.Point(116, 16);
            this.timerInfoLabel.Name = "timerInfoLabel";
            this.timerInfoLabel.Size = new System.Drawing.Size(61, 13);
            this.timerInfoLabel.TabIndex = 49;
            this.timerInfoLabel.Text = "HH:MM:SS";
            // 
            // timerNameBox
            // 
            this.timerNameBox.Location = new System.Drawing.Point(38, 88);
            this.timerNameBox.Name = "timerNameBox";
            this.timerNameBox.Size = new System.Drawing.Size(223, 20);
            this.timerNameBox.TabIndex = 3;
            this.timerNameBox.Text = "Enter name";
            // 
            // timerNumericS
            // 
            this.timerNumericS.Location = new System.Drawing.Point(171, 35);
            this.timerNumericS.Name = "timerNumericS";
            this.timerNumericS.Size = new System.Drawing.Size(37, 20);
            this.timerNumericS.TabIndex = 2;
            // 
            // timerNumericM
            // 
            this.timerNumericM.Location = new System.Drawing.Point(128, 35);
            this.timerNumericM.Name = "timerNumericM";
            this.timerNumericM.Size = new System.Drawing.Size(37, 20);
            this.timerNumericM.TabIndex = 1;
            // 
            // timerNumericH
            // 
            this.timerNumericH.Location = new System.Drawing.Point(85, 35);
            this.timerNumericH.Name = "timerNumericH";
            this.timerNumericH.Size = new System.Drawing.Size(37, 20);
            this.timerNumericH.TabIndex = 0;
            // 
            // stopTimerButton
            // 
            this.stopTimerButton.BackColor = System.Drawing.Color.Transparent;
            this.stopTimerButton.BackgroundImage = global::ReminderToast.Properties.Resources.pause;
            this.stopTimerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stopTimerButton.Enabled = false;
            this.stopTimerButton.FlatAppearance.BorderSize = 0;
            this.stopTimerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopTimerButton.Location = new System.Drawing.Point(295, 658);
            this.stopTimerButton.Name = "stopTimerButton";
            this.stopTimerButton.Size = new System.Drawing.Size(50, 40);
            this.stopTimerButton.TabIndex = 49;
            this.stopTimerButton.UseVisualStyleBackColor = false;
            this.stopTimerButton.Click += new System.EventHandler(this.stopTimerButton_Click);
            // 
            // recurTimer
            // 
            this.recurTimer.AutoSize = true;
            this.recurTimer.Location = new System.Drawing.Point(57, 115);
            this.recurTimer.Name = "recurTimer";
            this.recurTimer.Size = new System.Drawing.Size(55, 17);
            this.recurTimer.TabIndex = 52;
            this.recurTimer.Text = "Recur";
            this.recurTimer.UseVisualStyleBackColor = true;
            // 
            // Toast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(668, 743);
            this.Controls.Add(this.timerGroupBox);
            this.Controls.Add(this.startTimerButton);
            this.Controls.Add(this.stopTimerButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.resetTimerButton);
            this.Controls.Add(this.editTimerButton);
            this.Controls.Add(this.circularProgressBar1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.volumeValueLabel);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.timesHelpLabel);
            this.Controls.Add(this.AmountTimesLabel);
            this.Controls.Add(this.repeatTimesBox);
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
            this.Resize += new System.EventHandler(this.Toast_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatTimesBox)).EndInit();
            this.notifyContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.timerGroupBox.ResumeLayout(false);
            this.timerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timerNumericH)).EndInit();
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
        private System.Windows.Forms.NumericUpDown repeatTimesBox;
        private System.Windows.Forms.Label AmountTimesLabel;
        private System.Windows.Forms.Label timesHelpLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu12Hour;
        private System.Windows.Forms.ToolStripMenuItem menu24Hour;
        private System.Windows.Forms.ToolStripMenuItem startOnSystemBootToolStripMenuItem;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label volumeValueLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label6;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private System.Windows.Forms.Button startTimerButton;
        private System.Windows.Forms.Button editTimerButton;
        private System.Windows.Forms.Button resetTimerButton;
        private System.Windows.Forms.Timer timersTimer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox timerGroupBox;
        private System.Windows.Forms.Label timerInfoLabel;
        private System.Windows.Forms.TextBox timerNameBox;
        private System.Windows.Forms.NumericUpDown timerNumericS;
        private System.Windows.Forms.NumericUpDown timerNumericM;
        private System.Windows.Forms.NumericUpDown timerNumericH;
        private System.Windows.Forms.Button stopTimerButton;
        private System.Windows.Forms.Button discardTimerButton;
        private System.Windows.Forms.Button confirmTimerButton;
        private System.Windows.Forms.CheckBox recurTimer;
    }
}

