namespace ZbW.ProgrammingFoundation.Lessons.Module13.SinglyLinkedList.Loesung
{
  /// <summary>
  ///   Einfach verkettete Liste (Singly Linked List).
  ///   Jeder Knoten zeigt nur auf seinen Nachfolger.
  /// </summary>
  public class SinglyLinkedList
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
      var newNode = new Node { Data = data, Link = null };

      if (_start == null)
      {
        _start = newNode;
        _end = newNode;
      }
      else
      {
        _end.Link = newNode;
        _end = newNode;
      }

      Count++;
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

    /// <summary>Entfernt das erste Element mit dem angegebenen Wert aus der Liste.</summary>
    /// <param name="data">Der zu entfernende Wert.</param>
    /// <returns><c>true</c> wenn entfernt, <c>false</c> wenn nicht gefunden.</returns>
    public bool Remove(object data)
    {
      var node = Find(data);
      if (node == null)
      {
        return false;
      }

      var previous = FindPrevious(data);

      if (previous != null)
      {
        previous.Link = node.Link;
        if (node == _end)
        {
          _end = previous;
        }
      }
      else
      {
        _start = node.Link;
        if (_start == null)
        {
          _end = null;
        }
      }

      Count--;
      return true;
    }

    private Node Find(object data)
    {
      var node = _start;
      while (node != null)
      {
        if (node.Data.Equals(data))
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

    private Node FindPrevious(object data)
    {
      Node previous = null;
      var node = _start;
      while (node != null)
      {
        if (node.Data!.Equals(data))
        {
          return previous;
        }

        previous = node;
        node = node.Link;
      }

      return null;
    }
  }
}