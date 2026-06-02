namespace ZbW.ProgrammingFoundation.Lessons.Module14.Hashtable.Loesung
{
  /// <summary>
  ///   Einfache Hashtabelle mit String-Key und beliebigem Value.
  ///   <para>
  ///     Verwendet eine additive Hash-Funktion (Summe der ASCII-Werte % Kapazität).<br />
  ///     Kollisionen werden mit Chaining aufgelöst: mehrere Einträge mit demselben
  ///     Hash-Index werden in einer verketteten Liste im gleichen Bucket gespeichert.
  ///   </para>
  /// </summary>
  public class SimpleHashtableChaining
  {
    private readonly LinkedList<Entry>[] _items;

    /// <summary>Erstellt eine Hashtabelle mit fester Anzahl Buckets.</summary>
    public SimpleHashtableChaining(int capacity = 10)
    {
      _items = new LinkedList<Entry>[capacity > 0 ? capacity : 10];
    }

    /// <summary>Anzahl der gespeicherten Einträge.</summary>
    public int Count { get; private set; }

    /// <summary>Fügt einen Eintrag hinzu oder überschreibt einen bestehenden Key.</summary>
    public void Add(string key, object value)
    {
      int index = GetIndex(key);
      _items[index] ??= new LinkedList<Entry>();

      LinkedListNode<Entry> node = FindNode(index, key);
      if (node != null)
      {
        node.Value = new Entry(key, value);
        return;
      }

      _items[index].AddLast(new Entry(key, value));
      Count++;
    }

    /// <summary>Gibt true zurück wenn der Key vorhanden ist, sonst false.</summary>
    public bool Contains(string key)
    {
      int index = GetIndex(key);
      return FindNode(index, key) != null;
    }

    /// <summary>Gibt den Wert zum angegebenen Key zurück.</summary>
    /// <exception cref="KeyNotFoundException">Der Key ist nicht vorhanden.</exception>
    public object Get(string key)
    {
      int index = GetIndex(key);
      LinkedListNode<Entry> node = FindNode(index, key);
      if (node == null)
      {
        throw new KeyNotFoundException($"Key '{key}' nicht gefunden.");
      }

      return node.Value.Value;
    }

    private LinkedListNode<Entry> FindNode(int index, string key)
    {
      LinkedList<Entry> bucket = _items[index];
      if (bucket == null)
      {
        return null;
      }

      LinkedListNode<Entry> node = bucket.First;
      while (node != null)
      {
        if (node.Value.Key == key)
        {
          return node;
        }

        node = node.Next;
      }

      return null;
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
