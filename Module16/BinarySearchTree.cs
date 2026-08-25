namespace ZbW.ProgrammingFoundation.Lessons.Module16
{
  // ---------------------------------------------------------------------------
  // Traversierungs-Modi  (Folie 23–25)
  // ---------------------------------------------------------------------------

  public enum TraverseMode
  {
    PreOrder,   // Node → Links → Rechts
    InOrder,    // Links → Node → Rechts  ← ergibt sortierte Ausgabe!
    PostOrder   // Links → Rechts → Node
  }

  // ---------------------------------------------------------------------------
  // Binary Search Tree
  // ---------------------------------------------------------------------------

  /// <summary>
  ///   Binary Search Tree (BST) für int-Werte.
  ///   BST-Invariante: für jeden Node N gilt
  ///     • alle Werte im linken  Teilbaum  &lt; N.Item
  ///     • alle Werte im rechten Teilbaum  &gt; N.Item
  /// </summary>
  public class BinarySearchTree
  {
    private Node _root;

    /// <summary>Gibt true zurück, wenn der Baum keine Elemente enthält.</summary>
    public bool IsEmpty
    {
      get
      {
        return _root == null;
      }
    }

    /// <summary>Wurzel-Node – wird von der UI für die Visualisierung verwendet.</summary>
    public Node Root
    {
      get
      {
        return _root;
      }
    }

    // =========================================================================
    // AUFGABE 1 – EINFÜGEN  (Insert)
    // =========================================================================

    /// <summary>
    ///   Fügt einen neuen Wert in den BST ein.
    ///   Duplikate werden ignoriert.
    /// </summary>
    public void Insert(int value)
    {
      // TODO 1a: Rufe die rekursive Hilfsmethode InsertRecursive auf
      //          und weise das Ergebnis _root zu.
      //
      //   _root = InsertRecursive(???, ???);
      throw new NotImplementedException("TODO 1a: Insert aufrufen");
    }

    /// <summary>
    ///   Rekursive Hilfsmethode für Insert.
    ///
    ///   Algorithmus (Pseudocode):
    ///     FUNCTION InsertRecursive(current, value):
    ///       IF current == null  →  RETURN new Node(value)   // freie Stelle gefunden
    ///       IF value &lt; current.Item  →  current.Left  = InsertRecursive(current.Left,  value)
    ///       IF value &gt; current.Item  →  current.Right = InsertRecursive(current.Right, value)
    ///       // Duplikat (==): nichts tun
    ///       RETURN current
    /// </summary>
    private Node InsertRecursive(Node current, int value)
    {
      // TODO 1b: Implementiere den Algorithmus oben.
      //
      //   Tipp: Vergleiche mit  <  und  >
      //         value < current.Item  → geh nach links
      //         value > current.Item  → geh nach rechts
      throw new NotImplementedException("TODO 1b: InsertRecursive implementieren");
    }

    // =========================================================================
    // AUFGABE 2 – SUCHEN  (Find)
    // =========================================================================

    /// <summary>
    ///   Sucht einen Wert im BST.
    /// </summary>
    /// <returns>Den gefundenen Node, oder null wenn nicht vorhanden.</returns>
    public Node Find(int value)
    {
      // TODO 2a: Rufe FindRecursive mit _root und value auf und gib das Ergebnis zurück.
      throw new NotImplementedException("TODO 2a: Find aufrufen");
    }

    /// <summary>
    ///   Rekursive Hilfsmethode für Find.
    ///
    ///   Algorithmus (Pseudocode):
    ///     FUNCTION FindRecursive(current, value):
    ///       IF current == null        →  RETURN null      // nicht gefunden
    ///       IF value == current.Item  →  RETURN current   // gefunden!
    ///       IF value &lt; current.Item  →  RETURN FindRecursive(current.Left,  value)
    ///       ELSE                      →  RETURN FindRecursive(current.Right, value)
    /// </summary>
    private Node FindRecursive(Node current, int value)
    {
      // TODO 2b: Implementiere den Algorithmus oben.
      throw new NotImplementedException("TODO 2b: FindRecursive implementieren");
    }

    // =========================================================================
    // AUFGABE 3 – TRAVERSIEREN  (Traverse)
    // =========================================================================

    /// <summary>
    ///   Traversiert den gesamten Baum und gibt alle Werte als Liste zurück.
    ///   Die Reihenfolge hängt vom gewählten <see cref="TraverseMode"/> ab.
    /// </summary>
    public List<int> Traverse(TraverseMode mode)
    {
      var result = new List<int>();

      // TODO 3a: Rufe je nach mode die passende Hilfsmethode auf:
      //           TraverseMode.PreOrder   → TraversePreOrder(_root, result)
      //           TraverseMode.InOrder    → TraverseInOrder(_root, result)
      //           TraverseMode.PostOrder  → TraversePostOrder(_root, result)
      //
      //   Tipp: switch (mode) { case TraverseMode.PreOrder: ... }

      throw new NotImplementedException("TODO 3a: Traverse-Weiche implementieren");

      // return result;  ← auskommentiert, bis TODO 3a gelöst ist
    }

    /// <summary>
    ///   Pre-Order: Node → Links → Rechts
    ///   Typische Anwendung: Baum kopieren / serialisieren.
    ///   Beispiel-Baum (5,3,2,4,8,7,9) → 5 3 2 4 8 7 9
    /// </summary>
    private void TraversePreOrder(Node current, List<int> result)
    {
      // TODO 3b: Implementiere Pre-Order rekursiv.
      //
      //   1. Abbruchbedingung: wenn current == null → return
      //   2. result.Add(current.Item)          ← Node verarbeiten
      //   3. TraversePreOrder(current.Left,  result)
      //   4. TraversePreOrder(current.Right, result)
      throw new NotImplementedException("TODO 3b: TraversePreOrder implementieren");
    }

    /// <summary>
    ///   In-Order: Links → Node → Rechts
    ///   Typische Anwendung: sortierte Ausgabe (BST liefert aufsteigende Reihenfolge!).
    ///   Beispiel-Baum (5,3,2,4,8,7,9) → 2 3 4 5 7 8 9
    /// </summary>
    private void TraverseInOrder(Node current, List<int> result)
    {
      // TODO 3c: Implementiere In-Order rekursiv.
      //
      //   1. Abbruchbedingung: wenn current == null → return
      //   2. TraverseInOrder(current.Left,  result)  ← erst Links
      //   3. result.Add(current.Item)                ← dann Node
      //   4. TraverseInOrder(current.Right, result)  ← dann Rechts
      throw new NotImplementedException("TODO 3c: TraverseInOrder implementieren");
    }

    /// <summary>
    ///   Post-Order: Links → Rechts → Node
    ///   Typische Anwendung: Baum löschen, Ausdrücke auswerten.
    ///   Beispiel-Baum (5,3,2,4,8,7,9) → 2 4 3 7 9 8 5
    /// </summary>
    private void TraversePostOrder(Node current, List<int> result)
    {
      // TODO 3d: Implementiere Post-Order rekursiv.
      //
      //   1. Abbruchbedingung: wenn current == null → return
      //   2. TraversePostOrder(current.Left,  result)
      //   3. TraversePostOrder(current.Right, result)
      //   4. result.Add(current.Item)                ← Node zuletzt
      throw new NotImplementedException("TODO 3d: TraversePostOrder implementieren");
    }

    // =========================================================================
    // BONUSAUFGABE – LÖSCHEN  (Remove)
    // =========================================================================

    /// <summary>
    ///   Löscht einen Wert aus dem BST.
    ///   Drei Szenarien (Folien 11–20):
    ///     1. Leaf-Node     → einfach entfernen (return null)
    ///     2. Ein Kind      → Kind übernimmt die Position
    ///     3. Zwei Kinder   → ersetze Wert mit In-Order-Nachfolger
    ///                        (= kleinstes Element im rechten Teilbaum)
    /// </summary>
    public void Remove(int value)
    {
      // TODO BONUS a: Rufe RemoveRecursive auf und weise _root zu.
      throw new NotImplementedException("TODO BONUS a: Remove aufrufen");
    }

    private Node RemoveRecursive(Node current, int value)
    {
      // TODO BONUS b: Implementiere den Algorithmus oben.
      //
      //   Tipp: Hilfsmethode FindMostLeft(node) gibt den linkesten Node zurück.
      throw new NotImplementedException("TODO BONUS b: RemoveRecursive implementieren");
    }

    private Node FindMostLeft(Node node)
    {
      // TODO BONUS c: Solange node.Left != null, geh nach links.
      //               Gib den letzten Node zurück.
      throw new NotImplementedException("TODO BONUS c: FindMostLeft implementieren");
    }
  }
}
