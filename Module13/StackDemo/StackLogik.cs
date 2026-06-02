namespace ZbW.ProgrammingFoundation.Lessons.Module13.StackDemo
{
  using Stack.Loesung;

  /// <summary>
  ///   Kapselt beide Stack-Implementierungen (<see cref="StackArray" />, <see cref="StackLinkedList" />)
  ///   und stellt Push/Pop/Peek/Clear/ToggleMode für die Demo-View bereit.
  ///   Führt intern eine Spiegelliste (<see cref="Items" />) für die Zeichenroutine mit.
  /// </summary>
  public sealed class StackLogik
  {
    private readonly List<object> _items = new();
    private StackArray _stackArray = new();
    private StackLinkedList _stackLinked = new();

    /// <summary>Anzahl der Elemente im aktiven Stack.</summary>
    public int Count
    {
      get
      {
        return UseArray ? _stackArray.Count : _stackLinked.Count;
      }
    }

    /// <summary>Spiegelt den Stack-Inhalt von unten (Index 0) nach oben (letzter Index).</summary>
    public IReadOnlyList<object> Items
    {
      get
      {
        return _items;
      }
    }

    /// <summary>Anzeigetext für den aktuell aktiven Modus (z. B. "Modus: StackArray").</summary>
    public string ModeLabel
    {
      get
      {
        return UseArray ? "Modus: StackArray" : "Modus: StackLinkedList";
      }
    }

    /// <summary><c>true</c> wenn der array-basierte Stack aktiv ist; <c>false</c> für den listenbasierten Stack.</summary>
    public bool UseArray { get; private set; } = true;

    /// <summary>Leert beide Stack-Implementierungen und die Spiegelliste vollständig.</summary>
    public OperationResult Clear()
    {
      _stackArray = new StackArray();
      _stackLinked = new StackLinkedList();
      _items.Clear();
      return new OperationResult("Stack geleert.");
    }

    /// <summary>Gibt das oberste Element zurück, ohne es zu entfernen.</summary>
    public OperationResult Peek()
    {
      try
      {
        object val = UseArray ? _stackArray.Peek() : _stackLinked.Peek();
        return new OperationResult($"Peek()  →  \"{val}\"  |  Count = {Count}");
      }
      catch (InvalidOperationException ex)
      {
        return new OperationResult(ex.Message, isError: true);
      }
    }

    /// <summary>Entfernt das oberste Element und gibt es zurück.</summary>
    public OperationResult Pop()
    {
      try
      {
        object val = UseArray ? _stackArray.Pop() : _stackLinked.Pop();
        if (_items.Count > 0)
        {
          _items.RemoveAt(_items.Count - 1);
        }

        return new OperationResult($"Pop()  →  \"{val}\"  |  Count = {Count}");
      }
      catch (InvalidOperationException ex)
      {
        return new OperationResult(ex.Message, isError: true);
      }
    }

    // ── Operationen ───────────────────────────────────────────────────────

    /// <summary>Legt einen neuen Wert oben auf den aktiven Stack.</summary>
    /// <param name="value">Der einzufügende Wert.</param>
    public OperationResult Push(string value)
    {
      if (UseArray)
      {
        _stackArray.Push(value);
      }
      else
      {
        _stackLinked.Push(value);
      }

      _items.Add(value);
      return new OperationResult($"Push(\"{value}\")  →  Count = {Count}");
    }

    /// <summary>
    ///   Schaltet zwischen <see cref="StackArray" /> und <see cref="StackLinkedList" /> um
    ///   und überträgt den aktuellen Inhalt in die neue Implementierung.
    /// </summary>
    public OperationResult ToggleMode()
    {
      UseArray = !UseArray;

      // Inhalt in die neue Implementierung übertragen
      _stackArray = new StackArray();
      _stackLinked = new StackLinkedList();
      foreach (object item in _items)
      {
        if (UseArray)
        {
          _stackArray.Push(item);
        }
        else
        {
          _stackLinked.Push(item);
        }
      }

      return new OperationResult(UseArray ? "Umgeschaltet auf StackArray" : "Umgeschaltet auf StackLinkedList");
    }
  }
}