namespace ZbW.ProgrammingFoundation.Lessons.Module13.SinglyLinkedListDemo
{
  using SinglyLinkedList.Loesung;

  /// <summary>
  ///   Kapselt alle Operationen auf der <see cref="SinglyLinkedList" /> für die Demo-View.
  ///   Gibt pro Operation ein <see cref="OperationResult" /> zurück, das die
  ///   Statusmeldung und den hervorzuhebenden Index enthält.
  /// </summary>
  public sealed class SinglyLinkedListLogik
  {
    private readonly SinglyLinkedList _list = new();

    /// <summary>Anzahl der Elemente in der Liste.</summary>
    public int Count
    {
      get
      {
        return _list.Count;
      }
    }

    /// <summary>Fügt den Wert am Ende der Liste an und gibt ein Ergebnis mit dem neuen Count zurück.</summary>
    /// <param name="value">Der einzufügende Wert.</param>
    public OperationResult Add(string value)
    {
      _list.Add(value);
      return new OperationResult(
        $"Add(\"{value}\")  →  Count = {_list.Count}",
        _list.Count - 1);
    }

    /// <summary>Entfernt alle Elemente aus der Liste.</summary>
    public OperationResult Clear()
    {
      while (_list.Count > 0)
      {
        _list.Remove(_list[0]);
      }

      return new OperationResult("Liste geleert.", highlightIndex: -1);
    }

    /// <summary>Prüft, ob der Wert in der Liste vorhanden ist, und hebt den gefundenen Knoten hervor.</summary>
    /// <param name="value">Der zu suchende Wert.</param>
    public OperationResult Contains(string value)
    {
      bool ok = _list.Contains(value);
      int idx = -1;
      if (ok)
      {
        for (int i = 0; i < _list.Count; i++)
        {
          if (_list[i]?.Equals(value) == true)
          {
            idx = i;
            break;
          }
        }
      }

      return new OperationResult($"Contains(\"{value}\")  →  {ok}", idx);
    }

    /// <summary>Gibt den Wert am angegebenen Index zurück und hebt ihn hervor.</summary>
    /// <param name="index">Nullbasierter Index des gesuchten Elements.</param>
    public OperationResult FindByIndex(int index)
    {
      try
      {
        object val = _list.FindByIndex(index);
        return new OperationResult($"FindByIndex({index})  →  \"{val}\"", index);
      }
      catch (IndexOutOfRangeException)
      {
        return new OperationResult(
          $"FindByIndex({index})  →  IndexOutOfRangeException (Count={_list.Count})",
          highlightIndex: -1,
          isError: true);
      }
    }

    /// <summary>Gibt den Wert am Index zurück (für die Zeichenroutine der View).</summary>
    public object GetItem(int index)
    {
      return _list[index];
    }

    /// <summary>Entfernt das erste Element mit dem angegebenen Wert aus der Liste.</summary>
    /// <param name="value">Der zu entfernende Wert.</param>
    public OperationResult Remove(string value)
    {
      bool ok = _list.Remove(value);
      return ok
        ? new OperationResult($"Remove(\"{value}\")  →  entfernt, Count = {_list.Count}", highlightIndex: -1)
        : new OperationResult($"Remove(\"{value}\")  →  nicht gefunden", highlightIndex: -1, isError: true);
    }

    /// <summary>Setzt den Wert am angegebenen Index auf einen neuen Wert.</summary>
    /// <param name="index">Nullbasierter Index des zu ändernden Elements.</param>
    /// <param name="value">Der neue Wert.</param>
    public OperationResult SetByIndex(int index, string value)
    {
      try
      {
        _list[index] = value;
        return new OperationResult($"list[{index}] = \"{value}\"  →  gesetzt", index);
      }
      catch (IndexOutOfRangeException)
      {
        return new OperationResult(
          $"list[{index}] = \"{value}\"  →  IndexOutOfRangeException (Count={_list.Count})",
          highlightIndex: -1,
          isError: true);
      }
    }
  }
}