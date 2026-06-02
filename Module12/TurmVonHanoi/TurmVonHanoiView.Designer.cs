namespace ZbW.ProgrammingFoundation.Lessons.Module12.TurmVonHanoi
{
  using System.ComponentModel;

  partial class TurmVonHanoiView
  {
    private IContainer components = null;

    // Controls
    private System.Windows.Forms.Panel PnlControls;
    private System.Windows.Forms.Panel PnlBoard;
    private System.Windows.Forms.Label LblDisks;
    private System.Windows.Forms.ComboBox CmbDisks;
    private System.Windows.Forms.Label LblAlgorithm;
    private System.Windows.Forms.ComboBox CmbAlgorithm;
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

      PnlControls  = new System.Windows.Forms.Panel();
      PnlBoard     = new System.Windows.Forms.Panel();
      LblDisks     = new System.Windows.Forms.Label();
      CmbDisks     = new System.Windows.Forms.ComboBox();
      LblAlgorithm = new System.Windows.Forms.Label();
      CmbAlgorithm = new System.Windows.Forms.ComboBox();
      LblSpeed     = new System.Windows.Forms.Label();
      TrkSpeed     = new System.Windows.Forms.TrackBar();
      BtnStart     = new System.Windows.Forms.Button();
      LblStatus    = new System.Windows.Forms.Label();

      SuspendLayout();

      // ── PnlControls ──────────────────────────────────────────────────────
      PnlControls.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
      PnlControls.Dock      = System.Windows.Forms.DockStyle.Top;
      PnlControls.Height    = 65;
      PnlControls.Controls.Add(LblDisks);
      PnlControls.Controls.Add(CmbDisks);
      PnlControls.Controls.Add(LblAlgorithm);
      PnlControls.Controls.Add(CmbAlgorithm);
      PnlControls.Controls.Add(LblSpeed);
      PnlControls.Controls.Add(TrkSpeed);
      PnlControls.Controls.Add(BtnStart);
      PnlControls.Controls.Add(LblStatus);

      // ── LblDisks ─────────────────────────────────────────────────────────
      LblDisks.Text      = "Scheiben:";
      LblDisks.ForeColor = System.Drawing.Color.White;
      LblDisks.Location  = new System.Drawing.Point(12, 23);
      LblDisks.AutoSize  = true;

      // ── CmbDisks ─────────────────────────────────────────────────────────
      CmbDisks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      CmbDisks.Location      = new System.Drawing.Point(85, 19);
      CmbDisks.Width         = 55;
      for (int i = 1; i <= 21; i++) CmbDisks.Items.Add(i);
      CmbDisks.SelectedIndex = 2; // default: 3 Scheiben

      // ── LblAlgorithm ─────────────────────────────────────────────────────
      LblAlgorithm.Text      = "Algorithmus:";
      LblAlgorithm.ForeColor = System.Drawing.Color.White;
      LblAlgorithm.Location  = new System.Drawing.Point(160, 23);
      LblAlgorithm.AutoSize  = true;

      // ── CmbAlgorithm ─────────────────────────────────────────────────────
      CmbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      CmbAlgorithm.Location      = new System.Drawing.Point(255, 19);
      CmbAlgorithm.Width         = 160;
      CmbAlgorithm.Items.AddRange(new object[] { "Rekursiv", "For (Iterativ)", "Teile & Herrsche" });
      CmbAlgorithm.SelectedIndex = 0;

      // ── LblSpeed ─────────────────────────────────────────────────────────
      LblSpeed.Text      = "Geschwindigkeit:";
      LblSpeed.ForeColor = System.Drawing.Color.White;
      LblSpeed.Location  = new System.Drawing.Point(430, 23);
      LblSpeed.AutoSize  = true;

      // ── TrkSpeed ─────────────────────────────────────────────────────────
      TrkSpeed.Location      = new System.Drawing.Point(555, 10);
      TrkSpeed.Width         = 140;
      TrkSpeed.Minimum       = 1;
      TrkSpeed.Maximum       = 100;
      TrkSpeed.Value         = 50;
      TrkSpeed.TickFrequency = 10;

      // ── BtnStart ─────────────────────────────────────────────────────────
      BtnStart.Text      = "Start";
      BtnStart.Location  = new System.Drawing.Point(715, 14);
      BtnStart.Size      = new System.Drawing.Size(80, 36);
      BtnStart.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
      BtnStart.ForeColor = System.Drawing.Color.White;
      BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnStart.Click    += new System.EventHandler(this.BtnStart_Click);

      // ── LblStatus ────────────────────────────────────────────────────────
      LblStatus.Text      = "Bereit";
      LblStatus.ForeColor = System.Drawing.Color.LightGray;
      LblStatus.Location  = new System.Drawing.Point(810, 23);
      LblStatus.AutoSize  = true;

      // ── PnlBoard ─────────────────────────────────────────────────────────
      PnlBoard.Dock      = System.Windows.Forms.DockStyle.Fill;
      PnlBoard.BackColor = System.Drawing.Color.FromArgb(28, 28, 32);
      PnlBoard.Paint    += new System.Windows.Forms.PaintEventHandler(this.PnlBoard_Paint);

      // ── Form ─────────────────────────────────────────────────────────────
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize    = new System.Drawing.Size(1020, 600);
      Text          = "Türme von Hanoi – Rekursion Demo";
      BackColor     = System.Drawing.Color.FromArgb(28, 28, 32);
      Controls.Add(PnlBoard);     // Fill – processed last by layout
      Controls.Add(PnlControls); // Top  – processed first by layout

      ResumeLayout(false);
    }

    #endregion
  }
}
