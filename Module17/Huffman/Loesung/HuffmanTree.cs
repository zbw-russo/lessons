namespace ZbW.ProgrammingFoundation.Challenges.Module17.Huffman.Loesung
{
  /// <summary>
  ///   Musterlösung – baut den Huffman-Baum aus einer Häufigkeitstabelle und
  ///   bestimmt die Bitcodes der Zeichen.
  /// </summary>
  public class HuffmanTree
  {
    /// <summary>
    ///   Baut den Huffman-Baum: Die beiden Knoten mit der geringsten Häufigkeit werden
    ///   wiederholt zu einem neuen Knoten zusammengefasst, bis nur noch die Wurzel übrig ist.
    ///   Als Prioritätswarteschlange (MinHeap nach Häufigkeit) dient PriorityQueue&lt;Node, int&gt;.
    /// </summary>
    public HuffmanTree(ICollection<Entry> frequencies)
    {
      var queue = new PriorityQueue<Node, int>();

      foreach (var entry in frequencies)
      {
        queue.Enqueue(new Node(entry), entry.Key);
      }

      if (queue.Count == 0)
      {
        Root = null;
        return;
      }

      while (queue.Count > 1)
      {
        Node left  = queue.Dequeue();
        Node right = queue.Dequeue();

        int combinedFrequency = left.Value.Key + right.Value.Key;

        // Interner Knoten: kein Zeichen (Value = null), Häufigkeit = Summe der Kinder.
        var parent = new Node(new Entry(combinedFrequency, null), left, right);
        queue.Enqueue(parent, combinedFrequency);
      }

      Root = queue.Dequeue();
    }

    public Node Root { get; }

    /// <summary>
    ///   Traversiert den Baum rekursiv und bestimmt den Huffman-Bitcode.
    ///   Linker Ast = '0', rechter Ast = '1'. Gibt die Gesamtlänge des codierten
    ///   Textes in Bit zurück (Summe aus Häufigkeit * Codelänge je Zeichen).
    /// </summary>
    /// <param name="n">Der aktuelle Knoten des Baums.</param>
    /// <param name="bits">char-Array mit dem bisherigen Bitcode.</param>
    /// <param name="nBits">Länge des bisherigen Bitcodes.</param>
    /// <returns>Länge des gesamten Codes in Bit.</returns>
    public static int AssignBits(Node n, char[] bits, int nBits)
    {
      if (n == null)
      {
        return 0;
      }

      // Blatt erreicht → Zeichen mit seinem Code ausgeben.
      if (n.LeftChild == null && n.RightChild == null)
      {
        string code = nBits == 0 ? "0" : new string(bits, 0, nBits);
        Console.WriteLine($"'{n.Value.Value}' (Häufigkeit {n.Value.Key}) → {code}");

        int depth = nBits == 0 ? 1 : nBits; // Sonderfall: nur ein einziges Zeichen
        return n.Value.Key * depth;
      }

      int total = 0;

      bits[nBits] = '0';
      total += AssignBits(n.LeftChild, bits, nBits + 1);

      bits[nBits] = '1';
      total += AssignBits(n.RightChild, bits, nBits + 1);

      return total;
    }
  }
}
