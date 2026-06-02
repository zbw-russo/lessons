namespace ZbW.ProgrammingFoundation.Lessons.Module13.Stack
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
    /// <summary>Leert den Stack vollständig.</summary>
    public void Clear()
    {
      // TODO: start und end auf null setzen, Count = 0
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Gibt das oberste Element zurück, ohne es zu entfernen.
    /// </summary>
    /// <exception cref="InvalidOperationException">Stack ist leer.</exception>
    public object Peek()
    {
      // TODO: Exception werfen wenn Count == 0
      // TODO: start.Data zurückgeben
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Entfernt das oberste Element und gibt es zurück.
    ///   start wird auf start.Link gesetzt (das darunter liegende Element wird zum neuen TOP).
    /// </summary>
    /// <exception cref="InvalidOperationException">Stack ist leer.</exception>
    public object Pop()
    {
      // TODO: Exception werfen wenn Count == 0
      // TODO: Data von start merken
      // TODO: start = start.Link
      // TODO: Falls start danach null ist: end = null (Stack leer)
      // TODO: Count--, Data zurückgeben
      throw new NotImplementedException();
    }

    // ── Felder ────────────────────────────────────────────────────────────

    // TODO: Private Felder start (TOP) und end (BOTTOM) vom Typ Node

    // TODO: Property Count (nur von aussen lesbar)

    // ── Stack-Operationen ─────────────────────────────────────────────────

    /// <summary>
    ///   Legt ein neues Element oben auf den Stack.
    ///   Neuer Knoten zeigt mit Link auf den bisherigen start (darunter liegend).
    /// </summary>
    public void Push(object item)
    {
      // TODO: Neuen Node erstellen, Link = bisheriger start
      // TODO: Falls erster Knoten (start == null): end = newNode
      // TODO: start = newNode
      // TODO: Count++
      throw new NotImplementedException();
    }

    // ── Interner Knoten ───────────────────────────────────────────────────

    private sealed class Node
    {
      // TODO: Property Data (object) – speichert den Wert
      // TODO: Property Link (Node)  – zeigt auf den darunter liegenden Knoten
    }
  }
}