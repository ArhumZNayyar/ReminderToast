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
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.toastTimer = new System.Windows.Forms.Timer(this.components);
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.repeatCheckBox = new System.Windows.Forms.CheckBox();
            this.everyLabel = new System.Windows.Forms.Label();
            this.numericBox = new System.Windows.Forms.NumericUpDown();
            this.menu24Hour = new System.Windows.Forms.ToolStripMenuItem();
            this.menu12Hour = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toastBox.Size = new System.Drawing.Size(319, 191);
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
            this.addToastButton.Location = new System.Drawing.Point(337, 207);
            this.addToastButton.Name = "addToastButton";
            this.addToastButton.Size = new System.Drawing.Size(75, 23);
            this.addToastButton.TabIndex = 5;
            this.addToastButton.Text = "Add";
            this.addToastButton.UseVisualStyleBackColor = true;
            this.addToastButton.Click += new System.EventHandler(this.addToastButton_Click);
            // 
            // removeToastButton
            // 
            this.removeToastButton.Location = new System.Drawing.Point(434, 207);
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
            this.toastNameBox.Size = new System.Drawing.Size(295, 20);
            this.toastNameBox.TabIndex = 1;
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(431, 135);
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
            this.repeatBox.Location = new System.Drawing.Point(434, 170);
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
            this.menuStrip1.Size = new System.Drawing.Size(650, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
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
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
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
            this.descriptionBox.Size = new System.Drawing.Size(295, 20);
            this.descriptionBox.TabIndex = 2;
            // 
            // repeatCheckBox
            // 
            this.repeatCheckBox.AutoSize = true;
            this.repeatCheckBox.Location = new System.Drawing.Point(479, 135);
            this.repeatCheckBox.Name = "repeatCheckBox";
            this.repeatCheckBox.Size = new System.Drawing.Size(15, 14);
            this.repeatCheckBox.TabIndex = 16;
            this.repeatCheckBox.UseVisualStyleBackColor = true;
            this.repeatCheckBox.Click += new System.EventHandler(this.repeatCheckBox_Click);
            // 
            // everyLabel
            // 
            this.everyLabel.AutoSize = true;
            this.everyLabel.Location = new System.Drawing.Point(334, 155);
            this.everyLabel.Name = "everyLabel";
            this.everyLabel.Size = new System.Drawing.Size(34, 13);
            this.everyLabel.TabIndex = 18;
            this.everyLabel.Text = "Every";
            this.everyLabel.Visible = false;
            // 
            // numericBox
            // 
            this.numericBox.Location = new System.Drawing.Point(337, 171);
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
            // menu24Hour
            // 
            this.menu24Hour.CheckState = global::ReminderToast.Properties.Settings.Default.WorldTime;
            this.menu24Hour.Name = "menu24Hour";
            this.menu24Hour.Size = new System.Drawing.Size(180, 22);
            this.menu24Hour.Text = "24-Hour";
            this.menu24Hour.Click += new System.EventHandler(this.menu24Hour_Click);
            // 
            // menu12Hour
            // 
            this.menu12Hour.Checked = true;
            this.menu12Hour.CheckState = global::ReminderToast.Properties.Settings.Default.USATime;
            this.menu12Hour.Name = "menu12Hour";
            this.menu12Hour.Size = new System.Drawing.Size(180, 22);
            this.menu12Hour.Text = "12-Hour";
            this.menu12Hour.Click += new System.EventHandler(this.menu12Hour_Click);
            // 
            // Toast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(650, 238);
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
            this.Text = "Toast Reminder";
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
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
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
    }
}

