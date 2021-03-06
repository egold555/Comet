namespace Icicles {
	using System;
	using System.Drawing;
	using System.Windows.Forms;

	public partial class SetupDialog {
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code
		private Button buttonAssign;
		private Button buttonCancel;
		private Button buttonOK;
		private Button buttonSerialSetup;
		private ComboBox comboBoxVersion;
		private GroupBox groupBox1;
		private GroupBox groupBox2;
		private Label label1;
		private Label label2;
		private Label label3;
		private TextBox textBoxBoardID;

		private void InitializeComponent() {
			this.buttonSerialSetup = new Button();
			this.groupBox1 = new GroupBox();
			this.textBoxBoardID = new TextBox();
			this.buttonAssign = new Button();
			this.label3 = new Label();
			this.label2 = new Label();
			this.buttonOK = new Button();
			this.buttonCancel = new Button();
			this.groupBox2 = new GroupBox();
			this.label1 = new Label();
			this.comboBoxVersion = new ComboBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.buttonSerialSetup.Location = new Point(12, 12);
			this.buttonSerialSetup.Name = "buttonSerialSetup";
			this.buttonSerialSetup.Size = new Size(0x4b, 23);
			this.buttonSerialSetup.TabIndex = 0;
			this.buttonSerialSetup.Text = "Serial Setup";
			this.buttonSerialSetup.UseVisualStyleBackColor = true;
			this.buttonSerialSetup.Click += new EventHandler(this.buttonSerialSetup_Click);
			this.groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
			this.groupBox1.Controls.Add(this.textBoxBoardID);
			this.groupBox1.Controls.Add(this.buttonAssign);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new Point(12, 0x7f);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(0x151, 100);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Board ID assignment";
			this.textBoxBoardID.Location = new Point(0xe2, 22);
			this.textBoxBoardID.Name = "textBoxBoardID";
			this.textBoxBoardID.Size = new Size(0x26, 20);
			this.textBoxBoardID.TabIndex = 1;
			this.buttonAssign.Location = new Point(0xe2, 0x41);
			this.buttonAssign.Name = "buttonAssign";
			this.buttonAssign.Size = new Size(0x4b, 23);
			this.buttonAssign.TabIndex = 3;
			this.buttonAssign.Text = "Assign";
			this.buttonAssign.UseVisualStyleBackColor = true;
			this.buttonAssign.Click += new EventHandler(this.buttonAssign_Click);
			this.label3.Location = new Point(6, 0x38);
			this.label3.Name = "label3";
			this.label3.Size = new Size(0xcd, 0x20);
			this.label3.TabIndex = 2;
			this.label3.Text = "When the board is ready to accept the ID assignment, click the Assign button.";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(6, 25);
			this.label2.Name = "label2";
			this.label2.Size = new Size(0x51, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Board ID will be";
			this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new Point(0xc1, 0xea);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new Size(0x4b, 23);
			this.buttonOK.TabIndex = 3;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new Point(0x112, 0xea);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new Size(0x4b, 23);
			this.buttonCancel.TabIndex = 4;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.groupBox2.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
			this.groupBox2.Controls.Add(this.comboBoxVersion);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new Point(12, 0x29);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(0x151, 80);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Icicle Version";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(15, 0x15);
			this.label1.Name = "label1";
			this.label1.Size = new Size(160, 0x27);
			this.label1.TabIndex = 0;
			this.label1.Text = "Which version of the Icicle serial\r\nprotocol are you using?\r\n(Serial Type A)";
			this.comboBoxVersion.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBoxVersion.FormattingEnabled = true;
			this.comboBoxVersion.Items.AddRange(new object[] { "1", "2" });
			this.comboBoxVersion.Location = new Point(0xe2, 30);
			this.comboBoxVersion.Name = "comboBoxVersion";
			this.comboBoxVersion.Size = new Size(0x42, 0x15);
			this.comboBoxVersion.TabIndex = 1;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new Size(0x169, 0x109);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.buttonSerialSetup);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "SetupDialog";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Setup";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
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