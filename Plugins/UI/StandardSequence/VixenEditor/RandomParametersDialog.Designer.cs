using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VixenEditor {
    internal partial class RandomParametersDialog {
        private IContainer components = null;

        #region Windows Form Designer generated code
        private Button buttonCancel;
        private Button buttonOK;
        private CheckBox checkBoxIntensityLevel;
        private CheckBox checkBoxUseSaturation;
        private Label lblPctSaturation;
        private Label lblHeader;
        private Label lblBetween;
        private Label lblPctMin;
        private Label lblPctMax;
        private Label lblAnd;
        private NumericUpDown udMax;
        private NumericUpDown udMin;
        private NumericUpDown udPeriods;
        private NumericUpDown udSaturation;

        private void InitializeComponent() {
            this.udSaturation = new System.Windows.Forms.NumericUpDown();
            this.lblPctSaturation = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxUseSaturation = new System.Windows.Forms.CheckBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.udPeriods = new System.Windows.Forms.NumericUpDown();
            this.lblAnd = new System.Windows.Forms.Label();
            this.lblPctMax = new System.Windows.Forms.Label();
            this.udMax = new System.Windows.Forms.NumericUpDown();
            this.lblPctMin = new System.Windows.Forms.Label();
            this.udMin = new System.Windows.Forms.NumericUpDown();
            this.lblBetween = new System.Windows.Forms.Label();
            this.checkBoxIntensityLevel = new System.Windows.Forms.CheckBox();
            this.lblPeriodLen = new System.Windows.Forms.Label();
            this.pbExample = new System.Windows.Forms.PictureBox();
            this.lblExample = new System.Windows.Forms.Label();
            this.checkBoxExactlyOneRow = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.udSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExample)).BeginInit();
            this.SuspendLayout();
            // 
            // udSaturation
            // 
            this.udSaturation.Location = new System.Drawing.Point(212, 86);
            this.udSaturation.Name = "udSaturation";
            this.udSaturation.Size = new System.Drawing.Size(46, 20);
            this.udSaturation.TabIndex = 4;
            this.udSaturation.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udSaturation.ValueChanged += new System.EventHandler(this.ud_ValueChanged);
            this.udSaturation.Enter += new System.EventHandler(this.UpDownEnter);
            // 
            // lblPctSaturation
            // 
            this.lblPctSaturation.AutoSize = true;
            this.lblPctSaturation.Location = new System.Drawing.Point(258, 88);
            this.lblPctSaturation.Name = "lblPctSaturation";
            this.lblPctSaturation.Size = new System.Drawing.Size(15, 13);
            this.lblPctSaturation.TabIndex = 11;
            this.lblPctSaturation.Text = "%";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(124, 202);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(205, 202);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseSaturation
            // 
            this.checkBoxUseSaturation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(213)))));
            this.checkBoxUseSaturation.Location = new System.Drawing.Point(15, 87);
            this.checkBoxUseSaturation.Name = "checkBoxUseSaturation";
            this.checkBoxUseSaturation.Size = new System.Drawing.Size(136, 17);
            this.checkBoxUseSaturation.TabIndex = 3;
            this.checkBoxUseSaturation.Text = "Ensure Coverage:";
            this.checkBoxUseSaturation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxUseSaturation.UseVisualStyleBackColor = true;
            this.checkBoxUseSaturation.CheckedChanged += new System.EventHandler(this.checkBoxUseSaturation_CheckedChanged);
            // 
            // lblHeader
            // 
            this.lblHeader.Location = new System.Drawing.Point(12, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(268, 48);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "For standard random results without intensity variation, you can press Enter or c" +
    "lick OK, otherwise adjust the parameters below.";
            // 
            // udPeriods
            // 
            this.udPeriods.Location = new System.Drawing.Point(212, 60);
            this.udPeriods.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPeriods.Name = "udPeriods";
            this.udPeriods.Size = new System.Drawing.Size(46, 20);
            this.udPeriods.TabIndex = 2;
            this.udPeriods.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udPeriods.ValueChanged += new System.EventHandler(this.ud_ValueChanged);
            this.udPeriods.Enter += new System.EventHandler(this.UpDownEnter);
            // 
            // lblAnd
            // 
            this.lblAnd.AutoSize = true;
            this.lblAnd.Location = new System.Drawing.Point(181, 140);
            this.lblAnd.Name = "lblAnd";
            this.lblAnd.Size = new System.Drawing.Size(25, 13);
            this.lblAnd.TabIndex = 14;
            this.lblAnd.Text = "and";
            // 
            // lblPctMax
            // 
            this.lblPctMax.AutoSize = true;
            this.lblPctMax.Location = new System.Drawing.Point(258, 140);
            this.lblPctMax.Name = "lblPctMax";
            this.lblPctMax.Size = new System.Drawing.Size(15, 13);
            this.lblPctMax.TabIndex = 15;
            this.lblPctMax.Text = "%";
            // 
            // udMax
            // 
            this.udMax.Location = new System.Drawing.Point(212, 138);
            this.udMax.Name = "udMax";
            this.udMax.Size = new System.Drawing.Size(46, 20);
            this.udMax.TabIndex = 8;
            this.udMax.ValueChanged += new System.EventHandler(this.ud_ValueChanged);
            this.udMax.Enter += new System.EventHandler(this.UpDownEnter);
            // 
            // lblPctMin
            // 
            this.lblPctMin.AutoSize = true;
            this.lblPctMin.Location = new System.Drawing.Point(258, 114);
            this.lblPctMin.Name = "lblPctMin";
            this.lblPctMin.Size = new System.Drawing.Size(15, 13);
            this.lblPctMin.TabIndex = 13;
            this.lblPctMin.Text = "%";
            // 
            // udMin
            // 
            this.udMin.Location = new System.Drawing.Point(212, 112);
            this.udMin.Name = "udMin";
            this.udMin.Size = new System.Drawing.Size(46, 20);
            this.udMin.TabIndex = 7;
            this.udMin.ValueChanged += new System.EventHandler(this.ud_ValueChanged);
            this.udMin.Enter += new System.EventHandler(this.UpDownEnter);
            // 
            // lblBetween
            // 
            this.lblBetween.AutoSize = true;
            this.lblBetween.Location = new System.Drawing.Point(157, 114);
            this.lblBetween.Name = "lblBetween";
            this.lblBetween.Size = new System.Drawing.Size(49, 13);
            this.lblBetween.TabIndex = 6;
            this.lblBetween.Text = "Between";
            // 
            // checkBoxIntensityLevel
            // 
            this.checkBoxIntensityLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(213)))));
            this.checkBoxIntensityLevel.Location = new System.Drawing.Point(15, 113);
            this.checkBoxIntensityLevel.Name = "checkBoxIntensityLevel";
            this.checkBoxIntensityLevel.Size = new System.Drawing.Size(136, 17);
            this.checkBoxIntensityLevel.TabIndex = 5;
            this.checkBoxIntensityLevel.Text = "Vary Intensity Levels:";
            this.checkBoxIntensityLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxIntensityLevel.UseVisualStyleBackColor = true;
            this.checkBoxIntensityLevel.CheckedChanged += new System.EventHandler(this.checkBoxIntensityLevel_CheckedChanged);
            // 
            // lblPeriodLen
            // 
            this.lblPeriodLen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(213)))));
            this.lblPeriodLen.Location = new System.Drawing.Point(12, 60);
            this.lblPeriodLen.Margin = new System.Windows.Forms.Padding(3);
            this.lblPeriodLen.Name = "lblPeriodLen";
            this.lblPeriodLen.Size = new System.Drawing.Size(136, 17);
            this.lblPeriodLen.TabIndex = 1;
            this.lblPeriodLen.Text = "Period Length:";
            this.lblPeriodLen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbExample
            // 
            this.pbExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbExample.BackColor = System.Drawing.Color.Silver;
            this.pbExample.Location = new System.Drawing.Point(11, 231);
            this.pbExample.Name = "pbExample";
            this.pbExample.Size = new System.Drawing.Size(271, 271);
            this.pbExample.TabIndex = 9;
            this.pbExample.TabStop = false;
            this.pbExample.Paint += new System.Windows.Forms.PaintEventHandler(this.pbExample_Paint);
            // 
            // lblExample
            // 
            this.lblExample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblExample.AutoSize = true;
            this.lblExample.Location = new System.Drawing.Point(12, 207);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(50, 13);
            this.lblExample.TabIndex = 10;
            this.lblExample.Text = "Example:";
            // 
            // checkBoxExactlyOneRow
            // 
            this.checkBoxExactlyOneRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(213)))));
            this.checkBoxExactlyOneRow.Location = new System.Drawing.Point(15, 162);
            this.checkBoxExactlyOneRow.Name = "checkBoxExactlyOneRow";
            this.checkBoxExactlyOneRow.Size = new System.Drawing.Size(167, 27);
            this.checkBoxExactlyOneRow.TabIndex = 9;
            this.checkBoxExactlyOneRow.Text = "Exactly one channel at a time";
            this.checkBoxExactlyOneRow.UseVisualStyleBackColor = true;
            this.checkBoxExactlyOneRow.CheckedChanged += new System.EventHandler(this.checkBoxExactlyOneRow_CheckedChanged);
            // 
            // RandomParametersDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(294, 514);
            this.Controls.Add(this.checkBoxExactlyOneRow);
            this.Controls.Add(this.lblExample);
            this.Controls.Add(this.pbExample);
            this.Controls.Add(this.lblPeriodLen);
            this.Controls.Add(this.udPeriods);
            this.Controls.Add(this.checkBoxUseSaturation);
            this.Controls.Add(this.udSaturation);
            this.Controls.Add(this.lblAnd);
            this.Controls.Add(this.lblPctSaturation);
            this.Controls.Add(this.lblPctMax);
            this.Controls.Add(this.udMax);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblPctMin);
            this.Controls.Add(this.udMin);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.lblBetween);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkBoxIntensityLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RandomParametersDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Random Settings";
            ((System.ComponentModel.ISupportInitialize)(this.udSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        protected override void Dispose(bool disposing) {
            if (disposing && (this.components != null)) {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Label lblPeriodLen;
        private PictureBox pbExample;
        private Label lblExample;
        private CheckBox checkBoxExactlyOneRow;
    }
}