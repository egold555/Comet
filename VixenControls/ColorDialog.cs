﻿using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using CommonControls.Properties;

namespace CommonControls {
    public partial class ColorDialog : Form {
        private readonly string _customColors;

        public ColorDialog(Color color, string customColors) {
            InitializeComponent();
            SetColorOrImage(pbOriginalColor, color);
            colorEditor1.Color = color;
            _customColors = customColors;
        }


        private void colorEditor1_ColorChanged(object sender, EventArgs e) {
            SetColorOrImage(pbNewColor, colorEditor1.Color);
        }


        public Color GetColor() {
            return pbNewColor.BackColor;
        }


        public string GetCustomColors() {
            var colors = (from PictureBox c in (from object c in Controls where c is PictureBox select c)
                where c.Name.StartsWith("pbCustom")
                select c.BackColor).Reverse().ToArray();
            var color = new string[colors.Count()];
            for (var i=0; i < colors.Count();i++) {
                var raw = colors[i];
                color[i] = (raw.R + (raw.G << 8) + (raw.B << 16)).ToString(CultureInfo.InvariantCulture);
            }
            return string.Join(",", color);
        }


        private void SetCustomColors() {
            var colors = _customColors.Split(',');
            var colorCount = colors.Count() - 1;
            for (var i = 0; i < 16; i++) {
                var control = Controls.Find(string.Format("pbCustom{0:X}", i), true)[0];
                var color = Color.White;
                if (colorCount >= i) {
                    var raw = int.Parse(colors[i]);
                    var r = (raw & 0xFF);
                    var g = (raw & 0xFF00) >> 8;
                    var b = (raw & 0xFF0000) >> 16;
                    color = Color.FromArgb(r, g, b);
                }
                control.BackColor = color;
            }
        }


        private static void SetColorOrImage(Control pb, Color color) {
            pb.BackColor = color;
            pb.BackgroundImage = color == Color.Transparent ? Resources.cellbackground : null;
        }

        private void ColorDialog_Shown(object sender, EventArgs e) {
            SetCustomColors();
        }

        private void pbCustom_Click(object sender, EventArgs e) {
            var control = sender as PictureBox;
            if (null == control) {
                return;
            }

            colorEditor1.Color = control.BackColor;
            pbNewColor.BackColor = control.BackColor;

            foreach (PictureBox c in from object c in Controls where c is PictureBox select c) {
                c.BorderStyle = c == sender ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
            }
        }


        private void btnAddColor_Click(object sender, EventArgs e) {
            if ((from object c in Controls select c as PictureBox).Count(
                    pb => pb != null && pb.Name.StartsWith("pbCustom") && pb.BorderStyle == BorderStyle.Fixed3D) > 0) {
                foreach (var c in from PictureBox c in (from object c in Controls where c is PictureBox select c)
                    where c.Name.StartsWith("pbCustom") && c.BorderStyle == BorderStyle.Fixed3D
                    select c) {
                    c.BackColor = colorEditor1.Color;
                }
            }
            else {
                pbCustom0.BackColor = colorEditor1.Color;
            }
        }

        private void pbOriginalColor_Click(object sender, EventArgs e) {
            colorEditor1.Color = pbOriginalColor.BackColor;
            pbNewColor.BackColor = pbOriginalColor.BackColor;
        }
    }
}