namespace ZbW.ProgrammingFoundation.Lessons.Module14.Queue
{
  /// <summary>
  ///   Queue (FIFO) mit eigener einfach verketteter Liste.
  ///   <para>
  ///     <b>_head</b> zeigt auf das vorderste Element (FRONT) – zuerst enqueued, zuerst dequeued.<br />
  ///     <b>_tail</b> zeigt auf das hinterste Element (BACK) – zuletzt enqueued.
  ///   </para>
  ///   Enqueue arbeitet am <b>_tail</b>, Dequeue am <b>_head</b> → beides O(1).
  /// </summary>
  public class QueueLinkedList
  {
    /// <summary>Leert die Queue vollständig.</summary>
    public void Clear()
    {
      // TODO: _head und _tail auf null setzen, Count = 0
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Entfernt das vorderste Element und gibt es zurück.
    ///   _head wird auf _head.Next gesetzt.
    /// </summary>
    /// <exception cref="InvalidOperationException">Queue ist leer.</exception>
    public object Dequeue()
    {
      // TODO: Exception werfen wenn Count == 0
      // TODO: Data von _head merken
      // TODO: _head = _head.Next
      // TODO: Falls _head danach null ist: _tail = null (Queue ist leer)
      // TODO: Count--, Data zurückgeben
      throw new NotImplementedException();
    }

    // TODO: Private Felder _head (FRONT) und _tail (BACK) vom Typ Node

    // TODO: Property Count (nur von aussen lesbar)

    /// <summary>
    ///   Fügt ein neues Element am Ende der Queue ein.
    ///   Der neue Knoten wird an _tail angehängt.
    /// </summary>
    public void Enqueue(object item)
    {
      // TODO: Neuen Node erstellen
      // TODO: Falls erste Einfügung (_tail == null): _head = newNode, _tail = newNode
      // TODO: Sonst: _tail.Next = newNode; _tail = newNode
      // TODO: Count++
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Gibt das vorderste Element zurück, ohne es zu entfernen.
    /// </summary>
    /// <exception cref="InvalidOperationException">Queue ist leer.</exception>
    public object Peek()
    {
      // TODO: Exception werfen wenn Count == 0
      // TODO: _head.Data zurückgeben
      throw new NotImplementedException();
    }

    private sealed class Node
    {
      // TODO: Property Data (object) – speichert den Wert
      // TODO: Property Next (Node) – zeigt auf den nächsten Knoten in Richtung BACK
    }
  }
}