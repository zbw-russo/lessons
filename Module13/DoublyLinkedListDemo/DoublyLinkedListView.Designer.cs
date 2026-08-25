namespace ZbW.ProgrammingFoundation.Lessons.Module13.DoublyLinkedListDemo
{
  using System.ComponentModel;

  partial class DoublyLinkedListView
  {
    private IContainer components = null;

    private System.Windows.Forms.Panel   PnlControls;
    private System.Windows.Forms.Panel   PnlBoard;
    private System.Windows.Forms.Label   LblValue;
    private System.Windows.Forms.TextBox TxtValue;
    private System.Windows.Forms.Label   LblPrev;
    private System.Windows.Forms.TextBox TxtPrev;
    private System.Windows.Forms.Button  BtnAdd;
    private System.Windows.Forms.Button  BtnInsertAfter;
    private System.Windows.Forms.Button  BtnContains;
    private System.Windows.Forms.Button  BtnRemove;
    private System.Windows.Forms.Button  BtnFindByIndex;
    private System.Windows.Forms.Button  BtnIndexerSet;
    private System.Windows.Forms.Button  BtnClear;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
        components.Dispose();
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
      components     = new System.ComponentModel.Container();
      PnlControls    = new System.Windows.Forms.Panel();
      PnlBoard       = new System.Windows.Forms.Panel();
      LblValue       = new System.Windows.Forms.Label();
      TxtValue       = new System.Windows.Forms.TextBox();
      LblPrev        = new System.Windows.Forms.Label();
      TxtPrev        = new System.Windows.Forms.TextBox();
      BtnAdd         = new System.Windows.Forms.Button();
      BtnInsertAfter = new System.Windows.Forms.Button();
      BtnContains    = new System.Windows.Forms.Button();
      BtnRemove      = new System.Windows.Forms.Button();
      BtnFindByIndex = new System.Windows.Forms.Button();
      BtnIndexerSet  = new System.Windows.Forms.Button();
      BtnClear       = new System.Windows.Forms.Button();

      SuspendLayout();

      // ── PnlControls ──────────────────────────────────────────────────────
      PnlControls.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
      PnlControls.Dock      = System.Windows.Forms.DockStyle.Top;
      PnlControls.Height    = 60;
      PnlControls.Controls.AddRange(new System.Windows.Forms.Control[]
        { LblValue, TxtValue, LblPrev, TxtPrev,
          BtnAdd, BtnInsertAfter, BtnContains, BtnRemove,
          BtnFindByIndex, BtnIndexerSet, BtnClear });

      // ── LblValue ─────────────────────────────────────────────────────────
      LblValue.Text      = "Wert:";
      LblValue.ForeColor = System.Drawing.Color.White;
      LblValue.Location  = new System.Drawing.Point(12, 22);
      LblValue.AutoSize  = true;

      // ── TxtValue ─────────────────────────────────────────────────────────
      TxtValue.Location = new System.Drawing.Point(52, 18);
      TxtValue.Width    = 100;

      // ── LblPrev ──────────────────────────────────────────────────────────
      LblPrev.Text      = "nach / idx:";
      LblPrev.ForeColor = System.Drawing.Color.FromArgb(200, 180, 100);
      LblPrev.Location  = new System.Drawing.Point(163, 22);
      LblPrev.AutoSize  = true;

      // ── TxtPrev ──────────────────────────────────────────────────────────
      TxtPrev.Location = new System.Drawing.Point(245, 18);
      TxtPrev.Width    = 80;

      // ── BtnAdd ───────────────────────────────────────────────────────────
      BtnAdd.Text      = "Add";
      BtnAdd.Location  = new System.Drawing.Point(338, 12);
      BtnAdd.Size      = new System.Drawing.Size(68, 36);
      BtnAdd.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
      BtnAdd.ForeColor = System.Drawing.Color.White;
      BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnAdd.Click    += new System.EventHandler(this.BtnAdd_Click);

      // ── BtnInsertAfter ───────────────────────────────────────────────────
      BtnInsertAfter.Text      = "InsertAfter";
      BtnInsertAfter.Location  = new System.Drawing.Point(414, 12);
      BtnInsertAfter.Size      = new System.Drawing.Size(100, 36);
      BtnInsertAfter.BackColor = System.Drawing.Color.FromArgb(0, 140, 140);
      BtnInsertAfter.ForeColor = System.Drawing.Color.White;
      BtnInsertAfter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnInsertAfter.Click    += new System.EventHandler(this.BtnInsertAfter_Click);

      // ── BtnContains ──────────────────────────────────────────────────────
      BtnContains.Text      = "Contains";
      BtnContains.Location  = new System.Drawing.Point(522, 12);
      BtnContains.Size      = new System.Drawing.Size(88, 36);
      BtnContains.BackColor = System.Drawing.Color.FromArgb(60, 140, 60);
      BtnContains.ForeColor = System.Drawing.Color.White;
      BtnContains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnContains.Click    += new System.EventHandler(this.BtnContains_Click);

      // ── BtnRemove ────────────────────────────────────────────────────────
      BtnRemove.Text      = "Remove";
      BtnRemove.Location  = new System.Drawing.Point(618, 12);
      BtnRemove.Size      = new System.Drawing.Size(80, 36);
      BtnRemove.BackColor = System.Drawing.Color.FromArgb(180, 60, 60);
      BtnRemove.ForeColor = System.Drawing.Color.White;
      BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnRemove.Click    += new System.EventHandler(this.BtnRemove_Click);

      // ── BtnFindByIndex ───────────────────────────────────────────────────
      BtnFindByIndex.Text      = "FindByIndex";
      BtnFindByIndex.Location  = new System.Drawing.Point(706, 12);
      BtnFindByIndex.Size      = new System.Drawing.Size(104, 36);
      BtnFindByIndex.BackColor = System.Drawing.Color.FromArgb(130, 80, 170);
      BtnFindByIndex.ForeColor = System.Drawing.Color.White;
      BtnFindByIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnFindByIndex.Click    += new System.EventHandler(this.BtnFindByIndex_Click);

      // ── BtnIndexerSet ────────────────────────────────────────────────────
      BtnIndexerSet.Text      = "Indexer set";
      BtnIndexerSet.Location  = new System.Drawing.Point(818, 12);
      BtnIndexerSet.Size      = new System.Drawing.Size(96, 36);
      BtnIndexerSet.BackColor = System.Drawing.Color.FromArgb(180, 120, 0);
      BtnIndexerSet.ForeColor = System.Drawing.Color.White;
      BtnIndexerSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      BtnIndexerSet.Click    += new System.EventHandler(this.BtnIndexerSet_Click);

      // ── BtnClear ─────────────────────────────────────────────────────────
      BtnClear.Text      = "Clear";
      BtnClear.Location  = new System.Drawing.Point(922, 12);
      BtnClear.Size      = new System.Drawing.Size(68, 36);
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
      ClientSize    = new System.Drawing.Size(1020, 420);
      Text          = "DoublyLinkedList – Demo  |  → Link (nächster)   ← PrevLink (vorheriger)";
      BackColor     = System.Drawing.Color.FromArgb(28, 28, 32);
      Controls.Add(PnlBoard);
      Controls.Add(PnlControls);

      ResumeLayout(false);
    }

    #endregion
  }
}
