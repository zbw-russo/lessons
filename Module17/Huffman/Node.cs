namespace ZbW.ProgrammingFoundation.Challenges.Module17.Huffman
{
  public class Node : IComparable
  {
    public Node(Entry val)
    {
      Value = val;
    }

    public Node(Entry val, Node l, Node r) : this(val)
    {
      LeftChild = l;
      RightChild = r;
    }

    public Node LeftChild { get; }

    public Node RightChild { get; }

    public Entry Value { get; }

    public int CompareTo(object obj)
    {
      var other = obj as Node;
      if (other == null)
      {
        return -1;
      }

      return Value.Key.CompareTo(other.Value.Key);
    }
  }
}