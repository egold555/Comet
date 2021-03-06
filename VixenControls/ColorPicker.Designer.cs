﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VixenPlusCommon {
    partial class ColorPicker {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.btnCancel = new Button();
            this.btnNone = new Button();
            this.btnOkay = new Button();
            this.pbOriginalColor = new PictureBox();
            this.pbNewColor = new PictureBox();
            this.btnAddColor = new Button();
            this.pbCustomF = new PictureBox();
            this.pbCustomE = new PictureBox();
            this.pbCustomD = new PictureBox();
            this.pbCustomC = new PictureBox();
            this.pbCustomB = new PictureBox();
            this.pbCustomA = new PictureBox();
            this.pbCustom9 = new PictureBox();
            this.pbCustom8 = new PictureBox();
            this.pbCustom7 = new PictureBox();
            this.pbCustom6 = new PictureBox();
            this.pbCustom5 = new PictureBox();
            this.pbCustom4 = new PictureBox();
            this.pbCustom3 = new PictureBox();
            this.pbCustom2 = new PictureBox();
            this.pbCustom1 = new PictureBox();
            this.pbCustom0 = new PictureBox();
            this.colorEditor1 = new ColorEditor();
            ((ISupportInitialize)(this.pbOriginalColor)).BeginInit();
            ((ISupportInitialize)(this.pbNewColor)).BeginInit();
            ((ISupportInitialize)(this.pbCustomF)).BeginInit();
            ((ISupportInitialize)(this.pbCustomE)).BeginInit();
            ((ISupportInitialize)(this.pbCustomD)).BeginInit();
            ((ISupportInitialize)(this.pbCustomC)).BeginInit();
            ((ISupportInitialize)(this.pbCustomB)).BeginInit();
            ((ISupportInitialize)(this.pbCustomA)).BeginInit();
            ((ISupportInitialize)(this.pbCustom9)).BeginInit();
            ((ISupportInitialize)(this.pbCustom8)).BeginInit();
            ((ISupportInitialize)(this.pbCustom7)).BeginInit();
            ((ISupportInitialize)(this.pbCustom6)).BeginInit();
            ((ISupportInitialize)(this.pbCustom5)).BeginInit();
            ((ISupportInitialize)(this.pbCustom4)).BeginInit();
            ((ISupportInitialize)(this.pbCustom3)).BeginInit();
            ((ISupportInitialize)(this.pbCustom2)).BeginInit();
            ((ISupportInitialize)(this.pbCustom1)).BeginInit();
            ((ISupportInitialize)(this.pbCustom0)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(184, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnNone
            // 
            this.btnNone.DialogResult = DialogResult.No;
            this.btnNone.Location = new Point(98, 227);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new Size(75, 23);
            this.btnNone.TabIndex = 3;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            // 
            // btnOkay
            // 
            this.btnOkay.DialogResult = DialogResult.OK;
            this.btnOkay.Location = new Point(12, 227);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new Size(75, 23);
            this.btnOkay.TabIndex = 2;
            this.btnOkay.Text = "OK";
            this.btnOkay.UseVisualStyleBackColor = true;
            // 
            // pbOriginalColor
            // 
            this.pbOriginalColor.BorderStyle = BorderStyle.FixedSingle;
            this.pbOriginalColor.Location = new Point(12, 188);
            this.pbOriginalColor.Name = "pbOriginalColor";
            this.pbOriginalColor.Size = new Size(124, 33);
            this.pbOriginalColor.TabIndex = 5;
            this.pbOriginalColor.TabStop = false;
            this.pbOriginalColor.Click += new EventHandler(this.pbOriginalColor_Click);
            // 
            // pbNewColor
            // 
            this.pbNewColor.BorderStyle = BorderStyle.FixedSingle;
            this.pbNewColor.Location = new Point(135, 188);
            this.pbNewColor.Name = "pbNewColor";
            this.pbNewColor.Size = new Size(124, 33);
            this.pbNewColor.TabIndex = 7;
            this.pbNewColor.TabStop = false;
            // 
            // btnAddColor
            // 
            this.btnAddColor.Location = new Point(141, 106);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new Size(118, 23);
            this.btnAddColor.TabIndex = 1;
            this.btnAddColor.Text = "Add Custom Color";
            this.btnAddColor.UseVisualStyleBackColor = true;
            this.btnAddColor.Click += new EventHandler(this.btnAddColor_Click);
            // 
            // pbCustomF
            // 
            this.pbCustomF.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustomF.Location = new Point(237, 161);
            this.pbCustomF.Name = "pbCustomF";
            this.pbCustomF.Size = new Size(20, 20);
            this.pbCustomF.TabIndex = 24;
            this.pbCustomF.TabStop = false;
            this.pbCustomF.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustomE
            // 
            this.pbCustomE.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustomE.Location = new Point(205, 161);
            this.pbCustomE.Name = "pbCustomE";
            this.pbCustomE.Size = new Size(20, 20);
            this.pbCustomE.TabIndex = 23;
            this.pbCustomE.TabStop = false;
            this.pbCustomE.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustomD
            // 
            this.pbCustomD.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustomD.Location = new Point(173, 161);
            this.pbCustomD.Name = "pbCustomD";
            this.pbCustomD.Size = new Size(20, 20);
            this.pbCustomD.TabIndex = 22;
            this.pbCustomD.TabStop = false;
            this.pbCustomD.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustomC
            // 
            this.pbCustomC.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustomC.Location = new Point(141, 161);
            this.pbCustomC.Name = "pbCustomC";
            this.pbCustomC.Size = new Size(20, 20);
            this.pbCustomC.TabIndex = 21;
            this.pbCustomC.TabStop = false;
            this.pbCustomC.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustomB
            // 
            this.pbCustomB.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustomB.Location = new Point(109, 161);
            this.pbCustomB.Name = "pbCustomB";
            this.pbCustomB.Size = new Size(20, 20);
            this.pbCustomB.TabIndex = 20;
            this.pbCustomB.TabStop = false;
            this.pbCustomB.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustomA
            // 
            this.pbCustomA.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustomA.Location = new Point(77, 161);
            this.pbCustomA.Name = "pbCustomA";
            this.pbCustomA.Size = new Size(20, 20);
            this.pbCustomA.TabIndex = 19;
            this.pbCustomA.TabStop = false;
            this.pbCustomA.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustom9
            // 
            this.pbCustom9.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustom9.Location = new Point(45, 161);
            this.pbCustom9.Name = "pbCustom9";
            this.pbCustom9.Size = new Size(20, 20);
            this.pbCustom9.TabIndex = 18;
            this.pbCustom9.TabStop = false;
            this.pbCustom9.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustom8
            // 
            this.pbCustom8.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustom8.Location = new Point(13, 161);
            this.pbCustom8.Name = "pbCustom8";
            this.pbCustom8.Size = new Size(20, 20);
            this.pbCustom8.TabIndex = 17;
            this.pbCustom8.TabStop = false;
            this.pbCustom8.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustom7
            // 
            this.pbCustom7.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustom7.Location = new Point(237, 135);
            this.pbCustom7.Name = "pbCustom7";
            this.pbCustom7.Size = new Size(20, 20);
            this.pbCustom7.TabIndex = 16;
            this.pbCustom7.TabStop = false;
            this.pbCustom7.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustom6
            // 
            this.pbCustom6.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustom6.Location = new Point(205, 135);
            this.pbCustom6.Name = "pbCustom6";
            this.pbCustom6.Size = new Size(20, 20);
            this.pbCustom6.TabIndex = 15;
            this.pbCustom6.TabStop = false;
            this.pbCustom6.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustom5
            // 
            this.pbCustom5.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustom5.Location = new Point(173, 135);
            this.pbCustom5.Name = "pbCustom5";
            this.pbCustom5.Size = new Size(20, 20);
            this.pbCustom5.TabIndex = 14;
            this.pbCustom5.TabStop = false;
            this.pbCustom5.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustom4
            // 
            this.pbCustom4.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustom4.Location = new Point(141, 135);
            this.pbCustom4.Name = "pbCustom4";
            this.pbCustom4.Size = new Size(20, 20);
            this.pbCustom4.TabIndex = 13;
            this.pbCustom4.TabStop = false;
            this.pbCustom4.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustom3
            // 
            this.pbCustom3.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustom3.Location = new Point(109, 135);
            this.pbCustom3.Name = "pbCustom3";
            this.pbCustom3.Size = new Size(20, 20);
            this.pbCustom3.TabIndex = 12;
            this.pbCustom3.TabStop = false;
            this.pbCustom3.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustom2
            // 
            this.pbCustom2.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustom2.Location = new Point(77, 135);
            this.pbCustom2.Name = "pbCustom2";
            this.pbCustom2.Size = new Size(20, 20);
            this.pbCustom2.TabIndex = 11;
            this.pbCustom2.TabStop = false;
            this.pbCustom2.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustom1
            // 
            this.pbCustom1.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustom1.Location = new Point(45, 135);
            this.pbCustom1.Name = "pbCustom1";
            this.pbCustom1.Size = new Size(20, 20);
            this.pbCustom1.TabIndex = 10;
            this.pbCustom1.TabStop = false;
            this.pbCustom1.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // pbCustom0
            // 
            this.pbCustom0.BorderStyle = BorderStyle.FixedSingle;
            this.pbCustom0.Location = new Point(13, 135);
            this.pbCustom0.Name = "pbCustom0";
            this.pbCustom0.Size = new Size(20, 20);
            this.pbCustom0.TabIndex = 9;
            this.pbCustom0.TabStop = false;
            this.pbCustom0.MouseDown += new MouseEventHandler(this.pbCustom_MouseDown);
            // 
            // colorEditor1
            // 
            this.colorEditor1.Color = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorEditor1.Location = new Point(12, 12);
            this.colorEditor1.Name = "colorEditor1";
            this.colorEditor1.Size = new Size(247, 90);
            this.colorEditor1.TabIndex = 0;
            this.colorEditor1.ColorChanged += new EventHandler(this.colorEditor1_ColorChanged);
            // 
            // ColorPicker
            // 
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ClientSize = new Size(271, 262);
            this.Controls.Add(this.pbCustomF);
            this.Controls.Add(this.pbCustomE);
            this.Controls.Add(this.pbCustomD);
            this.Controls.Add(this.pbCustomC);
            this.Controls.Add(this.pbCustomB);
            this.Controls.Add(this.pbCustomA);
            this.Controls.Add(this.pbCustom9);
            this.Controls.Add(this.pbCustom8);
            this.Controls.Add(this.pbCustom7);
            this.Controls.Add(this.pbCustom6);
            this.Controls.Add(this.pbCustom5);
            this.Controls.Add(this.pbCustom4);
            this.Controls.Add(this.pbCustom3);
            this.Controls.Add(this.pbCustom2);
            this.Controls.Add(this.pbCustom1);
            this.Controls.Add(this.pbCustom0);
            this.Controls.Add(this.btnAddColor);
            this.Controls.Add(this.pbNewColor);
            this.Controls.Add(this.pbOriginalColor);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.colorEditor1);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorPicker";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "Choose a color";
            this.FormClosing += new FormClosingEventHandler(this.ColorPicker_FormClosing);
            this.Shown += new EventHandler(this.ColorPicker_Shown);
            ((ISupportInitialize)(this.pbOriginalColor)).EndInit();
            ((ISupportInitialize)(this.pbNewColor)).EndInit();
            ((ISupportInitialize)(this.pbCustomF)).EndInit();
            ((ISupportInitialize)(this.pbCustomE)).EndInit();
            ((ISupportInitialize)(this.pbCustomD)).EndInit();
            ((ISupportInitialize)(this.pbCustomC)).EndInit();
            ((ISupportInitialize)(this.pbCustomB)).EndInit();
            ((ISupportInitialize)(this.pbCustomA)).EndInit();
            ((ISupportInitialize)(this.pbCustom9)).EndInit();
            ((ISupportInitialize)(this.pbCustom8)).EndInit();
            ((ISupportInitialize)(this.pbCustom7)).EndInit();
            ((ISupportInitialize)(this.pbCustom6)).EndInit();
            ((ISupportInitialize)(this.pbCustom5)).EndInit();
            ((ISupportInitialize)(this.pbCustom4)).EndInit();
            ((ISupportInitialize)(this.pbCustom3)).EndInit();
            ((ISupportInitialize)(this.pbCustom2)).EndInit();
            ((ISupportInitialize)(this.pbCustom1)).EndInit();
            ((ISupportInitialize)(this.pbCustom0)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ColorEditor colorEditor1;
        private Button btnCancel;
        private Button btnNone;
        private Button btnOkay;
        private PictureBox pbOriginalColor;
        private PictureBox pbNewColor;
        private Button btnAddColor;
        private PictureBox pbCustom0;
        private PictureBox pbCustom1;
        private PictureBox pbCustom2;
        private PictureBox pbCustom3;
        private PictureBox pbCustom4;
        private PictureBox pbCustom7;
        private PictureBox pbCustom6;
        private PictureBox pbCustom5;
        private PictureBox pbCustomB;
        private PictureBox pbCustomA;
        private PictureBox pbCustom9;
        private PictureBox pbCustom8;
        private PictureBox pbCustomF;
        private PictureBox pbCustomE;
        private PictureBox pbCustomD;
        private PictureBox pbCustomC;
    }
}