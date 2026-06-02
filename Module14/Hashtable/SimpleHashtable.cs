namespace ZbW.ProgrammingFoundation.Lessons.Module14.Hashtable
{
  /// <summary>
  ///   Einfache Hashtabelle mit String-Key und beliebigem Value.
  ///   Kollisionen werden mit linearem Probing aufgelöst.
  /// </summary>
  public class SimpleHashtable
  {
    // TODO: Private Entry[] _items (festes Array der Grösse capacity)

    // TODO: Property Count (nur von aussen lesbar)

    /// <summary>Erstellt eine Hashtabelle mit fester Kapazität.</summary>
    public SimpleHashtable(int capacity = 10)
    {
      // TODO: _items = new Entry[capacity > 0 ? capacity : 10]
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Fügt einen Key-Value Eintrag hinzu oder überschreibt einen bestehenden Key.
    /// </summary>
    /// <exception cref="InvalidOperationException">Hashtabelle ist voll.</exception>
    public void Add(string key, object value)
    {
      // TODO: Index berechnen mit GetIndex(key)
      // TODO: Lineares Probing: solange _items[index] != null UND Key != key
      //       → index = (index + 1) % _items.Length
      //       Falls wir wieder beim Startindex ankommen: Exception werfen
      // TODO: Falls neuer Slot (war null): Count++
      // TODO: _items[index] = new Entry(key, value)
      throw new NotImplementedException();
    }

    /// <summary>Prüft ob ein Key vorhanden ist.</summary>
    public bool Contains(string key)
    {
      // TODO: Find(key) >= 0 zurückgeben
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Gibt den Wert zum angegebenen Key zurück.
    /// </summary>
    /// <exception cref="KeyNotFoundException">Key nicht vorhanden.</exception>
    public object Get(string key)
    {
      // TODO: Find(key) aufrufen
      // TODO: Falls index < 0: KeyNotFoundException werfen
      // TODO: _items[index].Value zurückgeben
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Gibt den Array-Index zum Key zurück, oder -1 falls nicht gefunden.
    /// </summary>
    private int Find(string key)
    {
      // TODO: Index berechnen mit GetIndex(key)
      // TODO: Lineares Probing: solange _items[index] != null
      //       Falls Key übereinstimmt: index zurückgeben
      //       Falls wir wieder beim Startindex ankommen: abbrechen
      // TODO: -1 zurückgeben (nicht gefunden)
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Additive Hash-Funktion: summiert die ASCII-Werte aller Zeichen, Modulo Array-Länge.
    /// </summary>
    private int GetIndex(string key)
    {
      // TODO: Summe aller (int)c für jeden char c in key berechnen
      // TODO: sum % _items.Length zurückgeben
      throw new NotImplementedException();
    }

    private sealed class Entry
    {
      // TODO: Properties Key (string) und Value (object)
      // TODO: Konstruktor Entry(string key, object value)
    }
  }
}