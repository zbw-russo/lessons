namespace ZbW.ProgrammingFoundation.Challenges.Module17.MinMaxHeap.Loesung
{

  using ZbW.ProgrammingFoundation.Common.Attributes;

  /// <summary>
  ///   Lauffähige Musterlösung für MinHeap und MaxHeap nebeneinander.
  ///   Verwendet die vollständig implementierten Klassen aus ZbW.ProgrammingFoundation.Challenges.Module17.MinMaxHeap.Loesung.
  /// </summary>
  [Exercise("Challenges", "Module17", "MinMaxHeap (Lösung)", "MinHeap & MaxHeap – Vergleich")]
  public sealed partial class MinMaxHeapLoesungForm : Form
  {
    private MinHeap _minHeap = new MinHeap();
    private MaxHeap _maxHeap = new MaxHeap();

    public MinMaxHeapLoesungForm()
    {
      InitializeComponent();
      LoadSample();
    }

    // ── Beispieldaten ─────────────────────────────────────────────────────────

    private void LoadSample()
    {
      int[] values = { 5, 3, 8, 1, 4, 7, 2, 9, 6 };
      foreach (int v in values)
      {
        _minHeap.Add(v);
        _maxHeap.Add(v);
      }

      RefreshBoth();
      lblStatus.Text = $"Beispieldaten geladen: {string.Join(", ", values)}";
    }

    // ── Buttons ───────────────────────────────────────────────────────────────

    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (!TryGetInput(out int val))
      {
        return;
      }

      _minHeap.Add(val);
      _maxHeap.Add(val);
      RefreshBoth();
      lblStatus.Text = $"✓ {val} in beide Heaps eingefügt";
      txtInput.Clear();
    }

    private void btnPopMin_Click(object sender, EventArgs e)
    {
      if (_minHeap.Empty)
      {
        lblStatus.Text = "MinHeap ist leer";
        return;
      }

      object val = _minHeap.Pop();
      RefreshBoth();
      lblStatus.Text = $"MinHeap Pop → {val} (Minimum) entfernt";
    }

    private void btnPopMax_Click(object sender, EventArgs e)
    {
      if (_maxHeap.Empty)
      {
        lblStatus.Text = "MaxHeap ist leer";
        return;
      }

      object val = _maxHeap.Pop();
      RefreshBoth();
      lblStatus.Text = $"MaxHeap Pop → {val} (Maximum) entfernt";
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      _minHeap = new MinHeap();
      _maxHeap = new MaxHeap();
      RefreshBoth();
      lblStatus.Text = "Beide Heaps geleert";
    }

    private void txtInput_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        e.SuppressKeyPress = true;
        btnAdd_Click(sender, e);
      }
    }

    // ── Anzeige ───────────────────────────────────────────────────────────────

    private void RefreshBoth()
    {
      RefreshHeap(lstMin, lblMinArray, lblMinTop, _minHeap, "Min");
      RefreshHeap(lstMax, lblMaxArray, lblMaxTop, _maxHeap, "Max");
    }

    private static void RefreshHeap(ListBox lst, Label lblArray, Label lblTop, dynamic heap, string label)
    {
      lst.Items.Clear();

      if (heap.Empty)
      {
        lblArray.Text = $"{label}Heap Array: []";
        lblTop.Text   = "–";
        lst.Items.Add("(leer)");
        return;
      }

      lblTop.Text   = heap.Peek().ToString();
      lblArray.Text = $"{label}Heap Array: {HeapToString(heap)}";

      BuildTreeView(lst, heap);
    }

    private static string HeapToString(dynamic heap)
    {
      var sw = new System.IO.StringWriter();
      var oldOut = Console.Out;
      Console.SetOut(sw);
      heap.PrintHeap();
      Console.SetOut(oldOut);
      return sw.ToString().Trim();
    }

    private static void BuildTreeView(ListBox lst, dynamic heap)
    {
      var sw = new System.IO.StringWriter();
      var oldOut = Console.Out;
      Console.SetOut(sw);
      heap.PrintHeap();
      Console.SetOut(oldOut);
      string arrayStr = sw.ToString().Trim();

      lst.Items.Add("Array-Darstellung:");
      lst.Items.Add($"  {arrayStr}");
      lst.Items.Add("");
      lst.Items.Add("Index-Formeln:");
      lst.Items.Add("  Parent(i) = (i-1)/2");
      lst.Items.Add("  Links(i)  = 2*i+1");
      lst.Items.Add("  Rechts(i) = 2*i+2");
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
