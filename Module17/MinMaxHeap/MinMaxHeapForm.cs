namespace ZbW.ProgrammingFoundation.Challenges.Module17.MinMaxHeap
{

  using ZbW.ProgrammingFoundation.Common.Attributes;

  /// <summary>
  ///   Interaktive Demo für MinHeap und MaxHeap nebeneinander.
  ///   Zeigt wie sich die beiden Heap-Varianten beim Einfügen und Entfernen unterscheiden.
  /// </summary>
  [Exercise("Challenges", "Module17", "MinMaxHeap", "MinHeap & MaxHeap – Vergleich")]
  public sealed partial class MinMaxHeapForm : Form
  {
    private MinHeap _minHeap = new MinHeap();
    private MaxHeap _maxHeap = new MaxHeap();

    public MinMaxHeapForm()
    {
      InitializeComponent();
      LoadSample();
    }

    // ── Beispieldaten ─────────────────────────────────────────────────────────

    private void LoadSample()
    {
      int[] values = { 5, 3, 8, 1, 4, 7, 2, 9, 6 };
      try
      {
        foreach (int v in values)
        {
          _minHeap.Add(v);
          _maxHeap.Add(v);
        }

        RefreshBoth();
        lblStatus.Text = $"Beispieldaten geladen: {string.Join(", ", values)}";
      }
      catch (NotImplementedException)
      {
        _minHeap = new MinHeap();
        _maxHeap = new MaxHeap();
        RefreshBoth();
        lblStatus.Text = "⚠  Heap-Methoden noch nicht implementiert → TODOs in MinHeap/MaxHeap lösen";
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
        _minHeap.Add(val);
        _maxHeap.Add(val);
        RefreshBoth();
        lblStatus.Text = $"✓ {val} in beide Heaps eingefügt";
        txtInput.Clear();
      }
      catch (NotImplementedException)
      {
        lblStatus.Text = "⚠  Add noch nicht implementiert → TODO in MinHeap/MaxHeap lösen";
      }
    }

    private void btnPopMin_Click(object sender, EventArgs e)
    {
      if (_minHeap.Empty)
      {
        lblStatus.Text = "MinHeap ist leer";
        return;
      }

      try
      {
        object val = _minHeap.Pop();
        RefreshBoth();
        lblStatus.Text = $"MinHeap Pop → {val} (Minimum) entfernt";
      }
      catch (NotImplementedException)
      {
        lblStatus.Text = "⚠  Pop noch nicht implementiert → TODO in MinHeap lösen";
      }
    }

    private void btnPopMax_Click(object sender, EventArgs e)
    {
      if (_maxHeap.Empty)
      {
        lblStatus.Text = "MaxHeap ist leer";
        return;
      }

      try
      {
        object val = _maxHeap.Pop();
        RefreshBoth();
        lblStatus.Text = $"MaxHeap Pop → {val} (Maximum) entfernt";
      }
      catch (NotImplementedException)
      {
        lblStatus.Text = "⚠  Pop noch nicht implementiert → TODO in MaxHeap lösen";
      }
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

      // Top-Element
      try
      {
        lblTop.Text = heap.Peek().ToString();
      }
      catch (NotImplementedException)
      {
        lblTop.Text = "TODO Peek";
      }

      lblArray.Text = $"{label}Heap Array: {HeapToString(heap)}";

      // Baum-Level-Darstellung
      BuildTreeView(lst, heap);
    }

    private static string HeapToString(dynamic heap)
    {
      // PrintHeap schreibt auf Console – wir bauen selbst einen String
      var sb = new System.Text.StringBuilder("[");
      bool first = true;
      int size = heap.Size;
      // Wir piepen uns durch Pop/Peek nicht – nutzen Größe und String-Darstellung
      // Da ArrayList nicht direkt zugänglich, nutzen wir Size + PrintHeap-Redirect
      // Einfachste Lösung: mehrfaches Peek+Pop ist destruktiv → ToString nutzen
      // → Heap hat kein ToString, daher nutzen wir PrintHeap mit Console-Redirect
      var sw = new System.IO.StringWriter();
      var oldOut = Console.Out;
      Console.SetOut(sw);
      heap.PrintHeap();
      Console.SetOut(oldOut);
      return sw.ToString().Trim();
    }

    private static void BuildTreeView(ListBox lst, dynamic heap)
    {
      // Level-Darstellung via Console-Redirect von PrintHeap
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
