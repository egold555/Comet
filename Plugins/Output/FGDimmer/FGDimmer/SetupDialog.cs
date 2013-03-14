﻿namespace FGDimmer
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO.Ports;
    using System.Windows.Forms;
    using Vixen.Dialogs;

    internal class SetupDialog : Form
    {
        private Button buttonCancel;
        private Button buttonOK;
        private Button buttonSerialSetup;
        private CheckBox checkBoxHoldPort;
        private CheckBox checkBoxModule1;
        private CheckBox checkBoxModule2;
        private CheckBox checkBoxModule3;
        private CheckBox checkBoxModule4;
        private ComboBox comboBoxModule1;
        private ComboBox comboBoxModule2;
        private ComboBox comboBoxModule3;
        private ComboBox comboBoxModule4;
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Module[] m_modules;
        private SerialPort m_selectedPort;
        private RadioButton radioButtonAC;
        private RadioButton radioButtonPWM;

        public SetupDialog(SerialPort selectedPort, Module[] modules, int startChannel, int endChannel, bool holdPort, bool acOperation)
        {
            this.InitializeComponent();
            this.m_selectedPort = selectedPort;
            this.m_modules = modules;
            while (startChannel <= endChannel)
            {
                this.comboBoxModule1.Items.Add(startChannel);
                this.comboBoxModule2.Items.Add(startChannel);
                this.comboBoxModule3.Items.Add(startChannel);
                this.comboBoxModule4.Items.Add(startChannel);
                startChannel++;
            }
            this.checkBoxModule1.Checked = this.m_modules[0].Enabled;
            if (this.checkBoxModule1.Checked && (this.m_modules[0].StartChannel >= ((int) this.comboBoxModule1.Items[0])))
            {
                this.comboBoxModule1.SelectedItem = this.m_modules[0].StartChannel;
            }
            this.checkBoxModule2.Checked = this.m_modules[1].Enabled;
            if (this.checkBoxModule2.Checked && (this.m_modules[1].StartChannel >= ((int) this.comboBoxModule2.Items[0])))
            {
                this.comboBoxModule2.SelectedItem = this.m_modules[1].StartChannel;
            }
            this.checkBoxModule3.Checked = this.m_modules[2].Enabled;
            if (this.checkBoxModule3.Checked && (this.m_modules[2].StartChannel >= ((int) this.comboBoxModule3.Items[0])))
            {
                this.comboBoxModule3.SelectedItem = this.m_modules[2].StartChannel;
            }
            this.checkBoxModule4.Checked = this.m_modules[3].Enabled;
            if (this.checkBoxModule4.Checked && (this.m_modules[3].StartChannel >= ((int) this.comboBoxModule4.Items[0])))
            {
                this.comboBoxModule4.SelectedItem = this.m_modules[3].StartChannel;
            }
            this.checkBoxHoldPort.Checked = holdPort;
            if (acOperation)
            {
                this.radioButtonAC.Checked = true;
            }
            else
            {
                this.radioButtonPWM.Checked = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.m_modules[0].Enabled = this.checkBoxModule1.Checked)
            {
                this.m_modules[0].StartChannel = (int) this.comboBoxModule1.SelectedItem;
            }
            if (this.m_modules[1].Enabled = this.checkBoxModule2.Checked)
            {
                this.m_modules[1].StartChannel = (int) this.comboBoxModule2.SelectedItem;
            }
            if (this.m_modules[2].Enabled = this.checkBoxModule3.Checked)
            {
                this.m_modules[2].StartChannel = (int) this.comboBoxModule3.SelectedItem;
            }
            if (this.m_modules[3].Enabled = this.checkBoxModule4.Checked)
            {
                this.m_modules[3].StartChannel = (int) this.comboBoxModule4.SelectedItem;
            }
        }

        private void buttonSerialSetup_Click(object sender, EventArgs e)
        {
            SerialSetupDialog dialog = new SerialSetupDialog(this.m_selectedPort);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.m_selectedPort = dialog.SelectedPort;
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
            this.groupBox1 = new GroupBox();
            this.comboBoxModule4 = new ComboBox();
            this.checkBoxModule4 = new CheckBox();
            this.comboBoxModule3 = new ComboBox();
            this.checkBoxModule3 = new CheckBox();
            this.comboBoxModule2 = new ComboBox();
            this.checkBoxModule2 = new CheckBox();
            this.comboBoxModule1 = new ComboBox();
            this.checkBoxModule1 = new CheckBox();
            this.buttonOK = new Button();
            this.buttonCancel = new Button();
            this.groupBox2 = new GroupBox();
            this.checkBoxHoldPort = new CheckBox();
            this.buttonSerialSetup = new Button();
            this.groupBox3 = new GroupBox();
            this.radioButtonPWM = new RadioButton();
            this.radioButtonAC = new RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.comboBoxModule4);
            this.groupBox1.Controls.Add(this.checkBoxModule4);
            this.groupBox1.Controls.Add(this.comboBoxModule3);
            this.groupBox1.Controls.Add(this.checkBoxModule3);
            this.groupBox1.Controls.Add(this.comboBoxModule2);
            this.groupBox1.Controls.Add(this.checkBoxModule2);
            this.groupBox1.Controls.Add(this.comboBoxModule1);
            this.groupBox1.Controls.Add(this.checkBoxModule1);
            this.groupBox1.Location = new Point(12, 0x76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x11d, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modules";
            this.comboBoxModule4.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxModule4.FormattingEnabled = true;
            this.comboBoxModule4.Location = new Point(0xd8, 0x62);
            this.comboBoxModule4.Name = "comboBoxModule4";
            this.comboBoxModule4.Size = new Size(0x38, 0x15);
            this.comboBoxModule4.TabIndex = 7;
            this.checkBoxModule4.AutoSize = true;
            this.checkBoxModule4.Location = new Point(0x12, 100);
            this.checkBoxModule4.Name = "checkBoxModule4";
            this.checkBoxModule4.Size = new Size(0xc0, 0x11);
            this.checkBoxModule4.TabIndex = 6;
            this.checkBoxModule4.Text = "Using module 4, starting at channel";
            this.checkBoxModule4.UseVisualStyleBackColor = true;
            this.comboBoxModule3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxModule3.FormattingEnabled = true;
            this.comboBoxModule3.Location = new Point(0xd8, 0x4b);
            this.comboBoxModule3.Name = "comboBoxModule3";
            this.comboBoxModule3.Size = new Size(0x38, 0x15);
            this.comboBoxModule3.TabIndex = 5;
            this.checkBoxModule3.AutoSize = true;
            this.checkBoxModule3.Location = new Point(0x12, 0x4d);
            this.checkBoxModule3.Name = "checkBoxModule3";
            this.checkBoxModule3.Size = new Size(0xc0, 0x11);
            this.checkBoxModule3.TabIndex = 4;
            this.checkBoxModule3.Text = "Using module 3, starting at channel";
            this.checkBoxModule3.UseVisualStyleBackColor = true;
            this.comboBoxModule2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxModule2.FormattingEnabled = true;
            this.comboBoxModule2.Location = new Point(0xd8, 0x34);
            this.comboBoxModule2.Name = "comboBoxModule2";
            this.comboBoxModule2.Size = new Size(0x38, 0x15);
            this.comboBoxModule2.TabIndex = 3;
            this.checkBoxModule2.AutoSize = true;
            this.checkBoxModule2.Location = new Point(0x12, 0x36);
            this.checkBoxModule2.Name = "checkBoxModule2";
            this.checkBoxModule2.Size = new Size(0xc0, 0x11);
            this.checkBoxModule2.TabIndex = 2;
            this.checkBoxModule2.Text = "Using module 2, starting at channel";
            this.checkBoxModule2.UseVisualStyleBackColor = true;
            this.comboBoxModule1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxModule1.FormattingEnabled = true;
            this.comboBoxModule1.Location = new Point(0xd8, 0x1d);
            this.comboBoxModule1.Name = "comboBoxModule1";
            this.comboBoxModule1.Size = new Size(0x38, 0x15);
            this.comboBoxModule1.TabIndex = 1;
            this.checkBoxModule1.AutoSize = true;
            this.checkBoxModule1.Location = new Point(0x12, 0x1f);
            this.checkBoxModule1.Name = "checkBoxModule1";
            this.checkBoxModule1.Size = new Size(0xc0, 0x11);
            this.checkBoxModule1.TabIndex = 0;
            this.checkBoxModule1.Text = "Using module 1, starting at channel";
            this.checkBoxModule1.UseVisualStyleBackColor = true;
            this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonOK.DialogResult = DialogResult.OK;
            this.buttonOK.Location = new Point(0x8d, 0x167);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new Size(0x4b, 0x17);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
            this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(0xde, 0x167);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(0x4b, 0x17);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.groupBox2.Controls.Add(this.checkBoxHoldPort);
            this.groupBox2.Controls.Add(this.buttonSerialSetup);
            this.groupBox2.Location = new Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0x11d, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port";
            this.checkBoxHoldPort.Location = new Point(0x11, 0x36);
            this.checkBoxHoldPort.Name = "checkBoxHoldPort";
            this.checkBoxHoldPort.Size = new Size(0xff, 40);
            this.checkBoxHoldPort.TabIndex = 1;
            this.checkBoxHoldPort.Text = "Hold port open during the duration of the sequence execution.";
            this.checkBoxHoldPort.UseVisualStyleBackColor = true;
            this.buttonSerialSetup.Location = new Point(0x69, 0x11);
            this.buttonSerialSetup.Name = "buttonSerialSetup";
            this.buttonSerialSetup.Size = new Size(0x4b, 0x17);
            this.buttonSerialSetup.TabIndex = 0;
            this.buttonSerialSetup.Text = "Serial Setup";
            this.buttonSerialSetup.UseVisualStyleBackColor = true;
            this.buttonSerialSetup.Click += new EventHandler(this.buttonSerialSetup_Click);
            this.groupBox3.Controls.Add(this.radioButtonAC);
            this.groupBox3.Controls.Add(this.radioButtonPWM);
            this.groupBox3.Location = new Point(12, 0x108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x11d, 0x59);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Operation";
            this.radioButtonPWM.AutoSize = true;
            this.radioButtonPWM.Location = new Point(0x21, 0x1b);
            this.radioButtonPWM.Name = "radioButtonPWM";
            this.radioButtonPWM.Size = new Size(0x63, 0x11);
            this.radioButtonPWM.TabIndex = 0;
            this.radioButtonPWM.TabStop = true;
            this.radioButtonPWM.Text = "PWM operation";
            this.radioButtonPWM.UseVisualStyleBackColor = true;
            this.radioButtonAC.AutoSize = true;
            this.radioButtonAC.Location = new Point(0x21, 0x38);
            this.radioButtonAC.Name = "radioButtonAC";
            this.radioButtonAC.Size = new Size(0x56, 0x11);
            this.radioButtonAC.TabIndex = 1;
            this.radioButtonAC.TabStop = true;
            this.radioButtonAC.Text = "AC operation";
            this.radioButtonAC.UseVisualStyleBackColor = true;
            base.AcceptButton = this.buttonOK;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.CancelButton = this.buttonCancel;
            base.ClientSize = new Size(0x135, 0x18a);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.buttonCancel);
            base.Controls.Add(this.buttonOK);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Name = "SetupDialog";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            base.ResumeLayout(false);
        }

        public bool ACOperation
        {
            get
            {
                return this.radioButtonAC.Checked;
            }
        }

        public bool HoldPort
        {
            get
            {
                return this.checkBoxHoldPort.Checked;
            }
        }

        public int Module1StartChannel
        {
            get
            {
                return (int) this.comboBoxModule1.SelectedItem;
            }
        }

        public int Module2StartChannel
        {
            get
            {
                return (int) this.comboBoxModule2.SelectedItem;
            }
        }

        public int Module3StartChannel
        {
            get
            {
                return (int) this.comboBoxModule3.SelectedItem;
            }
        }

        public int Module4StartChannel
        {
            get
            {
                return (int) this.comboBoxModule4.SelectedItem;
            }
        }

        public SerialPort SelectedPort
        {
            get
            {
                return this.m_selectedPort;
            }
        }

        public bool UsingModule1
        {
            get
            {
                return this.checkBoxModule1.Checked;
            }
        }

        public bool UsingModule2
        {
            get
            {
                return this.checkBoxModule2.Checked;
            }
        }

        public bool UsingModule3
        {
            get
            {
                return this.checkBoxModule3.Checked;
            }
        }

        public bool UsingModule4
        {
            get
            {
                return this.checkBoxModule4.Checked;
            }
        }
    }
}

