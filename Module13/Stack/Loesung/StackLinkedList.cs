namespace ZbW.ProgrammingFoundation.Lessons.Module13.Stack.Loesung
{
  /// <summary>
  ///   Stack (LIFO) mit eigener einfach verketteter Liste.
  ///   <para>
  ///     <b>start</b> zeigt auf das oberste Element (TOP) – zuletzt gepusht, zuerst gepoppt.<br />
  ///     <b>end</b>   zeigt auf das unterste Element (BOTTOM) – zuerst gepusht, zuletzt gepoppt.
  ///   </para>
  ///   Push und Pop arbeiten am <b>start</b> → beides O(1).
  /// </summary>
  public class StackLinkedList
  {
    private Node _end; // BOTTOM – zuerst gepusht

    // ── Felder ────────────────────────────────────────────────────────────

    private Node _start; // TOP  – zuletzt gepusht

    /// <summary>Anzahl der Elemente im Stack.</summary>
    public int Count { get; private set; }

    /// <summary>Leert den Stack vollständig.</summary>
    public void Clear()
    {
      _start = null;
      _end = null;
      Count = 0;
    }

    /// <summary>
    ///   Gibt das oberste Element zurück, ohne es zu entfernen.
    /// </summary>
    /// <exception cref="InvalidOperationException">Stack ist leer.</exception>
    public object Peek()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("Der Stack ist leer.");
      }

      return _start.Data;
    }

    /// <summary>
    ///   Entfernt das oberste Element und gibt es zurück (start entfernen).
    /// </summary>
    /// <exception cref="InvalidOperationException">Stack ist leer.</exception>
    public object Pop()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("Der Stack ist leer.");
      }

      object data = _start.Data;
      _start = _start.Link;

      if (_start == null)
      {
        // Stack ist jetzt leer: end ebenfalls zurücksetzen
        _end = null;
      }

      Count--;
      return data;
    }

    // ── Stack-Operationen ─────────────────────────────────────────────────

    /// <summary>Legt ein neues Element oben auf den Stack (am start einfügen).</summary>
    public void Push(object item)
    {
      var newNode = new Node { Data = item, Link = _start };

      if (_start == null)
      {
        // Erster Knoten: start und end zeigen auf denselben Knoten
        _end = newNode;
      }

      _start = newNode;
      Count++;
    }

    // ── Interner Knoten ───────────────────────────────────────────────────

    private sealed class Node
    {
      public object Data { get; set; }

      public Node Link { get; set; } // zeigt auf den darunter liegenden Knoten
    }
  }
}