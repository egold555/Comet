using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;

namespace JoystickInput {
	public partial class ButtonDialog {
		private IContainer components = null;

		#region Windows Form Designer generated code
		private Button buttonClose;
		private ListView listViewJoystickButtons;
		private Timer timerPoll;

		private void InitializeComponent() {
			this.components = new Container();
			this.listViewJoystickButtons = new ListView();
			this.buttonClose = new Button();
			this.timerPoll = new Timer(this.components);
			base.SuspendLayout();
			this.listViewJoystickButtons.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
			this.listViewJoystickButtons.HideSelection = false;
			this.listViewJoystickButtons.Location = new Point(12, 12);
			this.listViewJoystickButtons.Name = "listViewJoystickButtons";
			this.listViewJoystickButtons.Size = new Size(0x120, 250);
			this.listViewJoystickButtons.TabIndex = 0;
			this.listViewJoystickButtons.UseCompatibleStateImageBehavior = false;
			this.buttonClose.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonClose.Location = new Point(0xe1, 0x10c);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new Size(0x4b, 0x17);
			this.buttonClose.TabIndex = 1;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.timerPoll.Interval = 250;
			this.timerPoll.Tick += new EventHandler(this.timerPoll_Tick);
			base.AcceptButton = this.buttonClose;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonClose;
			base.ClientSize = new Size(0x138, 0x12f);
			base.Controls.Add(this.buttonClose);
			base.Controls.Add(this.listViewJoystickButtons);
			base.Name = "ButtonDialog";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Buttons";
			base.Load += new EventHandler(this.ButtonDialog_Load);
			base.FormClosing += new FormClosingEventHandler(this.ButtonDialog_FormClosing);
			base.ResumeLayout(false);
		}
		#endregion

		protected override void Dispose(bool disposing) {
			if (disposing && (this.components != null)) {
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}