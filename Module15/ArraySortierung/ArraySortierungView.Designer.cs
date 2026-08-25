namespace ZbW.ProgrammingFoundation.Lessons.Module15.ArraySortierung
{
  using System.ComponentModel;

  partial class ArraySortierungView
  {
    private IContainer components = null;

    private System.Windows.Forms.Panel PnlControls;
    private System.Windows.Forms.Panel PnlBoard;
    private System.Windows.Forms.Label LblLaenge;
    private System.Windows.Forms.NumericUpDown NudLaenge;
    private System.Windows.Forms.Label LblMin;
    private System.Windows.Forms.NumericUpDown NudMin;
    private System.Windows.Forms.Label LblMax;
    private System.Windows.Forms.NumericUpDown NudMax;
    private System.Windows.Forms.Button BtnGenerieren;
    private System.Windows.Forms.Button BtnSortieren;
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

      PnlControls   = new System.Windows.Forms.Panel();
      PnlBoard      = new System.Windows.Forms.Panel();
      LblLaenge     = new System.Windows.Forms.Label();
      NudLaenge     = new System.Windows.Forms.NumericUpDown();
      LblMin        = new System.Windows.Forms.Label();
      NudMin        = new System.Windows.Forms.NumericUpDown();
      LblMax        = new System.Windows.Forms.Label();
      NudMax        = new System.Windows.Forms.NumericUpDown();
      BtnGenerieren = new System.Windows.Forms.Button();
      BtnSortieren  = new System.Windows.Forms.Button();
      LblStatus     = new System.Windows.Forms.Label();

      SuspendLayout();

      // ── PnlControls ──────────────────────────────────────────────────────
      PnlControls.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
      PnlControls.Dock      = System.Windows.Forms.DockStyle.Top;
      PnlControls.Height    = 60;
      PnlControls.Controls.Add(LblLaenge);
      PnlControls.Controls.Add(NudLaenge);
      PnlControls.Controls.Add(LblMin);
      PnlControls.Controls.Add(NudMin);
      PnlControls.Controls.Add(LblMax);
      PnlControls.Controls.Add(NudMax);
      PnlControls.Controls.Add(BtnGenerieren);
      PnlControls.Controls.Add(BtnSortieren);
      PnlControls.Controls.Add(LblStatus);

      // ── LblLaenge ────────────────────────────────────────────────────────
      LblLaenge.Text      = "Array-Länge:";
      LblLaenge.ForeColor = System.Drawing.Color.White;
      LblLaenge.Location  = new System.Drawing.Point(12, 20);
      LblLaenge.AutoSize  = true;

      // ── NudLaenge ────────────────────────────────────────────────────────
      NudLaenge.Location = new System.Drawing.Point(100, 17);
      NudLaenge.Width    = 65;
      NudLaenge.Minimum  = 2;
      NudLaenge.Maximum  = 80;
      NudLaenge.Value    = 12;

      // ── LblMin ───────────────────────────────────────────────────────────
      LblMin.Text      = "Min:";
      LblMin.ForeColor = System.Drawing.Color.White;
      LblMin.Location  = new System.Drawing.Point(185, 20);
      LblMin.AutoSize  = true;

      // ── NudMin ───────────────────────────────────────────────────────────
      NudMin.Location = new System.Drawing.Point(215, 17);
      NudMin.Width    = 70;
      NudMin.Minimum  = -9999;
      NudMin.Maximum  = 9999;
      NudMin.Value    = 1;

      // ── LblMax ───────────────────────────────────────────────────────────
      LblMax.Text      = "Max:";
      LblMax.ForeColor = System.Drawing.Color.White;
      LblMax.Location  = new System.Drawing.Point(300, 20);
      LblMax.AutoSize  = true;

      // ── NudMax ───────────────────────────────────────────────────────────
      NudMax.Location = new System.Drawing.Point(330, 17);
      NudMax.Width    = 70;
      NudMax.Minimum  = -9999;
      NudMax.Maximum  = 9999;
      NudMax.Value    = 100;

      // ── BtnGenerieren ────────────────────────────────────────────────────
      BtnGenerieren.Text      = "► Generieren";
      BtnGenerieren.Location  = new System.Drawing.Point(420, 13);
      BtnGenerieren.Size      = new System.Drawing.Size(120, 34);
      BtnGenerieren.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
      BtnGenerieren.ForeColor = System.Drawing.Color.White;
      BtnGenerieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnGenerieren.Click    += new System.EventHandler(this.BtnGenerieren_Click);

      // ── BtnSortieren ─────────────────────────────────────────────────────
      BtnSortieren.Text      = "⇅ Bubble Sort";
      BtnSortieren.Location  = new System.Drawing.Point(550, 13);
      BtnSortieren.Size      = new System.Drawing.Size(120, 34);
      BtnSortieren.BackColor = System.Drawing.Color.FromArgb(60, 120, 60);
      BtnSortieren.ForeColor = System.Drawing.Color.White;
      BtnSortieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnSortieren.Enabled   = false;
      BtnSortieren.Click    += new System.EventHandler(this.BtnSortieren_Click);

      // ── LblStatus ────────────────────────────────────────────────────────
      LblStatus.Text      = "Array-Länge wählen und Generieren klicken";
      LblStatus.ForeColor = System.Drawing.Color.LightGray;
      LblStatus.Location  = new System.Drawing.Point(685, 20);
      LblStatus.AutoSize  = true;

      // ── PnlBoard ─────────────────────────────────────────────────────────
      PnlBoard.Dock      = System.Windows.Forms.DockStyle.Fill;
      PnlBoard.BackColor = System.Drawing.Color.FromArgb(28, 28, 32);
      PnlBoard.Paint    += new System.Windows.Forms.PaintEventHandler(this.PnlBoard_Paint);

      // ── Form ─────────────────────────────────────────────────────────────
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize    = new System.Drawing.Size(1000, 560);
      Text          = "Array-Sortierung – Zufälliges Array erzeugen und sortieren";
      BackColor     = System.Drawing.Color.FromArgb(28, 28, 32);
      Controls.Add(PnlBoard);
      Controls.Add(PnlControls);

      ResumeLayout(false);
    }

    #endregion
  }
}
