namespace ZbW.ProgrammingFoundation.Challenges.Module17.MinMaxHeap.Loesung
{
  partial class MinMaxHeapLoesungForm
  {
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null) components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      var pnlToolbar = new System.Windows.Forms.Panel();
      var pnlStatus  = new System.Windows.Forms.Panel();
      var pnlContent = new System.Windows.Forms.Panel();
      var pnlMin     = new System.Windows.Forms.Panel();
      var pnlMax     = new System.Windows.Forms.Panel();
      var lblMinTitle = new System.Windows.Forms.Label();
      var lblMaxTitle = new System.Windows.Forms.Label();
      var lblInput   = new System.Windows.Forms.Label();
      var lblMinTopLabel = new System.Windows.Forms.Label();
      var lblMaxTopLabel = new System.Windows.Forms.Label();

      txtInput    = new System.Windows.Forms.TextBox();
      btnAdd      = new System.Windows.Forms.Button();
      btnPopMin   = new System.Windows.Forms.Button();
      btnPopMax   = new System.Windows.Forms.Button();
      btnClear    = new System.Windows.Forms.Button();
      lblStatus   = new System.Windows.Forms.Label();
      lstMin      = new System.Windows.Forms.ListBox();
      lstMax      = new System.Windows.Forms.ListBox();
      lblMinArray = new System.Windows.Forms.Label();
      lblMaxArray = new System.Windows.Forms.Label();
      lblMinTop   = new System.Windows.Forms.Label();
      lblMaxTop   = new System.Windows.Forms.Label();

      SuspendLayout();

      // ── Toolbar ──────────────────────────────────────────────────────────
      pnlToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
      pnlToolbar.Height    = 48;
      pnlToolbar.BackColor = System.Drawing.SystemColors.ControlLight;

      lblInput.Text     = "Wert:";
      lblInput.AutoSize = true;
      lblInput.Location = new System.Drawing.Point(10, 15);

      txtInput.Location = new System.Drawing.Point(52, 12);
      txtInput.Width    = 60;
      txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(txtInput_KeyDown);

      btnAdd.Text      = "Add (beide)";
      btnAdd.Location  = new System.Drawing.Point(120, 10);
      btnAdd.Width     = 90;
      btnAdd.BackColor = System.Drawing.Color.FromArgb(0x5C, 0xB8, 0x5C);
      btnAdd.ForeColor = System.Drawing.Color.White;
      btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnAdd.Click    += new System.EventHandler(btnAdd_Click);

      btnPopMin.Text      = "Pop Min";
      btnPopMin.Location  = new System.Drawing.Point(218, 10);
      btnPopMin.Width     = 80;
      btnPopMin.BackColor = System.Drawing.Color.FromArgb(0x20, 0x6F, 0xC4);
      btnPopMin.ForeColor = System.Drawing.Color.White;
      btnPopMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnPopMin.Click    += new System.EventHandler(btnPopMin_Click);

      btnPopMax.Text      = "Pop Max";
      btnPopMax.Location  = new System.Drawing.Point(306, 10);
      btnPopMax.Width     = 80;
      btnPopMax.BackColor = System.Drawing.Color.FromArgb(0xF0, 0xAD, 0x4E);
      btnPopMax.ForeColor = System.Drawing.Color.White;
      btnPopMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnPopMax.Click    += new System.EventHandler(btnPopMax_Click);

      btnClear.Text    = "Leeren";
      btnClear.Location = new System.Drawing.Point(394, 10);
      btnClear.Width   = 70;
      btnClear.Click  += new System.EventHandler(btnClear_Click);

      pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[]
        { lblInput, txtInput, btnAdd, btnPopMin, btnPopMax, btnClear });

      // ── Status ────────────────────────────────────────────────────────────
      pnlStatus.Dock      = System.Windows.Forms.DockStyle.Bottom;
      pnlStatus.Height    = 28;
      pnlStatus.BackColor = System.Drawing.Color.FromArgb(230, 240, 255);
      lblStatus.Dock      = System.Windows.Forms.DockStyle.Fill;
      lblStatus.Font      = new System.Drawing.Font("Segoe UI", 9f);
      lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      lblStatus.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);
      pnlStatus.Controls.Add(lblStatus);

      // ── Min-Panel (links) ─────────────────────────────────────────────────
      pnlMin.Dock      = System.Windows.Forms.DockStyle.Left;
      pnlMin.Width     = 0; // wird per SplitContainer gesetzt → Fill
      pnlMin.Padding   = new System.Windows.Forms.Padding(6);

      lblMinTitle.Text      = "MinHeap  (kleinstes Element oben)";
      lblMinTitle.Dock      = System.Windows.Forms.DockStyle.Top;
      lblMinTitle.Height    = 26;
      lblMinTitle.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
      lblMinTitle.BackColor = System.Drawing.Color.FromArgb(0x20, 0x6F, 0xC4);
      lblMinTitle.ForeColor = System.Drawing.Color.White;
      lblMinTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

      lblMinTopLabel.Text      = "Top (Minimum):";
      lblMinTopLabel.Dock      = System.Windows.Forms.DockStyle.Top;
      lblMinTopLabel.Height    = 22;
      lblMinTopLabel.Font      = new System.Drawing.Font("Segoe UI", 9f);
      lblMinTopLabel.Padding   = new System.Windows.Forms.Padding(4, 0, 0, 0);

      lblMinTop.Text      = "–";
      lblMinTop.Dock      = System.Windows.Forms.DockStyle.Top;
      lblMinTop.Height    = 28;
      lblMinTop.Font      = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
      lblMinTop.ForeColor = System.Drawing.Color.FromArgb(0x20, 0x6F, 0xC4);
      lblMinTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

      lblMinArray.Text    = "MinHeap Array: []";
      lblMinArray.Dock    = System.Windows.Forms.DockStyle.Bottom;
      lblMinArray.Height  = 24;
      lblMinArray.Font    = new System.Drawing.Font("Consolas", 9f);
      lblMinArray.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);

      lstMin.Dock = System.Windows.Forms.DockStyle.Fill;
      lstMin.Font = new System.Drawing.Font("Consolas", 10f);
      lstMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

      pnlMin.Controls.Add(lstMin);
      pnlMin.Controls.Add(lblMinTop);
      pnlMin.Controls.Add(lblMinTopLabel);
      pnlMin.Controls.Add(lblMinTitle);
      pnlMin.Controls.Add(lblMinArray);

      // ── Max-Panel (rechts) ────────────────────────────────────────────────
      pnlMax.Dock    = System.Windows.Forms.DockStyle.Fill;
      pnlMax.Padding = new System.Windows.Forms.Padding(6);

      lblMaxTitle.Text      = "MaxHeap  (grösstes Element oben)";
      lblMaxTitle.Dock      = System.Windows.Forms.DockStyle.Top;
      lblMaxTitle.Height    = 26;
      lblMaxTitle.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
      lblMaxTitle.BackColor = System.Drawing.Color.FromArgb(0xF0, 0xAD, 0x4E);
      lblMaxTitle.ForeColor = System.Drawing.Color.White;
      lblMaxTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

      lblMaxTopLabel.Text      = "Top (Maximum):";
      lblMaxTopLabel.Dock      = System.Windows.Forms.DockStyle.Top;
      lblMaxTopLabel.Height    = 22;
      lblMaxTopLabel.Font      = new System.Drawing.Font("Segoe UI", 9f);
      lblMaxTopLabel.Padding   = new System.Windows.Forms.Padding(4, 0, 0, 0);

      lblMaxTop.Text      = "–";
      lblMaxTop.Dock      = System.Windows.Forms.DockStyle.Top;
      lblMaxTop.Height    = 28;
      lblMaxTop.Font      = new System.Drawing.Font("Segoe UI", 14f, System.Drawing.FontStyle.Bold);
      lblMaxTop.ForeColor = System.Drawing.Color.FromArgb(0xD0, 0x7A, 0x00);
      lblMaxTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

      lblMaxArray.Text    = "MaxHeap Array: []";
      lblMaxArray.Dock    = System.Windows.Forms.DockStyle.Bottom;
      lblMaxArray.Height  = 24;
      lblMaxArray.Font    = new System.Drawing.Font("Consolas", 9f);
      lblMaxArray.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);

      lstMax.Dock = System.Windows.Forms.DockStyle.Fill;
      lstMax.Font = new System.Drawing.Font("Consolas", 10f);
      lstMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

      pnlMax.Controls.Add(lstMax);
      pnlMax.Controls.Add(lblMaxTop);
      pnlMax.Controls.Add(lblMaxTopLabel);
      pnlMax.Controls.Add(lblMaxTitle);
      pnlMax.Controls.Add(lblMaxArray);

      // ── Content (Split) ───────────────────────────────────────────────────
      var splitter = new System.Windows.Forms.Splitter();
      splitter.Dock  = System.Windows.Forms.DockStyle.Left;
      splitter.Width = 6;

      pnlMin.Width = 420;
      pnlMin.Dock  = System.Windows.Forms.DockStyle.Left;

      // ── Form ──────────────────────────────────────────────────────────────
      ClientSize  = new System.Drawing.Size(900, 520);
      Text        = "Module 17 – MinHeap & MaxHeap (Lösung)";
      MinimumSize = new System.Drawing.Size(700, 400);

      Controls.Add(pnlMax);
      Controls.Add(splitter);
      Controls.Add(pnlMin);
      Controls.Add(pnlStatus);
      Controls.Add(pnlToolbar);

      ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox  txtInput;
    private System.Windows.Forms.Button   btnAdd;
    private System.Windows.Forms.Button   btnPopMin;
    private System.Windows.Forms.Button   btnPopMax;
    private System.Windows.Forms.Button   btnClear;
    private System.Windows.Forms.Label    lblStatus;
    private System.Windows.Forms.ListBox  lstMin;
    private System.Windows.Forms.ListBox  lstMax;
    private System.Windows.Forms.Label    lblMinArray;
    private System.Windows.Forms.Label    lblMaxArray;
    private System.Windows.Forms.Label    lblMinTop;
    private System.Windows.Forms.Label    lblMaxTop;
  }
}
