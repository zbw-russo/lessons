namespace ZbW.ProgrammingFoundation.Challenges.Module17.Huffman.Loesung
{
  using ZbW.ProgrammingFoundation.Common.Attributes;

  /// <summary>
  ///   Lauffähige Musterlösung der Huffman-Codierung.
  ///   Verwendet die vollständig implementierten Klassen aus ZbW.ProgrammingFoundation.Challenges.Module17.Huffman.Loesung.
  /// </summary>
  [Exercise("Challenges", "Module17", "Huffman (Lösung)", "Codierung")]
  public sealed partial class HuffmanLoesungForm : Form
  {
    public HuffmanLoesungForm()
    {
      InitializeComponent();
      txtText.Text = "hello world";
      lblStatus.Text = "Text eingeben und 'Codieren' klicken";
    }

    private void btnEncode_Click(object sender, EventArgs e)
    {
      lstOutput.Items.Clear();

      string text = txtText.Text;
      if (string.IsNullOrEmpty(text))
      {
        lblStatus.Text = "Bitte einen Text eingeben";
        return;
      }

      var frequencies = new ZbW.ProgrammingFoundation.Challenges.Module17.Huffman.Loesung.Frequency().CountFrequency(text);

      lstOutput.Items.Add("Häufigkeiten:");
      foreach (var entry in frequencies)
      {
        lstOutput.Items.Add($"  '{entry.Value}' : {entry.Key}");
      }

      var tree = new ZbW.ProgrammingFoundation.Challenges.Module17.Huffman.Loesung.HuffmanTree(frequencies);
      char[] bits = new char[frequencies.Count + 1];

      var sw = new System.IO.StringWriter();
      var oldOut = Console.Out;
      Console.SetOut(sw);
      int total = ZbW.ProgrammingFoundation.Challenges.Module17.Huffman.Loesung.HuffmanTree.AssignBits(tree.Root, bits, 0);
      Console.SetOut(oldOut);

      lstOutput.Items.Add(string.Empty);
      lstOutput.Items.Add("Bitcodes:");
      foreach (var line in sw.ToString().Split('\n'))
      {
        if (line.Trim().Length > 0)
        {
          lstOutput.Items.Add("  " + line.Trim());
        }
      }

      lstOutput.Items.Add(string.Empty);
      lstOutput.Items.Add($"Gesamtlänge codiert: {total} Bit  ({text.Length} Zeichen)");
      lblStatus.Text = $"✓ {frequencies.Count} verschiedene Zeichen codiert";
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      lstOutput.Items.Clear();
      lblStatus.Text = "Geleert";
    }
  }
}
