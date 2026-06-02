namespace ZbW.ProgrammingFoundation.Lessons.Module13.DoublyLinkedListDemo
{
  /// <summary>
  ///   Visualisiert die doppelt verkettete Liste (Doubly Linked List).
  ///   Die gesamte Listenlogik liegt in <see cref="DoublyLinkedListLogik" />.
  ///   Diese View ist ausschliesslich für UI-Events und das Zeichnen zuständig.
  /// </summary>
  public partial class DoublyLinkedListView : Form
  {
    private readonly DoublyLinkedListLogik _logik = new();
    private OperationResult _last = new(string.Empty);

    /// <summary>Initialisiert das Formular und alle Steuerelemente.</summary>
    public DoublyLinkedListView()
    {
      InitializeComponent();
    }

    private static void DrawHinweis(Graphics g, int w, int h)
    {
      string[] zeilen = { "Doppelt verkettete Liste", "", "Wert eingeben → Add klicken" };
      using var fTitel = new Font("Segoe UI", 16f, FontStyle.Bold);
      using var fText = new Font("Segoe UI", 11f);
      float y = h / 2f - 40;
      foreach (string zeile in zeilen)
      {
        if (zeile.Length == 0)
        {
          y += 10;
          continue;
        }

        Font f = zeile == zeilen[0] ? fTitel : fText;
        Color c = zeile == zeilen[0] ? Color.FromArgb(200, 200, 210) : Color.FromArgb(130, 130, 140);
        SizeF ts = g.MeasureString(zeile, f);
        g.DrawString(zeile, f, new SolidBrush(c), w / 2f - ts.Width / 2f, y);
        y += ts.Height + 4;
      }
    }

    // ── Button-Handler ────────────────────────────────────────────────────

    private void BtnAdd_Click(object sender, EventArgs e)
    {
      string val = TxtValue.Text.Trim();
      if (val.Length == 0)
      {
        return;
      }

      _last = _logik.Add(val);
      TxtValue.Clear();
      PnlBoard.Invalidate();
    }

    private void BtnClear_Click(object sender, EventArgs e)
    {
      _last = _logik.Clear();
      PnlBoard.Invalidate();
    }

    private void BtnContains_Click(object sender, EventArgs e)
    {
      string val = TxtValue.Text.Trim();
      if (val.Length == 0)
      {
        return;
      }

      _last = _logik.Contains(val);
      PnlBoard.Invalidate();
    }

    private void BtnFindByIndex_Click(object sender, EventArgs e)
    {
      if (!int.TryParse(TxtValue.Text.Trim(), out int idx))
      {
        _last = new OperationResult("Bitte einen ganzzahligen Index als Wert eingeben.", isError: true);
        PnlBoard.Invalidate();
        return;
      }

      _last = _logik.FindByIndex(idx);
      PnlBoard.Invalidate();
    }

    private void BtnIndexerSet_Click(object sender, EventArgs e)
    {
      if (!int.TryParse(TxtPrev.Text.Trim(), out int idx))
      {
        _last = new OperationResult("Bitte einen Index im 'nach / idx'-Feld eingeben.", isError: true);
        PnlBoard.Invalidate();
        return;
      }

      string val = TxtValue.Text.Trim();
      if (val.Length == 0)
      {
        return;
      }

      _last = _logik.SetByIndex(idx, val);
      PnlBoard.Invalidate();
    }

    private void BtnInsertAfter_Click(object sender, EventArgs e)
    {
      string after = TxtPrev.Text.Trim();
      string val = TxtValue.Text.Trim();
      if (after.Length == 0 || val.Length == 0)
      {
        return;
      }

      _last = _logik.InsertAfter(after, val);
      PnlBoard.Invalidate();
    }

    private void BtnRemove_Click(object sender, EventArgs e)
    {
      string val = TxtValue.Text.Trim();
      if (val.Length == 0)
      {
        return;
      }

      _last = _logik.Remove(val);
      PnlBoard.Invalidate();
    }

    private void DrawBoard(Graphics g, int w, int h)
    {
      g.Clear(Color.FromArgb(28, 28, 32));
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

      if (_logik.Count == 0)
      {
        DrawHinweis(g, w, h);
        return;
      }

      const int boxW = 80;
      const int boxH = 48;
      const int arrowW = 36;
      const int nodeStep = boxW + arrowW;
      int totalW = _logik.Count * nodeStep - arrowW;
      int startX = Math.Max(12, (w - totalW) / 2);
      int y = h / 2 - boxH / 2;

      for (int i = 0; i < _logik.Count; i++)
      {
        int x = startX + i * nodeStep;
        bool highlight = i == _last.HighlightIndex;
        Color bg = highlight ? Color.FromArgb(0, 122, 204) : Color.FromArgb(50, 50, 62);
        Color border = highlight ? Color.White : Color.FromArgb(100, 100, 120);

        var rect = new Rectangle(x, y, boxW, boxH);
        using var bgBrush = new SolidBrush(bg);
        g.FillRectangle(bgBrush, rect);
        using var borderPen = new Pen(border, highlight ? 2f : 1f);
        g.DrawRectangle(borderPen, rect);

        string label = _logik.GetItem(i)?.ToString() ?? "null";
        using var fVal = new Font("Segoe UI", 11f, FontStyle.Bold);
        SizeF ts = g.MeasureString(label, fVal);
        g.DrawString(label, fVal, Brushes.White, x + boxW / 2f - ts.Width / 2f, y + boxH / 2f - ts.Height / 2f);

        using var fIdx = new Font("Segoe UI", 8f);
        string idxLabel = $"[{i}]";
        SizeF ti = g.MeasureString(idxLabel, fIdx);
        g.DrawString(
          idxLabel,
          fIdx,
          new SolidBrush(Color.FromArgb(120, 120, 140)),
          x + boxW / 2f - ti.Width / 2f,
          y + boxH + 4);

        if (i < _logik.Count - 1)
        {
          int ax = x + boxW, bx = ax + arrowW, midY = y + boxH / 2;
          using var fwdPen = new Pen(Color.FromArgb(100, 160, 220), 1.5f);
          fwdPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
          g.DrawLine(fwdPen, ax, midY - 4, bx, midY - 4);

          using var bwdPen = new Pen(Color.FromArgb(220, 140, 80), 1.5f);
          bwdPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
          g.DrawLine(bwdPen, bx, midY + 4, ax, midY + 4);
        }
        else
        {
          using var fNull = new Font("Consolas", 8f);
          var nullBrush = new SolidBrush(Color.FromArgb(160, 80, 80));
          g.DrawString("null→", fNull, nullBrush, x + boxW + 4, y + boxH / 2 - 14);
          g.DrawString("←null", fNull, nullBrush, x + boxW + 4, y + boxH / 2 + 2);
        }
      }

      using var fLeg = new Font("Segoe UI", 8f);
      g.DrawString("→ Link (nächster)", fLeg, new SolidBrush(Color.FromArgb(100, 160, 220)), 12, h - 46);
      g.DrawString("← PrevLink (vorheriger)", fLeg, new SolidBrush(Color.FromArgb(220, 140, 80)), 12, h - 30);

      if (_last.Message.Length > 0)
      {
        using var fRes = new Font("Consolas", 10f);
        Color rc = _last.IsError ? Color.FromArgb(220, 80, 80) : Color.FromArgb(80, 200, 80);
        g.DrawString(_last.Message, fRes, new SolidBrush(rc), 200, h - 38);
      }
    }

    // ── Zeichnen ──────────────────────────────────────────────────────────

    private void PnlBoard_Paint(object sender, PaintEventArgs e)
    {
      DrawBoard(e.Graphics, PnlBoard.Width, PnlBoard.Height);
    }
  }
}
