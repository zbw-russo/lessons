namespace ZbW.ProgrammingFoundation.Challenges.Module17.Flughafen
{
  partial class FlughafenForm
  {
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null) components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      var pnlToolbar   = new System.Windows.Forms.Panel();
      var pnlStatus    = new System.Windows.Forms.Panel();
      var pnlLeft      = new System.Windows.Forms.Panel();
      var pnlRight     = new System.Windows.Forms.Panel();
      var lblAirport   = new System.Windows.Forms.Label();
      var lblFuel      = new System.Windows.Forms.Label();
      var lblQueueTitle  = new System.Windows.Forms.Label();
      var lblLandedTitle = new System.Windows.Forms.Label();

      txtAirport  = new System.Windows.Forms.TextBox();
      txtFuel     = new System.Windows.Forms.TextBox();
      btnAdd      = new System.Windows.Forms.Button();
      btnLand     = new System.Windows.Forms.Button();
      btnClear    = new System.Windows.Forms.Button();
      lblStatus   = new System.Windows.Forms.Label();
      lstQueue    = new System.Windows.Forms.ListBox();
      lstLanded   = new System.Windows.Forms.ListBox();

      SuspendLayout();

      // ── Toolbar ──────────────────────────────────────────────────────────
      pnlToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
      pnlToolbar.Height    = 52;
      pnlToolbar.BackColor = System.Drawing.SystemColors.ControlLight;

      lblAirport.Text     = "Flughafen:";
      lblAirport.AutoSize = true;
      lblAirport.Location = new System.Drawing.Point(10, 16);

      txtAirport.Location = new System.Drawing.Point(80, 13);
      txtAirport.Width    = 70;
      txtAirport.Text     = "ZRH";

      lblFuel.Text     = "Treibstoff (L):";
      lblFuel.AutoSize = true;
      lblFuel.Location = new System.Drawing.Point(162, 16);

      txtFuel.Location  = new System.Drawing.Point(262, 13);
      txtFuel.Width     = 70;
      txtFuel.Text      = "1200";
      txtFuel.KeyDown  += new System.Windows.Forms.KeyEventHandler(txtFuel_KeyDown);

      btnAdd.Text      = "Flugzeug hinzufügen";
      btnAdd.Location  = new System.Drawing.Point(342, 11);
      btnAdd.Width     = 150;
      btnAdd.BackColor = System.Drawing.Color.FromArgb(0x5C, 0xB8, 0x5C);
      btnAdd.ForeColor = System.Drawing.Color.White;
      btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnAdd.Click    += new System.EventHandler(btnAdd_Click);

      btnLand.Text      = "✈ Nächstes landen";
      btnLand.Location  = new System.Drawing.Point(502, 11);
      btnLand.Width     = 140;
      btnLand.BackColor = System.Drawing.Color.FromArgb(0x20, 0x6F, 0xC4);
      btnLand.ForeColor = System.Drawing.Color.White;
      btnLand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnLand.Click    += new System.EventHandler(btnLand_Click);

      btnClear.Text    = "Leeren";
      btnClear.Location = new System.Drawing.Point(652, 11);
      btnClear.Width   = 70;
      btnClear.Click  += new System.EventHandler(btnClear_Click);

      pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[]
        { lblAirport, txtAirport, lblFuel, txtFuel, btnAdd, btnLand, btnClear });

      // ── Status ────────────────────────────────────────────────────────────
      pnlStatus.Dock      = System.Windows.Forms.DockStyle.Bottom;
      pnlStatus.Height    = 28;
      pnlStatus.BackColor = System.Drawing.Color.FromArgb(230, 240, 255);
      lblStatus.Dock      = System.Windows.Forms.DockStyle.Fill;
      lblStatus.Font      = new System.Drawing.Font("Segoe UI", 9f);
      lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      lblStatus.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);
      pnlStatus.Controls.Add(lblStatus);

      // ── Linke Seite: Warteschlange ────────────────────────────────────────
      pnlLeft.Dock    = System.Windows.Forms.DockStyle.Left;
      pnlLeft.Width   = 400;
      pnlLeft.Padding = new System.Windows.Forms.Padding(6);

      lblQueueTitle.Text      = "Warteschlange  (Priorität: wenigster Treibstoff)";
      lblQueueTitle.Dock      = System.Windows.Forms.DockStyle.Top;
      lblQueueTitle.Height    = 26;
      lblQueueTitle.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
      lblQueueTitle.BackColor = System.Drawing.Color.FromArgb(0x20, 0x6F, 0xC4);
      lblQueueTitle.ForeColor = System.Drawing.Color.White;
      lblQueueTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

      lstQueue.Dock = System.Windows.Forms.DockStyle.Fill;
      lstQueue.Font = new System.Drawing.Font("Consolas", 10f);
      lstQueue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

      pnlLeft.Controls.Add(lstQueue);
      pnlLeft.Controls.Add(lblQueueTitle);

      // ── Rechte Seite: Gelandet ────────────────────────────────────────────
      pnlRight.Dock    = System.Windows.Forms.DockStyle.Fill;
      pnlRight.Padding = new System.Windows.Forms.Padding(6);

      lblLandedTitle.Text      = "Gelandet  (Reihenfolge nach Priorität)";
      lblLandedTitle.Dock      = System.Windows.Forms.DockStyle.Top;
      lblLandedTitle.Height    = 26;
      lblLandedTitle.Font      = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
      lblLandedTitle.BackColor = System.Drawing.Color.FromArgb(0x5C, 0xB8, 0x5C);
      lblLandedTitle.ForeColor = System.Drawing.Color.White;
      lblLandedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

      lstLanded.Dock = System.Windows.Forms.DockStyle.Fill;
      lstLanded.Font = new System.Drawing.Font("Consolas", 10f);
      lstLanded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

      pnlRight.Controls.Add(lstLanded);
      pnlRight.Controls.Add(lblLandedTitle);

      // ── Form ──────────────────────────────────────────────────────────────
      var splitter = new System.Windows.Forms.Splitter { Dock = System.Windows.Forms.DockStyle.Left, Width = 6 };

      ClientSize  = new System.Drawing.Size(850, 480);
      Text        = "Module 17 – Flughafen Priority Queue";
      MinimumSize = new System.Drawing.Size(650, 380);

      Controls.Add(pnlRight);
      Controls.Add(splitter);
      Controls.Add(pnlLeft);
      Controls.Add(pnlStatus);
      Controls.Add(pnlToolbar);

      ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox  txtAirport;
    private System.Windows.Forms.TextBox  txtFuel;
    private System.Windows.Forms.Button   btnAdd;
    private System.Windows.Forms.Button   btnLand;
    private System.Windows.Forms.Button   btnClear;
    private System.Windows.Forms.Label    lblStatus;
    private System.Windows.Forms.ListBox  lstQueue;
    private System.Windows.Forms.ListBox  lstLanded;
  }
}
