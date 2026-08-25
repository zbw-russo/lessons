namespace ZbW.ProgrammingFoundation.Lessons.Module17
{
  using Common.Attributes;

  /// <summary>
  ///   Test-UI für die selbst implementierte MinHeap-Klasse.
  ///   Alles läuft über den Studierenden-Code.
  ///   Solange ein TODO noch offen ist, zeigt die Form einen klaren Hinweis.
  /// </summary>
  [Exercise("Lessons", "Module17", "MinHeap", "MinHeap – eigene Implementierung testen")]
  public sealed partial class MinHeapForm : Form
  {
    private MinHeap _heap = new MinHeap();

    public MinHeapForm()
    {
      InitializeComponent();
      TryLoadSample();
    }

    // ── Beispielwerte laden ───────────────────────────────────────────────────

    private void TryLoadSample()
    {
      try
      {
        foreach (int v in new[] { 5, 3, 8, 1, 4, 7, 2 })
        {
          _heap.Add(v);
        }

        RefreshDisplay();
        lblStatus.Text = "Beispiel geladen: 5, 3, 8, 1, 4, 7, 2  →  Min = 1";
      }
      catch (NotImplementedException)
      {
        RefreshDisplay();
        lblStatus.Text = "⚠  Add noch nicht implementiert → TODO 1 lösen";
      }
    }

    // ── Buttons ───────────────────────────────────────────────────────────────

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (!TryGetInput(out int val))
      {
        return;
      }

      try
      {
        _heap.Add(val);
        RefreshDisplay();
        lblStatus.Text = $"✓ {val} eingefügt   Heap-Grösse: {_heap.Count}";
        txtInput.Clear();
      }
      catch (NotImplementedException)
      {
        lblStatus.Text = "⚠  Add nicht implementiert → TODO 1 lösen";
        RefreshDisplay();
      }
    }

    private void btnPeek_Click(object sender, EventArgs e)
    {
      try
      {
        int min = _heap.Peek();
        lblStatus.Text = $"Peek → Minimum = {min}  (Heap unverändert)";
        lblMin.Text = min.ToString();
      }
      catch (NotImplementedException)
      {
        lblStatus.Text = "⚠  Peek nicht implementiert → TODO 2 lösen";
      }
      catch (InvalidOperationException ex)
      {
        lblStatus.Text = ex.Message;
      }
    }

    private void btnPop_Click(object sender, EventArgs e)
    {
      try
      {
        int min = _heap.Pop();
        RefreshDisplay();
        lblStatus.Text = $"Pop → {min} entfernt   Heap-Grösse: {_heap.Count}";
        lblMin.Text = _heap.IsEmpty ? "–" : "?";
      }
      catch (NotImplementedException)
      {
        lblStatus.Text = "⚠  Pop nicht implementiert → TODO 3 lösen";
      }
      catch (InvalidOperationException ex)
      {
        lblStatus.Text = ex.Message;
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      _heap = new MinHeap();
      RefreshDisplay();
      lblStatus.Text = "Heap geleert";
      lblMin.Text = "–";
    }

    private void txtInput_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        e.SuppressKeyPress = true;
        btnAdd_Click(sender, e);
      }
    }

    // ── Anzeige aktualisieren ─────────────────────────────────────────────────

    private void RefreshDisplay()
    {
      lstHeap.Items.Clear();

      if (_heap.IsEmpty)
      {
        lstHeap.Items.Add("(Heap ist leer)");
        lblHeapArray.Text = "Array: []";
        lblMin.Text = "–";
        return;
      }

      // Heap als Array anzeigen
      lblHeapArray.Text = $"Array: {_heap}";

      // Baum-Darstellung im ListBox
      lstHeap.Items.Add("Heap als Baum:");
      lstHeap.Items.Add("");

      try
      {
        // Peek für Min-Anzeige
        lblMin.Text = _heap.Peek().ToString();
      }
      catch (NotImplementedException)
      {
        lblMin.Text = "TODO 2";
      }

      // Einfache Level-Darstellung
      lstHeap.Items.Add(_heap.ToString());
      lstHeap.Items.Add("");
      lstHeap.Items.Add("Erklärung der Positionen:");
      lstHeap.Items.Add("  Parent(i)  = (i - 1) / 2");
      lstHeap.Items.Add("  Links(i)   = 2 * i + 1");
      lstHeap.Items.Add("  Rechts(i)  = 2 * i + 2");
    }

    // ── Eingabe ───────────────────────────────────────────────────────────────

    private bool TryGetInput(out int val)
    {
      val = 0;
      if (string.IsNullOrWhiteSpace(txtInput.Text))
      {
        lblStatus.Text = "Bitte eine Zahl eingeben";
        return false;
      }

      if (!int.TryParse(txtInput.Text.Trim(), out val))
      {
        lblStatus.Text = "Ungültige Eingabe – nur ganze Zahlen";
        return false;
      }

      return true;
    }
  }
}
