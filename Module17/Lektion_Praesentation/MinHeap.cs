namespace ZbW.ProgrammingFoundation.Lessons.Module17
{
  /// <summary>
  ///   MinHeap – speichert int-Werte so, dass das kleinste Element immer oben (Index 0) liegt.
  ///
  ///   Intern wird der Heap als Array gespeichert. Die Position der Kinder und des Elternteils
  ///   werden über folgende Formeln berechnet:
  ///
  ///     Parent :  (i - 1) / 2
  ///     Links  :  2 * i + 1
  ///     Rechts :  2 * i + 2
  ///
  ///   Beispiel als Array: [ 1, 3, 2, 7, 4, 5 ]
  ///
  ///         1          ← Index 0
  ///        / \
  ///       3   2        ← Index 1, 2
  ///      / \ /
  ///     7  4 5         ← Index 3, 4, 5
  /// </summary>
  public class MinHeap
  {
    private readonly List<int> _data = new List<int>();

    /// <summary>Anzahl Elemente im Heap.</summary>
    public int Count
    {
      get
      {
        return _data.Count;
      }
    }

    /// <summary>Gibt true zurück wenn der Heap leer ist.</summary>
    public bool IsEmpty
    {
      get
      {
        return _data.Count == 0;
      }
    }

    // =========================================================================
    // AUFGABE 1 – EINFÜGEN  (Add)
    // =========================================================================

    /// <summary>
    ///   Fügt einen neuen Wert in den Heap ein.
    ///
    ///   Algorithmus:
    ///     1. Wert ans Ende des Arrays anhängen
    ///     2. SiftUp: solange der Wert kleiner als sein Elternteil ist, tauschen
    ///        (damit die Heap-Eigenschaft wiederhergestellt wird)
    /// </summary>
    public void Add(int value)
    {
      // TODO 1a: Wert ans Ende hinzufügen
      //   _data.Add(???);

      // TODO 1b: SiftUp aufrufen mit dem Index des neuen Elements
      //   SiftUp(???);

      throw new NotImplementedException("TODO 1: Add implementieren");
    }

    /// <summary>
    ///   SiftUp: verschiebt das Element am Index idx nach oben,
    ///   solange es kleiner als sein Elternteil ist.
    ///
    ///   Algorithmus (Pseudocode):
    ///     WHILE idx > 0:
    ///       parentIdx = GetParentIndex(idx)
    ///       IF _data[idx] &lt; _data[parentIdx]:
    ///         Swap(idx, parentIdx)
    ///         idx = parentIdx
    ///       ELSE: BREAK
    /// </summary>
    private void SiftUp(int idx)
    {
      // TODO 1c: Implementiere SiftUp gemäss Algorithmus oben.
      //   Tipp: Verwende GetParentIndex(idx) und Swap(a, b)
      throw new NotImplementedException("TODO 1c: SiftUp implementieren");
    }

    // =========================================================================
    // AUFGABE 2 – MINIMUM LESEN  (Peek)
    // =========================================================================

    /// <summary>
    ///   Gibt das kleinste Element zurück, ohne es zu entfernen.
    ///   Im MinHeap liegt das Minimum immer an Index 0.
    /// </summary>
    public int Peek()
    {
      // TODO 2: Gib _data[0] zurück.
      //         Prüfe zuerst ob der Heap leer ist (IsEmpty).
      throw new NotImplementedException("TODO 2: Peek implementieren");
    }

    // =========================================================================
    // AUFGABE 3 – MINIMUM ENTFERNEN  (Pop)
    // =========================================================================

    /// <summary>
    ///   Entfernt das kleinste Element (Index 0) und gibt es zurück.
    ///
    ///   Algorithmus:
    ///     1. Minimum merken (Index 0)
    ///     2. Letztes Element an Index 0 verschieben
    ///     3. Letztes Element entfernen
    ///     4. SiftDown: das neue Root-Element nach unten schieben,
    ///        bis die Heap-Eigenschaft wieder gilt
    ///     5. Gemerktes Minimum zurückgeben
    /// </summary>
    public int Pop()
    {
      // TODO 3a: Prüfe ob der Heap leer ist
      // TODO 3b: Minimum merken (_data[0])
      // TODO 3c: Letztes Element an Index 0 schreiben
      // TODO 3d: Letztes Element entfernen (_data.RemoveAt(...))
      // TODO 3e: SiftDown(0) aufrufen
      // TODO 3f: Minimum zurückgeben
      throw new NotImplementedException("TODO 3: Pop implementieren");
    }

    /// <summary>
    ///   SiftDown: verschiebt das Element am Index idx nach unten,
    ///   solange eines seiner Kinder kleiner ist.
    ///
    ///   Algorithmus (Pseudocode):
    ///     WHILE true:
    ///       smallest = idx
    ///       left  = GetLeftIndex(idx)
    ///       right = GetRightIndex(idx)
    ///       IF left  &lt; Count AND _data[left]  &lt; _data[smallest]: smallest = left
    ///       IF right &lt; Count AND _data[right] &lt; _data[smallest]: smallest = right
    ///       IF smallest == idx: BREAK   // Heap-Eigenschaft erfüllt
    ///       Swap(idx, smallest)
    ///       idx = smallest
    /// </summary>
    private void SiftDown(int idx)
    {
      // TODO 3g: Implementiere SiftDown gemäss Algorithmus oben.
      //   Tipp: Verwende GetLeftIndex(idx), GetRightIndex(idx) und Swap(a, b)
      throw new NotImplementedException("TODO 3g: SiftDown implementieren");
    }

    // =========================================================================
    // AUFGABE 4 – INDEX-HILFSMETHODEN
    // =========================================================================

    /// <summary>Gibt den Index des Elternteils von idx zurück.  Formel: (idx - 1) / 2</summary>
    private static int GetParentIndex(int idx)
    {
      // TODO 4a: return (idx - 1) / 2;
      throw new NotImplementedException("TODO 4a: GetParentIndex implementieren");
    }

    /// <summary>Gibt den Index des linken Kindes von idx zurück.  Formel: 2 * idx + 1</summary>
    private static int GetLeftIndex(int idx)
    {
      // TODO 4b: return 2 * idx + 1;
      throw new NotImplementedException("TODO 4b: GetLeftIndex implementieren");
    }

    /// <summary>Gibt den Index des rechten Kindes von idx zurück.  Formel: 2 * idx + 2</summary>
    private static int GetRightIndex(int idx)
    {
      // TODO 4c: return 2 * idx + 2;
      throw new NotImplementedException("TODO 4c: GetRightIndex implementieren");
    }

    // =========================================================================
    // HILFSMETHODEN (fertig – nicht verändern)
    // =========================================================================

    /// <summary>Tauscht die Elemente an den Positionen a und b.</summary>
    private void Swap(int a, int b)
    {
      int temp = _data[a];
      _data[a] = _data[b];
      _data[b] = temp;
    }

    /// <summary>Gibt den Heap als Array-Darstellung zurück, z. B. [1, 3, 2, 7, 4, 5]</summary>
    public override string ToString()
    {
      return "[" + string.Join(", ", _data) + "]";
    }
  }
}
