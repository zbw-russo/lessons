namespace ZbW.ProgrammingFoundation.Lessons.Module16
{
  partial class BinarySearchTreeForm
  {
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
      if (disposing && components != null) components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      // ── Controls deklarieren ─────────────────────────────────────────────
      var pnlToolbar   = new System.Windows.Forms.Panel();
      var pnlTraversal = new System.Windows.Forms.Panel();
      var pnlStatus    = new System.Windows.Forms.Panel();
      var lblInput     = new System.Windows.Forms.Label();
      var lblLegend    = new System.Windows.Forms.Label();

      txtInput      = new System.Windows.Forms.TextBox();
      btnAdd        = new System.Windows.Forms.Button();
      btnFind       = new System.Windows.Forms.Button();
      btnClear      = new System.Windows.Forms.Button();
      lblStatus     = new System.Windows.Forms.Label();
      treePanel     = new System.Windows.Forms.Panel();
      lblPreOrder   = new System.Windows.Forms.Label();
      lblInOrder    = new System.Windows.Forms.Label();
      lblPostOrder  = new System.Windows.Forms.Label();

      SuspendLayout();

      // ── Toolbar (oben) ───────────────────────────────────────────────────
      pnlToolbar.Dock       = System.Windows.Forms.DockStyle.Top;
      pnlToolbar.Height     = 48;
      pnlToolbar.BackColor  = System.Drawing.SystemColors.ControlLight;
      pnlToolbar.Padding    = new System.Windows.Forms.Padding(8, 8, 8, 4);

      lblInput.Text      = "Wert:";
      lblInput.AutoSize  = true;
      lblInput.Location  = new System.Drawing.Point(10, 15);

      txtInput.Location  = new System.Drawing.Point(52, 12);
      txtInput.Width     = 60;
      txtInput.KeyDown  += new System.Windows.Forms.KeyEventHandler(txtInput_KeyDown);

      btnAdd.Text    = "Einfügen";
      btnAdd.Location = new System.Drawing.Point(120, 10);
      btnAdd.Width    = 82;
      btnAdd.Click   += new System.EventHandler(btnAdd_Click);

      btnFind.Text    = "Suchen";
      btnFind.Location = new System.Drawing.Point(210, 10);
      btnFind.Width    = 75;
      btnFind.Click   += new System.EventHandler(btnFind_Click);

      btnClear.Text    = "Leeren";
      btnClear.Location = new System.Drawing.Point(293, 10);
      btnClear.Width    = 70;
      btnClear.Click   += new System.EventHandler(btnClear_Click);

      // Legende
      lblLegend.Text      = "● Root  ● Inner  ● Leaf  ● Pfad  ★ Highlight";
      lblLegend.AutoSize  = true;
      lblLegend.Font      = new System.Drawing.Font("Segoe UI", 8.5f);
      lblLegend.ForeColor = System.Drawing.Color.DimGray;
      lblLegend.Location  = new System.Drawing.Point(378, 15);

      pnlToolbar.Controls.AddRange(new System.Windows.Forms.Control[]
        { lblInput, txtInput, btnAdd, btnFind, btnClear, lblLegend });

      // ── Status-Leiste (unten) ────────────────────────────────────────────
      pnlStatus.Dock      = System.Windows.Forms.DockStyle.Bottom;
      pnlStatus.Height    = 28;
      pnlStatus.BackColor = System.Drawing.Color.FromArgb(230, 240, 255);

      lblStatus.Dock      = System.Windows.Forms.DockStyle.Fill;
      lblStatus.Font      = new System.Drawing.Font("Segoe UI", 9f);
      lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      lblStatus.Padding   = new System.Windows.Forms.Padding(8, 0, 0, 0);

      pnlStatus.Controls.Add(lblStatus);

      // ── Traversal-Panel (unterhalb des Baums) ────────────────────────────
      pnlTraversal.Dock      = System.Windows.Forms.DockStyle.Bottom;
      pnlTraversal.Height    = 84;
      pnlTraversal.BackColor = System.Drawing.SystemColors.Control;
      pnlTraversal.Padding   = new System.Windows.Forms.Padding(6, 4, 6, 4);

      lblPreOrder.Dock      = System.Windows.Forms.DockStyle.Top;
      lblPreOrder.Height    = 24;
      lblPreOrder.Font      = new System.Drawing.Font("Consolas", 9f);
      lblPreOrder.BackColor = System.Drawing.Color.FromArgb(255, 243, 205);
      lblPreOrder.Padding   = new System.Windows.Forms.Padding(6, 4, 0, 0);
      lblPreOrder.Text      = "Pre-Order  (Node→L→R):    …";

      lblInOrder.Dock       = System.Windows.Forms.DockStyle.Top;
      lblInOrder.Height     = 24;
      lblInOrder.Font       = new System.Drawing.Font("Consolas", 9f);
      lblInOrder.BackColor  = System.Drawing.Color.FromArgb(198, 239, 206);
      lblInOrder.Padding    = new System.Windows.Forms.Padding(6, 4, 0, 0);
      lblInOrder.Text       = "In-Order   (L→Node→R):    …  ← sortiert!";

      lblPostOrder.Dock      = System.Windows.Forms.DockStyle.Top;
      lblPostOrder.Height    = 24;
      lblPostOrder.Font      = new System.Drawing.Font("Consolas", 9f);
      lblPostOrder.BackColor = System.Drawing.Color.FromArgb(189, 215, 238);
      lblPostOrder.Padding   = new System.Windows.Forms.Padding(6, 4, 0, 0);
      lblPostOrder.Text      = "Post-Order (L→R→Node):    …";

      // Reihenfolge: Post unten, In mitte, Pre oben
      pnlTraversal.Controls.Add(lblPostOrder);
      pnlTraversal.Controls.Add(lblInOrder);
      pnlTraversal.Controls.Add(lblPreOrder);

      // ── Baum-Panel (Mitte) ───────────────────────────────────────────────
      treePanel.Dock        = System.Windows.Forms.DockStyle.Fill;
      treePanel.BackColor   = System.Drawing.Color.White;
      treePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      treePanel.Paint      += new System.Windows.Forms.PaintEventHandler(treePanel_Paint);

      // ── Form ─────────────────────────────────────────────────────────────
      ClientSize  = new System.Drawing.Size(900, 560);
      Text        = "Module 16 – Binary Search Tree (eigene Implementierung)";
      MinimumSize = new System.Drawing.Size(700, 450);

      Controls.Add(treePanel);
      Controls.Add(pnlTraversal);
      Controls.Add(pnlStatus);
      Controls.Add(pnlToolbar);

      ResumeLayout(false);
    }

    // ── Felder ───────────────────────────────────────────────────────────────
    private System.Windows.Forms.TextBox  txtInput;
    private System.Windows.Forms.Button   btnAdd;
    private System.Windows.Forms.Button   btnFind;
    private System.Windows.Forms.Button   btnClear;
    private System.Windows.Forms.Label    lblStatus;
    private System.Windows.Forms.Panel    treePanel;
    private System.Windows.Forms.Label    lblPreOrder;
    private System.Windows.Forms.Label    lblInOrder;
    private System.Windows.Forms.Label    lblPostOrder;
  }
}
