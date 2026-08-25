namespace ZbW.ProgrammingFoundation.Challenges.Module17.Huffman
{

  using ZbW.ProgrammingFoundation.Common.Attributes;

  /// <summary>
  ///   Aufgabe – Huffman-Codierung testen.
  ///   Verwendet die noch zu implementierenden Klassen aus ZbW.ProgrammingFoundation.Challenges.Module17.Huffman.
  ///   Solange ein TODO offen ist, zeigt die Form einen Hinweis.
  /// </summary>
  [Exercise("Challenges", "Module17", "Huffman", "Codierung")]
  public sealed partial class HuffmanForm : Form
  {
    public HuffmanForm()
    {
      InitializeComponent();
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

      try
      {
        var frequencies = new Frequency().CountFrequency(text);

        lstOutput.Items.Add("Häufigkeiten:");
        foreach (var entry in frequencies)
        {
          lstOutput.Items.Add($"  '{entry.Value}' : {entry.Key}");
        }

        var tree = new HuffmanTree(frequencies);
        char[] bits = new char[frequencies.Count + 1];

        var sw = new System.IO.StringWriter();
        var oldOut = Console.Out;
        Console.SetOut(sw);
        int total = HuffmanTree.AssignBits(tree.Root, bits, 0);
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
        lstOutput.Items.Add($"Gesamtlänge codiert: {total} Bit");
        lblStatus.Text = "✓ Codierung erstellt";
      }
      catch (NotImplementedException)
      {
        lstOutput.Items.Add("⚠  Noch nicht implementiert");
        lblStatus.Text = "⚠  Huffman noch nicht implementiert → TODOs in Frequency/HuffmanTree lösen";
      }
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      lstOutput.Items.Clear();
      lblStatus.Text = "Geleert";
    }
  }
}
