﻿namespace LedTriks
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Vixen.Dialogs;

    public class SetupDialog : Form
    {
        private Button buttonCancel;
        private Button buttonOK;
        private Button buttonParallelSetup;
        private CheckBox checkBoxUseWithScript;
        private IContainer components = null;
        private GroupBox groupBox1;
        private ushort m_portAddress;

        public SetupDialog(ushort portAddress, bool useWithScript)
        {
            this.InitializeComponent();
            this.m_portAddress = portAddress;
            this.checkBoxUseWithScript.Checked = useWithScript;
        }

        private void buttonParallelSetup_Click(object sender, EventArgs e)
        {
            ParallelSetupDialog dialog = new ParallelSetupDialog(this.m_portAddress);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.m_portAddress = dialog.PortAddress;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.buttonParallelSetup = new Button();
            this.checkBoxUseWithScript = new CheckBox();
            this.groupBox1 = new GroupBox();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.buttonParallelSetup.Location = new Point(0x4f, 0x1c);
            this.buttonParallelSetup.Name = "buttonParallelSetup";
            this.buttonParallelSetup.Size = new Size(0x6f, 0x17);
            this.buttonParallelSetup.TabIndex = 0;
            this.buttonParallelSetup.Text = "Parallel Port Setup";
            this.buttonParallelSetup.UseVisualStyleBackColor = true;
            this.buttonParallelSetup.Click += new EventHandler(this.buttonParallelSetup_Click);
            this.checkBoxUseWithScript.AutoSize = true;
            this.checkBoxUseWithScript.Location = new Point(0x12, 0x4c);
            this.checkBoxUseWithScript.Name = "checkBoxUseWithScript";
            this.checkBoxUseWithScript.Size = new Size(0xe4, 0x11);
            this.checkBoxUseWithScript.TabIndex = 1;
            this.checkBoxUseWithScript.Text = "This will be used with a scripted sequence.";
            this.checkBoxUseWithScript.UseVisualStyleBackColor = true;
            this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.buttonParallelSetup);
            this.groupBox1.Controls.Add(this.checkBoxUseWithScript);
            this.groupBox1.Location = new Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x10c, 0x7a);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LedTriks Setup";
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x7c, 140);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0xcd, 140);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x124, 0xaf);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Name = "SetupDialog";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        public ushort PortAddress
        {
            get
            {
                return this.m_portAddress;
            }
        }

        public bool UseWithScript
        {
            get
            {
                return this.checkBoxUseWithScript.Checked;
            }
        }
    }
}

