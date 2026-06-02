namespace ZbW.ProgrammingFoundation.Lessons.Module13.SinglyLinkedListDemo
{
  using System.ComponentModel;

  partial class SinglyLinkedListView
  {
    private IContainer components = null;

    private System.Windows.Forms.Panel PnlControls;
    private System.Windows.Forms.Panel PnlBoard;
    private System.Windows.Forms.Label LblValue;
    private System.Windows.Forms.TextBox TxtValue;
    private System.Windows.Forms.Label LblIndex;
    private System.Windows.Forms.TextBox TxtIndex;
    private System.Windows.Forms.Button BtnAdd;
    private System.Windows.Forms.Button BtnRemove;
    private System.Windows.Forms.Button BtnContains;
    private System.Windows.Forms.Button BtnFindByIndex;
    private System.Windows.Forms.Button BtnSet;
    private System.Windows.Forms.Button BtnClear;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
        components.Dispose();
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
      components      = new System.ComponentModel.Container();
      PnlControls     = new System.Windows.Forms.Panel();
      PnlBoard        = new System.Windows.Forms.Panel();
      LblValue        = new System.Windows.Forms.Label();
      TxtValue        = new System.Windows.Forms.TextBox();
      LblIndex        = new System.Windows.Forms.Label();
      TxtIndex        = new System.Windows.Forms.TextBox();
      BtnAdd          = new System.Windows.Forms.Button();
      BtnRemove       = new System.Windows.Forms.Button();
      BtnContains     = new System.Windows.Forms.Button();
      BtnFindByIndex  = new System.Windows.Forms.Button();
      BtnSet          = new System.Windows.Forms.Button();
      BtnClear        = new System.Windows.Forms.Button();

      SuspendLayout();

      // ── PnlControls ──────────────────────────────────────────────────────
      PnlControls.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
      PnlControls.Dock      = System.Windows.Forms.DockStyle.Top;
      PnlControls.Height    = 60;
      PnlControls.Controls.AddRange(new System.Windows.Forms.Control[]
        { LblValue, TxtValue, LblIndex, TxtIndex, BtnAdd, BtnRemove, BtnContains, BtnFindByIndex, BtnSet, BtnClear });

      // ── LblValue ─────────────────────────────────────────────────────────
      LblValue.Text      = "Wert:";
      LblValue.ForeColor = System.Drawing.Color.White;
      LblValue.Location  = new System.Drawing.Point(12, 22);
      LblValue.AutoSize  = true;

      // ── TxtValue ─────────────────────────────────────────────────────────
      TxtValue.Location  = new System.Drawing.Point(55, 18);
      TxtValue.Width     = 110;

      // ── LblIndex ─────────────────────────────────────────────────────────
      LblIndex.Text      = "Index:";
      LblIndex.ForeColor = System.Drawing.Color.White;
      LblIndex.Location  = new System.Drawing.Point(178, 22);
      LblIndex.AutoSize  = true;

      // ── TxtIndex ─────────────────────────────────────────────────────────
      TxtIndex.Location  = new System.Drawing.Point(225, 18);
      TxtIndex.Width     = 50;
      TxtIndex.Text      = "0";

      // ── BtnAdd ───────────────────────────────────────────────────────────
      BtnAdd.Text      = "Add";
      BtnAdd.Location  = new System.Drawing.Point(290, 12);
      BtnAdd.Size      = new System.Drawing.Size(72, 36);
      BtnAdd.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
      BtnAdd.ForeColor = System.Drawing.Color.White;
      BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnAdd.Click    += new System.EventHandler(this.BtnAdd_Click);

      // ── BtnRemove ────────────────────────────────────────────────────────
      BtnRemove.Text      = "Remove";
      BtnRemove.Location  = new System.Drawing.Point(370, 12);
      BtnRemove.Size      = new System.Drawing.Size(80, 36);
      BtnRemove.BackColor = System.Drawing.Color.FromArgb(180, 60, 60);
      BtnRemove.ForeColor = System.Drawing.Color.White;
      BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnRemove.Click    += new System.EventHandler(this.BtnRemove_Click);

      // ── BtnContains ──────────────────────────────────────────────────────
      BtnContains.Text      = "Contains";
      BtnContains.Location  = new System.Drawing.Point(458, 12);
      BtnContains.Size      = new System.Drawing.Size(88, 36);
      BtnContains.BackColor = System.Drawing.Color.FromArgb(60, 140, 60);
      BtnContains.ForeColor = System.Drawing.Color.White;
      BtnContains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnContains.Click    += new System.EventHandler(this.BtnContains_Click);

      // ── BtnFindByIndex ───────────────────────────────────────────────────
      BtnFindByIndex.Text      = "FindByIndex";
      BtnFindByIndex.Location  = new System.Drawing.Point(554, 12);
      BtnFindByIndex.Size      = new System.Drawing.Size(104, 36);
      BtnFindByIndex.BackColor = System.Drawing.Color.FromArgb(130, 80, 170);
      BtnFindByIndex.ForeColor = System.Drawing.Color.White;
      BtnFindByIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnFindByIndex.Click    += new System.EventHandler(this.BtnFindByIndex_Click);

      // ── BtnSet ───────────────────────────────────────────────────────────
      BtnSet.Text      = "Indexer set";
      BtnSet.Location  = new System.Drawing.Point(666, 12);
      BtnSet.Size      = new System.Drawing.Size(88, 36);
      BtnSet.BackColor = System.Drawing.Color.FromArgb(180, 120, 0);
      BtnSet.ForeColor = System.Drawing.Color.White;
      BtnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnSet.Click    += new System.EventHandler(this.BtnSet_Click);

      // ── BtnClear ─────────────────────────────────────────────────────────
      BtnClear.Text      = "Clear";
      BtnClear.Location  = new System.Drawing.Point(762, 12);
      BtnClear.Size      = new System.Drawing.Size(72, 36);
      BtnClear.BackColor = System.Drawing.Color.FromArgb(70, 70, 80);
      BtnClear.ForeColor = System.Drawing.Color.White;
      BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnClear.Click    += new System.EventHandler(this.BtnClear_Click);

      // ── PnlBoard ─────────────────────────────────────────────────────────
      PnlBoard.Dock      = System.Windows.Forms.DockStyle.Fill;
      PnlBoard.BackColor = System.Drawing.Color.FromArgb(28, 28, 32);
      PnlBoard.Paint    += new System.Windows.Forms.PaintEventHandler(this.PnlBoard_Paint);

      // ── Form ─────────────────────────────────────────────────────────────
      AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      ClientSize    = new System.Drawing.Size(950, 400);
      Text          = "SinglyLinkedList – Demo  |  A1: Add  A2: Contains  A3: Remove  A4: FindByIndex  A5: Indexer";
      BackColor     = System.Drawing.Color.FromArgb(28, 28, 32);
      Controls.Add(PnlBoard);
      Controls.Add(PnlControls);

      ResumeLayout(false);
    }

    #endregion
  }
}
