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
            this.toastBox = new System.Windows.Forms.CheckedListBox();
            this.timeControl = new System.Windows.Forms.DateTimePicker();
            this.addToastButton = new System.Windows.Forms.Button();
            this.removeToastButton = new System.Windows.Forms.Button();
            this.toastNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.repeatBox = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toastTimer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toastBox
            // 
            this.toastBox.FormattingEnabled = true;
            this.toastBox.HorizontalScrollbar = true;
            this.toastBox.Location = new System.Drawing.Point(12, 38);
            this.toastBox.Name = "toastBox";
            this.toastBox.Size = new System.Drawing.Size(319, 169);
            this.toastBox.TabIndex = 0;
            // 
            // timeControl
            // 
            this.timeControl.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeControl.Location = new System.Drawing.Point(337, 149);
            this.timeControl.Name = "timeControl";
            this.timeControl.ShowUpDown = true;
            this.timeControl.Size = new System.Drawing.Size(88, 20);
            this.timeControl.TabIndex = 1;
            // 
            // addToastButton
            // 
            this.addToastButton.Location = new System.Drawing.Point(337, 184);
            this.addToastButton.Name = "addToastButton";
            this.addToastButton.Size = new System.Drawing.Size(75, 23);
            this.addToastButton.TabIndex = 2;
            this.addToastButton.Text = "Add";
            this.addToastButton.UseVisualStyleBackColor = true;
            this.addToastButton.Click += new System.EventHandler(this.addToastButton_Click);
            // 
            // removeToastButton
            // 
            this.removeToastButton.Location = new System.Drawing.Point(434, 184);
            this.removeToastButton.Name = "removeToastButton";
            this.removeToastButton.Size = new System.Drawing.Size(75, 23);
            this.removeToastButton.TabIndex = 3;
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
            this.toastNameBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Repeat";
            // 
            // repeatBox
            // 
            this.repeatBox.FormattingEnabled = true;
            this.repeatBox.Items.AddRange(new object[] {
            "Never",
            "Every Hour",
            "Every Four Hours"});
            this.repeatBox.Location = new System.Drawing.Point(479, 152);
            this.repeatBox.Name = "repeatBox";
            this.repeatBox.Size = new System.Drawing.Size(153, 21);
            this.repeatBox.TabIndex = 6;
            this.repeatBox.Text = "Never";
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
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Task Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Time";
            // 
            // toastTimer
            // 
            this.toastTimer.Enabled = true;
            this.toastTimer.Interval = 1000;
            this.toastTimer.Tick += new System.EventHandler(this.toastTimer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Description";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(337, 93);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(295, 20);
            this.descriptionBox.TabIndex = 11;
            // 
            // Toast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 221);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.repeatBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toastNameBox);
            this.Controls.Add(this.removeToastButton);
            this.Controls.Add(this.addToastButton);
            this.Controls.Add(this.timeControl);
            this.Controls.Add(this.toastBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Toast";
            this.Text = "Toast Reminder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox toastBox;
        private System.Windows.Forms.DateTimePicker timeControl;
        private System.Windows.Forms.Button addToastButton;
        private System.Windows.Forms.Button removeToastButton;
        private System.Windows.Forms.TextBox toastNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox repeatBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer toastTimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descriptionBox;
    }
}

