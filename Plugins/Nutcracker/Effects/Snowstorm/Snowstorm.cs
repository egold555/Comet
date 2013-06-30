﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using CommonUtils;
using VixenPlus;

namespace Snowstorm {
    public partial class Snowstorm : UserControl, INutcrackerEffect {
        public Snowstorm() {
            InitializeComponent();
        }


        public event EventHandler OnControlChanged;
        private readonly Random _random = new Random();

        public string EffectName {
            get { return "Snow Storm"; }
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

        private class SnowstormClass {
            public readonly List<Point> Points = new List<Point>();
            public HSVUtils HSV;
            public int Idx, SsDecay;


            public SnowstormClass() {
                Points.Clear();
            }
        }

        private readonly List<SnowstormClass> _snowstormItems = new List<SnowstormClass>();
        private int _bufferHeight;
        private int _bufferWidth;
        private Color[] _palette;


        private void InitializeSnowstorm() {
            if (_palette == null) return;

            var hsv0 = HSVUtils.ColorToHSV(_palette[0]);
            var hsv1 = HSVUtils.ColorToHSV(_palette.Length > 1 ? _palette[1] : _palette[0]);

            var count = Convert.ToInt32(_bufferWidth * _bufferHeight * tbMaxFlakes.Value / 2000) + 1;
            var tailLength = _bufferWidth * _bufferHeight * tbTailLength.Value / 2000 + 2;
            var xy = new Point();
            // create snowstorm elements
            _snowstormItems.Clear();
            for (var i = 0; i < count; i++) {
                var ssItem = new SnowstormClass {Idx = i, SsDecay = 0};
                ssItem.Points.Clear();
                ssItem.HSV = HSVUtils.SetRangeColor(hsv0, hsv1);
                // start in a random state
                var r = Rand() % (2 * tailLength);
                if (r > 0) {
                    xy.X = Rand() % _bufferWidth;
                    xy.Y = Rand() % _bufferHeight;
                    //ssItem.points.push_back(xy);
                    ssItem.Points.Add(xy);
                }
                if (r >= tailLength) {
                    ssItem.SsDecay = r - tailLength;
                    r = tailLength;
                }
                for (var j = 1; j < r; j++) {
                    SnowstormAdvance(ssItem);
                }
                //SnowstormItems.push_back(ssItem);
                _snowstormItems.Add(ssItem);
            }
        }


        private int lastRenderedEvent = -1;
        
        public Color[,] RenderEffect(Color[,] buffer, Color[] palette, int eventToRender) {
            _bufferHeight = buffer.GetLength(Utils.IndexRowsOrHeight);
            _bufferWidth = buffer.GetLength(Utils.IndexColsOrWidth);
            _palette = palette;
            var speed = eventToRender - lastRenderedEvent;
            lastRenderedEvent = eventToRender;
            var tailLength = _bufferWidth * _bufferHeight * tbTailLength.Value / 2000 + 2;
            var xy = new Point();
            if (eventToRender == 0 || _snowstormItems.Count == 0) {
                InitializeSnowstorm();
            }

            foreach (var it in _snowstormItems) {
                if (it.Points.Count > tailLength) {
                    if (it.SsDecay > tailLength) {
                        it.Points.Clear(); // start over
                        it.SsDecay = 0;
                    }
                    else if (Rand() % 20 < speed) {
                        it.SsDecay++;
                    }
                }
                if (it.Points.Count == 0) {
                    xy.X = Rand() % _bufferWidth;
                    xy.Y = Rand() % _bufferHeight;
                    //it.points.push_back(xy);
                    it.Points.Add(xy);
                }
                else if (Rand() % 20 < speed) {
                    SnowstormAdvance(it);
                }
                var sz = it.Points.Count;
                for (var pt = 0; pt < sz; pt++) {
                    var hsv = it.HSV;
                    hsv.Value = (float) (1.0 - (double) (sz - pt + it.SsDecay) / tailLength);
                    if (hsv.Value < 0.0) {
                        hsv.Value = 0.0f;
                    }
                    buffer[it.Points[pt].Y, it.Points[pt].X] = HSVUtils.HSVtoColor(hsv); // (it.points[pt].X, it.points[pt].Y, hsv);
                }
                //cnt++;
            }

            return buffer;
        }


        private int Rand() {
            return _random.Next();
        }


        private Point SnowstormVector(int idx) {
            var xy = new Point();
            switch (idx) {
                case 0:
                    xy.X = -1;
                    xy.Y = 0;
                    break;
                case 1:
                    xy.X = -1;
                    xy.Y = -1;
                    break;
                case 2:
                    xy.X = 0;
                    xy.Y = -1;
                    break;
                case 3:
                    xy.X = 1;
                    xy.Y = -1;
                    break;
                case 4:
                    xy.X = 1;
                    xy.Y = 0;
                    break;
                case 5:
                    xy.X = 1;
                    xy.Y = 1;
                    break;
                case 6:
                    xy.X = 0;
                    xy.Y = 1;
                    break;
                default:
                    xy.X = -1;
                    xy.Y = 1;
                    break;
            }
            return xy;
        }


        private void SnowstormAdvance(SnowstormClass ssItem) {
            const int cnt = 8; // # of integers in each set in arr[]
            int[] arr = {30, 20, 10, 5, 0, 5, 10, 20, 20, 15, 10, 10, 10, 10, 10, 15}; // 2 sets of 8 numbers, each of which add up to 100
            var adv = SnowstormVector(7);
            var i0 = ssItem.Idx % 7 <= 4 ? 0 : cnt;
            var r = Rand() % 100;
            for (int i = 0, val = 0; i < cnt; i++) {
                val += arr[i0 + i];
                if (r >= val) {
                    continue;
                }
                adv = SnowstormVector(i);
                break;
            }
            if (ssItem.Idx % 3 == 0) {
                adv.X *= 2;
                adv.Y *= 2;
            }
            //Point xy = ssItem.points.back() + adv;
            var xy = ssItem.Points[ssItem.Points.Count - 1];
            xy.X += adv.X;
            xy.Y += adv.Y;

            xy.X %= _bufferWidth;
            xy.Y %= _bufferHeight;
            if (xy.X < 0) {
                xy.X += _bufferWidth;
            }
            if (xy.Y < 0) {
                xy.Y += _bufferHeight;
            }
            //ssItem.points.push_back(xy);
            ssItem.Points.Add(xy);
        }


        private void SnowStorm_ControlChanged(object sender, EventArgs e) {
            InitializeSnowstorm();
            OnControlChanged(this, new EventArgs());
        }
    }
}