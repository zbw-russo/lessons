namespace ZbW.ProgrammingFoundation.Lessons.Module16
{
  /// <summary>
  ///   Test-UI für die selbst implementierte BinarySearchTree-Klasse.
  ///   Alles läuft über den Studierenden-Code.
  ///   Solange ein TODO noch offen ist, zeigt die Form einen Hinweis statt dem Baum.
  /// </summary>
  public sealed partial class BinarySearchTreeForm : Form
  {
    private const int LevelHeight = 65;
    private const int NodeRadius  = 20;

    private BinarySearchTree _tree = new BinarySearchTree();
    private int?         _highlightedValue = null;
    private HashSet<int> _pathValues       = new HashSet<int>();
    private Dictionary<int, Point> _nodePositions = new Dictionary<int, Point>();

    public BinarySearchTreeForm()
    {
      InitializeComponent();
      TryLoadSample();
    }

    // ── Beispielbaum ─────────────────────────────────────────────────────────

    private void TryLoadSample()
    {
      try
      {
        foreach (int v in new[] { 5, 3, 2, 4, 8, 7, 9 })
          _tree.Insert(v);
        RefreshTraversalLabels();
        treePanel.Invalidate();
        lblStatus.Text = "Beispielbaum geladen: 5, 3, 2, 4, 8, 7, 9";
      }
      catch (NotImplementedException)
      {
        treePanel.Invalidate();
        lblStatus.Text = "⚠  Insert noch nicht implementiert → TODO 1 lösen";
      }
    }

    // ── Buttons ───────────────────────────────────────────────────────────────

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (!TryGetInput(out int val)) return;
      try
      {
        _tree.Insert(val);
        _highlightedValue = val;
        _pathValues = PathToNode(val);
        RefreshTraversalLabels();
        treePanel.Invalidate();
        lblStatus.Text = $"✓ {val} eingefügt   Pfad: {string.Join(" → ", _pathValues)}";
        txtInput.Clear();
      }
      catch (NotImplementedException)
      {
        lblStatus.Text = "⚠  Insert nicht implementiert → TODO 1 lösen";
        treePanel.Invalidate();
      }
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
      if (!TryGetInput(out int val)) return;
      try
      {
        var node = _tree.Find(val);
        _highlightedValue = node != null ? val : (int?)null;
        _pathValues = PathToNode(val);
        treePanel.Invalidate();
        string pathStr = string.Join(" → ", _pathValues);
        lblStatus.Text = node != null
          ? $"✓ {val} gefunden   Pfad: {pathStr}"
          : $"✗ {val} nicht im Baum   Pfad: {pathStr}";
      }
      catch (NotImplementedException)
      {
        lblStatus.Text = "⚠  Find nicht implementiert → TODO 2 lösen";
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      _tree             = new BinarySearchTree();
      _highlightedValue = null;
      _pathValues       = new HashSet<int>();
      RefreshTraversalLabels();
      treePanel.Invalidate();
      lblStatus.Text = "Baum geleert";
    }

    // ── Traversal-Labels ──────────────────────────────────────────────────────

    private void RefreshTraversalLabels()
    {
      lblPreOrder.Text  = FormatTraversal("Pre-Order  (Node→L→R)", TraverseMode.PreOrder);
      lblInOrder.Text   = FormatTraversal("In-Order   (L→Node→R)", TraverseMode.InOrder);
      lblPostOrder.Text = FormatTraversal("Post-Order (L→R→Node)", TraverseMode.PostOrder);
    }

    private string FormatTraversal(string label, TraverseMode mode)
    {
      try
      {
        var values = _tree.Traverse(mode);
        string seq = values.Count == 0 ? "(leer)" : string.Join("  →  ", values);
        return $"{label}:    {seq}";
      }
      catch (NotImplementedException)
      {
        return $"{label}:    ⚠ TODO 3 lösen";
      }
    }

    // ── Pfad via Root traversieren ────────────────────────────────────────────

    private HashSet<int> PathToNode(int value)
    {
      var path = new HashSet<int>();
      var cur  = _tree.Root;
      while (cur != null)
      {
        path.Add(cur.Item);
        int cmp = value.CompareTo(cur.Item);
        if (cmp == 0) break;
        cur = cmp < 0 ? cur.Left : cur.Right;
      }
      return path;
    }

    // ── Eingabe ───────────────────────────────────────────────────────────────

    private bool TryGetInput(out int val)
    {
      val = 0;
      if (string.IsNullOrWhiteSpace(txtInput.Text)) { lblStatus.Text = "Bitte eine Zahl eingeben"; return false; }
      if (!int.TryParse(txtInput.Text.Trim(), out val)) { lblStatus.Text = "Ungültige Eingabe – nur ganze Zahlen"; return false; }
      return true;
    }

    private void txtInput_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnAdd_Click(sender, e); }
    }

    // ── GDI+ Zeichnen ─────────────────────────────────────────────────────────

    private void treePanel_Paint(object sender, PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
      g.Clear(Color.White);

      // Wenn Root null ist und der Baum leer erscheint, prüfen ob Insert schon implementiert ist
      if (_tree.IsEmpty)
      {
        // Probe-Insert um zu prüfen ob die Methode schon existiert
        var probe = new BinarySearchTree();
        try
        {
          probe.Insert(42);
          // Insert funktioniert → Baum ist einfach leer
          g.DrawString("(Baum ist leer – Zahlen einfügen!)",
            new Font("Segoe UI", 11), Brushes.Gray, 20, treePanel.Height / 2 - 10);
        }
        catch (NotImplementedException)
        {
          DrawHint(g, "TODO 1 – Insert implementieren",
                      "BinarySearchTree.cs  →  InsertRecursive(...)  lösen");
        }
        return;
      }

      _nodePositions.Clear();
      DrawNode(g, _tree.Root, treePanel.Width / 2, 35, treePanel.Width / 4);
    }

    private void DrawHint(Graphics g, string title, string sub)
    {
      int cx = treePanel.Width / 2, cy = treePanel.Height / 2;
      var tf = new Font("Segoe UI", 13, FontStyle.Bold);
      var sf = new Font("Segoe UI", 10);
      var ts = g.MeasureString(title, tf);
      var ss = g.MeasureString(sub,   sf);
      g.DrawString(title, tf, new SolidBrush(Color.Crimson), cx - ts.Width / 2, cy - 28);
      g.DrawString(sub,   sf, Brushes.DimGray,               cx - ss.Width / 2, cy + 8);
    }

    private void DrawNode(Graphics g, Node node, int x, int y, int offsetX)
    {
      if (node == null) return;

      bool leftOnPath  = _pathValues.Contains(node.Item) && node.Left  != null && _pathValues.Contains(node.Left.Item);
      bool rightOnPath = _pathValues.Contains(node.Item) && node.Right != null && _pathValues.Contains(node.Right.Item);

      if (node.Left  != null)
      {
        g.DrawLine(leftOnPath  ? new Pen(Color.DodgerBlue, 2f) : Pens.Silver, x, y, x - offsetX, y + LevelHeight);
        DrawNode(g, node.Left,  x - offsetX, y + LevelHeight, offsetX / 2);
      }
      if (node.Right != null)
      {
        g.DrawLine(rightOnPath ? new Pen(Color.DodgerBlue, 2f) : Pens.Silver, x, y, x + offsetX, y + LevelHeight);
        DrawNode(g, node.Right, x + offsetX, y + LevelHeight, offsetX / 2);
      }

      bool isRoot      = node == _tree.Root;
      bool isLeaf      = node.Left == null && node.Right == null;
      bool isHighlight = _highlightedValue.HasValue && node.Item == _highlightedValue.Value;
      bool isOnPath    = _pathValues.Contains(node.Item) && !isHighlight;

      Brush fill = isHighlight ? new SolidBrush(Color.Gold)
                 : isOnPath    ? new SolidBrush(Color.DodgerBlue)
                 : isRoot      ? new SolidBrush(Color.FromArgb(0x20, 0x6F, 0xC4))
                 : isLeaf      ? new SolidBrush(Color.FromArgb(0x5C, 0xB8, 0x5C))
                 :               new SolidBrush(Color.FromArgb(0xF0, 0xAD, 0x4E));

      var rect = new Rectangle(x - NodeRadius, y - NodeRadius, NodeRadius * 2, NodeRadius * 2);
      g.FillEllipse(fill, rect);
      g.DrawEllipse(isHighlight ? new Pen(Color.DarkOrange, 2.5f) : Pens.DimGray, rect);

      var font = new Font("Segoe UI", 9, FontStyle.Bold);
      var sz   = g.MeasureString(node.Item.ToString(), font);
      g.DrawString(node.Item.ToString(), font, Brushes.White, x - sz.Width / 2, y - sz.Height / 2);

      _nodePositions[node.Item] = new Point(x, y);
    }
  }
}
