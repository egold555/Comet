﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using VixenPlus.Annotations;

using VixenPlusCommon;

namespace Nutcracker.Effects {
    [UsedImplicitly]
    public partial class Spirals : UserControl, INutcrackerEffect {

        private const string SpiralsCount = "ID_SLIDER_Spirals{0}_Count";
        private const string SpiralsRotation = "ID_SLIDER_Spirals{0}_Rotation";
        private const string SpiralsThickness = "ID_SLIDER_Spirals{0}_Thickness";
        private const string SpiralsDirection = "ID_SLIDER_Spirals{0}_Direction";
        private const string SpiralsBlend = "ID_CHECKBOX_Spirals{0}_Blend";
        private const string Spirals3D = "ID_CHECKBOX_Spirals{0}_3D";

        public Spirals() {
            InitializeComponent();
        }

        public event EventHandler OnControlChanged;

        public string EffectName {
            get { return "Spirals"; }
        }

        public string Notes {
            get { return String.Empty; }
        }

        public bool UsesPalette {
            get { return true; }
        }

        public bool UsesSpeed {
            get { return true; }
        }

        public List<string> Settings {
            get { return GetCurrentSettings(); }
            set { Setup(value); }
        }

        private List<string> GetCurrentSettings() {
            return new List<string> {
                Spirals3D + "=" + (chkBox3D.Checked ? "1" : "0"),
                SpiralsBlend+ "=" + (chkBoxBlend.Checked ? "1" : "0"),
                SpiralsCount+ "=" + tbPaletteRepeat.Value,
                SpiralsDirection+ "=" + tbDirection.Value,
                SpiralsRotation+ "=" + tbRotations.Value,
                SpiralsThickness + "=" + tbThickness.Value
            };
        }

        private void Setup(IList<string> settings) {
            var effectNum = settings[0];
            var spirals3D = string.Format(Spirals3D, effectNum);
            var spiralsBlend = string.Format(SpiralsBlend, effectNum);
            var spiralsCount = string.Format(SpiralsCount, effectNum);
            var spiralsDirection = string.Format(SpiralsDirection, effectNum);
            var spiralsRotation = string.Format(SpiralsRotation, effectNum);
            var spiralsThickness = string.Format(SpiralsThickness, effectNum);

            foreach (var keyValue in settings.Select(s => s.Split('='))) {
                if (keyValue[0].Equals(spirals3D)) {
                    chkBox3D.Checked = keyValue[1].Equals("1");
                }
                else if (keyValue[0].Equals(spiralsBlend)) {
                    chkBoxBlend.Checked = keyValue[1].Equals("1");
                }
                else if (keyValue[0].Equals(spiralsCount)) {
                    tbPaletteRepeat.Value = keyValue[1].ToInt();
                }
                else if (keyValue[0].Equals(spiralsDirection)) {
                    tbDirection.Value = keyValue[1].ToInt();
                }
                else if (keyValue[0].Equals(spiralsRotation)) {
                    tbRotations.Value = keyValue[1].ToInt();
                }
                else if (keyValue[0].Equals(spiralsThickness)) {
                    tbThickness.Value = keyValue[1].ToInt();
                }
            }
        }


        public Color[,] RenderEffect(Color[,] buffer, Color[] palette, int eventToRender) {
            var colorCount = palette.Length;
            var spiralCount = colorCount * tbPaletteRepeat.Value;
            var bufferHeight = buffer.GetLength(Utils.IndexRowsOrHeight);
            var bufferWidth = buffer.GetLength(Utils.IndexColsOrWidth);
            var deltaStrands = bufferWidth / spiralCount;
            var spiralThickness = (deltaStrands * tbThickness.Value / 100) + 1;
            long spiralState = eventToRender * tbDirection.Value;

            for (var spiral = 0; spiral < spiralCount; spiral++) {
                var strandBase = spiral * deltaStrands;
                var color = palette[spiral % colorCount];
                for (var thickness = 0; thickness < spiralThickness; thickness++) {
                    var strand = (strandBase + thickness) % bufferWidth;
                    for (var row = 0; row < bufferHeight; row++) {
                        var column = (strand + ((int)spiralState / 10) + (row * tbRotations.Value / bufferHeight)) % bufferWidth;
                        if (column < 0) {
                            column += bufferWidth;
                        }
                        if (chkBoxBlend.Checked) {
                            color = palette.GetMultiColorBlend((bufferHeight - row - 1) / (double)bufferHeight, false);
                        }
                        if (chkBox3D.Checked) {
                            var hsv = color.ToHSV();
                            hsv.Value = (float)((double)(tbRotations.Value < 0 ? thickness + 1 : spiralThickness - thickness) / spiralThickness);
                            color = hsv.ToColor();
                        }
                        buffer[row, column] = color;
                    }
                }
            }
            return buffer;
        }

        private void Spirals_ControlChanged(object sender, EventArgs e) {
            if (OnControlChanged == null) return;

            OnControlChanged(this, e);
        }
    }
}
