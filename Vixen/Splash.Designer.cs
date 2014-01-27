using System.ComponentModel;

internal partial class Splash
{
    private IContainer components = null;

    #region Windows Form Designer generated code
        
    private void InitializeComponent()
    {
        this.SuspendLayout();
        // 
        // Splash
        // 
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        this.BackColor = System.Drawing.Color.Gainsboro;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        this.ClientSize = new System.Drawing.Size(606, 192);
        this.ControlBox = false;
        this.DoubleBuffered = true;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "Splash";
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.TopMost = true;
        this.TransparencyKey = System.Drawing.Color.Gainsboro;
        this.ResumeLayout(false);

    }
    #endregion

    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.components != null))
        {
            this.components.Dispose();
        }
        base.Dispose(disposing);
    }
}