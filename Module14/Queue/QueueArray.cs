namespace ZbW.ProgrammingFoundation.Lessons.Module14.Queue
{
  /// <summary>
  ///   Queue (FIFO – First In, First Out) implementiert mit einem internen Array.
  ///   Das Array wächst automatisch, wenn die Kapazität erschöpft ist.
  /// </summary>
  public class QueueArray
  {
    // TODO: Privates Array _items (Typ: object[])

    // TODO: Private Felder _head (Index vorderstes Element) und _tail (Index nächster freier Platz)

    // TODO: Property Count (nur von aussen lesbar): Count = _tail - _head

    /// <summary>Erstellt eine neue Queue mit optionaler Startkapazität.</summary>
    public QueueArray(int initialCapacity = 10)
    {
      // TODO: _items = new object[initialCapacity > 0 ? initialCapacity : 10]
      throw new NotImplementedException();
    }

    /// <summary>Leert die Queue vollständig.</summary>
    public void Clear()
    {
      // TODO: _items neu initialisieren, _head = 0, _tail = 0
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Entfernt das vorderste Element und gibt es zurück.
    /// </summary>
    /// <exception cref="InvalidOperationException">Queue ist leer.</exception>
    public object Dequeue()
    {
      // TODO: Exception werfen wenn Count == 0
      // TODO: Element merken, Slot auf null setzen, _head++, Element zurückgeben
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Fügt ein Element am Ende der Queue ein (tail).
    /// </summary>
    public void Enqueue(object item)
    {
      // TODO: Grow() aufrufen falls kein Platz mehr
      // TODO: _items[_tail] = item; _tail++
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Gibt das vorderste Element zurück, ohne es zu entfernen.
    /// </summary>
    /// <exception cref="InvalidOperationException">Queue ist leer.</exception>
    public object Peek()
    {
      // TODO: Exception werfen wenn Count == 0
      // TODO: _items[_head] zurückgeben
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Verschiebt Elemente an den Anfang des Arrays und/oder verdoppelt die Kapazität.
    /// </summary>
    private void Grow()
    {
      // TODO: Falls _tail < _items.Length → nichts tun (noch Platz vorhanden)
      // TODO: Falls _head > 0: Array.Copy(_items, _head, _items, 0, Count), dann _tail = Count, _head = 0
      // TODO: Sonst (Array ist wirklich voll): Array.Resize(ref _items, _items.Length * 2)
      throw new NotImplementedException();
    }
  }
}