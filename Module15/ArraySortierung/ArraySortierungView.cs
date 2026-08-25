namespace ZbW.ProgrammingFoundation.Lessons.Module15.ArraySortierung
{

  /// <summary>
  ///   Visualisiert das Erstellen und Sortieren eines zufälligen Integer-Arrays.
  ///   Zeigt beide Arrays – unsortiert und sortiert – als Balken-Diagramm nebeneinander.
  /// </summary>
  public partial class ArraySortierungView : Form
  {
    private ArraySortierungErgebnis _ergebnis = new();

    public ArraySortierungView()
    {
      InitializeComponent();
    }

    private void BtnGenerieren_Click(object sender, EventArgs e)
    {
      int laenge = (int)NudLaenge.Value;
      int min = (int)NudMin.Value;
      int max = (int)NudMax.Value;

      try
      {
        _ergebnis = ArraySortierungLogik.Generieren(laenge, min, max);
        BtnSortieren.Enabled = true;
        ZeigeStatus();
      }
      catch (ArgumentException ex)
      {
        LblStatus.Text = ex.Message;
        LblStatus.ForeColor = Color.FromArgb(220, 80, 80);
        return;
      }

      PnlBoard.Invalidate();
    }

    private void BtnSortieren_Click(object sender, EventArgs e)
    {
      if (_ergebnis.Original.Length == 0)
      {
        return;
      }

      _ergebnis = ArraySortierungLogik.BubbleSortieren(_ergebnis.Original);
      ZeigeStatus();
      PnlBoard.Invalidate();
    }

    private void ZeigeStatus()
    {
      LblStatus.Text = $"{_ergebnis.Original.Length} Elemente  |  Min: {_ergebnis.Min}  |  Max: {_ergebnis.Max}  |  Ø {_ergebnis.Durchschnitt:F1}";
      LblStatus.ForeColor = Color.FromArgb(160, 160, 175);
    }

    private void PnlBoard_Paint(object sender, PaintEventArgs e)
    {
      DrawBoard(e.Graphics, PnlBoard.Width, PnlBoard.Height);
    }

    private void DrawBoard(Graphics g, int w, int h)
    {
      g.Clear(Color.FromArgb(28, 28, 32));

      if (_ergebnis.Original.Length == 0)
      {
        DrawHinweis(g, w, h);
        return;
      }

      int halfH = h / 2;

      // Trennlinie in der Mitte
      g.DrawLine(new Pen(Color.FromArgb(60, 60, 70), 1), 0, halfH, w, halfH);

      DrawArrayBereich(g, w, halfH, _ergebnis.Original, "Unsortiert", useValueColor: false);

      // Untere Hälfte: sortiertes Array (Ursprung y = halfH)
      var state = g.Save();
      g.TranslateTransform(0, halfH);
      if (_ergebnis.Sortiert.Length == 0)
      {
        DrawSortierHinweis(g, w, halfH);
      }
      else
      {
        string titel = $"Sortiert  ({_ergebnis.SortierMethode})";
        DrawArrayBereich(g, w, halfH, _ergebnis.Sortiert, titel, useValueColor: true);
      }
      g.Restore(state);
    }

    private void DrawArrayBereich(Graphics g, int w, int h, int[] arr, string titel, bool useValueColor)
    {
      // Titel
      using (var f = new Font("Segoe UI", 10f, FontStyle.Bold))
      {
        g.DrawString(titel, f, new SolidBrush(Color.FromArgb(180, 180, 195)), 12, 8);
      }

      if (arr.Length == 0)
      {
        return;
      }

      int margin = 12;
      int labelH = 28;  // Platz oben für Titel
      int indexH = 16;  // Platz unten für Indizes
      int availW = w - margin * 2;
      int availH = h - labelH - indexH - 8;

      int boxW = Math.Max(4, availW / arr.Length - 2);
      int gap = Math.Max(1, (availW - arr.Length * boxW) / Math.Max(1, arr.Length - 1));

      int globalMin = arr.Min();
      int globalMax = arr.Max();
      int valueRange = globalMax == globalMin ? 1 : globalMax - globalMin;

      for (int i = 0; i < arr.Length; i++)
      {
        float ratio = (float)(arr[i] - globalMin) / valueRange;
        int barH = Math.Max(4, (int)(availH * ratio));

        int x = margin + i * (boxW + gap);
        int y = labelH + (availH - barH);

        Color bg = useValueColor
          ? GetGradientColor(ratio)                         // sortiert: Farbverlauf kalt → warm
          : Color.FromArgb(60, 120, 190);                   // unsortiert: einheitliches Blau

        var rect = new Rectangle(x, y, boxW, barH);
        g.FillRectangle(new SolidBrush(bg), rect);
        g.DrawRectangle(new Pen(Color.FromArgb(80, 80, 95), 1), rect);

        // Wert oben auf dem Balken (nur wenn genug Platz)
        if (boxW >= 20)
        {
          using (var f = new Font("Segoe UI", 7.5f))
          {
            string val = arr[i].ToString();
            SizeF ts = g.MeasureString(val, f);
            if (ts.Width <= boxW + 2)
            {
              float tx = x + boxW / 2f - ts.Width / 2f;
              float ty = Math.Max(labelH, y - ts.Height - 1);
              g.DrawString(val, f, new SolidBrush(Color.FromArgb(200, 200, 210)), tx, ty);
            }
          }
        }

        // Index unter Box (nur wenn genug Platz)
        if (boxW >= 16 && arr.Length <= 40)
        {
          using (var f = new Font("Segoe UI", 7f))
          {
            string idx = i.ToString();
            SizeF ts = g.MeasureString(idx, f);
            float tx = x + boxW / 2f - ts.Width / 2f;
            g.DrawString(idx, f, new SolidBrush(Color.FromArgb(90, 90, 105)), tx, labelH + availH + 2);
          }
        }
      }

      // Zahlenwerte als Text rechts unten
      if (arr.Length <= 50)
      {
        using (var f = new Font("Consolas", 8.5f))
        {
          string text = "[ " + string.Join(", ", arr) + " ]";
          SizeF ts = g.MeasureString(text, f);
          float maxW = w - margin * 2;
          if (ts.Width <= maxW)
          {
            g.DrawString(text, f, new SolidBrush(Color.FromArgb(100, 100, 115)), margin, h - indexH - 2);
          }
        }
      }
    }

    private static Color GetGradientColor(float ratio)
    {
      // 0.0 = kalt (Blau), 0.5 = Grün, 1.0 = warm (Rot-Orange)
      if (ratio < 0.5f)
      {
        float t = ratio * 2f;
        return Color.FromArgb(
          (int)(0 + 0 * t),
          (int)(80 + 140 * t),
          (int)(190 - 90 * t));
      }
      else
      {
        float t = (ratio - 0.5f) * 2f;
        return Color.FromArgb(
          (int)(180 * t),
          (int)(220 - 160 * t),
          (int)(100 - 100 * t));
      }
    }

    private static void DrawSortierHinweis(Graphics g, int w, int h)
    {
      using (var f = new Font("Segoe UI", 11f))
      {
        const string text = "⇅ Bubble Sort klicken um zu sortieren";
        SizeF ts = g.MeasureString(text, f);
        g.DrawString(text, f, new SolidBrush(Color.FromArgb(100, 100, 115)), w / 2f - ts.Width / 2f, h / 2f - ts.Height / 2f);
      }
    }

    private static void DrawHinweis(Graphics g, int w, int h)
    {
      string[] zeilen = { "Array-Sortierung", "", "Länge, Min- und Max-Wert wählen,", "dann  ► Generieren  klicken" };

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
