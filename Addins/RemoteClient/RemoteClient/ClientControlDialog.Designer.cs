using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;

namespace RemoteClient
{
	internal partial class ClientControlDialog {
		private IContainer components = null;

		#region Windows Form Designer generated code
		private Button buttonAllOff;
private Button buttonAllOn;
private Button buttonAllToggle;
private Button buttonAuthenticate;
private Button buttonDone;
private Button buttonPause;
private Button buttonPlay;
private Button buttonRefresh;
private Button buttonStop;
private GroupBox groupBoxChannels;
private GroupBox groupBoxClients;
private GroupBox groupBoxExecutionControl;
private GroupBox groupBoxPassword;
private Label label1;
private Label labelServerData;
private ListBox listBoxChannels;
private ListBox listBoxClients;
private RadioButton radioButtonControlAll;
private RadioButton radioButtonControlOne;
private TextBox textBoxPassword;

		private void InitializeComponent()
		{
			this.groupBoxClients = new GroupBox();
			this.buttonRefresh = new Button();
			this.listBoxClients = new ListBox();
			this.radioButtonControlOne = new RadioButton();
			this.radioButtonControlAll = new RadioButton();
			this.groupBoxChannels = new GroupBox();
			this.buttonAllToggle = new Button();
			this.buttonAllOff = new Button();
			this.buttonAllOn = new Button();
			this.label1 = new Label();
			this.listBoxChannels = new ListBox();
			this.groupBoxExecutionControl = new GroupBox();
			this.buttonStop = new Button();
			this.buttonPause = new Button();
			this.buttonPlay = new Button();
			this.buttonDone = new Button();
			this.labelServerData = new Label();
			this.groupBoxPassword = new GroupBox();
			this.buttonAuthenticate = new Button();
			this.textBoxPassword = new TextBox();
			this.groupBoxClients.SuspendLayout();
			this.groupBoxChannels.SuspendLayout();
			this.groupBoxExecutionControl.SuspendLayout();
			this.groupBoxPassword.SuspendLayout();
			base.SuspendLayout();
			this.groupBoxClients.Controls.Add(this.buttonRefresh);
			this.groupBoxClients.Controls.Add(this.listBoxClients);
			this.groupBoxClients.Controls.Add(this.radioButtonControlOne);
			this.groupBoxClients.Controls.Add(this.radioButtonControlAll);
			this.groupBoxClients.Enabled = false;
			this.groupBoxClients.Location = new Point(12, 0x49);
			this.groupBoxClients.Name = "groupBoxClients";
			this.groupBoxClients.Size = new Size(0x11e, 0xcf);
			this.groupBoxClients.TabIndex = 1;
			this.groupBoxClients.TabStop = false;
			this.groupBoxClients.Text = "Registered Clients";
			this.buttonRefresh.Location = new Point(6, 0x7e);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new Size(0x4b, 0x17);
			this.buttonRefresh.TabIndex = 1;
			this.buttonRefresh.Text = "Refresh";
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new EventHandler(this.buttonRefresh_Click);
			this.listBoxClients.Dock = DockStyle.Top;
			this.listBoxClients.FormattingEnabled = true;
			this.listBoxClients.Location = new Point(3, 0x10);
			this.listBoxClients.Name = "listBoxClients";
			this.listBoxClients.Size = new Size(280, 0x6c);
			this.listBoxClients.TabIndex = 0;
			this.listBoxClients.DoubleClick += new EventHandler(this.listBoxClients_DoubleClick);
			this.listBoxClients.SelectedIndexChanged += new EventHandler(this.listBoxClients_SelectedIndexChanged);
			this.radioButtonControlOne.AutoSize = true;
			this.radioButtonControlOne.Checked = true;
			this.radioButtonControlOne.Location = new Point(6, 0x9b);
			this.radioButtonControlOne.Name = "radioButtonControlOne";
			this.radioButtonControlOne.Size = new Size(0x93, 0x11);
			this.radioButtonControlOne.TabIndex = 0;
			this.radioButtonControlOne.TabStop = true;
			this.radioButtonControlOne.Text = "Control the selected client";
			this.radioButtonControlOne.UseVisualStyleBackColor = true;
			this.radioButtonControlOne.CheckedChanged += new EventHandler(this.radioButtonControlAll_CheckedChanged);
			this.radioButtonControlAll.AutoSize = true;
			this.radioButtonControlAll.Location = new Point(6, 0xb2);
			this.radioButtonControlAll.Name = "radioButtonControlAll";
			this.radioButtonControlAll.Size = new Size(0xb5, 0x11);
			this.radioButtonControlAll.TabIndex = 1;
			this.radioButtonControlAll.Text = "Simultaneous control of all clients";
			this.radioButtonControlAll.UseVisualStyleBackColor = true;
			this.radioButtonControlAll.CheckedChanged += new EventHandler(this.radioButtonControlAll_CheckedChanged);
			this.groupBoxChannels.Controls.Add(this.buttonAllToggle);
			this.groupBoxChannels.Controls.Add(this.buttonAllOff);
			this.groupBoxChannels.Controls.Add(this.buttonAllOn);
			this.groupBoxChannels.Controls.Add(this.label1);
			this.groupBoxChannels.Controls.Add(this.listBoxChannels);
			this.groupBoxChannels.Enabled = false;
			this.groupBoxChannels.Location = new Point(0x130, 0x49);
			this.groupBoxChannels.Name = "groupBoxChannels";
			this.groupBoxChannels.Size = new Size(0x86, 270);
			this.groupBoxChannels.TabIndex = 2;
			this.groupBoxChannels.TabStop = false;
			this.groupBoxChannels.Text = "Client Channels";
			this.buttonAllToggle.Location = new Point(0x16, 0x55);
			this.buttonAllToggle.Name = "buttonAllToggle";
			this.buttonAllToggle.Size = new Size(90, 0x15);
			this.buttonAllToggle.TabIndex = 3;
			this.buttonAllToggle.Text = "All toggle";
			this.buttonAllToggle.UseVisualStyleBackColor = true;
			this.buttonAllToggle.Click += new EventHandler(this.buttonAllToggle_Click);
			this.buttonAllOff.Location = new Point(0x16, 0x41);
			this.buttonAllOff.Name = "buttonAllOff";
			this.buttonAllOff.Size = new Size(90, 0x13);
			this.buttonAllOff.TabIndex = 2;
			this.buttonAllOff.Text = "All off";
			this.buttonAllOff.UseVisualStyleBackColor = true;
			this.buttonAllOff.Click += new EventHandler(this.buttonAllOff_Click);
			this.buttonAllOn.Location = new Point(0x16, 0x2d);
			this.buttonAllOn.Name = "buttonAllOn";
			this.buttonAllOn.Size = new Size(90, 0x13);
			this.buttonAllOn.TabIndex = 1;
			this.buttonAllOn.Text = "All on";
			this.buttonAllOn.UseVisualStyleBackColor = true;
			this.buttonAllOn.Click += new EventHandler(this.buttonAllOn_Click);
			this.label1.Dock = DockStyle.Top;
			this.label1.Location = new Point(3, 0x10);
			this.label1.Name = "label1";
			this.label1.Size = new Size(0x80, 0x24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select/deselect items to turn the channels on/off.";
			this.listBoxChannels.Dock = DockStyle.Bottom;
			this.listBoxChannels.FormattingEnabled = true;
			this.listBoxChannels.Location = new Point(3, 0x6b);
			this.listBoxChannels.Name = "listBoxChannels";
			this.listBoxChannels.SelectionMode = SelectionMode.MultiSimple;
			this.listBoxChannels.Size = new Size(0x80, 160);
			this.listBoxChannels.TabIndex = 4;
			this.listBoxChannels.MouseDown += new MouseEventHandler(this.listBoxChannels_MouseDown);
			this.groupBoxExecutionControl.Controls.Add(this.buttonStop);
			this.groupBoxExecutionControl.Controls.Add(this.buttonPause);
			this.groupBoxExecutionControl.Controls.Add(this.buttonPlay);
			this.groupBoxExecutionControl.Enabled = false;
			this.groupBoxExecutionControl.Location = new Point(12, 0x11b);
			this.groupBoxExecutionControl.Name = "groupBoxExecutionControl";
			this.groupBoxExecutionControl.Size = new Size(0x11e, 60);
			this.groupBoxExecutionControl.TabIndex = 3;
			this.groupBoxExecutionControl.TabStop = false;
			this.groupBoxExecutionControl.Text = "Client Execution Control";
			this.buttonStop.Location = new Point(0xbc, 0x17);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new Size(0x4b, 0x17);
			this.buttonStop.TabIndex = 4;
			this.buttonStop.Text = "Stop";
			this.buttonStop.UseVisualStyleBackColor = true;
			this.buttonStop.Click += new EventHandler(this.buttonStop_Click);
			this.buttonPause.Location = new Point(0x6b, 0x17);
			this.buttonPause.Name = "buttonPause";
			this.buttonPause.Size = new Size(0x4b, 0x17);
			this.buttonPause.TabIndex = 3;
			this.buttonPause.Text = "Pause";
			this.buttonPause.UseVisualStyleBackColor = true;
			this.buttonPause.Click += new EventHandler(this.buttonPause_Click);
			this.buttonPlay.Location = new Point(0x1a, 0x17);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new Size(0x4b, 0x17);
			this.buttonPlay.TabIndex = 2;
			this.buttonPlay.Text = "Play";
			this.buttonPlay.UseVisualStyleBackColor = true;
			this.buttonPlay.Click += new EventHandler(this.buttonPlay_Click);
			this.buttonDone.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonDone.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonDone.Location = new Point(0x16c, 0x15f);
			this.buttonDone.Name = "buttonDone";
			this.buttonDone.Size = new Size(0x4b, 0x17);
			this.buttonDone.TabIndex = 4;
			this.buttonDone.Text = "Done";
			this.buttonDone.UseVisualStyleBackColor = true;
			this.labelServerData.AutoSize = true;
			this.labelServerData.Location = new Point(15, 0x164);
			this.labelServerData.Name = "labelServerData";
			this.labelServerData.Size = new Size(0, 13);
			this.labelServerData.TabIndex = 4;
			this.groupBoxPassword.Controls.Add(this.buttonAuthenticate);
			this.groupBoxPassword.Controls.Add(this.textBoxPassword);
			this.groupBoxPassword.Location = new Point(12, 9);
			this.groupBoxPassword.Name = "groupBoxPassword";
			this.groupBoxPassword.Size = new Size(0x1aa, 0x3a);
			this.groupBoxPassword.TabIndex = 0;
			this.groupBoxPassword.TabStop = false;
			this.groupBoxPassword.Text = "Server Password";
			this.buttonAuthenticate.Location = new Point(0x12a, 0x15);
			this.buttonAuthenticate.Name = "buttonAuthenticate";
			this.buttonAuthenticate.Size = new Size(0x60, 0x17);
			this.buttonAuthenticate.TabIndex = 1;
			this.buttonAuthenticate.Text = "Authenticate";
			this.buttonAuthenticate.UseVisualStyleBackColor = true;
			this.buttonAuthenticate.Click += new EventHandler(this.buttonAuthenticate_Click);
			this.textBoxPassword.Location = new Point(6, 0x17);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new Size(280, 20);
			this.textBoxPassword.TabIndex = 0;
			this.textBoxPassword.Enter += new EventHandler(this.textBoxPassword_Enter);
			this.textBoxPassword.Leave += new EventHandler(this.textBoxPassword_Leave);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new Size(0x1c3, 0x182);
			base.Controls.Add(this.groupBoxPassword);
			base.Controls.Add(this.labelServerData);
			base.Controls.Add(this.buttonDone);
			base.Controls.Add(this.groupBoxExecutionControl);
			base.Controls.Add(this.groupBoxChannels);
			base.Controls.Add(this.groupBoxClients);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "ClientControlDialog";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Client Control";
			base.FormClosing += new FormClosingEventHandler(this.ClientControlDialog_FormClosing);
			this.groupBoxClients.ResumeLayout(false);
			this.groupBoxClients.PerformLayout();
			this.groupBoxChannels.ResumeLayout(false);
			this.groupBoxExecutionControl.ResumeLayout(false);
			this.groupBoxPassword.ResumeLayout(false);
			this.groupBoxPassword.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
		#endregion

		protected override void Dispose(bool disposing)
		{
			if (disposing && (this.components != null))
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
