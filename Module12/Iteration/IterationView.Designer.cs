namespace ZbW.ProgrammingFoundation.Lessons.Module12.Iteration
{
  using System.ComponentModel;

  partial class IterationView
  {
    private IContainer components = null;

    private System.Windows.Forms.Panel PnlControls;
    private System.Windows.Forms.Panel PnlBoard;
    private System.Windows.Forms.Label LblZahlen;
    private System.Windows.Forms.TextBox TxtZahlen;
    private System.Windows.Forms.Label LblSpeed;
    private System.Windows.Forms.TrackBar TrkSpeed;
    private System.Windows.Forms.Button BtnStart;
    private System.Windows.Forms.Label LblStatus;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
        components.Dispose();
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();

      PnlControls = new System.Windows.Forms.Panel();
      PnlBoard    = new System.Windows.Forms.Panel();
      LblZahlen   = new System.Windows.Forms.Label();
      TxtZahlen   = new System.Windows.Forms.TextBox();
      LblSpeed    = new System.Windows.Forms.Label();
      TrkSpeed    = new System.Windows.Forms.TrackBar();
      BtnStart    = new System.Windows.Forms.Button();
      LblStatus   = new System.Windows.Forms.Label();

      SuspendLayout();

      // ── PnlControls ──────────────────────────────────────────────────────
      PnlControls.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
      PnlControls.Dock      = System.Windows.Forms.DockStyle.Top;
      PnlControls.Height    = 65;
      PnlControls.Controls.Add(LblZahlen);
      PnlControls.Controls.Add(TxtZahlen);
      PnlControls.Controls.Add(LblSpeed);
      PnlControls.Controls.Add(TrkSpeed);
      PnlControls.Controls.Add(BtnStart);
      PnlControls.Controls.Add(LblStatus);

      // ── LblZahlen ────────────────────────────────────────────────────────
      LblZahlen.Text      = "Zahlen:";
      LblZahlen.ForeColor = System.Drawing.Color.White;
      LblZahlen.Location  = new System.Drawing.Point(12, 23);
      LblZahlen.AutoSize  = true;

      // ── TxtZahlen ────────────────────────────────────────────────────────
      TxtZahlen.Text     = "3, 7, 2, 9, 1, 5, 8, 4";
      TxtZahlen.Location = new System.Drawing.Point(70, 19);
      TxtZahlen.Width    = 230;

      // ── LblSpeed ─────────────────────────────────────────────────────────
      LblSpeed.Text      = "Geschwindigkeit:";
      LblSpeed.ForeColor = System.Drawing.Color.White;
      LblSpeed.Location  = new System.Drawing.Point(315, 23);
      LblSpeed.AutoSize  = true;

      // ── TrkSpeed ─────────────────────────────────────────────────────────
      TrkSpeed.Location      = new System.Drawing.Point(440, 10);
      TrkSpeed.Width         = 110;
      TrkSpeed.Minimum       = 1;
      TrkSpeed.Maximum       = 100;
      TrkSpeed.Value         = 50;
      TrkSpeed.TickFrequency = 10;

      // ── BtnStart ─────────────────────────────────────────────────────────
      BtnStart.Text      = "Start";
      BtnStart.Location  = new System.Drawing.Point(565, 14);
      BtnStart.Size      = new System.Drawing.Size(80, 36);
      BtnStart.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
      BtnStart.ForeColor = System.Drawing.Color.White;
      BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnStart.Click    += new System.EventHandler(this.BtnStart_Click);

      // ── LblStatus ────────────────────────────────────────────────────────
      LblStatus.Text      = "Bereit";
      LblStatus.ForeColor = System.Drawing.Color.LightGray;
      LblStatus.Location  = new System.Drawing.Point(660, 23);
      LblStatus.AutoSize  = true;

      // ── PnlBoard ─────────────────────────────────────────────────────────
      PnlBoard.Dock      = System.Windows.Forms.DockStyle.Fill;
      PnlBoard.BackColor = System.Drawing.Color.FromArgb(28, 28, 32);
      PnlBoard.Paint    += new System.Windows.Forms.PaintEventHandler(this.PnlBoard_Paint);

      // ── Form ─────────────────────────────────────────────────────────────
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize    = new System.Drawing.Size(900, 500);
      Text          = "Iteration – Summe & Maximum";
      BackColor     = System.Drawing.Color.FromArgb(28, 28, 32);
      Controls.Add(PnlBoard);
      Controls.Add(PnlControls);

      ResumeLayout(false);
    }

    #endregion
  }
}
