namespace ZbW.ProgrammingFoundation.Lessons.Module12.BinaereSuche
{
  using Timer = System.Windows.Forms.Timer;

  /// <summary>
  ///   Visualisiert die binäre Suche Schritt für Schritt.
  ///   Zeigt drei Zeiger: L (links), M (mitte), R (rechts).
  ///   Muster: Divide &amp; Conquer – Suchbereich bei jedem Schritt halbieren.
  /// </summary>
  public partial class BinaereSucheView : Form
  {
    private readonly Timer _timer;
    private int[] _zahlen;
    private List<BinaereSucheSchritt> _schritte;
    private int _aktuellerSchritt; // Index in _schritte
    private bool _isRunning;

    /// <summary>Erstellt die View mit dem Standard-Array aus den Folien.</summary>
    public BinaereSucheView()
    {
      InitializeComponent();
      _timer = new Timer { Interval = 1000 };
      _timer.Tick += OnTimerTick;
      _zahlen = new[] { 2, 5, 8, 12, 16, 23, 38, 45 };
    }

    private void BtnSuchen_Click(object sender, EventArgs e)
    {
      if (_isRunning)
      {
        _timer.Stop();
        _isRunning = false;
        BtnSuchen.Text = "Suchen";
        LblStatus.Text = "Gestoppt";
        return;
      }

      // Array einlesen
      var liste = new List<int>();
      foreach (string teil in TxtArray.Text.Split(','))
      {
        if (int.TryParse(teil.Trim(), out int z))
        {
          liste.Add(z);
        }
      }

      if (liste.Count == 0)
      {
        LblStatus.Text = "Kein gültiges Array!";
        return;
      }

      // Suchwert einlesen
      if (!int.TryParse(TxtSuche.Text.Trim(), out int suchwert))
      {
        LblStatus.Text = "Ungültiger Suchwert!";
        return;
      }

      _zahlen = liste.ToArray();

      // Array muss sortiert sein für binäre Suche
      Array.Sort(_zahlen);
      TxtArray.Text = string.Join(", ", _zahlen);

      // Schritte berechnen
      _schritte = RdoRekursiv.Checked
        ? BinaereSucheLogik.SucheRekursiv(_zahlen, suchwert)
        : BinaereSucheLogik.SucheIterativ(_zahlen, suchwert);

      _aktuellerSchritt = -1; // noch kein Schritt gezeigt
      _timer.Interval = Math.Max(1, 1010 - TrkSpeed.Value * 10);
      _isRunning = true;
      BtnSuchen.Text = "Stop";
      LblStatus.Text = $"Suche {suchwert} – {_schritte.Count} Schritte nötig";
      _timer.Start();
      PnlBoard.Invalidate();
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
      _aktuellerSchritt++;

      if (_aktuellerSchritt >= _schritte.Count)
      {
        _timer.Stop();
        _isRunning = false;
        BtnSuchen.Text = "Suchen";
        var letzter = _schritte[_schritte.Count - 1];
        LblStatus.Text = letzter.Gefunden
          ? $"Fertig – Wert bei Index {letzter.Mitte} gefunden nach {_schritte.Count} Schritt(en)"
          : $"Fertig – Wert nicht gefunden nach {_schritte.Count - 1} Schritt(en)";
      }
      else
      {
        LblStatus.Text = $"Schritt {_aktuellerSchritt + 1} / {_schritte.Count}: {_schritte[_aktuellerSchritt].Erklaerung}";
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

      if (_schritte == null || _aktuellerSchritt < 0)
      {
        DrawHinweis(g, w, h);
        return;
      }

      var schritt = _aktuellerSchritt < _schritte.Count
        ? _schritte[_aktuellerSchritt]
        : _schritte[_schritte.Count - 1];

      DrawLegende(g, w, h);
      DrawSucheArray(g, w, h, schritt);
      DrawErklaerung(g, w, h, schritt);
      DrawSchrittInfo(g, w, h);
    }

    private void DrawSucheArray(Graphics g, int w, int h, BinaereSucheSchritt schritt)
    {
      const int boxB = 64;
      const int boxH = 50;
      int gesamt = _zahlen.Length * (boxB + 10) - 10;
      int startX = (w - gesamt) / 2;
      int boxY = h / 2 - boxH / 2 - 30;

      for (int i = 0; i < _zahlen.Length; i++)
      {
        int x = startX + i * (boxB + 10);

        bool istMitte = i == schritt.Mitte;
        bool inBereich = schritt.Links >= 0 && i >= schritt.Links && i <= schritt.Rechts;
        bool gefunden = istMitte && schritt.Gefunden;

        Color bg;
        if (gefunden)
        {
          bg = Color.FromArgb(0, 160, 80); // grün = gefunden
        }
        else if (istMitte)
        {
          bg = Color.FromArgb(200, 100, 0); // orange = aktuelle Mitte
        }
        else if (inBereich)
        {
          bg = Color.FromArgb(40, 70, 110); // blau = aktiver Suchbereich
        }
        else
        {
          bg = Color.FromArgb(35, 35, 42); // dunkel = ausgeschlossen
        }

        var rect = new Rectangle(x, boxY, boxB, boxH);
        g.FillRectangle(new SolidBrush(bg), rect);

        Color rahmen = istMitte ? Color.White : inBereich ? Color.FromArgb(80, 130, 180) : Color.FromArgb(55, 55, 65);
        g.DrawRectangle(new Pen(rahmen, istMitte ? 2.5f : 1f), rect);

        // Wert
        using (var f = new Font("Segoe UI", 14f, FontStyle.Bold))
        {
          string val = _zahlen[i].ToString();
          SizeF ts = g.MeasureString(val, f);
          Color fc = inBereich || istMitte ? Color.White : Color.FromArgb(80, 80, 90);
          g.DrawString(val, f, new SolidBrush(fc), x + boxB / 2f - ts.Width / 2f, boxY + boxH / 2f - ts.Height / 2f);
        }

        // Index unter Box
        using (var f = new Font("Segoe UI", 8f))
        {
          string idx = $"[{i}]";
          SizeF ts = g.MeasureString(idx, f);
          g.DrawString(idx, f, new SolidBrush(Color.FromArgb(100, 100, 115)), x + boxB / 2f - ts.Width / 2f, boxY + boxH + 3);
        }

        // Zeiger-Labels (L, M, R) über den Boxen
        DrawZeiger(g, x, boxY, boxB, i, schritt);
      }
    }

    private static void DrawZeiger(Graphics g, int x, int boxY, int boxB, int i, BinaereSucheSchritt schritt)
    {
      var labels = new List<(string, Color)>();
      if (schritt.Links >= 0 && i == schritt.Links)
      {
        labels.Add(("L", Color.FromArgb(80, 200, 80)));
      }

      if (schritt.Rechts >= 0 && i == schritt.Rechts)
      {
        labels.Add(("R", Color.FromArgb(220, 80, 80)));
      }

      if (schritt.Mitte >= 0 && i == schritt.Mitte)
      {
        labels.Add(("M", Color.FromArgb(240, 160, 30)));
      }

      if (labels.Count == 0)
      {
        return;
      }

      float labelX = x + boxB / 2f;
      float labelY = boxY - 22;

      using (var f = new Font("Segoe UI", 9f, FontStyle.Bold))
      {
        float totalW = 0;
        foreach (var (lbl, _) in labels)
        {
          totalW += g.MeasureString(lbl, f).Width + 2;
        }

        float cx = labelX - totalW / 2f;
        foreach (var (lbl, farbe) in labels)
        {
          SizeF ts = g.MeasureString(lbl, f);
          g.DrawString(lbl, f, new SolidBrush(farbe), cx, labelY);
          cx += ts.Width + 2;
        }
      }
    }

    private void DrawErklaerung(Graphics g, int w, int h, BinaereSucheSchritt schritt)
    {
      using (var f = new Font("Consolas", 10f))
      {
        SizeF ts = g.MeasureString(schritt.Erklaerung, f);
        Color farbe = schritt.Gefunden
          ? Color.FromArgb(80, 220, 80)
          : schritt.Mitte < 0
            ? Color.FromArgb(220, 100, 80)
            : Color.FromArgb(200, 200, 100);

        g.DrawString(schritt.Erklaerung, f, new SolidBrush(farbe), w / 2f - ts.Width / 2f, h / 2f + 50);
      }
    }

    private void DrawSchrittInfo(Graphics g, int w, int h)
    {
      if (_schritte == null)
      {
        return;
      }

      using (var f = new Font("Segoe UI", 9f))
      {
        string info = $"Schritt {Math.Min(_aktuellerSchritt + 1, _schritte.Count)} von {_schritte.Count}  |  Array: {_zahlen.Length} Elemente  |  max. log₂({_zahlen.Length}) ≈ {Math.Ceiling(Math.Log2(_zahlen.Length))} Schritte";
        SizeF ts = g.MeasureString(info, f);
        g.DrawString(info, f, new SolidBrush(Color.FromArgb(100, 100, 115)), w / 2f - ts.Width / 2f, h - 24);
      }
    }

    private static void DrawLegende(Graphics g, int w, int h)
    {
      var eintraege = new (string Text, Color Farbe)[]
      {
        ("L = Links", Color.FromArgb(80, 200, 80)),
        ("M = Mitte", Color.FromArgb(240, 160, 30)),
        ("R = Rechts", Color.FromArgb(220, 80, 80)),
        ("Suchbereich", Color.FromArgb(40, 70, 110)),
        ("Gefunden", Color.FromArgb(0, 160, 80))
      };

      using (var f = new Font("Segoe UI", 9f))
      {
        float x = 12;
        float y = 8;
        foreach (var (text, farbe) in eintraege)
        {
          g.FillRectangle(new SolidBrush(farbe), x, y + 2, 12, 12);
          g.DrawString(text, f, new SolidBrush(Color.FromArgb(160, 160, 175)), x + 16, y);
          x += g.MeasureString(text, f).Width + 28;
        }
      }
    }

    private static void DrawHinweis(Graphics g, int w, int h)
    {
      string[] zeilen = { "Binäre Suche – Divide & Conquer", "", "Array und Suchwert eingeben,", "dann  ► Suchen  klicken" };

      using (var fTitel = new Font("Segoe UI", 16f, FontStyle.Bold))
      using (var fText = new Font("Segoe UI", 11f))
      {
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
    }
  }
}
