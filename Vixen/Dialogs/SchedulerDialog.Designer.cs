namespace VixenPlus.Dialogs
{
    partial class SchedulerDialog
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
            if (disposing && (components != null)) {
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
            this.listBoxPrograms = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddProgram = new System.Windows.Forms.Button();
            this.buttonRemoveProgram = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.timePickerStop = new System.Windows.Forms.DateTimePicker();
            this.checkBoxMon = new System.Windows.Forms.CheckBox();
            this.checkBoxTue = new System.Windows.Forms.CheckBox();
            this.checkBoxWed = new System.Windows.Forms.CheckBox();
            this.checkBoxThu = new System.Windows.Forms.CheckBox();
            this.checkBoxFri = new System.Windows.Forms.CheckBox();
            this.checkBoxSat = new System.Windows.Forms.CheckBox();
            this.checkBoxSun = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerFirstDay = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerLastDay = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.listBoxSequences = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonRemoveSequence = new System.Windows.Forms.Button();
            this.buttonAddSequence = new System.Windows.Forms.Button();
            this.buttonUpdateProgram = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // listBoxPrograms
            // 
            this.listBoxPrograms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPrograms.FormattingEnabled = true;
            this.listBoxPrograms.ItemHeight = 17;
            this.listBoxPrograms.Location = new System.Drawing.Point(12, 38);
            this.listBoxPrograms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxPrograms.Name = "listBoxPrograms";
            this.listBoxPrograms.Size = new System.Drawing.Size(433, 310);
            this.listBoxPrograms.TabIndex = 0;
            this.listBoxPrograms.SelectedIndexChanged += new System.EventHandler(this.listBoxPrograms_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Scheduled Programs:";
            // 
            // buttonAddProgram
            // 
            this.buttonAddProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddProgram.Location = new System.Drawing.Point(13, 353);
            this.buttonAddProgram.Name = "buttonAddProgram";
            this.buttonAddProgram.Size = new System.Drawing.Size(75, 25);
            this.buttonAddProgram.TabIndex = 2;
            this.buttonAddProgram.Text = "New";
            this.buttonAddProgram.UseVisualStyleBackColor = true;
            this.buttonAddProgram.Click += new System.EventHandler(this.buttonAddProgram_Click);
            // 
            // buttonRemoveProgram
            // 
            this.buttonRemoveProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveProgram.Location = new System.Drawing.Point(94, 353);
            this.buttonRemoveProgram.Name = "buttonRemoveProgram";
            this.buttonRemoveProgram.Size = new System.Drawing.Size(75, 25);
            this.buttonRemoveProgram.TabIndex = 3;
            this.buttonRemoveProgram.Text = "Remove";
            this.buttonRemoveProgram.UseVisualStyleBackColor = true;
            this.buttonRemoveProgram.Click += new System.EventHandler(this.buttonRemoveProgram_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(474, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(543, 20);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(414, 25);
            this.textBoxName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Run:";
            // 
            // timePickerStart
            // 
            this.timePickerStart.CustomFormat = "h:mm tt";
            this.timePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePickerStart.Location = new System.Drawing.Point(543, 65);
            this.timePickerStart.Name = "timePickerStart";
            this.timePickerStart.ShowUpDown = true;
            this.timePickerStart.Size = new System.Drawing.Size(90, 25);
            this.timePickerStart.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(639, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "to";
            // 
            // timePickerStop
            // 
            this.timePickerStop.CustomFormat = "h:mm tt";
            this.timePickerStop.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePickerStop.Location = new System.Drawing.Point(665, 65);
            this.timePickerStop.Name = "timePickerStop";
            this.timePickerStop.ShowUpDown = true;
            this.timePickerStop.Size = new System.Drawing.Size(90, 25);
            this.timePickerStop.TabIndex = 9;
            // 
            // checkBoxMon
            // 
            this.checkBoxMon.AutoSize = true;
            this.checkBoxMon.Location = new System.Drawing.Point(543, 97);
            this.checkBoxMon.Name = "checkBoxMon";
            this.checkBoxMon.Size = new System.Drawing.Size(54, 21);
            this.checkBoxMon.TabIndex = 10;
            this.checkBoxMon.Text = "Mon";
            this.checkBoxMon.UseVisualStyleBackColor = true;
            this.checkBoxMon.CheckedChanged += new System.EventHandler(this.checkBoxDayOfWeek_CheckedChanged);
            // 
            // checkBoxTue
            // 
            this.checkBoxTue.AutoSize = true;
            this.checkBoxTue.Location = new System.Drawing.Point(603, 97);
            this.checkBoxTue.Name = "checkBoxTue";
            this.checkBoxTue.Size = new System.Drawing.Size(48, 21);
            this.checkBoxTue.TabIndex = 11;
            this.checkBoxTue.Text = "Tue";
            this.checkBoxTue.UseVisualStyleBackColor = true;
            this.checkBoxTue.CheckedChanged += new System.EventHandler(this.checkBoxDayOfWeek_CheckedChanged);
            // 
            // checkBoxWed
            // 
            this.checkBoxWed.AutoSize = true;
            this.checkBoxWed.Location = new System.Drawing.Point(663, 96);
            this.checkBoxWed.Name = "checkBoxWed";
            this.checkBoxWed.Size = new System.Drawing.Size(53, 21);
            this.checkBoxWed.TabIndex = 12;
            this.checkBoxWed.Text = "Wed";
            this.checkBoxWed.UseVisualStyleBackColor = true;
            this.checkBoxWed.CheckedChanged += new System.EventHandler(this.checkBoxDayOfWeek_CheckedChanged);
            // 
            // checkBoxThu
            // 
            this.checkBoxThu.AutoSize = true;
            this.checkBoxThu.Location = new System.Drawing.Point(723, 97);
            this.checkBoxThu.Name = "checkBoxThu";
            this.checkBoxThu.Size = new System.Drawing.Size(48, 21);
            this.checkBoxThu.TabIndex = 13;
            this.checkBoxThu.Text = "Thu";
            this.checkBoxThu.UseVisualStyleBackColor = true;
            this.checkBoxThu.CheckedChanged += new System.EventHandler(this.checkBoxDayOfWeek_CheckedChanged);
            // 
            // checkBoxFri
            // 
            this.checkBoxFri.AutoSize = true;
            this.checkBoxFri.Location = new System.Drawing.Point(783, 97);
            this.checkBoxFri.Name = "checkBoxFri";
            this.checkBoxFri.Size = new System.Drawing.Size(41, 21);
            this.checkBoxFri.TabIndex = 14;
            this.checkBoxFri.Text = "Fri";
            this.checkBoxFri.UseVisualStyleBackColor = true;
            this.checkBoxFri.CheckedChanged += new System.EventHandler(this.checkBoxDayOfWeek_CheckedChanged);
            // 
            // checkBoxSat
            // 
            this.checkBoxSat.AutoSize = true;
            this.checkBoxSat.Location = new System.Drawing.Point(843, 97);
            this.checkBoxSat.Name = "checkBoxSat";
            this.checkBoxSat.Size = new System.Drawing.Size(45, 21);
            this.checkBoxSat.TabIndex = 15;
            this.checkBoxSat.Text = "Sat";
            this.checkBoxSat.UseVisualStyleBackColor = true;
            this.checkBoxSat.CheckedChanged += new System.EventHandler(this.checkBoxDayOfWeek_CheckedChanged);
            // 
            // checkBoxSun
            // 
            this.checkBoxSun.AutoSize = true;
            this.checkBoxSun.Location = new System.Drawing.Point(903, 97);
            this.checkBoxSun.Name = "checkBoxSun";
            this.checkBoxSun.Size = new System.Drawing.Size(48, 21);
            this.checkBoxSun.TabIndex = 16;
            this.checkBoxSun.Text = "Sun";
            this.checkBoxSun.UseVisualStyleBackColor = true;
            this.checkBoxSun.CheckedChanged += new System.EventHandler(this.checkBoxDayOfWeek_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "First Day:";
            // 
            // dateTimePickerFirstDay
            // 
            this.dateTimePickerFirstDay.Location = new System.Drawing.Point(543, 133);
            this.dateTimePickerFirstDay.Name = "dateTimePickerFirstDay";
            this.dateTimePickerFirstDay.Size = new System.Drawing.Size(224, 25);
            this.dateTimePickerFirstDay.TabIndex = 18;
            // 
            // dateTimePickerLastDay
            // 
            this.dateTimePickerLastDay.Location = new System.Drawing.Point(543, 164);
            this.dateTimePickerLastDay.Name = "dateTimePickerLastDay";
            this.dateTimePickerLastDay.Size = new System.Drawing.Size(224, 25);
            this.dateTimePickerLastDay.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(474, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Last Day:";
            // 
            // listBoxSequences
            // 
            this.listBoxSequences.FormattingEnabled = true;
            this.listBoxSequences.ItemHeight = 17;
            this.listBoxSequences.Location = new System.Drawing.Point(477, 225);
            this.listBoxSequences.Name = "listBoxSequences";
            this.listBoxSequences.Size = new System.Drawing.Size(481, 123);
            this.listBoxSequences.TabIndex = 21;
            this.listBoxSequences.SelectedIndexChanged += new System.EventHandler(this.listBoxSequences_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(474, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Sequences:";
            // 
            // buttonRemoveSequence
            // 
            this.buttonRemoveSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveSequence.Location = new System.Drawing.Point(882, 194);
            this.buttonRemoveSequence.Name = "buttonRemoveSequence";
            this.buttonRemoveSequence.Size = new System.Drawing.Size(75, 25);
            this.buttonRemoveSequence.TabIndex = 24;
            this.buttonRemoveSequence.Text = "Remove";
            this.buttonRemoveSequence.UseVisualStyleBackColor = true;
            this.buttonRemoveSequence.Click += new System.EventHandler(this.buttonRemoveSequence_Click);
            // 
            // buttonAddSequence
            // 
            this.buttonAddSequence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddSequence.Location = new System.Drawing.Point(801, 194);
            this.buttonAddSequence.Name = "buttonAddSequence";
            this.buttonAddSequence.Size = new System.Drawing.Size(75, 25);
            this.buttonAddSequence.TabIndex = 23;
            this.buttonAddSequence.Text = "Add";
            this.buttonAddSequence.UseVisualStyleBackColor = true;
            this.buttonAddSequence.Click += new System.EventHandler(this.buttonAddSequence_Click);
            // 
            // buttonUpdateProgram
            // 
            this.buttonUpdateProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonUpdateProgram.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateProgram.Location = new System.Drawing.Point(477, 352);
            this.buttonUpdateProgram.Name = "buttonUpdateProgram";
            this.buttonUpdateProgram.Size = new System.Drawing.Size(156, 25);
            this.buttonUpdateProgram.TabIndex = 25;
            this.buttonUpdateProgram.Text = "Update Program";
            this.buttonUpdateProgram.UseVisualStyleBackColor = true;
            this.buttonUpdateProgram.Click += new System.EventHandler(this.buttonUpdateProgram_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "vix";
            this.openFileDialog1.Filter = "Vixen event sequence | *.vix";
            this.openFileDialog1.InitialDirectory = "Sequences";
            // 
            // SchedulerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 388);
            this.Controls.Add(this.buttonUpdateProgram);
            this.Controls.Add(this.buttonRemoveSequence);
            this.Controls.Add(this.buttonAddSequence);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBoxSequences);
            this.Controls.Add(this.dateTimePickerLastDay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePickerFirstDay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.checkBoxSun);
            this.Controls.Add(this.checkBoxSat);
            this.Controls.Add(this.checkBoxFri);
            this.Controls.Add(this.checkBoxThu);
            this.Controls.Add(this.checkBoxWed);
            this.Controls.Add(this.checkBoxTue);
            this.Controls.Add(this.checkBoxMon);
            this.Controls.Add(this.timePickerStop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.timePickerStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRemoveProgram);
            this.Controls.Add(this.buttonAddProgram);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxPrograms);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SchedulerDialog";
            this.Text = "Program Scheduler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPrograms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddProgram;
        private System.Windows.Forms.Button buttonRemoveProgram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker timePickerStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker timePickerStop;
        private System.Windows.Forms.CheckBox checkBoxMon;
        private System.Windows.Forms.CheckBox checkBoxTue;
        private System.Windows.Forms.CheckBox checkBoxWed;
        private System.Windows.Forms.CheckBox checkBoxThu;
        private System.Windows.Forms.CheckBox checkBoxFri;
        private System.Windows.Forms.CheckBox checkBoxSat;
        private System.Windows.Forms.CheckBox checkBoxSun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerFirstDay;
        private System.Windows.Forms.DateTimePicker dateTimePickerLastDay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox listBoxSequences;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonRemoveSequence;
        private System.Windows.Forms.Button buttonAddSequence;
        private System.Windows.Forms.Button buttonUpdateProgram;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}