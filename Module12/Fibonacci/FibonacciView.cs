namespace ZbW.ProgrammingFoundation.Lessons.Module12.Fibonacci
{
  using System.Drawing.Drawing2D;

  using Timer = System.Windows.Forms.Timer;

  /// <summary>
  ///   Visualisiert die Fibonacci-Folge mit drei Algorithmen:
  ///   1. For (Iterativ)   – O(n):     klassische Schleife mit zwei Variablen
  ///   2. Rekursiv         – O(2^n):   naive Rekursion (lehrreich, langsam für n>30)
  ///   3. Teile & Herrsche – O(log n): Fast-Doubling-Algorithmus
  ///   Grafik: Balkendiagramm (logarithmische Skalierung).
  ///   Der zuletzt berechnete Balken wird hervorgehoben und mit der
  ///   Formel F(n) = F(n-1) + F(n-2) annotiert.
  /// </summary>
  public partial class FibonacciView : Form
  {
    private readonly Timer _timer;
    private bool _isRunning;

    private int _revealedCount; // wie viele Balken bereits angezeigt werden

    // ── Zustand ───────────────────────────────────────────────────────────────

    private long[] _sequence; // berechnete Fibonacci-Zahlen F(1)..F(n)
    private int _termCount; // Gesamtanzahl gewählter Glieder

    // ── Konstruktor ───────────────────────────────────────────────────────────

    public FibonacciView()
    {
      InitializeComponent();
      _timer = new Timer { Interval = 400 };
      _timer.Tick += OnTimerTick;
    }

    private static Color Darken(Color c, float amount)
    {
      return Color.FromArgb(
        255,
        Math.Max(0, c.R - (int)(amount * 255)),
        Math.Max(0, c.G - (int)(amount * 255)),
        Math.Max(0, c.B - (int)(amount * 255)));
    }

    private static void DrawHint(Graphics g, int w, int h)
    {
      string[] lines = { "Fibonacci-Folge Visualisierung", "", "Wähle Anzahl Glieder und Algorithmus,", "dann klicke  ► Start" };

      using (var title = new Font("Segoe UI", 16f, FontStyle.Bold))
      using (var body = new Font("Segoe UI", 11f))
      {
        float y = h / 2f - 60;
        foreach (string line in lines)
        {
          if (line.Length == 0)
          {
            y += 10;
            continue;
          }

          Font f = line == lines[0] ? title : body;
          Brush br = line == lines[0]
            ? new SolidBrush(Color.FromArgb(200, 200, 210))
            : new SolidBrush(Color.FromArgb(130, 130, 140));
          SizeF ts = g.MeasureString(line, f);
          g.DrawString(line, f, br, w / 2f - ts.Width / 2f, y);
          br.Dispose();
          y += ts.Height + 4;
        }
      }
    }

    // ── Hilfsmethoden ─────────────────────────────────────────────────────────

    private static string FormatFib(long val)
    {
      if (val >= 1_000_000_000L)
      {
        return $"{val / 1_000_000_000.0:F1}G";
      }

      if (val >= 1_000_000L)
      {
        return $"{val / 1_000_000.0:F1}M";
      }

      if (val >= 10_000L)
      {
        return $"{val / 1_000.0:F1}k";
      }

      return val.ToString();
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

    // ── UI-Events ─────────────────────────────────────────────────────────────

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

      _termCount = (int)CmbCount.SelectedItem;
      string algo = CmbAlgorithm.SelectedItem?.ToString() ?? "For (Iterativ)";
      switch (algo)
      {
        case "Rekursiv":
          _sequence = FibonacciLogik.BerechneRekursiv(_termCount);
          break;
        case "Teile & Herrsche":
          _sequence = FibonacciLogik.BerechneTeilUndHerrsche(_termCount);
          break;
        default: // For (Iterativ)
          _sequence = FibonacciLogik.BerechneIterativ(_termCount);
          break;
      }

      _revealedCount = 0;
      _timer.Interval = Math.Max(1, 1010 - TrkSpeed.Value * 10);
      _isRunning = true;
      BtnStart.Text = "Stop";
      LblStatus.Text = $"0 / {_termCount} Glieder";
      _timer.Start();
      PnlBoard.Invalidate();
    }

    private void DrawAnnotation(
      Graphics g,
      int marginL,
      int marginB,
      int h,
      int spacing,
      int barW,
      int barAreaH,
      double logMax)
    {
      int n = _revealedCount; // neuster Index (1-basiert)
      int iN = n - 1; // Array-Index neuester Balken
      if (iN < 2)
      {
        return;
      }

      int iN1 = iN - 1;
      int iN2 = iN - 2;

      long vN = _sequence[iN];
      long vN1 = _sequence[iN1];
      long vN2 = _sequence[iN2];

      int xN = marginL + iN * spacing + barW / 2;
      int xN1 = marginL + iN1 * spacing + barW / 2;
      int xN2 = marginL + iN2 * spacing + barW / 2;

      int yN = h - marginB - Math.Max(3, (int)(Math.Log(vN + 1) / logMax * barAreaH));
      int yN1 = h - marginB - Math.Max(3, (int)(Math.Log(vN1 + 1) / logMax * barAreaH));
      int yN2 = h - marginB - Math.Max(3, (int)(Math.Log(vN2 + 1) / logMax * barAreaH));

      // Klammer über F(n-2) und F(n-1)
      int bracketY = Math.Min(yN1, yN2) - 14;
      if (bracketY < 10)
      {
        bracketY = 10;
      }

      using (var pen = new Pen(Color.FromArgb(200, 255, 220, 80), 1.5f))
      {
        g.DrawLine(pen, xN2, bracketY + 6, xN2, bracketY);
        g.DrawLine(pen, xN2, bracketY, xN1, bracketY);
        g.DrawLine(pen, xN1, bracketY, xN1, bracketY + 6);
      }

      // Pfeil von Klammer-Mitte zum neuesten Balken
      int midX = (xN2 + xN1) / 2;
      using (var pen = new Pen(Color.FromArgb(200, 255, 220, 80), 1.5f))
      {
        pen.CustomEndCap = new AdjustableArrowCap(4, 4);
        g.DrawLine(pen, midX, bracketY, xN, yN - 4);
      }

      // Formel-Label
      string label = $"F({n}) = F({n - 1}) + F({n - 2})";
      using (var font = new Font("Segoe UI", 8.5f, FontStyle.Italic))
      {
        SizeF ts = g.MeasureString(label, font);
        float lx = Math.Max(2f, xN - ts.Width / 2f);
        float ly = Math.Max(2f, yN - ts.Height - 18);

        using (var bg = new SolidBrush(Color.FromArgb(190, 20, 20, 28)))
        {
          g.FillRectangle(bg, lx - 3, ly - 2, ts.Width + 6, ts.Height + 4);
        }

        g.DrawString(label, font, new SolidBrush(Color.FromArgb(255, 255, 220, 80)), lx, ly);
      }
    }

    private void DrawBoard(Graphics g, int w, int h)
    {
      g.Clear(Color.FromArgb(28, 28, 32));

      // Vor dem ersten Start: Hinweis anzeigen
      if (_sequence == null || _revealedCount == 0)
      {
        DrawHint(g, w, h);
        return;
      }

      const int marginL = 48;
      const int marginR = 20;
      const int marginB = 50;
      const int marginT = 42;

      int barAreaH = h - marginT - marginB;
      int barAreaW = w - marginL - marginR;

      int spacing = Math.Max(6, barAreaW / _termCount);
      int barW = Math.Max(3, spacing - 3);

      // Normierungsbasis: grösster Wert der VOLLSTÄNDIGEN Sequenz
      long maxVal = _sequence[_termCount - 1];
      double logMax = Math.Log(maxVal + 2);

      // Y-Achse
      DrawYAxis(g, marginL, marginT, barAreaH, maxVal, h - marginB);

      // Balken
      for (int i = 0; i < _revealedCount; i++)
      {
        long val = _sequence[i];

        // Logarithmische Skalierung für visuellen Ausgleich
        float logRatio = (float)(Math.Log(val + 1) / logMax);
        int barH = Math.Max(3, (int)(logRatio * barAreaH));
        int x = marginL + i * spacing;
        int y = h - marginB - barH;

        // Farbe: Regenbogen (blau=klein → rot=gross)
        float hue = (1f - (float)i / Math.Max(_termCount - 1, 1)) * 240f;
        Color col = HsvToRgb(hue, 0.82f, 0.90f);

        bool isNewest = (i == _revealedCount - 1);
        bool isPrev1 = (i == _revealedCount - 2);
        bool isPrev2 = (i == _revealedCount - 3);

        Color topCol = isNewest ? Lighten(col, 0.4f)
          : (isPrev1 || isPrev2) ? Lighten(col, 0.2f)
          : Lighten(col, 0.18f);
        Color botCol = isNewest ? Darken(col, 0.05f) : Darken(col, 0.28f);

        var rect = new Rectangle(x, y, barW, barH);

        if (barH > 1)
        {
          using (var brush = new LinearGradientBrush(
                   new Rectangle(rect.X, rect.Y, rect.Width, rect.Height + 1),
                   topCol,
                   botCol,
                   LinearGradientMode.Vertical))
          {
            g.FillRectangle(brush, rect);
          }
        }

        using (var pen = new Pen(
                 isNewest ? Color.White : Darken(col, 0.38f),
                 isNewest ? 1.5f : 0.8f))
        {
          g.DrawRectangle(pen, rect);
        }

        // Wert-Label (rotiert) auf dem Balken
        if (barH >= 22 && barW >= 10)
        {
          string valStr = FormatFib(val);
          int fontSize = Math.Max(6, Math.Min(9, barW - 2));
          using (var font = new Font("Segoe UI", fontSize, FontStyle.Bold))
          {
            SizeF ts = g.MeasureString(valStr, font);
            if (ts.Width <= barH - 4)
            {
              var state = g.Save();
              g.TranslateTransform(x + barW / 2f, y + barH / 2f);
              g.RotateTransform(-90);
              g.DrawString(valStr, font, Brushes.White, -ts.Width / 2f, -ts.Height / 2f);
              g.Restore(state);
            }
          }
        }

        // Index-Label unter dem Balken
        using (var font = new Font("Segoe UI", 7.5f))
        {
          string idx = (i + 1).ToString();
          SizeF ts = g.MeasureString(idx, font);
          g.DrawString(
            idx,
            font,
            Brushes.DarkGray,
            x + barW / 2f - ts.Width / 2f,
            h - marginB + 4);
        }
      }

      // Annotation: F(n) = F(n-1) + F(n-2) für den neuesten Balken
      if (_revealedCount >= 3)
      {
        DrawAnnotation(g, marginL, marginB, h, spacing, barW, barAreaH, logMax);
      }

      // Baseline
      using (var pen = new Pen(Color.FromArgb(80, 80, 80), 1))
      {
        g.DrawLine(pen, marginL - 4, h - marginB, w - marginR, h - marginB);
      }

      // Titel
      string title = $"Fibonacci-Folge  (log. Skalierung, {_termCount} Glieder)";
      using (var font = new Font("Segoe UI", 10f, FontStyle.Bold))
      {
        g.DrawString(title, font, new SolidBrush(Color.FromArgb(180, 180, 190)), marginL, 8);
      }
    }

    private void DrawYAxis(
      Graphics g,
      int marginL,
      int marginT,
      int barAreaH,
      long maxVal,
      int baseY)
    {
      using (var pen = new Pen(Color.FromArgb(70, 70, 70), 1))
      using (var font = new Font("Segoe UI", 7f))
      {
        g.DrawLine(pen, marginL - 4, marginT, marginL - 4, baseY);

        // Tick marks: 0 %, 25 %, 50 %, 75 %, 100 % (log scale)
        for (int t = 0; t <= 4; t++)
        {
          int tickY = baseY - (int)((float)t / 4 * barAreaH);
          g.DrawLine(pen, marginL - 9, tickY, marginL - 4, tickY);

          // Approximate value at this log position
          float logFrac = (float)t / 4;
          double approx = Math.Pow(maxVal + 2, logFrac) - 1;
          string label = FormatFib((long)Math.Round(approx));
          SizeF ts = g.MeasureString(label, font);
          g.DrawString(
            label,
            font,
            Brushes.DimGray,
            marginL - 10 - ts.Width,
            tickY - ts.Height / 2f);
        }
      }
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
      _revealedCount++;
      long current = _sequence[_revealedCount - 1];

      double phi = _revealedCount > 1
        ? (double)current / _sequence[_revealedCount - 2]
        : 1.0;

      string phiStr = _revealedCount > 1 ? $"  |  φ ≈ {phi:F6}" : string.Empty;

      if (_revealedCount >= _termCount)
      {
        _timer.Stop();
        _isRunning = false;
        BtnStart.Text = "Start";
        LblStatus.Text = $"Fertig – F({_termCount}) = {current:N0}{phiStr}";
      }
      else
      {
        LblStatus.Text = $"F({_revealedCount}) = {current:N0}{phiStr}";
      }

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
  }
}
