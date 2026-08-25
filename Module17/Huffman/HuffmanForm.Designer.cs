namespace ZbW.ProgrammingFoundation.Challenges.Module17.Huffman
{
  partial class HuffmanForm
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
      var lblText    = new System.Windows.Forms.Label();

      txtText   = new System.Windows.Forms.TextBox();
      btnEncode = new System.Windows.Forms.Button();
      btnClear  = new System.Windows.Forms.Button();
      lblStatus = new System.Windows.Forms.Label();
      lstOutput = new System.Windows.Forms.ListBox();

      SuspendLayout();

      // ── Toolbar ──────────────────────────────────────────────────────────
      pnlToolbar.Dock      = System.Windows.Forms.DockStyle.Top;
      pnlToolbar.Height    = 52;
      pnlToolbar.BackColor = System.Drawing.SystemColors.ControlLight;

      lblText.Text     = "Text:";
      lblText.AutoSize = true;
      lblText.Location = new System.Drawing.Point(10, 16);

      txtText.Location = new System.Drawing.Point(52, 13);
      txtText.Width    = 360;

      btnEncode.Text      = "Codieren";
      btnEncode.Location  = new System.Drawing.Point(424, 11);
      btnEncode.Width     = 110;
      btnEncode.BackColor = System.Drawing.Color.FromArgb(0x5C, 0xB8, 0x5C);
      btnEncode.ForeColor = System.Drawing.Color.White;
      btnEncode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      btnEncode.Click    += new System.EventHandler(btnEncode_Click);

      btnClear.Text     = "Leeren";
      btnClear.Location = new System.Drawing.Point(544, 11);
      btnClear.Width    = 70;
      btnClear.Click   += new System.EventHandler(btnClear_Click);

      pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[]
        { lblText, txtText, btnEncode, btnClear });

      // ── Status ────────────────────────────────────────────────────────────
      pnlStatus.Dock      = System.Windows.Forms.DockStyle.Bottom;
      pnlStatus.Height    = 28;
      pnlStatus.BackColor = System.Drawing.Color.FromArgb(230, 240, 255);
      lblStatus.Dock      = System.Windows.Forms.DockStyle.Fill;
      lblStatus.Font      = new System.Drawing.Font("Segoe UI", 9f);
      lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      lblStatus.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);
      pnlStatus.Controls.Add(lblStatus);

      // ── Ausgabe ───────────────────────────────────────────────────────────
      lstOutput.Dock        = System.Windows.Forms.DockStyle.Fill;
      lstOutput.Font        = new System.Drawing.Font("Consolas", 10f);
      lstOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

      // ── Form ──────────────────────────────────────────────────────────────
      ClientSize  = new System.Drawing.Size(660, 460);
      Text        = "Module 17 – Huffman-Codierung";
      MinimumSize = new System.Drawing.Size(500, 360);

      Controls.Add(lstOutput);
      Controls.Add(pnlStatus);
      Controls.Add(pnlToolbar);

      ResumeLayout(false);
    }

    private System.Windows.Forms.TextBox txtText;
    private System.Windows.Forms.Button  btnEncode;
    private System.Windows.Forms.Button  btnClear;
    private System.Windows.Forms.Label   lblStatus;
    private System.Windows.Forms.ListBox lstOutput;
  }
}
