namespace ZbW.ProgrammingFoundation.Lessons.Module16.Loesung
{
  /// <summary>
  ///   Repräsentiert einen einzelnen Knoten im Binary Search Tree.
  ///   BST-Regel: linker Teilbaum &lt; Item, rechter Teilbaum &gt; Item.
  /// </summary>
  public sealed class Node
  {
    public Node(int item)
    {
      Item  = item;
      Left  = null;
      Right = null;
    }

    public int  Item  { get; set; }
    public Node Left  { get; set; }
    public Node Right { get; set; }

    public override string ToString()
    {
      return Item.ToString();
    }
  }
}
