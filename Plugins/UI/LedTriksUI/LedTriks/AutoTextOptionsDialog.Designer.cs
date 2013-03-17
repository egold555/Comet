using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Collections;

namespace LedTriks
{
	public partial class AutoTextOptionsDialog {
		private IContainer components = null;

		#region Windows Form Designer generated code
		private Button buttonCancel;
private Button buttonOK;
private ErrorProvider errorProvider;
private GroupBox groupBox1;
private GroupBox groupBox2;
private GroupBox groupBox3;
private Label label1;
private NumericUpDown numericUpDownTextHeight;
private PictureBox pictureBoxImageLarge;
private PictureBox pictureBoxImageSmall;
private PictureBox pictureBoxSample;
private PictureBox pictureBoxScrollDown;
private PictureBox pictureBoxScrollLeft;
private PictureBox pictureBoxScrollRight;
private PictureBox pictureBoxScrollUp;
private RadioButton radioButtonPositionBottom;
private RadioButton radioButtonPositionPercent;
private RadioButton radioButtonPositionPixel;
private RadioButton radioButtonPositionTop;
private RadioButton radioButtonScrollOn;
private RadioButton radioButtonScrollOnOff;
private TextBox textBoxPositionValue;
private Timer timer;
private ToolTip toolTip;

		private void InitializeComponent()
		{
			this.components = new Container();
			this.toolTip = new ToolTip(this.components);
			this.pictureBoxScrollUp = new PictureBox();
			this.pictureBoxScrollDown = new PictureBox();
			this.pictureBoxScrollLeft = new PictureBox();
			this.pictureBoxScrollRight = new PictureBox();
			this.pictureBoxSample = new PictureBox();
			this.groupBox1 = new GroupBox();
			this.textBoxPositionValue = new TextBox();
			this.radioButtonPositionPercent = new RadioButton();
			this.radioButtonPositionPixel = new RadioButton();
			this.radioButtonPositionBottom = new RadioButton();
			this.radioButtonPositionTop = new RadioButton();
			this.groupBox2 = new GroupBox();
			this.radioButtonScrollOnOff = new RadioButton();
			this.radioButtonScrollOn = new RadioButton();
			this.buttonOK = new Button();
			this.buttonCancel = new Button();
			this.timer = new Timer(this.components);
			this.pictureBoxImageSmall = new PictureBox();
			this.pictureBoxImageLarge = new PictureBox();
			this.groupBox3 = new GroupBox();
			this.label1 = new Label();
			this.numericUpDownTextHeight = new NumericUpDown();
			this.errorProvider = new ErrorProvider(this.components);
			((ISupportInitialize) this.pictureBoxScrollUp).BeginInit();
			((ISupportInitialize) this.pictureBoxScrollDown).BeginInit();
			((ISupportInitialize) this.pictureBoxScrollLeft).BeginInit();
			((ISupportInitialize) this.pictureBoxScrollRight).BeginInit();
			((ISupportInitialize) this.pictureBoxSample).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize) this.pictureBoxImageSmall).BeginInit();
			((ISupportInitialize) this.pictureBoxImageLarge).BeginInit();
			this.groupBox3.SuspendLayout();
			this.numericUpDownTextHeight.BeginInit();
			((ISupportInitialize) this.errorProvider).BeginInit();
			base.SuspendLayout();
			this.pictureBoxScrollUp.Location = new Point(0x71, 0x17);
			this.pictureBoxScrollUp.Name = "pictureBoxScrollUp";
			this.pictureBoxScrollUp.Size = new Size(0x18, 0x18);
			this.pictureBoxScrollUp.TabIndex = 0;
			this.pictureBoxScrollUp.TabStop = false;
			this.toolTip.SetToolTip(this.pictureBoxScrollUp, "Scroll from bottom to top");
			this.pictureBoxScrollUp.Click += new EventHandler(this.pictureBoxScrollUp_Click);
			this.pictureBoxScrollDown.Location = new Point(0x71, 0x5b);
			this.pictureBoxScrollDown.Name = "pictureBoxScrollDown";
			this.pictureBoxScrollDown.Size = new Size(0x18, 0x18);
			this.pictureBoxScrollDown.TabIndex = 1;
			this.pictureBoxScrollDown.TabStop = false;
			this.toolTip.SetToolTip(this.pictureBoxScrollDown, "Scroll from top to bottom");
			this.pictureBoxScrollDown.Click += new EventHandler(this.pictureBoxScrollDown_Click);
			this.pictureBoxScrollLeft.Location = new Point(0x2f, 0x39);
			this.pictureBoxScrollLeft.Name = "pictureBoxScrollLeft";
			this.pictureBoxScrollLeft.Size = new Size(0x18, 0x18);
			this.pictureBoxScrollLeft.TabIndex = 2;
			this.pictureBoxScrollLeft.TabStop = false;
			this.toolTip.SetToolTip(this.pictureBoxScrollLeft, "Scroll from right to left");
			this.pictureBoxScrollLeft.Click += new EventHandler(this.pictureBoxScrollLeft_Click);
			this.pictureBoxScrollRight.Location = new Point(0xb3, 0x39);
			this.pictureBoxScrollRight.Name = "pictureBoxScrollRight";
			this.pictureBoxScrollRight.Size = new Size(0x18, 0x18);
			this.pictureBoxScrollRight.TabIndex = 3;
			this.pictureBoxScrollRight.TabStop = false;
			this.toolTip.SetToolTip(this.pictureBoxScrollRight, "Scroll from left to right");
			this.pictureBoxScrollRight.Click += new EventHandler(this.pictureBoxScrollRight_Click);
			this.pictureBoxSample.Location = new Point(0x4d, 0x35);
			this.pictureBoxSample.Name = "pictureBoxSample";
			this.pictureBoxSample.Size = new Size(0x60, 0x20);
			this.pictureBoxSample.TabIndex = 4;
			this.pictureBoxSample.TabStop = false;
			this.pictureBoxSample.Paint += new PaintEventHandler(this.pictureBoxSample_Paint);
			this.groupBox1.Controls.Add(this.textBoxPositionValue);
			this.groupBox1.Controls.Add(this.radioButtonPositionPercent);
			this.groupBox1.Controls.Add(this.radioButtonPositionPixel);
			this.groupBox1.Controls.Add(this.radioButtonPositionBottom);
			this.groupBox1.Controls.Add(this.radioButtonPositionTop);
			this.groupBox1.Location = new Point(12, 0xcd);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(0xe2, 0x7e);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Position";
			this.textBoxPositionValue.Enabled = false;
			this.textBoxPositionValue.Location = new Point(0xa7, 0x52);
			this.textBoxPositionValue.Name = "textBoxPositionValue";
			this.textBoxPositionValue.Size = new Size(0x29, 20);
			this.textBoxPositionValue.TabIndex = 4;
			this.textBoxPositionValue.Leave += new EventHandler(this.textBoxPositionValue_Leave);
			this.radioButtonPositionPercent.AutoSize = true;
			this.radioButtonPositionPercent.Location = new Point(20, 0x5f);
			this.radioButtonPositionPercent.Name = "radioButtonPositionPercent";
			this.radioButtonPositionPercent.Size = new Size(0x80, 0x11);
			this.radioButtonPositionPercent.TabIndex = 3;
			this.radioButtonPositionPercent.Text = "Percent vertical offset";
			this.radioButtonPositionPercent.UseVisualStyleBackColor = true;
			this.radioButtonPositionPercent.CheckedChanged += new EventHandler(this.radioButtonPositionPercent_CheckedChanged);
			this.radioButtonPositionPixel.AutoSize = true;
			this.radioButtonPositionPixel.Location = new Point(20, 0x48);
			this.radioButtonPositionPixel.Name = "radioButtonPositionPixel";
			this.radioButtonPositionPixel.Size = new Size(0x71, 0x11);
			this.radioButtonPositionPixel.TabIndex = 2;
			this.radioButtonPositionPixel.Text = "Pixel vertical offset";
			this.radioButtonPositionPixel.UseVisualStyleBackColor = true;
			this.radioButtonPositionPixel.CheckedChanged += new EventHandler(this.radioButtonPositionPixel_CheckedChanged);
			this.radioButtonPositionBottom.AutoSize = true;
			this.radioButtonPositionBottom.Location = new Point(20, 0x31);
			this.radioButtonPositionBottom.Name = "radioButtonPositionBottom";
			this.radioButtonPositionBottom.Size = new Size(0x3a, 0x11);
			this.radioButtonPositionBottom.TabIndex = 1;
			this.radioButtonPositionBottom.Text = "Bottom";
			this.radioButtonPositionBottom.UseVisualStyleBackColor = true;
			this.radioButtonPositionBottom.CheckedChanged += new EventHandler(this.radioButtonPositionBottom_CheckedChanged);
			this.radioButtonPositionTop.AutoSize = true;
			this.radioButtonPositionTop.Checked = true;
			this.radioButtonPositionTop.Location = new Point(20, 0x1a);
			this.radioButtonPositionTop.Name = "radioButtonPositionTop";
			this.radioButtonPositionTop.Size = new Size(0x2c, 0x11);
			this.radioButtonPositionTop.TabIndex = 0;
			this.radioButtonPositionTop.TabStop = true;
			this.radioButtonPositionTop.Text = "Top";
			this.radioButtonPositionTop.UseVisualStyleBackColor = true;
			this.radioButtonPositionTop.CheckedChanged += new EventHandler(this.radioButtonPositionTop_CheckedChanged);
			this.groupBox2.Controls.Add(this.radioButtonScrollOnOff);
			this.groupBox2.Controls.Add(this.radioButtonScrollOn);
			this.groupBox2.Location = new Point(12, 0x15b);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(0xe2, 0x48);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "How to scroll";
			this.radioButtonScrollOnOff.AutoSize = true;
			this.radioButtonScrollOnOff.Checked = true;
			this.radioButtonScrollOnOff.Location = new Point(20, 0x13);
			this.radioButtonScrollOnOff.Name = "radioButtonScrollOnOff";
			this.radioButtonScrollOnOff.Size = new Size(0x66, 0x11);
			this.radioButtonScrollOnOff.TabIndex = 0;
			this.radioButtonScrollOnOff.TabStop = true;
			this.radioButtonScrollOnOff.Text = "Scroll on and off";
			this.radioButtonScrollOnOff.UseVisualStyleBackColor = true;
			this.radioButtonScrollOnOff.CheckedChanged += new EventHandler(this.RespondToChange);
			this.radioButtonScrollOn.AutoSize = true;
			this.radioButtonScrollOn.Location = new Point(20, 0x2a);
			this.radioButtonScrollOn.Name = "radioButtonScrollOn";
			this.radioButtonScrollOn.Size = new Size(0x6d, 0x11);
			this.radioButtonScrollOn.TabIndex = 1;
			this.radioButtonScrollOn.Text = "Scroll and stay on";
			this.radioButtonScrollOn.UseVisualStyleBackColor = true;
			this.radioButtonScrollOn.CheckedChanged += new EventHandler(this.RespondToChange);
			this.buttonOK.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new Point(0x52, 0x1b2);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new Size(0x4b, 0x17);
			this.buttonOK.TabIndex = 7;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
			this.buttonCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new Point(0xa3, 0x1b2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new Size(0x4b, 0x17);
			this.buttonCancel.TabIndex = 8;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.timer.Interval = 50;
			this.timer.Tick += new EventHandler(this.timer_Tick);
			this.pictureBoxImageSmall.Location = new Point(0x1f, 0x17);
			this.pictureBoxImageSmall.Name = "pictureBoxImageSmall";
			this.pictureBoxImageSmall.Size = new Size(0x4c, 14);
			this.pictureBoxImageSmall.SizeMode = PictureBoxSizeMode.AutoSize;
			this.pictureBoxImageSmall.TabIndex = 9;
			this.pictureBoxImageSmall.TabStop = false;
			this.pictureBoxImageSmall.Visible = false;
			this.pictureBoxImageLarge.Location = new Point(0x1f, 0x5b);
			this.pictureBoxImageLarge.Name = "pictureBoxImageLarge";
			this.pictureBoxImageLarge.Size = new Size(0x4c, 0x1c);
			this.pictureBoxImageLarge.SizeMode = PictureBoxSizeMode.AutoSize;
			this.pictureBoxImageLarge.TabIndex = 10;
			this.pictureBoxImageLarge.TabStop = false;
			this.pictureBoxImageLarge.Visible = false;
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.numericUpDownTextHeight);
			this.groupBox3.Location = new Point(12, 0x8d);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(0xe1, 0x35);
			this.groupBox3.TabIndex = 11;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Text height";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(0x77, 0x17);
			this.label1.Name = "label1";
			this.label1.Size = new Size(0x21, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "pixels";
			this.numericUpDownTextHeight.Location = new Point(0x48, 0x15);
			int[] bits = new int[4];
			bits[0] = 8;
			this.numericUpDownTextHeight.Minimum = new decimal(bits);
			this.numericUpDownTextHeight.Name = "numericUpDownTextHeight";
			this.numericUpDownTextHeight.Size = new Size(0x29, 20);
			this.numericUpDownTextHeight.TabIndex = 0;
			int[] bits1 = new int[4];
			bits1[0] = 8;
			this.numericUpDownTextHeight.Value = new decimal(bits1);
			this.errorProvider.ContainerControl = this;
			base.AcceptButton = this.buttonOK;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.buttonCancel;
			base.ClientSize = new Size(250, 0x1d5);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.pictureBoxImageLarge);
			base.Controls.Add(this.pictureBoxImageSmall);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOK);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.pictureBoxSample);
			base.Controls.Add(this.pictureBoxScrollRight);
			base.Controls.Add(this.pictureBoxScrollLeft);
			base.Controls.Add(this.pictureBoxScrollDown);
			base.Controls.Add(this.pictureBoxScrollUp);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AutoTextOptionsDialog";
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Auto Text Options";
			base.FormClosing += new FormClosingEventHandler(this.AutoTextOptionsDialog_FormClosing);
			base.Load += new EventHandler(this.AutoTextOptionsDialog_Load);
			((ISupportInitialize) this.pictureBoxScrollUp).EndInit();
			((ISupportInitialize) this.pictureBoxScrollDown).EndInit();
			((ISupportInitialize) this.pictureBoxScrollLeft).EndInit();
			((ISupportInitialize) this.pictureBoxScrollRight).EndInit();
			((ISupportInitialize) this.pictureBoxSample).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((ISupportInitialize) this.pictureBoxImageSmall).EndInit();
			((ISupportInitialize) this.pictureBoxImageLarge).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.numericUpDownTextHeight.EndInit();
			((ISupportInitialize) this.errorProvider).EndInit();
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
			if (this.m_generator != null)
			{
				this.m_generator.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
