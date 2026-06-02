namespace ZbW.ProgrammingFoundation.Lessons.Module13.DoublyLinkedList.Loesung
{
  /// <summary>
  ///   Doppelt verkettete Liste (Doubly Linked List).
  ///   Jeder Knoten kennt sowohl seinen Nachfolger (<see cref="Node.Link" />) als
  ///   auch seinen Vorgänger (<see cref="Node.PrevLink" />).
  /// </summary>
  public class DoublyLinkedList
  {
    private Node _end;
    private Node _start;

    /// <summary>Anzahl der Elemente in der Liste.</summary>
    public int Count { get; private set; }

    /// <summary>Ermöglicht den lesenden und schreibenden Zugriff per Index (<c>list[0]</c>, <c>list[1] = "neu"</c>).</summary>
    /// <param name="index">Nullbasierter Index des Elements.</param>
    /// <exception cref="IndexOutOfRangeException">Index ist ausserhalb des gültigen Bereichs.</exception>
    public object this[int index]
    {
      get
      {
        return FindByIndexInternal(index).Data;
      }
      set
      {
        FindByIndexInternal(index).Data = value;
      }
    }

    /// <summary>Fügt einen neuen Wert am Ende der Liste an.</summary>
    /// <param name="data">Der zu speichernde Wert.</param>
    public void Add(object data)
    {
      var newNode = new Node { Data = data };

      if (_start == null)
      {
        _start = newNode;
        _end = newNode;
      }
      else
      {
        _end.Link = newNode;
        newNode.PrevLink = _end;
        _end = newNode;
      }

      Count++;
    }

    /// <summary>Entfernt alle Elemente aus der Liste und setzt <see cref="Count" /> auf 0.</summary>
    public void Clear()
    {
      _start = _end = null;
      Count = 0;
    }

    /// <summary>Gibt an, ob ein Element mit dem angegebenen Wert in der Liste vorhanden ist.</summary>
    /// <param name="data">Der gesuchte Wert.</param>
    /// <returns><c>true</c> wenn gefunden, sonst <c>false</c>.</returns>
    public bool Contains(object data)
    {
      return Find(data) != null;
    }

    /// <summary>Gibt den Wert am angegebenen nullbasierten Index zurück.</summary>
    /// <param name="index">Nullbasierter Index des Elements.</param>
    /// <returns>Der gespeicherte Wert an dieser Position.</returns>
    /// <exception cref="IndexOutOfRangeException">Index ist ausserhalb des gültigen Bereichs.</exception>
    public object FindByIndex(int index)
    {
      return FindByIndexInternal(index).Data;
    }

    /// <summary>Fügt einen neuen Wert unmittelbar nach dem Element mit dem Wert <paramref name="previousData" /> ein.</summary>
    /// <param name="previousData">Wert des Vorgänger-Knotens.</param>
    /// <param name="data">Der einzufügende Wert.</param>
    /// <returns><c>true</c> wenn erfolgreich eingefügt, <c>false</c> wenn <paramref name="previousData" /> nicht gefunden.</returns>
    public bool InsertAfter(object previousData, object data)
    {
      var prev = Find(previousData);
      if (prev == null)
      {
        return false;
      }

      var newNode = new Node { Data = data };
      newNode.Link = prev.Link;
      newNode.PrevLink = prev;
      prev.Link = newNode;

      if (newNode.Link != null)
      {
        newNode.Link.PrevLink = newNode;
      }
      else
      {
        _end = newNode;
      }

      Count++;
      return true;
    }

    /// <summary>Entfernt das erste Element mit dem angegebenen Wert und aktualisiert alle betroffenen Zeiger.</summary>
    /// <param name="data">Der zu entfernende Wert.</param>
    /// <returns><c>true</c> wenn entfernt, <c>false</c> wenn nicht gefunden.</returns>
    public bool Remove(object data)
    {
      var node = Find(data);
      if (node == null)
      {
        return false;
      }

      if (_start == node)
      {
        _start = node.Link;
      }

      if (_end == node)
      {
        _end = node.PrevLink;
      }

      if (node.PrevLink != null)
      {
        node.PrevLink.Link = node.Link;
      }

      if (node.Link != null)
      {
        node.Link.PrevLink = node.PrevLink;
      }

      Count--;
      return true;
    }

    private Node Find(object data)
    {
      var node = _start;
      while (node != null)
      {
        if (node.Data!.Equals(data))
        {
          return node;
        }

        node = node.Link;
      }

      return null;
    }

    private Node FindByIndexInternal(int index)
    {
      if (index < 0 || index >= Count)
      {
        throw new IndexOutOfRangeException($"Index {index} liegt ausserhalb der Liste (Count={Count}).");
      }

      var node = _start;
      for (int i = 0; i < index; i++)
      {
        node = node.Link;
      }

      return node;
    }
  }
}