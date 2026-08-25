namespace ZbW.ProgrammingFoundation.Lessons.Module16.Loesung
{
  // ---------------------------------------------------------------------------
  // Traversierungs-Modi
  // ---------------------------------------------------------------------------

  public enum TraverseMode
  {
    PreOrder,   // Node → Links → Rechts
    InOrder,    // Links → Node → Rechts  ← sortierte Ausgabe!
    PostOrder   // Links → Rechts → Node
  }

  // ---------------------------------------------------------------------------
  // Binary Search Tree – vollständige Lösung
  // ---------------------------------------------------------------------------

  /// <summary>
  ///   Binary Search Tree (BST) für int-Werte.
  ///   Musterlösung für die Aufgaben 1–3 inkl. Bonusaufgabe Remove.
  /// </summary>
  public class BinarySearchTree
  {
    private Node _root;

    public bool IsEmpty
    {
      get
      {
        return _root == null;
      }
    }

    // =========================================================================
    // Aufgabe 1 – Insert
    // =========================================================================

    public void Insert(int value)
    {
      // TODO 1a – Lösung:
      _root = InsertRecursive(_root, value);
    }

    private Node InsertRecursive(Node current, int value)
    {
      // TODO 1b – Lösung:
      if (current == null)
      {
        return new Node(value); // freie Stelle gefunden → neuen Node anlegen
      }

      if (value < current.Item)
      {
        current.Left = InsertRecursive(current.Left, value); // kleiner → links
      }
      else if (value > current.Item)
      {
        current.Right = InsertRecursive(current.Right, value); // grösser → rechts
      }

      // Duplikat → nichts tun
      return current;
    }

    // =========================================================================
    // Aufgabe 2 – Find
    // =========================================================================

    public Node Find(int value)
    {
      // TODO 2a – Lösung:
      return FindRecursive(_root, value);
    }

    private Node FindRecursive(Node current, int value)
    {
      // TODO 2b – Lösung:
      if (current == null)
      {
        return null; // nicht gefunden
      }

      if (value == current.Item)
      {
        return current; // gefunden!
      }

      if (value < current.Item)
      {
        return FindRecursive(current.Left, value);
      }

      return FindRecursive(current.Right, value);
    }

    // =========================================================================
    // Aufgabe 3 – Traverse
    // =========================================================================

    public List<int> Traverse(TraverseMode mode)
    {
      var result = new List<int>();

      // TODO 3a – Lösung:
      switch (mode)
      {
        case TraverseMode.PreOrder:  TraversePreOrder (_root, result); break;
        case TraverseMode.InOrder:   TraverseInOrder  (_root, result); break;
        case TraverseMode.PostOrder: TraversePostOrder(_root, result); break;
      }

      return result;
    }

    private void TraversePreOrder(Node current, List<int> result)
    {
      // TODO 3b – Lösung:
      if (current == null)
      {
        return;
      }

      result.Add(current.Item);                  // 1. Node
      TraversePreOrder(current.Left,  result);   // 2. Links
      TraversePreOrder(current.Right, result);   // 3. Rechts
    }

    private void TraverseInOrder(Node current, List<int> result)
    {
      // TODO 3c – Lösung:
      if (current == null)
      {
        return;
      }

      TraverseInOrder(current.Left,  result);    // 1. Links
      result.Add(current.Item);                  // 2. Node
      TraverseInOrder(current.Right, result);    // 3. Rechts
    }

    private void TraversePostOrder(Node current, List<int> result)
    {
      // TODO 3d – Lösung:
      if (current == null)
      {
        return;
      }

      TraversePostOrder(current.Left,  result);  // 1. Links
      TraversePostOrder(current.Right, result);  // 2. Rechts
      result.Add(current.Item);                  // 3. Node (zuletzt!)
    }

    // =========================================================================
    // Bonusaufgabe – Remove
    // =========================================================================

    public void Remove(int value)
    {
      // TODO BONUS a – Lösung:
      _root = RemoveRecursive(_root, value);
    }

    private Node RemoveRecursive(Node current, int value)
    {
      // TODO BONUS b – Lösung:
      if (current == null)
      {
        return null;
      }

      if (value < current.Item)
      {
        current.Left = RemoveRecursive(current.Left, value);
        return current;
      }

      if (value > current.Item)
      {
        current.Right = RemoveRecursive(current.Right, value);
        return current;
      }

      // Gefunden – löschen:

      // Szenario 1 – Leaf
      if (current.Left == null && current.Right == null)
      {
        return null;
      }

      // Szenario 2a – nur linkes Kind
      if (current.Right == null)
      {
        return current.Left;
      }

      // Szenario 2b – nur rechtes Kind
      if (current.Left == null)
      {
        return current.Right;
      }

      // Szenario 3 – In-Order-Nachfolger übernimmt
      Node successor = FindMostLeft(current.Right);
      current.Item  = successor.Item;
      current.Right = RemoveRecursive(current.Right, successor.Item);
      return current;
    }

    private Node FindMostLeft(Node node)
    {
      // TODO BONUS c – Lösung:
      while (node.Left != null)
      {
        node = node.Left;
      }

      return node;
    }
  }
}
