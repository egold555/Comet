namespace VixenPlus.Dialogs
{
    partial class FortuneTellerDialog
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
            this.buttonRemoveSequence = new System.Windows.Forms.Button();
            this.buttonAddSequence = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxSequences = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.checkBoxRandom = new System.Windows.Forms.CheckBox();
            this.textBoxDetection = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonRemoveSequence
            // 
            this.buttonRemoveSequence.Location = new System.Drawing.Point(418, 34);
            this.buttonRemoveSequence.Name = "buttonRemoveSequence";
            this.buttonRemoveSequence.Size = new System.Drawing.Size(75, 25);
            this.buttonRemoveSequence.TabIndex = 51;
            this.buttonRemoveSequence.Text = "Remove";
            this.buttonRemoveSequence.UseVisualStyleBackColor = true;
            this.buttonRemoveSequence.Click += new System.EventHandler(this.buttonRemoveSequence_Click);
            // 
            // buttonAddSequence
            // 
            this.buttonAddSequence.Location = new System.Drawing.Point(317, 34);
            this.buttonAddSequence.Name = "buttonAddSequence";
            this.buttonAddSequence.Size = new System.Drawing.Size(75, 25);
            this.buttonAddSequence.TabIndex = 50;
            this.buttonAddSequence.Text = "Add";
            this.buttonAddSequence.UseVisualStyleBackColor = true;
            this.buttonAddSequence.Click += new System.EventHandler(this.buttonAddSequence_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 49;
            this.label7.Text = "Sequences:";
            // 
            // listBoxSequences
            // 
            this.listBoxSequences.FormattingEnabled = true;
            this.listBoxSequences.ItemHeight = 17;
            this.listBoxSequences.Location = new System.Drawing.Point(12, 78);
            this.listBoxSequences.Name = "listBoxSequences";
            this.listBoxSequences.Size = new System.Drawing.Size(481, 208);
            this.listBoxSequences.TabIndex = 48;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "vix";
            this.openFileDialog1.Filter = "Vixen event sequence | *.vix";
            this.openFileDialog1.InitialDirectory = "Sequences";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "Key Press:";
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(78, 13);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.ReadOnly = true;
            this.textBoxKey.Size = new System.Drawing.Size(72, 25);
            this.textBoxKey.TabIndex = 57;
            this.textBoxKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxKey_KeyDown);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(440, 325);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 23);
            this.buttonTest.TabIndex = 58;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // checkBoxRandom
            // 
            this.checkBoxRandom.AutoSize = true;
            this.checkBoxRandom.Location = new System.Drawing.Point(12, 325);
            this.checkBoxRandom.Name = "checkBoxRandom";
            this.checkBoxRandom.Size = new System.Drawing.Size(82, 21);
            this.checkBoxRandom.TabIndex = 60;
            this.checkBoxRandom.Text = "Random?";
            this.checkBoxRandom.UseVisualStyleBackColor = true;
            this.checkBoxRandom.CheckedChanged += new System.EventHandler(this.checkBoxRandom_CheckedChanged);
            // 
            // textBoxDetection
            // 
            this.textBoxDetection.Location = new System.Drawing.Point(12, 292);
            this.textBoxDetection.Name = "textBoxDetection";
            this.textBoxDetection.ReadOnly = true;
            this.textBoxDetection.Size = new System.Drawing.Size(82, 25);
            this.textBoxDetection.TabIndex = 61;
            this.textBoxDetection.Text = "Detection";
            this.textBoxDetection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDetection_KeyDown);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(317, 325);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 62;
            this.buttonStop.Text = "STOP!";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // FortuneTellerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 358);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.textBoxDetection);
            this.Controls.Add(this.checkBoxRandom);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.buttonRemoveSequence);
            this.Controls.Add(this.buttonAddSequence);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBoxSequences);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FortuneTellerDialog";
            this.Text = "FortuneTeller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonRemoveSequence;
        private System.Windows.Forms.Button buttonAddSequence;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBoxSequences;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.CheckBox checkBoxRandom;
        private System.Windows.Forms.TextBox textBoxDetection;
        private System.Windows.Forms.Button buttonStop;
    }
}