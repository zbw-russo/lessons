namespace ZbW.ProgrammingFoundation.Lessons.Module17
{
  partial class MinHeapForm
  {
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null)
      {
        components.Dispose();
      }

      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      var pnlToolbar  = new System.Windows.Forms.Panel();
      var pnlBottom   = new System.Windows.Forms.Panel();
      var pnlStatus   = new System.Windows.Forms.Panel();
      var lblInput    = new System.Windows.Forms.Label();
      var lblMinLabel = new System.Windows.Forms.Label();

      txtInput     = new System.Windows.Forms.TextBox();
      btnAdd       = new System.Windows.Forms.Button();
      btnPeek      = new System.Windows.Forms.Button();
      btnPop       = new System.Windows.Forms.Button();
      btnClear     = new System.Windows.Forms.Button();
      lblStatus    = new System.Windows.Forms.Label();
      lblHeapArray = new System.Windows.Forms.Label();
      lblMin       = new System.Windows.Forms.Label();
      lstHeap      = new System.Windows.Forms.ListBox();

      SuspendLayout();

      // ── Toolbar (oben) ───────────────────────────────────────────────────
      pnlToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
      pnlToolbar.Height    = 48;
      pnlToolbar.BackColor = System.Drawing.SystemColors.ControlLight;

      lblInput.Text     = "Wert:";
      lblInput.AutoSize = true;
      lblInput.Location = new System.Drawing.Point(10, 15);

      txtInput.Location  = new System.Drawing.Point(52, 12);
      txtInput.Width     = 60;
      txtInput.KeyDown  += new System.Windows.Forms.KeyEventHandler(txtInput_KeyDown);

      btnAdd.Text     = "Add";
      btnAdd.Location = new System.Drawing.Point(120, 10);
      btnAdd.Width    = 65;
      btnAdd.BackColor = System.Drawing.Color.FromArgb(0x5C, 0xB8, 0x5C);
      btnAdd.ForeColor = System.Drawing.Color.White;
      btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnAdd.Click    += new System.EventHandler(btnAdd_Click);

      btnPeek.Text     = "Peek";
      btnPeek.Location = new System.Drawing.Point(193, 10);
      btnPeek.Width    = 65;
      btnPeek.BackColor = System.Drawing.Color.FromArgb(0x20, 0x6F, 0xC4);
      btnPeek.ForeColor = System.Drawing.Color.White;
      btnPeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnPeek.Click    += new System.EventHandler(btnPeek_Click);

      btnPop.Text     = "Pop";
      btnPop.Location = new System.Drawing.Point(266, 10);
      btnPop.Width    = 65;
      btnPop.BackColor = System.Drawing.Color.FromArgb(0xF0, 0xAD, 0x4E);
      btnPop.ForeColor = System.Drawing.Color.White;
      btnPop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnPop.Click    += new System.EventHandler(btnPop_Click);

      btnClear.Text     = "Leeren";
      btnClear.Location = new System.Drawing.Point(339, 10);
      btnClear.Width    = 70;
      btnClear.Click   += new System.EventHandler(btnClear_Click);

      lblMinLabel.Text      = "Min:";
      lblMinLabel.AutoSize  = true;
      lblMinLabel.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
      lblMinLabel.Location  = new System.Drawing.Point(430, 13);

      lblMin.Text      = "–";
      lblMin.AutoSize  = false;
      lblMin.Width     = 60;
      lblMin.Height    = 24;
      lblMin.Location  = new System.Drawing.Point(465, 12);
      lblMin.Font      = new System.Drawing.Font("Segoe UI", 13f, System.Drawing.FontStyle.Bold);
      lblMin.ForeColor = System.Drawing.Color.Crimson;

      pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[]
        { lblInput, txtInput, btnAdd, btnPeek, btnPop, btnClear, lblMinLabel, lblMin });

      // ── Status (unten) ───────────────────────────────────────────────────
      pnlStatus.Dock      = System.Windows.Forms.DockStyle.Bottom;
      pnlStatus.Height    = 28;
      pnlStatus.BackColor = System.Drawing.Color.FromArgb(230, 240, 255);

      lblStatus.Dock      = System.Windows.Forms.DockStyle.Fill;
      lblStatus.Font      = new System.Drawing.Font("Segoe UI", 9f);
      lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      lblStatus.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);

      pnlStatus.Controls.Add(lblStatus);

      // ── Array-Anzeige (unterhalb des Hauptbereichs) ──────────────────────
      pnlBottom.Dock      = System.Windows.Forms.DockStyle.Bottom;
      pnlBottom.Height    = 30;
      pnlBottom.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

      lblHeapArray.Dock      = System.Windows.Forms.DockStyle.Fill;
      lblHeapArray.Font      = new System.Drawing.Font("Consolas", 10f, System.Drawing.FontStyle.Bold);
      lblHeapArray.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      lblHeapArray.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);
      lblHeapArray.Text      = "Array: []";

      pnlBottom.Controls.Add(lblHeapArray);

      // ── ListBox (Mitte) ──────────────────────────────────────────────────
      lstHeap.Dock      = System.Windows.Forms.DockStyle.Fill;
      lstHeap.Font      = new System.Drawing.Font("Consolas", 10f);
      lstHeap.BorderStyle = System.Windows.Forms.BorderStyle.None;

      // ── Form ─────────────────────────────────────────────────────────────
      ClientSize  = new System.Drawing.Size(700, 440);
      Text        = "Module 17 – MinHeap (eigene Implementierung)";
      MinimumSize = new System.Drawing.Size(550, 350);

      Controls.Add(lstHeap);
      Controls.Add(pnlBottom);
      Controls.Add(pnlStatus);
      Controls.Add(pnlToolbar);

      ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox  txtInput;
    private System.Windows.Forms.Button   btnAdd;
    private System.Windows.Forms.Button   btnPeek;
    private System.Windows.Forms.Button   btnPop;
    private System.Windows.Forms.Button   btnClear;
    private System.Windows.Forms.Label    lblStatus;
    private System.Windows.Forms.Label    lblHeapArray;
    private System.Windows.Forms.Label    lblMin;
    private System.Windows.Forms.ListBox  lstHeap;
  }
}
