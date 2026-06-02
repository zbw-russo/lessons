namespace ZbW.ProgrammingFoundation.Lessons.Module12.MuenzWechsel
{
  using Timer = System.Windows.Forms.Timer;

  /// <summary>
  ///   Visualisiert den Greedy-Algorithmus für das Münzwechselproblem.
  ///   Die Münzen werden Schritt für Schritt animiert eingeblendet.
  /// </summary>
  public partial class MuenzWechselView : Form
  {
    // Vordefinierte Münzsysteme (Werte in der kleinsten Einheit: Rappen / Cents)
    private static readonly int[] MuenzenChf = { 5, 10, 20, 50, 100, 200, 500 };
    private static readonly int[] MuenzenEur = { 1, 2, 5, 10, 20, 50, 100, 200 };

    private readonly Timer _timer;
    private int _anzahlAngezeigt; // wie viele Münzen bereits eingeblendet sind

    private List<int> _gewaehlteMuenzen; // Münzen in der Reihenfolge, wie Greedy sie wählt
    private bool _isRunning;
    private int _startBetrag; // ursprünglicher Betrag für die Anzeige
    private string _waehrung; // aktuell gewählte Währung ("CHF", "EUR", "Benutzerdefiniert")

    public MuenzWechselView()
    {
      InitializeComponent();
      _timer = new Timer { Interval = 400 };
      _timer.Tick += OnTimerTick;
      _waehrung = "CHF";
      CmbWaehrung_SelectedIndexChanged(this, EventArgs.Empty); // Label beim Start initialisieren
    }

    private static void DrawHinweis(Graphics g, int w, int h)
    {
      string[] zeilen = { "Münzwechsel – Greedy Algorithmus", "", "Währung und Betrag wählen,", "dann  ► Start  klicken" };

      using (var titel = new Font("Segoe UI", 16f, FontStyle.Bold))
      using (var text = new Font("Segoe UI", 11f))
      {
        float y = h / 2f - 60;
        foreach (string zeile in zeilen)
        {
          if (zeile.Length == 0)
          {
            y += 10;
            continue;
          }

          Font f = zeile == zeilen[0] ? titel : text;
          Color c = zeile == zeilen[0] ? Color.FromArgb(200, 200, 210) : Color.FromArgb(130, 130, 140);
          SizeF ts = g.MeasureString(zeile, f);
          g.DrawString(zeile, f, new SolidBrush(c), w / 2f - ts.Width / 2f, y);
          y += ts.Height + 4;
        }
      }
    }

    private static Color WertZuFarbe(int wert)
    {
      if (wert >= 500)
      {
        return Color.FromArgb(200, 160, 50); // gold (5 Fr. / 5 €)
      }

      if (wert >= 200)
      {
        return Color.FromArgb(180, 140, 60); // gold
      }

      if (wert >= 100)
      {
        return Color.FromArgb(160, 120, 50); // gold
      }

      if (wert >= 50)
      {
        return Color.FromArgb(140, 100, 160); // silber-violett
      }

      if (wert >= 20)
      {
        return Color.FromArgb(100, 130, 170); // silber-blau
      }

      if (wert >= 10)
      {
        return Color.FromArgb(80, 120, 80); // silber-grün
      }

      if (wert >= 5)
      {
        return Color.FromArgb(160, 80, 80); // kupfer
      }

      return Color.FromArgb(110, 90, 80); // dunkelkupfer (1/2 Ct)
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

      if (!int.TryParse(TxtBetrag.Text.Trim(), out int betrag) || betrag <= 0)
      {
        LblStatus.Text = "Ungültiger Betrag!";
        return;
      }

      int[] muenzen = LeseMuenzen();
      if (muenzen == null)
      {
        return;
      }

      _waehrung = CmbWaehrung.SelectedItem.ToString();
      _startBetrag = betrag;
      _gewaehlteMuenzen = MuenzWechselLogik.BerechneWechselgeld(betrag, muenzen);
      _anzahlAngezeigt = 0;

      _timer.Interval = Math.Max(1, 1010 - TrkSpeed.Value * 10);
      _isRunning = true;
      BtnStart.Text = "Stop";
      LblStatus.Text = $"0 / {_gewaehlteMuenzen.Count} Münzen";
      _timer.Start();
      PnlBoard.Invalidate();
    }

    private void CmbWaehrung_SelectedIndexChanged(object sender, EventArgs e)
    {
      _waehrung = CmbWaehrung.SelectedItem.ToString();

      switch (_waehrung)
      {
        case "CHF":
          TxtMuenzen.Text = "5, 10, 20, 50, 100, 200, 500";
          TxtMuenzen.ReadOnly = true;
          TxtBetrag.Text = "87";
          break;
        case "EUR":
          TxtMuenzen.Text = "1, 2, 5, 10, 20, 50, 100, 200";
          TxtMuenzen.ReadOnly = true;
          TxtBetrag.Text = "87";
          break;
        default: // Benutzerdefiniert
          TxtMuenzen.ReadOnly = false;
          break;
      }

      LblBetrag.Text = $"Betrag ({EinheitKlein()}):";
    }

    private void DrawBoard(Graphics g, int w, int h)
    {
      g.Clear(Color.FromArgb(28, 28, 32));

      if (_gewaehlteMuenzen == null || _gewaehlteMuenzen.Count == 0)
      {
        DrawHinweis(g, w, h);
        return;
      }

      const int muenzDurchmesser = 70;
      const int abstand = 12;
      const int zeilenHoehe = muenzDurchmesser + abstand + 24;
      int proZeile = Math.Max(1, (w - 40) / (muenzDurchmesser + abstand));

      for (int i = 0; i < _anzahlAngezeigt; i++)
      {
        int spalte = i % proZeile;
        int zeile = i / proZeile;
        int x = 20 + spalte * (muenzDurchmesser + abstand);
        int y = 20 + zeile * zeilenHoehe;
        DrawMuenze(g, x, y, muenzDurchmesser, _gewaehlteMuenzen[i], i == _anzahlAngezeigt - 1);
      }

      int restbetrag = _startBetrag - _gewaehlteMuenzen.Take(_anzahlAngezeigt).Sum();
      string info = $"Betrag: {FormatiereBetrag(_startBetrag)}  |  Gewechselt: {FormatiereBetrag(_startBetrag - restbetrag)}  |  Rest: {FormatiereBetrag(restbetrag)}";
      using (var font = new Font("Segoe UI", 10f, FontStyle.Bold))
      {
        SizeF ts = g.MeasureString(info, font);
        g.DrawString(info, font, new SolidBrush(Color.FromArgb(180, 180, 190)), w / 2f - ts.Width / 2f, h - 36);
      }
    }

    private void DrawMuenze(Graphics g, int x, int y, int durchmesser, int wert, bool hervorheben)
    {
      Color farbe = WertZuFarbe(wert);
      Color rand = hervorheben
        ? Color.White
        : Color.FromArgb(Math.Max(0, farbe.R - 60), Math.Max(0, farbe.G - 60), Math.Max(0, farbe.B - 60));

      var rect = new Rectangle(x, y, durchmesser, durchmesser);

      using (var pinsel = new SolidBrush(farbe))
      {
        g.FillEllipse(pinsel, rect);
      }

      using (var stift = new Pen(rand, hervorheben ? 3f : 1.5f))
      {
        g.DrawEllipse(stift, rect);
      }

      string text = FormatiereMuenze(wert);
      using (var font = new Font("Segoe UI", wert >= 100 ? 9f : 10f, FontStyle.Bold))
      {
        SizeF ts = g.MeasureString(text, font);
        g.DrawString(text, font, Brushes.White, x + durchmesser / 2f - ts.Width / 2f, y + durchmesser / 2f - ts.Height / 2f);
      }
    }

    /// <summary>Gibt die Bezeichnung der kleinsten Einheit zurück (für Labels).</summary>
    private string EinheitKlein()
    {
      switch (_waehrung)
      {
        case "CHF": return "Rappen";
        case "EUR": return "Cents";
        default: return "Einheiten";
      }
    }

    /// <summary>Formatiert einen Betrag (in kleinster Einheit) als lesbaren Text.</summary>
    private string FormatiereBetrag(int betrag)
    {
      switch (_waehrung)
      {
        case "CHF": return $"{betrag} Rp";
        case "EUR": return $"{betrag} Ct";
        default: return betrag.ToString();
      }
    }

    /// <summary>Formatiert einen Münzwert als lesbaren Text je nach Währung.</summary>
    private string FormatiereMuenze(int wert)
    {
      switch (_waehrung)
      {
        case "CHF": return wert >= 100 ? $"{wert / 100} Fr." : $"{wert} Rp";
        case "EUR": return wert >= 100 ? $"{wert / 100} €" : $"{wert} Ct";
        default: return wert.ToString();
      }
    }

    private int[] LeseMuenzen()
    {
      var muenzen = new List<int>();
      foreach (string teil in TxtMuenzen.Text.Split(','))
      {
        if (int.TryParse(teil.Trim(), out int wert) && wert > 0)
        {
          muenzen.Add(wert);
        }
      }

      if (muenzen.Count == 0)
      {
        LblStatus.Text = "Keine gültigen Münzen!";
        return null;
      }

      return muenzen.ToArray();
    }

    private void OnTimerTick(object sender, EventArgs e)
    {
      _anzahlAngezeigt++;

      int restbetrag = _startBetrag - _gewaehlteMuenzen.Take(_anzahlAngezeigt).Sum();
      int aktuelleMuenze = _gewaehlteMuenzen[_anzahlAngezeigt - 1];
      LblStatus.Text = $"Münze {_anzahlAngezeigt}/{_gewaehlteMuenzen.Count}: -{FormatiereBetrag(aktuelleMuenze)}  |  Rest: {FormatiereBetrag(restbetrag)}";

      if (_anzahlAngezeigt >= _gewaehlteMuenzen.Count)
      {
        _timer.Stop();
        _isRunning = false;
        BtnStart.Text = "Start";
        LblStatus.Text = $"Fertig – {_gewaehlteMuenzen.Count} Münzen für {FormatiereBetrag(_startBetrag)}";
      }

      PnlBoard.Invalidate();
    }

    private void PnlBoard_Paint(object sender, PaintEventArgs e)
    {
      DrawBoard(e.Graphics, PnlBoard.Width, PnlBoard.Height);
    }
  }
}
