namespace ZbW.ProgrammingFoundation.Challenges.Module17.Huffman
{
  /// <summary>
  ///   Baut den Huffman-Baum aus einer Häufigkeitstabelle und bestimmt die Bitcodes.
  ///   Implementiere die mit TODO markierten Stellen.
  ///   Musterlösung: Huffman/Loesung/HuffmanTree.cs
  /// </summary>
  public class HuffmanTree
  {
    public HuffmanTree(ICollection<Entry> frequencies)
    {
      // TODO: Huffman-Baum aufbauen.
      //   1. Für jeden Entry einen Node in eine Prioritätswarteschlange (MinHeap nach Häufigkeit) legen,
      //      z. B. PriorityQueue<Node, int> oder deinen MinHeap aus Aufgabe 2.
      //   2. Solange mehr als ein Knoten übrig ist: die zwei kleinsten entnehmen, zu einem neuen
      //      Knoten (Häufigkeit = Summe, Zeichen = null) zusammenfassen und wieder einfügen.
      //   3. Der letzte verbleibende Knoten ist die Wurzel (Root).
      throw new NotImplementedException("TODO: HuffmanTree aufbauen");
    }

    public Node Root { get; }

    /// <summary>
    ///   Recursively traverses the tree and determines the Huffman-Bitcode.
    /// </summary>
    /// <param name="n">The current node of the tree.</param>
    /// <param name="bits">char-array containing the actual bitcode so far.</param>
    /// <param name="nBits">The length of the actual bitcode.</param>
    /// <returns>Length of the whole code.</returns>
    public static int AssignBits(Node n, char[] bits, int nBits)
    {
      // TODO: Baum rekursiv traversieren. Linker Ast = '0', rechter Ast = '1'.
      //       An jedem Blatt das Zeichen mit seinem Code festhalten und die Gesamtlänge
      //       (Summe aus Häufigkeit * Codelänge) zurückgeben.
      throw new NotImplementedException("TODO: AssignBits implementieren");
    }
  }
}
