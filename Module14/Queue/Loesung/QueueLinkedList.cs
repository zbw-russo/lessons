namespace ZbW.ProgrammingFoundation.Lessons.Module14.Queue.Loesung
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
    private Node _head; // FRONT – zuerst raus
    private Node _tail; // BACK  – zuletzt rein

    /// <summary>Anzahl der Elemente in der Queue.</summary>
    public int Count { get; private set; }

    /// <summary>Leert die Queue vollständig.</summary>
    public void Clear()
    {
      _head = null;
      _tail = null;
      Count = 0;
    }

    /// <summary>Entfernt das vorderste Element und gibt es zurück.</summary>
    /// <exception cref="InvalidOperationException">Die Queue ist leer.</exception>
    public object Dequeue()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("Die Queue ist leer.");
      }

      object data = _head.Data;
      _head = _head.Next;

      if (_head == null)
      {
        // Queue ist jetzt leer: _tail ebenfalls zurücksetzen
        _tail = null;
      }

      Count--;
      return data;
    }

    /// <summary>Fügt ein neues Element am Ende der Queue ein.</summary>
    public void Enqueue(object item)
    {
      var newNode = new Node { Data = item };

      if (_tail == null)
      {
        // Erster Knoten: _head und _tail zeigen auf denselben Knoten
        _head = newNode;
        _tail = newNode;
      }
      else
      {
        _tail.Next = newNode;
        _tail = newNode;
      }

      Count++;
    }

    /// <summary>Gibt das vorderste Element zurück, ohne es zu entfernen.</summary>
    /// <exception cref="InvalidOperationException">Die Queue ist leer.</exception>
    public object Peek()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("Die Queue ist leer.");
      }

      return _head.Data;
    }

    private sealed class Node
    {
      public object Data { get; set; }

      public Node Next { get; set; } // zeigt auf den nächsten Knoten in Richtung BACK
    }
  }
}