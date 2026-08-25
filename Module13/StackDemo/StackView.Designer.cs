namespace ZbW.ProgrammingFoundation.Lessons.Module13.StackDemo
{
  using System.ComponentModel;

  partial class StackView
  {
    private IContainer components = null;

    private System.Windows.Forms.Panel  PnlControls;
    private System.Windows.Forms.Panel  PnlBoard;
    private System.Windows.Forms.Label  LblValue;
    private System.Windows.Forms.TextBox TxtValue;
    private System.Windows.Forms.Button BtnPush;
    private System.Windows.Forms.Button BtnPop;
    private System.Windows.Forms.Button BtnPeek;
    private System.Windows.Forms.Button BtnClear;
    private System.Windows.Forms.Button BtnToggleMode;
    private System.Windows.Forms.Label  LblMode;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
        components.Dispose();
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
      components    = new System.ComponentModel.Container();
      PnlControls   = new System.Windows.Forms.Panel();
      PnlBoard      = new System.Windows.Forms.Panel();
      LblValue      = new System.Windows.Forms.Label();
      TxtValue      = new System.Windows.Forms.TextBox();
      BtnPush       = new System.Windows.Forms.Button();
      BtnPop        = new System.Windows.Forms.Button();
      BtnPeek       = new System.Windows.Forms.Button();
      BtnClear      = new System.Windows.Forms.Button();
      BtnToggleMode = new System.Windows.Forms.Button();
      LblMode       = new System.Windows.Forms.Label();

      SuspendLayout();

      // ── PnlControls ──────────────────────────────────────────────────────
      PnlControls.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
      PnlControls.Dock      = System.Windows.Forms.DockStyle.Top;
      PnlControls.Height    = 60;
      PnlControls.Controls.AddRange(new System.Windows.Forms.Control[]
        { LblValue, TxtValue, BtnPush, BtnPop, BtnPeek, BtnClear, BtnToggleMode, LblMode });

      // ── LblValue ─────────────────────────────────────────────────────────
      LblValue.Text      = "Wert:";
      LblValue.ForeColor = System.Drawing.Color.White;
      LblValue.Location  = new System.Drawing.Point(12, 22);
      LblValue.AutoSize  = true;

      // ── TxtValue ─────────────────────────────────────────────────────────
      TxtValue.Location  = new System.Drawing.Point(55, 18);
      TxtValue.Width     = 120;

      // ── BtnPush ──────────────────────────────────────────────────────────
      BtnPush.Text      = "Push";
      BtnPush.Location  = new System.Drawing.Point(190, 12);
      BtnPush.Size      = new System.Drawing.Size(72, 36);
      BtnPush.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
      BtnPush.ForeColor = System.Drawing.Color.White;
      BtnPush.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnPush.Click    += new System.EventHandler(this.BtnPush_Click);

      // ── BtnPop ───────────────────────────────────────────────────────────
      BtnPop.Text      = "Pop";
      BtnPop.Location  = new System.Drawing.Point(270, 12);
      BtnPop.Size      = new System.Drawing.Size(72, 36);
      BtnPop.BackColor = System.Drawing.Color.FromArgb(180, 60, 60);
      BtnPop.ForeColor = System.Drawing.Color.White;
      BtnPop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnPop.Click    += new System.EventHandler(this.BtnPop_Click);

      // ── BtnPeek ──────────────────────────────────────────────────────────
      BtnPeek.Text      = "Peek";
      BtnPeek.Location  = new System.Drawing.Point(350, 12);
      BtnPeek.Size      = new System.Drawing.Size(72, 36);
      BtnPeek.BackColor = System.Drawing.Color.FromArgb(60, 140, 60);
      BtnPeek.ForeColor = System.Drawing.Color.White;
      BtnPeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnPeek.Click    += new System.EventHandler(this.BtnPeek_Click);

      // ── BtnClear ─────────────────────────────────────────────────────────
      BtnClear.Text      = "Clear";
      BtnClear.Location  = new System.Drawing.Point(430, 12);
      BtnClear.Size      = new System.Drawing.Size(72, 36);
      BtnClear.BackColor = System.Drawing.Color.FromArgb(70, 70, 80);
      BtnClear.ForeColor = System.Drawing.Color.White;
      BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnClear.Click    += new System.EventHandler(this.BtnClear_Click);

      // ── BtnToggleMode ────────────────────────────────────────────────────
      BtnToggleMode.Text      = "⇄ Umschalten";
      BtnToggleMode.Location  = new System.Drawing.Point(516, 12);
      BtnToggleMode.Size      = new System.Drawing.Size(110, 36);
      BtnToggleMode.BackColor = System.Drawing.Color.FromArgb(130, 80, 170);
      BtnToggleMode.ForeColor = System.Drawing.Color.White;
      BtnToggleMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnToggleMode.Click    += new System.EventHandler(this.BtnToggleMode_Click);

      // ── LblMode ──────────────────────────────────────────────────────────
      LblMode.Text      = "Modus: StackArray";
      LblMode.ForeColor = System.Drawing.Color.FromArgb(180, 180, 100);
      LblMode.Location  = new System.Drawing.Point(638, 22);
      LblMode.AutoSize  = true;

      // ── PnlBoard ─────────────────────────────────────────────────────────
      PnlBoard.Dock      = System.Windows.Forms.DockStyle.Fill;
      PnlBoard.BackColor = System.Drawing.Color.FromArgb(28, 28, 32);
      PnlBoard.Paint    += new System.Windows.Forms.PaintEventHandler(this.PnlBoard_Paint);

      // ── Form ─────────────────────────────────────────────────────────────
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize    = new System.Drawing.Size(800, 520);
      Text          = "Stack (LIFO) – Array vs. LinkedList";
      BackColor     = System.Drawing.Color.FromArgb(28, 28, 32);
      Controls.Add(PnlBoard);
      Controls.Add(PnlControls);

      ResumeLayout(false);
    }

    #endregion
  }
}
