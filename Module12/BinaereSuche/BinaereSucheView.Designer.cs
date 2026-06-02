namespace ZbW.ProgrammingFoundation.Lessons.Module12.BinaereSuche
{
  using System.ComponentModel;

  partial class BinaereSucheView
  {
    private IContainer components = null;

    private System.Windows.Forms.Panel PnlControls;
    private System.Windows.Forms.Panel PnlBoard;
    private System.Windows.Forms.Label LblArray;
    private System.Windows.Forms.TextBox TxtArray;
    private System.Windows.Forms.Label LblSuche;
    private System.Windows.Forms.TextBox TxtSuche;
    private System.Windows.Forms.RadioButton RdoIterativ;
    private System.Windows.Forms.RadioButton RdoRekursiv;
    private System.Windows.Forms.Label LblSpeed;
    private System.Windows.Forms.TrackBar TrkSpeed;
    private System.Windows.Forms.Button BtnSuchen;
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
      LblArray    = new System.Windows.Forms.Label();
      TxtArray    = new System.Windows.Forms.TextBox();
      LblSuche    = new System.Windows.Forms.Label();
      TxtSuche    = new System.Windows.Forms.TextBox();
      RdoIterativ = new System.Windows.Forms.RadioButton();
      RdoRekursiv = new System.Windows.Forms.RadioButton();
      LblSpeed    = new System.Windows.Forms.Label();
      TrkSpeed    = new System.Windows.Forms.TrackBar();
      BtnSuchen   = new System.Windows.Forms.Button();
      LblStatus   = new System.Windows.Forms.Label();

      SuspendLayout();

      // ── PnlControls ──────────────────────────────────────────────────────
      PnlControls.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
      PnlControls.Dock      = System.Windows.Forms.DockStyle.Top;
      PnlControls.Height    = 65;
      PnlControls.Controls.Add(LblArray);
      PnlControls.Controls.Add(TxtArray);
      PnlControls.Controls.Add(LblSuche);
      PnlControls.Controls.Add(TxtSuche);
      PnlControls.Controls.Add(RdoIterativ);
      PnlControls.Controls.Add(RdoRekursiv);
      PnlControls.Controls.Add(LblSpeed);
      PnlControls.Controls.Add(TrkSpeed);
      PnlControls.Controls.Add(BtnSuchen);
      PnlControls.Controls.Add(LblStatus);

      // ── LblArray ─────────────────────────────────────────────────────────
      LblArray.Text      = "Array (sortiert):";
      LblArray.ForeColor = System.Drawing.Color.White;
      LblArray.Location  = new System.Drawing.Point(12, 23);
      LblArray.AutoSize  = true;

      // ── TxtArray ─────────────────────────────────────────────────────────
      TxtArray.Text     = "2, 5, 8, 12, 16, 23, 38, 45";
      TxtArray.Location = new System.Drawing.Point(115, 19);
      TxtArray.Width    = 210;

      // ── LblSuche ─────────────────────────────────────────────────────────
      LblSuche.Text      = "Suche:";
      LblSuche.ForeColor = System.Drawing.Color.White;
      LblSuche.Location  = new System.Drawing.Point(338, 23);
      LblSuche.AutoSize  = true;

      // ── TxtSuche ─────────────────────────────────────────────────────────
      TxtSuche.Text     = "23";
      TxtSuche.Location = new System.Drawing.Point(385, 19);
      TxtSuche.Width    = 55;

      // ── RdoIterativ ──────────────────────────────────────────────────────
      RdoIterativ.Text      = "Iterativ";
      RdoIterativ.ForeColor = System.Drawing.Color.White;
      RdoIterativ.Location  = new System.Drawing.Point(453, 19);
      RdoIterativ.AutoSize  = true;
      RdoIterativ.Checked   = true;

      // ── RdoRekursiv ──────────────────────────────────────────────────────
      RdoRekursiv.Text      = "Rekursiv";
      RdoRekursiv.ForeColor = System.Drawing.Color.White;
      RdoRekursiv.Location  = new System.Drawing.Point(453, 38);
      RdoRekursiv.AutoSize  = true;

      // ── LblSpeed ─────────────────────────────────────────────────────────
      LblSpeed.Text      = "Geschwindigkeit:";
      LblSpeed.ForeColor = System.Drawing.Color.White;
      LblSpeed.Location  = new System.Drawing.Point(545, 23);
      LblSpeed.AutoSize  = true;

      // ── TrkSpeed ─────────────────────────────────────────────────────────
      TrkSpeed.Location      = new System.Drawing.Point(670, 10);
      TrkSpeed.Width         = 110;
      TrkSpeed.Minimum       = 1;
      TrkSpeed.Maximum       = 100;
      TrkSpeed.Value         = 40;
      TrkSpeed.TickFrequency = 10;

      // ── BtnSuchen ────────────────────────────────────────────────────────
      BtnSuchen.Text      = "Suchen";
      BtnSuchen.Location  = new System.Drawing.Point(795, 14);
      BtnSuchen.Size      = new System.Drawing.Size(80, 36);
      BtnSuchen.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
      BtnSuchen.ForeColor = System.Drawing.Color.White;
      BtnSuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnSuchen.Click    += new System.EventHandler(this.BtnSuchen_Click);

      // ── LblStatus ────────────────────────────────────────────────────────
      LblStatus.Text      = "Bereit";
      LblStatus.ForeColor = System.Drawing.Color.LightGray;
      LblStatus.Location  = new System.Drawing.Point(890, 23);
      LblStatus.AutoSize  = true;

      // ── PnlBoard ─────────────────────────────────────────────────────────
      PnlBoard.Dock      = System.Windows.Forms.DockStyle.Fill;
      PnlBoard.BackColor = System.Drawing.Color.FromArgb(28, 28, 32);
      PnlBoard.Paint    += new System.Windows.Forms.PaintEventHandler(this.PnlBoard_Paint);

      // ── Form ─────────────────────────────────────────────────────────────
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize    = new System.Drawing.Size(1100, 420);
      Text          = "Binäre Suche – Divide & Conquer";
      BackColor     = System.Drawing.Color.FromArgb(28, 28, 32);
      Controls.Add(PnlBoard);
      Controls.Add(PnlControls);

      ResumeLayout(false);
    }

    #endregion
  }
}
