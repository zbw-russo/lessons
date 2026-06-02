namespace ZbW.ProgrammingFoundation.Lessons.Module14.Hashtable.Loesung
{
  /// <summary>
  ///   Einfache Hashtabelle mit String-Key und beliebigem Value.
  ///   <para>
  ///     Verwendet eine additive Hash-Funktion (Summe der ASCII-Werte % Kapazität).<br />
  ///     Kollisionen werden mit linearem Probing aufgelöst: beim Konflikt wird der
  ///     nächste freie Slot gesucht (index + 1) % capacity.
  ///   </para>
  /// </summary>
  public class SimpleHashtable
  {
    private readonly Entry[] _items;

    /// <summary>Erstellt eine Hashtabelle mit fester Kapazität.</summary>
    public SimpleHashtable(int capacity = 10)
    {
      _items = new Entry[capacity > 0 ? capacity : 10];
    }

    /// <summary>Anzahl der gespeicherten Einträge.</summary>
    public int Count { get; private set; }

    /// <summary>Fügt einen Eintrag hinzu oder überschreibt einen bestehenden Key.</summary>
    /// <exception cref="InvalidOperationException">Die Hashtabelle ist voll.</exception>
    public void Add(string key, object value)
    {
      int index = GetIndex(key);
      int start = index;

      while (_items[index] != null && _items[index].Key != key)
      {
        index = (index + 1) % _items.Length;
        if (index == start)
        {
          throw new InvalidOperationException("Die Hashtabelle ist voll.");
        }
      }

      if (_items[index] == null)
      {
        Count++;
      }

      _items[index] = new Entry(key, value);
    }

    /// <summary>Gibt true zurück wenn der Key vorhanden ist, sonst false.</summary>
    public bool Contains(string key)
    {
      return Find(key) >= 0;
    }

    /// <summary>Gibt den Wert zum angegebenen Key zurück.</summary>
    /// <exception cref="KeyNotFoundException">Der Key ist nicht vorhanden.</exception>
    public object Get(string key)
    {
      int index = Find(key);
      if (index < 0)
      {
        throw new KeyNotFoundException($"Key '{key}' nicht gefunden.");
      }

      return _items[index].Value;
    }

    private int Find(string key)
    {
      int index = GetIndex(key);
      int start = index;

      while (_items[index] != null)
      {
        if (_items[index].Key == key)
        {
          return index;
        }

        index = (index + 1) % _items.Length;
        if (index == start)
        {
          break;
        }
      }

      return -1;
    }

    /// <summary>
    ///   Additive Hash-Funktion: summiert die ASCII-Werte aller Zeichen, Modulo Array-Länge.
    /// </summary>
    private int GetIndex(string key)
    {
      int sum = 0;
      foreach (char c in key)
      {
        sum += c;
      }

      return sum % _items.Length;
    }

    private sealed class Entry
    {
      public Entry(string key, object value)
      {
        Key = key;
        Value = value;
      }

      public string Key { get; }

      public object Value { get; }
    }
  }
}