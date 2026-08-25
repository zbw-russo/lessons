namespace ZbW.ProgrammingFoundation.Lessons.Module13.Stack.Loesung
{
  /// <summary>
  ///   Stack (LIFO – Last In, First Out) implementiert mit einem internen Array.
  ///   Das Array verdoppelt sich automatisch, wenn die Kapazität erschöpft ist.
  /// </summary>
  public class StackArray
  {
    private object[] items;

    /// <summary>Erstellt einen neuen Stack mit optionaler Startkapazität.</summary>
    /// <param name="initialCapacity">Anfangskapazität des internen Arrays. Muss &gt; 0 sein; Standard ist 10.</param>
    public StackArray(int initialCapacity = 10)
    {
      items = new object[initialCapacity > 0 ? initialCapacity : 10];
    }

    /// <summary>Anzahl der Elemente im Stack.</summary>
    public int Count { get; private set; }

    /// <summary>Entfernt alle Elemente und setzt <see cref="Count" /> auf 0.</summary>
    public void Clear()
    {
      items = new object[10];
      Count = 0;
    }

    /// <summary>Gibt das oberste Element zurück, ohne es zu entfernen.</summary>
    /// <returns>Das oberste Element.</returns>
    /// <exception cref="InvalidOperationException">Der Stack ist leer.</exception>
    public object Peek()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("Der Stack ist leer.");
      }

      return items[Count - 1];
    }

    /// <summary>Entfernt das oberste Element und gibt es zurück.</summary>
    /// <returns>Das entfernte oberste Element.</returns>
    /// <exception cref="InvalidOperationException">Der Stack ist leer.</exception>
    public object Pop()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("Der Stack ist leer.");
      }

      var item = items[Count - 1];
      items[Count - 1] = null;
      Count--;
      return item;
    }

    /// <summary>Legt ein neues Element oben auf den Stack.</summary>
    /// <param name="item">Der zu speichernde Wert.</param>
    public void Push(object item)
    {
      Grow();
      items[Count] = item;
      Count++;
    }

    private void Grow()
    {
      if (items.Length >= Count + 1)
      {
        return;
      }

      Array.Resize(ref items, items.Length * 2);
    }
  }
}