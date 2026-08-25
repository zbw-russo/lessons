namespace ZbW.ProgrammingFoundation.Challenges.Module17.Flughafen
{

  using ZbW.ProgrammingFoundation.Common.Attributes;

  /// <summary>
  ///   Prioritätswarteschlange für Flugzeuge.
  ///   Flugzeuge mit dem wenigsten Treibstoff landen zuerst (MinHeap / PriorityQueue).
  /// </summary>
  [Exercise("Challenges", "Module17", "Flughafen", "Flughafen – Priority Queue")]
  public sealed partial class FlughafenForm : Form
  {
    private LandingOrder _landingOrder = new LandingOrder();
    private int _counter = 1;

    public FlughafenForm()
    {
      InitializeComponent();
      LoadSample();
    }

    private void LoadSample()
    {
      try
      {
        AddPlane("ZRH", 800);
        AddPlane("FRA", 3200);
        AddPlane("LHR", 1500);
        AddPlane("JFK", 400);
        AddPlane("CDG", 2100);
        lblStatus.Text = "5 Flugzeuge in die Warteschlange geladen";
      }
      catch (NotImplementedException)
      {
        _landingOrder = new LandingOrder();
        lblStatus.Text = "⚠  LandingOrder noch nicht implementiert → TODOs in LandingOrder lösen";
      }
    }

    // ── Buttons ───────────────────────────────────────────────────────────────

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (!int.TryParse(txtFuel.Text.Trim(), out int fuel) || fuel < 0)
      {
        lblStatus.Text = "Bitte gültige Treibstoffmenge eingeben (≥ 0)";
        return;
      }

      string airport = string.IsNullOrWhiteSpace(txtAirport.Text) ? $"PLANE-{_counter}" : txtAirport.Text.Trim().ToUpper();
      try
      {
        AddPlane(airport, fuel);
        lblStatus.Text = $"✓ {airport} ({fuel} L) in die Warteschlange";
        txtAirport.Clear();
        txtFuel.Clear();
      }
      catch (NotImplementedException)
      {
        lblStatus.Text = "⚠  AddAirplane noch nicht implementiert → TODO in LandingOrder lösen";
      }
    }

    private void btnLand_Click(object sender, EventArgs e)
    {
      try
      {
        Airplane plane = _landingOrder.GetNextAirplane();
        lstLanded.Items.Insert(0, $"✈  {plane.DepartureAirport}  –  {plane.QuantityOfPetrol} L Treibstoff");
        lblStatus.Text = $"✈ {plane.DepartureAirport} landet ({plane.QuantityOfPetrol} L) – nächstes Flugzeug abrufen";
        RefreshQueue();
      }
      catch (InvalidOperationException)
      {
        lblStatus.Text = "Keine Flugzeuge in der Warteschlange";
      }
      catch (NotImplementedException)
      {
        lblStatus.Text = "⚠  GetNextAirplane noch nicht implementiert → TODO in LandingOrder lösen";
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      _landingOrder = new LandingOrder();
      lstQueue.Items.Clear();
      lstLanded.Items.Clear();
      lblStatus.Text = "Warteschlange geleert";
    }

    private void txtFuel_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        e.SuppressKeyPress = true;
        btnAdd_Click(sender, e);
      }
    }

    // ── Hilfsmethoden ─────────────────────────────────────────────────────────

    private void AddPlane(string airport, int fuel)
    {
      var plane = new Airplane(airport, fuel);
      _landingOrder.AddAirplane(plane);
      _counter++;
      RefreshQueue();
    }

    private void RefreshQueue()
    {
      // Da PriorityQueue kein Enumerate bietet, zeigen wir nur was eingetragen wurde.
      // Die Reihenfolge ergibt sich beim Landen.
      lstQueue.Items.Clear();
      lstQueue.Items.Add("(Reihenfolge wird beim Landen bestimmt)");
      lstQueue.Items.Add("Priorität: wenigster Treibstoff landet zuerst");
    }
  }
}
