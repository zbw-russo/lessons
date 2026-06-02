namespace ZbW.ProgrammingFoundation.Lessons.Module12.MuenzWechsel
{
  using System.ComponentModel;

  partial class MuenzWechselView
  {
    private IContainer components = null;

    // Controls
    private System.Windows.Forms.Panel PnlControls;
    private System.Windows.Forms.Panel PnlBoard;
    private System.Windows.Forms.Label LblWaehrung;
    private System.Windows.Forms.ComboBox CmbWaehrung;
    private System.Windows.Forms.Label LblBetrag;
    private System.Windows.Forms.TextBox TxtBetrag;
    private System.Windows.Forms.Label LblMuenzen;
    private System.Windows.Forms.TextBox TxtMuenzen;
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
      LblWaehrung = new System.Windows.Forms.Label();
      CmbWaehrung = new System.Windows.Forms.ComboBox();
      LblBetrag   = new System.Windows.Forms.Label();
      TxtBetrag   = new System.Windows.Forms.TextBox();
      LblMuenzen  = new System.Windows.Forms.Label();
      TxtMuenzen  = new System.Windows.Forms.TextBox();
      LblSpeed    = new System.Windows.Forms.Label();
      TrkSpeed    = new System.Windows.Forms.TrackBar();
      BtnStart    = new System.Windows.Forms.Button();
      LblStatus   = new System.Windows.Forms.Label();

      SuspendLayout();

      // ── PnlControls ──────────────────────────────────────────────────────
      PnlControls.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
      PnlControls.Dock      = System.Windows.Forms.DockStyle.Top;
      PnlControls.Height    = 65;
      PnlControls.Controls.Add(LblWaehrung);
      PnlControls.Controls.Add(CmbWaehrung);
      PnlControls.Controls.Add(LblBetrag);
      PnlControls.Controls.Add(TxtBetrag);
      PnlControls.Controls.Add(LblMuenzen);
      PnlControls.Controls.Add(TxtMuenzen);
      PnlControls.Controls.Add(LblSpeed);
      PnlControls.Controls.Add(TrkSpeed);
      PnlControls.Controls.Add(BtnStart);
      PnlControls.Controls.Add(LblStatus);

      // ── LblWaehrung ──────────────────────────────────────────────────────
      LblWaehrung.Text      = "Währung:";
      LblWaehrung.ForeColor = System.Drawing.Color.White;
      LblWaehrung.Location  = new System.Drawing.Point(12, 23);
      LblWaehrung.AutoSize  = true;

      // ── CmbWaehrung ──────────────────────────────────────────────────────
      CmbWaehrung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      CmbWaehrung.Location      = new System.Drawing.Point(78, 19);
      CmbWaehrung.Width         = 90;
      CmbWaehrung.Items.AddRange(new object[] { "CHF", "EUR", "Benutzerdefiniert" });
      CmbWaehrung.SelectedIndex  = 0;
      CmbWaehrung.SelectedIndexChanged += new System.EventHandler(this.CmbWaehrung_SelectedIndexChanged);

      // ── LblBetrag ────────────────────────────────────────────────────────
      LblBetrag.Text      = "Betrag:";
      LblBetrag.ForeColor = System.Drawing.Color.White;
      LblBetrag.Location  = new System.Drawing.Point(182, 23);
      LblBetrag.AutoSize  = true;

      // ── TxtBetrag ────────────────────────────────────────────────────────
      TxtBetrag.Text     = "87";
      TxtBetrag.Location = new System.Drawing.Point(320, 19);
      TxtBetrag.Width    = 60;

      // ── LblMuenzen ───────────────────────────────────────────────────────
      LblMuenzen.Text      = "Münzen:";
      LblMuenzen.ForeColor = System.Drawing.Color.White;
      LblMuenzen.Location  = new System.Drawing.Point(395, 23);
      LblMuenzen.AutoSize  = true;

      // ── TxtMuenzen ───────────────────────────────────────────────────────
      TxtMuenzen.Text     = "5, 10, 20, 50, 100, 200, 500";
      TxtMuenzen.Location = new System.Drawing.Point(455, 19);
      TxtMuenzen.Width    = 200;

      // ── LblSpeed ─────────────────────────────────────────────────────────
      LblSpeed.Text      = "Geschwindigkeit:";
      LblSpeed.ForeColor = System.Drawing.Color.White;
      LblSpeed.Location  = new System.Drawing.Point(668, 23);
      LblSpeed.AutoSize  = true;

      // ── TrkSpeed ─────────────────────────────────────────────────────────
      TrkSpeed.Location      = new System.Drawing.Point(790, 10);
      TrkSpeed.Width         = 110;
      TrkSpeed.Minimum       = 1;
      TrkSpeed.Maximum       = 100;
      TrkSpeed.Value         = 60;
      TrkSpeed.TickFrequency = 10;

      // ── BtnStart ─────────────────────────────────────────────────────────
      BtnStart.Text      = "Start";
      BtnStart.Location  = new System.Drawing.Point(915, 14);
      BtnStart.Size      = new System.Drawing.Size(80, 36);
      BtnStart.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
      BtnStart.ForeColor = System.Drawing.Color.White;
      BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnStart.Click    += new System.EventHandler(this.BtnStart_Click);

      // ── LblStatus ────────────────────────────────────────────────────────
      LblStatus.Text      = "Bereit";
      LblStatus.ForeColor = System.Drawing.Color.LightGray;
      LblStatus.Location  = new System.Drawing.Point(1010, 23);
      LblStatus.AutoSize  = true;

      // ── PnlBoard ─────────────────────────────────────────────────────────
      PnlBoard.Dock      = System.Windows.Forms.DockStyle.Fill;
      PnlBoard.BackColor = System.Drawing.Color.FromArgb(28, 28, 32);
      PnlBoard.Paint    += new System.Windows.Forms.PaintEventHandler(this.PnlBoard_Paint);

      // ── Form ─────────────────────────────────────────────────────────────
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize    = new System.Drawing.Size(1100, 500);
      Text          = "Münzwechsel – Greedy Demo";
      BackColor     = System.Drawing.Color.FromArgb(28, 28, 32);
      Controls.Add(PnlBoard);    // Fill – processed last by layout
      Controls.Add(PnlControls); // Top  – processed first by layout

      ResumeLayout(false);
    }

    #endregion
  }
}
