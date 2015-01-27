using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VixenPlus {
    public partial class OutputPlugInUIBase {
        private IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // OutputPlugInUIBase
            // 
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size(284, 262);
            this.Name = "OutputPlugInUIBase";
            this.ShowInTaskbar = false;
            this.Text = "OutputPlugInUIBase";
            this.ResumeLayout(false);

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