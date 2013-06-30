﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using CommonUtils;
using VixenPlus;

namespace Twinkle {
    public partial class Twinkle : UserControl, INutcrackerEffect {
        public Twinkle() {
            InitializeComponent();
        }

        public event EventHandler OnControlChanged;

        public string EffectName {
            get { return "Twinkle"; }
        }

        public string Notes {
            get { return "Does not use speed control."; }
        }

        public bool UsesPalette {
            get { return true; }
        }

        public bool UsesSpeed {
            get { return false; }
        }

        public XmlElement Settings {
            get { return GetCurrentSettings(); }
            set { Setup(value); }
        }

        private static XmlElement GetCurrentSettings() {
            return Xml.CreateXmlDocument().DocumentElement;
        }

        private static void Setup(XmlElement settings) {
            System.Diagnostics.Debug.Print(settings.ToString());
        }


        public Color[,] RenderEffect(Color[,] buffer, Color[] palette, int eventToRender) {
            var bufferHeight = buffer.GetLength(Utils.IndexRowsOrHeight);
            var bufferWidth = buffer.GetLength(Utils.IndexColsOrWidth);
            var random = new Random(chkBoxStrobe.Checked ? DateTime.Now.Millisecond : 2271965);
            var steps = tbSteps.Value;
            var stepsHalf = steps / 2.0f;
            var lights = Convert.ToInt32((bufferHeight * bufferWidth) * (tbLightCount.Value / 100.0));
            var step = Math.Max(1, (bufferHeight * bufferWidth) / lights);

            for (var y = 0; y < bufferHeight; y++) {
                for (var x = 0; x < bufferWidth; x++) {
                    if ((y * bufferHeight + x + 1) % step != 1 && step != 1) {
                        continue;
                    }

                    var hsv = HSVUtils.ColorToHSV(palette[random.Next() % palette.Length]);

                    var randomStep = (eventToRender + random.Next()) % steps;

                    hsv.Value = chkBoxStrobe.Checked ? ((randomStep == (int)(stepsHalf + 0.5f)) ? 1.0f : 0.0f) :
                        Math.Max(0.0f, ((randomStep <= stepsHalf ? randomStep : steps - randomStep) / stepsHalf));

                    buffer[y, x] = HSVUtils.HSVtoColor(hsv);
                }
            }
            return buffer;
        }


        private void Twinkle_ControlChanged(object sender, EventArgs e) {
            OnControlChanged(this, new EventArgs());
        }
    }
}