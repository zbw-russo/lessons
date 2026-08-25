namespace ZbW.ProgrammingFoundation.Lessons.Module12.Iteration
{
  using Timer = System.Windows.Forms.Timer;

  /// <summary>
  ///   Visualisiert die Iteration-Muster: Summe (for-Schleife) und Maximum (foreach-Schleife).
  ///   Beide Algorithmen werden gleichzeitig Schritt für Schritt animiert.
  /// </summary>
  public partial class IterationView : Form
  {
    private readonly Timer _timer;
    private int[] _zahlen;
    private int _schritt; // 0 = bereit, 1..n = index [schritt-1] gerade verarbeitet, n+1 = fertig
    private bool _isRunning;

    /// <summary>Erstellt die View und setzt Startwerte.</summary>
    public IterationView()
    {
      InitializeComponent();
      _timer = new Timer { Interval = 700 };
      _timer.Tick += OnTimerTick;
      _zahlen = new[] { 3, 7, 2, 9, 1, 5, 8, 4 };
    }

    private void BtnStart_Click(object sender, EventArgs e)
    {
      if (_isRunning)
      {
        _timer.Stop();
        _isRunning = false;
        BtnStart.Text = "Start";
        LblStatus.Text = "Gestoppt";
        return;
      }

      var liste = new List<int>();
      foreach (string teil in TxtZahlen.Text.Split(','))
      {
        if (int.TryParse(teil.Trim(), out int z))
        {
          liste.Add(z);
        }
      }

      if (liste.Count == 0)
      {
        LblStatus.Text = "Keine gültigen Zahlen!";
        return;
      }

      _zahlen = liste.ToArray();
      _schritt = 0;
      _timer.Interval = Math.Max(1, 1010 - TrkSpeed.Value * 10);
      _isRunning = true;
      BtnStart.Text = "Stop";
      LblStatus.Text = $"0 / {_zahlen.Length} Schritte";
      _timer.Start();
      PnlBoard.Invalidate();
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
      _schritt++;

      if (_schritt > _zahlen.Length)
      {
        _timer.Stop();
        _isRunning = false;
        BtnStart.Text = "Start";
        LblStatus.Text = $"Fertig – Summe = {IterationLogik.Summe(_zahlen)}, Maximum = {IterationLogik.Maximum(_zahlen)}";
      }
      else
      {
        LblStatus.Text = $"Schritt {_schritt} von {_zahlen.Length}";
      }

      PnlBoard.Invalidate();
    }

    private void PnlBoard_Paint(object sender, PaintEventArgs e)
    {
      DrawBoard(e.Graphics, PnlBoard.Width, PnlBoard.Height);
    }

    private void DrawBoard(Graphics g, int w, int h)
    {
      g.Clear(Color.FromArgb(28, 28, 32));

      if (_schritt == 0 && !_isRunning)
      {
        DrawHinweis(g, w, h);
        return;
      }

      int halbH = h / 2 - 1;
      DrawSummeAbschnitt(g, w, halbH, 0);

      using (var pen = new Pen(Color.FromArgb(55, 55, 65), 1))
      {
        g.DrawLine(pen, 0, halbH, w, halbH);
      }

      DrawMaximumAbschnitt(g, w, halbH, halbH + 2);
    }

    private void DrawSummeAbschnitt(Graphics g, int w, int h, int offY)
    {
      bool fertig = _schritt > _zahlen.Length;
      int aktIdx = fertig ? _zahlen.Length : _schritt - 1; // index being highlighted

      // Laufende Summe berechnen
      int laufend = 0;
      for (int i = 0; i < _schritt && i < _zahlen.Length; i++)
      {
        laufend += _zahlen[i];
      }

      // Code-Zeile
      string codeZeile;
      if (_schritt == 0)
      {
        codeZeile = "for (int i = 0; i < zahlen.Length; i++)   summe = summe + zahlen[i];";
      }
      else if (fertig)
      {
        codeZeile = $"Alle {_zahlen.Length} Elemente verarbeitet.";
      }
      else
      {
        int vorher = laufend - _zahlen[aktIdx];
        codeZeile = $"i = {aktIdx}: summe = {vorher} + {_zahlen[aktIdx]} = {laufend}";
      }

      DrawAbschnittKopf(g, w, offY, "Summe mit for-Schleife", codeZeile);
      DrawArrayBoxen(g, w, offY + 48, aktIdx, false);

      // Ergebnis
      if (fertig)
      {
        DrawErgebnis(g, w, offY + h - 32, $"Summe = {IterationLogik.Summe(_zahlen)}");
      }
    }

    private void DrawMaximumAbschnitt(Graphics g, int w, int h, int offY)
    {
      bool fertig = _schritt > _zahlen.Length;
      int aktIdx = fertig ? _zahlen.Length : _schritt - 1;

      // Laufendes Maximum berechnen
      int laufend = _zahlen.Length > 0 ? _zahlen[0] : 0;
      for (int i = 0; i < _schritt && i < _zahlen.Length; i++)
      {
        if (_zahlen[i] > laufend)
        {
          laufend = _zahlen[i];
        }
      }

      // Vorheriges Maximum (vor diesem Schritt)
      int vorMax = _zahlen.Length > 0 ? _zahlen[0] : 0;
      for (int i = 0; i < _schritt - 1 && i < _zahlen.Length; i++)
      {
        if (_zahlen[i] > vorMax)
        {
          vorMax = _zahlen[i];
        }
      }

      string codeZeile;
      if (_schritt == 0)
      {
        codeZeile = "foreach (int zahl in zahlen)   if (zahl > maximum) maximum = zahl;";
      }
      else if (fertig)
      {
        codeZeile = $"Alle {_zahlen.Length} Elemente verarbeitet.";
      }
      else if (aktIdx < _zahlen.Length)
      {
        bool update = _zahlen[aktIdx] > vorMax;
        codeZeile = update
          ? $"zahl = {_zahlen[aktIdx]} > maximum ({vorMax})  →  maximum = {_zahlen[aktIdx]}"
          : $"zahl = {_zahlen[aktIdx]} ≤ maximum ({vorMax})  →  keine Änderung";
      }
      else
      {
        codeZeile = string.Empty;
      }

      DrawAbschnittKopf(g, w, offY, "Maximum mit foreach-Schleife", codeZeile);
      DrawArrayBoxen(g, w, offY + 48, aktIdx, true);

      if (fertig)
      {
        DrawErgebnis(g, w, offY + h - 32, $"Maximum = {IterationLogik.Maximum(_zahlen)}");
      }
    }

    private void DrawAbschnittKopf(Graphics g, int w, int offY, string titel, string code)
    {
      using (var fTitel = new Font("Segoe UI", 10f, FontStyle.Bold))
      using (var fCode = new Font("Consolas", 9f))
      {
        g.DrawString(titel, fTitel, new SolidBrush(Color.FromArgb(180, 180, 210)), 12, offY + 6);
        g.DrawString(code, fCode, new SolidBrush(Color.FromArgb(100, 200, 100)), 12, offY + 26);
      }
    }

    private void DrawArrayBoxen(Graphics g, int w, int boxY, int aktuellerIndex, bool isForeach)
    {
      const int boxB = 54;
      const int boxH = 42;
      int gesamt = _zahlen.Length * (boxB + 8) - 8;
      int startX = (w - gesamt) / 2;

      for (int i = 0; i < _zahlen.Length; i++)
      {
        int x = startX + i * (boxB + 8);
        bool aktiv = i == aktuellerIndex;
        bool verarbeitet = i < _schritt && !aktiv;

        Color bg = aktiv
          ? Color.FromArgb(0, 122, 204)
          : verarbeitet
            ? Color.FromArgb(35, 70, 35)
            : Color.FromArgb(45, 45, 55);

        var rect = new Rectangle(x, boxY, boxB, boxH);
        g.FillRectangle(new SolidBrush(bg), rect);
        g.DrawRectangle(new Pen(aktiv ? Color.White : Color.FromArgb(75, 75, 88), aktiv ? 2f : 1f), rect);

        using (var fVal = new Font("Segoe UI", 13f, FontStyle.Bold))
        {
          string val = _zahlen[i].ToString();
          SizeF ts = g.MeasureString(val, fVal);
          g.DrawString(val, fVal, Brushes.White, x + boxB / 2f - ts.Width / 2f, boxY + boxH / 2f - ts.Height / 2f);
        }

        if (!isForeach) // for-loop zeigt Index
        {
          using (var fIdx = new Font("Segoe UI", 8f))
          {
            string idx = $"[{i}]";
            SizeF ts = g.MeasureString(idx, fIdx);
            g.DrawString(idx, fIdx, new SolidBrush(Color.FromArgb(120, 120, 135)), x + boxB / 2f - ts.Width / 2f, boxY + boxH + 2);
          }
        }
      }
    }

    private static void DrawErgebnis(Graphics g, int w, float y, string text)
    {
      using (var f = new Font("Segoe UI", 13f, FontStyle.Bold))
      {
        SizeF ts = g.MeasureString(text, f);
        g.DrawString(text, f, new SolidBrush(Color.FromArgb(80, 220, 80)), w / 2f - ts.Width / 2f, y);
      }
    }

    private static void DrawHinweis(Graphics g, int w, int h)
    {
      string[] zeilen = { "Iteration – for und foreach", "", "Zahlen eingeben, dann  ► Start  klicken" };

      using (var fTitel = new Font("Segoe UI", 16f, FontStyle.Bold))
      using (var fText = new Font("Segoe UI", 11f))
      {
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
    }
  }
}
