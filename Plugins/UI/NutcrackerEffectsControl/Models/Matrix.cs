﻿using System;
using System.Drawing;
using System.Windows.Forms;

using VixenPlus.Annotations;

namespace Nutcracker.Models {
    [UsedImplicitly]
    public partial class Matrix : NutcrackerModelBase {
        public Matrix() {
            InitializeComponent();
        }

        public override string EffectName {
            get { return "Matrix"; }
        }

        private void InitMatrix() {
            var strandsPerString = (int)nudStrandCount.Value;

            var numStrands = Cols;
            var pixelsPerStrand = Rows;
            var xFactor = (pbPreview.Width - (XyOffset * 2)) / Cols;
            var yFactor = (pbPreview.Height - (XyOffset * 2)) / Rows;
            var index = 0;
            for (var strand = 0; strand < numStrands; strand++) {
                var segmentnum = strand % strandsPerString;
                for (var pixel = 0; pixel < pixelsPerStrand; pixel++) {
                    var y = index % Rows;
                    var x = index / Rows;
                    var ptX = IsLtoR ? strand : numStrands - strand - 1;
                    var ptY = (segmentnum % 2 != 0) ? pixel : pixelsPerStrand - pixel - 1;
                    Nodes[y, x].Model = new Point(ptX * xFactor, ptY * yFactor );
                    index++;
                }
            }
        }


        private void control_ValueChanged(object sender, EventArgs e) {
            ResetNodes();
            InitMatrix();
            pbPreview.Invalidate();
        }


        internal override void ResetNodes() {
            var nodesPerString = (int) nudNodeCount.Value / (int) nudStrandCount.Value;
            var totalStringCount = (int) nudStringCount.Value * (int) nudStrandCount.Value;
            Rows = rbVertical.Checked ? nodesPerString : totalStringCount;
            Cols = rbVertical.Checked ? totalStringCount : nodesPerString;

            base.ResetNodes();
        }


        private void pbPreview_Paint(object sender, PaintEventArgs e) {
            if (Rows == 0 || Cols == 0) {
                ResetNodes();
                InitMatrix();
            }

            Draw(pbPreview, e.Graphics);
        }
    }
}
