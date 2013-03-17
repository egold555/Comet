namespace VixenEditor {
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Timers;
	using System.Windows.Forms;

	internal class SparkleParamsDialog : Form {
		private bool m_actualLevels;
		private SolidBrush m_brush = null;
		private int m_decay = 0;
		private System.Timers.Timer m_drawTimer;
		private FrequencyEffectGenerator m_effectGenerator;
		private byte[,] m_effectValues;
		private int m_frequency = 0;
		private int m_max = 100;
		private int m_maxColumn;
		private int m_min = 0;
		private int m_tickCount;
		private Point[][] m_treePoints;

		public SparkleParamsDialog(int maxFrequency, FrequencyEffectGenerator effectGenerator, byte sequenceMin, byte sequenceMax, byte currentDrawingIntensity, bool actualLevels) {
			this.InitializeComponent();
			this.m_actualLevels = actualLevels;
			this.m_brush = new SolidBrush(Color.Black);
			this.trackBarFrequency.Maximum = maxFrequency;
			this.m_effectGenerator = effectGenerator;
			this.m_refreshInvoker = new MethodInvoker(this.pictureBoxExample.Refresh);
			this.m_effectValues = new byte[4, maxFrequency * 5];
			this.m_maxColumn = this.m_effectValues.GetLength(1);
			this.m_min = sequenceMin;
			this.m_max = currentDrawingIntensity;
			int[] effectParameters = new int[4];
			effectParameters[2] = this.m_min;
			effectParameters[3] = this.m_max;
			effectGenerator(this.m_effectValues, effectParameters);
			this.m_tickCount = 0;
			Point[][] pointArray = new Point[4][];
			Point[] pointArray2 = new Point[] { new Point(0x16, 0x2e), new Point(0x25, 0x5b), new Point(7, 0x5b) };
			pointArray[0] = pointArray2;
			pointArray2 = new Point[] { new Point(0x43, 0x2e), new Point(0x52, 0x5b), new Point(0x34, 0x5b) };
			pointArray[1] = pointArray2;
			pointArray2 = new Point[] { new Point(0x70, 0x2e), new Point(0x7f, 0x5b), new Point(0x61, 0x5b) };
			pointArray[2] = pointArray2;
			pointArray2 = new Point[] { new Point(0x9d, 0x2e), new Point(0xac, 0x5b), new Point(0x8e, 0x5b) };
			pointArray[3] = pointArray2;
			this.m_treePoints = pointArray;
			this.m_drawTimer = new System.Timers.Timer(100.0);
			this.m_drawTimer.Elapsed += new ElapsedEventHandler(this.m_drawTimer_Elapsed);
			this.m_drawTimer.Start();
			if (actualLevels) {
				this.numericUpDownMin.Minimum = this.numericUpDownMax.Minimum = this.numericUpDownMin.Value = sequenceMin;
				this.numericUpDownMin.Maximum = this.numericUpDownMax.Maximum = sequenceMax;
				this.numericUpDownMax.Value = this.m_max;
			}
			else {
				this.numericUpDownMin.Minimum = this.numericUpDownMax.Minimum = this.numericUpDownMin.Value = (int)Math.Round((double)((sequenceMin * 100f) / 255f), MidpointRounding.AwayFromZero);
				this.numericUpDownMin.Maximum = this.numericUpDownMax.Maximum = (int)Math.Round((double)((sequenceMax * 100f) / 255f), MidpointRounding.AwayFromZero);
				this.numericUpDownMax.Value = (int)Math.Round((double)((this.m_max * 100f) / 255f), MidpointRounding.AwayFromZero);
			}
		}

		private void m_drawTimer_Elapsed(object sender, ElapsedEventArgs e) {
			base.BeginInvoke(this.m_refreshInvoker);
			if (++this.m_tickCount == this.m_maxColumn) {
				this.Regenerate();
			}
		}

		private void numericUpDownMax_ValueChanged(object sender, EventArgs e) {
			if (this.m_actualLevels) {
				this.m_max = (int)this.numericUpDownMax.Value;
			}
			else {
				this.m_max = (((int)this.numericUpDownMax.Value) * 0xff) / 100;
			}
			this.Regenerate();
		}

		private void numericUpDownMin_ValueChanged(object sender, EventArgs e) {
			if (this.m_actualLevels) {
				this.m_min = (int)this.numericUpDownMin.Value;
			}
			else {
				this.m_min = (((int)this.numericUpDownMin.Value) * 0xff) / 100;
			}
			this.Regenerate();
		}

		private void pictureBoxExample_Paint(object sender, PaintEventArgs e) {
			if (this.m_drawTimer.Enabled) {
				this.m_brush.Color = Color.FromArgb(this.m_effectValues[0, this.m_tickCount], Color.Red);
				e.Graphics.FillPolygon(this.m_brush, this.m_treePoints[0]);
				this.m_brush.Color = Color.FromArgb(this.m_effectValues[1, this.m_tickCount], Color.Green);
				e.Graphics.FillPolygon(this.m_brush, this.m_treePoints[1]);
				this.m_brush.Color = Color.FromArgb(this.m_effectValues[2, this.m_tickCount], Color.Blue);
				e.Graphics.FillPolygon(this.m_brush, this.m_treePoints[2]);
				this.m_brush.Color = Color.FromArgb(this.m_effectValues[3, this.m_tickCount], Color.White);
				e.Graphics.FillPolygon(this.m_brush, this.m_treePoints[3]);
			}
		}

		private void Regenerate() {
			this.m_drawTimer.Stop();
			this.m_effectGenerator(this.m_effectValues, new int[] { this.m_frequency, this.m_decay, this.m_min, this.m_max });
			this.m_tickCount = 0;
			this.m_drawTimer.Start();
		}

		private void SparkleParamsDialog_FormClosing(object sender, FormClosingEventArgs e) {
			this.m_drawTimer.Stop();
		}

		private void trackBarDecay_Scroll(object sender, EventArgs e) {
			this.m_decay = this.trackBarDecay.Value;
			this.Regenerate();
		}

		private void trackBarFrequency_Scroll(object sender, EventArgs e) {
			this.m_frequency = this.trackBarFrequency.Value;
			this.Regenerate();
		}

		public int DecayTime {
			get {
				return this.trackBarDecay.Value;
			}
		}

		public int Frequency {
			get {
				return this.trackBarFrequency.Value;
			}
		}

		public byte MaximumIntensity {
			get {
				return (byte)this.m_max;
			}
		}

		public byte MinimumIntensity {
			get {
				return (byte)this.m_min;
			}
		}
	}
}