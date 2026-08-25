namespace ZbW.ProgrammingFoundation.Lessons.Module14.Queue.Loesung
{
  /// <summary>
  ///   Queue (FIFO – First In, First Out) implementiert mit einem internen Array.
  ///   <para>
  ///     <b>_head</b> zeigt auf das vorderste Element (FRONT).<br />
  ///     <b>_tail</b> zeigt auf den nächsten freien Slot (hinter dem letzten Element).
  ///   </para>
  ///   Beim Wachsen werden die Elemente zuerst kompaktiert (nach vorne verschoben),
  ///   bevor das Array vergrössert wird.
  /// </summary>
  public class QueueArray
  {
    private int _head;
    private object[] _items;
    private int _tail;

    /// <summary>Erstellt eine neue Queue mit optionaler Startkapazität.</summary>
    /// <param name="initialCapacity">Anfangskapazität des internen Arrays. Muss &gt; 0 sein; Standard ist 10.</param>
    public QueueArray(int initialCapacity = 10)
    {
      _items = new object[initialCapacity > 0 ? initialCapacity : 10];
    }

    /// <summary>Anzahl der Elemente in der Queue.</summary>
    public int Count
    {
      get
      {
        return _tail - _head;
      }
    }

    /// <summary>Entfernt alle Elemente und setzt Count auf 0.</summary>
    public void Clear()
    {
      _items = new object[10];
      _head = 0;
      _tail = 0;
    }

    /// <summary>Entfernt das vorderste Element und gibt es zurück.</summary>
    /// <returns>Das entfernte vorderste Element.</returns>
    /// <exception cref="InvalidOperationException">Die Queue ist leer.</exception>
    public object Dequeue()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("Die Queue ist leer.");
      }

      var item = _items[_head];
      _items[_head] = null;
      _head++;
      return item;
    }

    /// <summary>Fügt ein neues Element am Ende der Queue ein.</summary>
    /// <param name="item">Der zu speichernde Wert.</param>
    public void Enqueue(object item)
    {
      Grow();
      _items[_tail] = item;
      _tail++;
    }

    /// <summary>Gibt das vorderste Element zurück, ohne es zu entfernen.</summary>
    /// <returns>Das vorderste Element.</returns>
    /// <exception cref="InvalidOperationException">Die Queue ist leer.</exception>
    public object Peek()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("Die Queue ist leer.");
      }

      return _items[_head];
    }

    private void Grow()
    {
      if (_tail < _items.Length)
      {
        return;
      }

      if (_head > 0)
      {
        // Elemente nach vorne verschieben und Indizes zurücksetzen
        int count = Count;
        Array.Copy(_items, _head, _items, 0, count);
        Array.Clear(_items, count, _items.Length - count);
        _tail = count;
        _head = 0;
      }
      else
      {
        Array.Resize(ref _items, _items.Length * 2);
      }
    }
  }
}