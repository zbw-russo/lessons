namespace ZbW.ProgrammingFoundation.Lessons.Module16
{
  /// <summary>
  ///   Repräsentiert einen einzelnen Knoten im Binary Search Tree.
  ///   Jeder Node speichert einen int-Wert sowie einen Zeiger auf das
  ///   linke und das rechte Kind.
  ///
  ///   BST-Regel (gilt für jeden Node N):
  ///     • Alle Werte im linken  Teilbaum  &lt;  N.Item
  ///     • Alle Werte im rechten Teilbaum  &gt;  N.Item
  /// </summary>
  public sealed class Node
  {
    public Node(int item)
    {
      Item  = item;
      Left  = null;
      Right = null;
    }

    /// <summary>Der gespeicherte Wert dieses Knotens.</summary>
    public int  Item  { get; set; }

    /// <summary>Linkes Kind – enthält im BST immer kleinere Werte.</summary>
    public Node Left  { get; set; }

    /// <summary>Rechtes Kind – enthält im BST immer grössere Werte.</summary>
    public Node Right { get; set; }

    public override string ToString()
    {
      return Item.ToString();
    }
  }
}
