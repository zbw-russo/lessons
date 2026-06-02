namespace ZbW.ProgrammingFoundation.Lessons.Module12.TurmVonHanoi
{
  using System.Drawing.Drawing2D;

  using Timer = System.Windows.Forms.Timer;

  /// <summary>
  ///   Visualisiert das "Türme von Hanoi"-Problem mit drei Algorithmen:
  ///   1. Rekursiv          – klassische rekursive Lösung
  ///   2. For (Iterativ)    – iterative Lösung mittels Schleife + Rotationsmuster
  ///   3. Teile &amp; Herrsche – expliziter Work-Stack macht die Divide-Schritt sichtbar
  ///   Die Züge werden vorab generiert; ein Timer animiert sie Schritt für Schritt.
  ///   Anzahl Scheiben: 1–21 (21 → 2 097 151 Züge).
  /// </summary>
  public partial class TurmVonHanoiView : Form
  {
    private readonly Color[] _diskColors; // Index 1..21

    private readonly Timer _timer;
    private int _diskCount; // aktuell gewählte Scheibenzahl
    private bool _isRunning;
    private int _moveIndex; // nächster auszuführender Zug

    private List<Zug> _moves; // vorberechnete Zugfolge

    // ── Zustand ───────────────────────────────────────────────────────────────

    private Stack<int>[] _pegs; // drei Stapel (Peg A=0, B=1, C=2)

    // ── Konstruktor ───────────────────────────────────────────────────────────

    public TurmVonHanoiView()
    {
      InitializeComponent();
      _diskColors = BuildDiskColors(21);
      _timer = new Timer { Interval = 100 };
      _timer.Tick += OnTimerTick;
      ResetPegs(3); // Startzustand zeichnen
    }

    private static Color[] BuildDiskColors(int count)
    {
      var colors = new Color[count + 1]; // Indizes 1..count
      for (int i = 1; i <= count; i++)
      {
        float hue = (i - 1) * 360f / count;
        colors[i] = HsvToRgb(hue, 0.85f, 0.90f);
      }

      return colors;
    }

    private static Color Darken(Color c, float amount)
    {
      return Color.FromArgb(
        255,
        Math.Max(0, c.R - (int)(amount * 255)),
        Math.Max(0, c.G - (int)(amount * 255)),
        Math.Max(0, c.B - (int)(amount * 255)));
    }

    private static Color HsvToRgb(float h, float s, float v)
    {
      int hi = (int)(h / 60f) % 6;
      float f = h / 60f - (float)Math.Floor(h / 60f);
      int vv = (int)(v * 255);
      int p = (int)(v * (1 - s) * 255);
      int q = (int)(v * (1 - f * s) * 255);
      int t = (int)(v * (1 - (1 - f) * s) * 255);
      switch (hi)
      {
        case 0: return Color.FromArgb(255, vv, t, p);
        case 1: return Color.FromArgb(255, q, vv, p);
        case 2: return Color.FromArgb(255, p, vv, t);
        case 3: return Color.FromArgb(255, p, q, vv);
        case 4: return Color.FromArgb(255, t, p, vv);
        default: return Color.FromArgb(255, vv, p, q);
      }
    }

    private static Color Lighten(Color c, float amount)
    {
      return Color.FromArgb(
        255,
        Math.Min(255, c.R + (int)(amount * 255)),
        Math.Min(255, c.G + (int)(amount * 255)),
        Math.Min(255, c.B + (int)(amount * 255)));
    }

    // ── Hilfsmethoden ─────────────────────────────────────────────────────────

    private static GraphicsPath RoundedRect(Rectangle r, int radius)
    {
      int d = radius * 2;
      var path = new GraphicsPath();
      if (d <= 0 || d >= r.Width || d >= r.Height)
      {
        path.AddRectangle(r);
        return path;
      }

      path.AddArc(r.X, r.Y, d, d, 180, 90);
      path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
      path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
      path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
      path.CloseFigure();
      return path;
    }

    // ── UI-Events ─────────────────────────────────────────────────────────────

    private void BtnStart_Click(object sender, EventArgs e)
    {
      // Läuft gerade → stoppen
      if (_isRunning)
      {
        _timer.Stop();
        _isRunning = false;
        BtnStart.Text = "Start";
        LblStatus.Text = "Gestoppt";
        return;
      }

      // Neuen Durchlauf starten
      _diskCount = (int)CmbDisks.SelectedItem;
      ResetPegs(_diskCount);

      _moveIndex = 0;

      string algo = CmbAlgorithm.SelectedItem?.ToString() ?? "Rekursiv";
      switch (algo)
      {
        case "For (Iterativ)":
          _moves = HanoiLogik.GeneriereIterativ(_diskCount);
          break;
        case "Teile & Herrsche":
          _moves = HanoiLogik.GeneriereTeilUndHerrsche(_diskCount, 0, 2, 1);
          break;
        default: // Rekursiv
          _moves = HanoiLogik.GeneriereRekursiv(_diskCount, 0, 2, 1);
          break;
      }

      // Geschwindigkeit: TrkSpeed 1=langsam, 100=schnell → Interval 1–1000 ms
      _timer.Interval = Math.Max(1, 1010 - TrkSpeed.Value * 10);

      _isRunning = true;
      BtnStart.Text = "Stop";
      LblStatus.Text = $"0 / {_moves.Count:N0} Züge";
      _timer.Start();
      PnlBoard.Invalidate();
    }

    private void DrawBoard(Graphics g, int w, int h)
    {
      g.Clear(Color.FromArgb(28, 28, 32));

      int pegSpacing = w / 4;
      int baseY = h - 50;
      int pegAreaH = h - 110;
      int diskH = Math.Max(8, Math.Min(30, (pegAreaH - 10) / Math.Max(_diskCount, 1)));
      int maxDiskW = pegSpacing - 24;
      int pegW = 10;

      // Sockel
      var baseRect = new Rectangle(20, baseY, w - 40, 18);
      using (var b = new SolidBrush(Color.FromArgb(100, 65, 30)))
      {
        g.FillRectangle(b, baseRect);
      }

      using (var p = new Pen(Color.FromArgb(150, 95, 45), 2))
      {
        g.DrawRectangle(p, baseRect);
      }

      string[] labels = { "A", "B", "C" };

      for (int peg = 0; peg < 3; peg++)
      {
        int pegX = pegSpacing * (peg + 1);

        // Stab
        var pegRect = new Rectangle(pegX - pegW / 2, baseY - pegAreaH, pegW, pegAreaH);
        using (var pegBrush = new LinearGradientBrush(
                 new Rectangle(pegRect.X, pegRect.Y, pegW + 1, pegRect.Height + 1),
                 Color.FromArgb(180, 115, 55),
                 Color.FromArgb(100, 60, 20),
                 LinearGradientMode.Horizontal))
        {
          g.FillRectangle(pegBrush, pegRect);
        }

        // Buchstaben-Label
        using (var font = new Font("Segoe UI", 13f, FontStyle.Bold))
        {
          SizeF sz = g.MeasureString(labels[peg], font);
          g.DrawString(
            labels[peg],
            font,
            Brushes.White,
            pegX - sz.Width / 2f,
            baseY + 22);
        }

        // Scheiben zeichnen
        // Stack.ToArray: Index 0 = Scheibe ganz oben (kleinste)
        int[] disks = _pegs[peg].ToArray();
        for (int d = 0; d < disks.Length; d++)
        {
          int size = disks[d];
          float ratio = (float)size / _diskCount;
          int dw = Math.Max(24, (int)(maxDiskW * ratio));
          int dx = pegX - dw / 2;

          // d=0 (Top/kleinste) liegt am höchsten, d=letzter (unterste) am tiefsten
          int dy = baseY - diskH * (disks.Length - d);

          if (dy < 0 || dw <= 0 || diskH <= 2)
          {
            continue;
          }

          var rect = new Rectangle(dx, dy, dw, diskH - 2);
          Color c = _diskColors[size];

          using (var path = RoundedRect(rect, Math.Min(6, diskH / 3)))
          {
            // Gradient: oben heller, unten dunkler
            using (var brush = new LinearGradientBrush(
                     new Rectangle(rect.X, rect.Y, rect.Width, rect.Height + 1),
                     Lighten(c, 0.25f),
                     Darken(c, 0.25f),
                     LinearGradientMode.Vertical))
            {
              g.FillPath(brush, path);
            }

            using (var pen = new Pen(Darken(c, 0.45f), 1.5f))
            {
              g.DrawPath(pen, path);
            }
          }

          // Nummer auf der Scheibe
          if (diskH >= 14 && dw >= 22)
          {
            int fontSize = Math.Max(6, Math.Min(10, diskH - 4));
            using (var font = new Font("Segoe UI", fontSize, FontStyle.Bold))
            {
              string num = size.ToString();
              SizeF ts = g.MeasureString(num, font);
              g.DrawString(
                num,
                font,
                Brushes.White,
                dx + dw / 2f - ts.Width / 2f,
                dy + (diskH - 2) / 2f - ts.Height / 2f);
            }
          }
        }
      }
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
      if (_moveIndex >= _moves.Count)
      {
        _timer.Stop();
        _isRunning = false;
        BtnStart.Text = "Start";
        LblStatus.Text = $"Fertig – {_moves.Count:N0} Züge";
        return;
      }

      Zug move = _moves[_moveIndex++];
      if (_pegs[move.Von].Count > 0)
      {
        _pegs[move.Nach].Push(_pegs[move.Von].Pop());
      }

      LblStatus.Text = $"{_moveIndex:N0} / {_moves.Count:N0} Züge";
      PnlBoard.Invalidate();
    }

    // =========================================================================
    // Grafik
    // =========================================================================

    private void PnlBoard_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      DrawBoard(e.Graphics, PnlBoard.Width, PnlBoard.Height);
    }

    // ── Pegs initialisieren ───────────────────────────────────────────────────

    private void ResetPegs(int diskCount)
    {
      _diskCount = diskCount;
      _pegs = new Stack<int>[3];
      for (int i = 0; i < 3; i++)
      {
        _pegs[i] = new Stack<int>();
      }

      for (int i = diskCount; i >= 1; i--)
      {
        _pegs[0].Push(i); // groß unten
      }
    }
  }
}
