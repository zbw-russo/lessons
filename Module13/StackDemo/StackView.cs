namespace ZbW.ProgrammingFoundation.Lessons.Module13.StackDemo
{
  /// <summary>
  ///   Visualisiert den Stack (LIFO) mit beiden Implementierungen.
  ///   Die gesamte Stack-Logik liegt in <see cref="StackLogik" />.
  ///   Diese View ist ausschliesslich für UI-Events und das Zeichnen zuständig.
  /// </summary>
  public partial class StackView : Form
  {
    private readonly StackLogik _logik = new();
    private OperationResult _last = new(string.Empty);

    /// <summary>Initialisiert das Formular, alle Steuerelemente und setzt das Modus-Label.</summary>
    public StackView()
    {
      InitializeComponent();
      LblMode.Text = _logik.ModeLabel;
    }

    private static void DrawHinweis(Graphics g, int w, int h)
    {
      string[] zeilen = { "Stack – LIFO", "", "Wert eingeben → Push klicken" };
      using var fTitel = new Font("Segoe UI", 16f, FontStyle.Bold);
      using var fText = new Font("Segoe UI", 11f);
      float y = h / 2f - 50;
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

    private void BtnClear_Click(object sender, EventArgs e)
    {
      _last = _logik.Clear();
      PnlBoard.Invalidate();
    }

    private void BtnPeek_Click(object sender, EventArgs e)
    {
      _last = _logik.Peek();
      PnlBoard.Invalidate();
    }

    private void BtnPop_Click(object sender, EventArgs e)
    {
      _last = _logik.Pop();
      PnlBoard.Invalidate();
    }

    // ── Button-Handler ────────────────────────────────────────────────────

    private void BtnPush_Click(object sender, EventArgs e)
    {
      string val = TxtValue.Text.Trim();
      if (val.Length == 0)
      {
        return;
      }

      _last = _logik.Push(val);
      TxtValue.Clear();
      PnlBoard.Invalidate();
    }

    private void BtnToggleMode_Click(object sender, EventArgs e)
    {
      _last = _logik.ToggleMode();
      LblMode.Text = _logik.ModeLabel;
      PnlBoard.Invalidate();
    }

    private void DrawBoard(Graphics g, int w, int h)
    {
      g.Clear(Color.FromArgb(28, 28, 32));
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

      const int boxW = 160;
      const int boxH = 44;
      const int gap = 6;
      int centerX = w / 2;

      if (_logik.Items.Count == 0)
      {
        DrawHinweis(g, w, h);
      }
      else
      {
        int totalH = _logik.Items.Count * (boxH + gap) - gap;
        int startY = Math.Max(16, (h - 60) / 2 - totalH / 2);

        for (int i = _logik.Items.Count - 1; i >= 0; i--)
        {
          int drawRow = _logik.Items.Count - 1 - i;
          int y = startY + drawRow * (boxH + gap);
          int x = centerX - boxW / 2;
          bool isTop = i == _logik.Items.Count - 1;

          Color bg = isTop ? Color.FromArgb(0, 122, 204) : Color.FromArgb(50, 50, 62);
          Color border = isTop ? Color.White : Color.FromArgb(100, 100, 120);

          var rect = new Rectangle(x, y, boxW, boxH);
          using var bgBrush = new SolidBrush(bg);
          g.FillRectangle(bgBrush, rect);
          using var pen = new Pen(border, isTop ? 2f : 1f);
          g.DrawRectangle(pen, rect);

          string label = _logik.Items[i].ToString() ?? "null";
          using var fVal = new Font("Segoe UI", 12f, FontStyle.Bold);
          SizeF ts = g.MeasureString(label, fVal);
          g.DrawString(label, fVal, Brushes.White, x + boxW / 2f - ts.Width / 2f, y + boxH / 2f - ts.Height / 2f);

          if (isTop)
          {
            using var fTop = new Font("Segoe UI", 8f, FontStyle.Bold);
            g.DrawString("◄ TOP", fTop, new SolidBrush(Color.FromArgb(180, 220, 255)), x + boxW + 6, y + boxH / 2f - 8);
          }
        }
      }

      if (_last.Message.Length > 0)
      {
        using var fRes = new Font("Consolas", 10f);
        Color rc = _last.IsError ? Color.FromArgb(220, 80, 80) : Color.FromArgb(80, 200, 80);
        g.DrawString(_last.Message, fRes, new SolidBrush(rc), 12, h - 28);
      }
    }

    // ── Zeichnen ───────────────────────────────────────────────────────────

    private void PnlBoard_Paint(object sender, PaintEventArgs e)
    {
      DrawBoard(e.Graphics, PnlBoard.Width, PnlBoard.Height);
    }
  }
}
