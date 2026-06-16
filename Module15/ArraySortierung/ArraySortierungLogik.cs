namespace ZbW.ProgrammingFoundation.Lessons.Module15.ArraySortierung
{
  /// <summary>
  ///   Erzeugt ein zufälliges Integer-Array und liefert sortierte Kopien davon.
  ///   Kein UI-Code – nur reine Datenverarbeitung.
  /// </summary>
  public static class ArraySortierungLogik
  {
    /// <summary>
    ///   Erzeugt ein zufälliges Array und gibt Original + mit Array.Sort sortierte Kopie zurück.
    /// </summary>
    /// <param name="laenge">Anzahl der Elemente.</param>
    /// <param name="min">Kleinster möglicher Wert (inklusive).</param>
    /// <param name="max">Grösster möglicher Wert (inklusive).</param>
    /// <exception cref="ArgumentException">Wenn <paramref name="min"/> >= <paramref name="max"/>.</exception>
    public static ArraySortierungErgebnis Generieren(int laenge, int min, int max)
    {
      if (min >= max)
      {
        throw new ArgumentException("Min muss kleiner als Max sein.");
      }

      var rng = new Random();
      var original = new int[laenge];
      for (int i = 0; i < laenge; i++)
      {
        original[i] = rng.Next(min, max + 1);
      }

      return new ArraySortierungErgebnis
      {
        Original = original,
        Sortiert = Array.Empty<int>(),
        Min = original.Min(),
        Max = original.Max(),
        Durchschnitt = original.Average(),
        SortierMethode = string.Empty
      };
    }

    /// <summary>
    ///   Sortiert das Original-Array mit Bubble Sort (O(n²)) und gibt ein neues Ergebnis zurück.
    ///   Das Original wird nicht verändert.
    /// </summary>
    /// <param name="original">Das unsortierte Ausgangs-Array.</param>
    /// <exception cref="ArgumentException">Wenn <paramref name="original"/> leer ist.</exception>
    public static ArraySortierungErgebnis BubbleSortieren(int[] original)
    {
      if (original.Length == 0)
      {
        throw new ArgumentException("Array ist leer.");
      }

      var sortiert = (int[])original.Clone();

      for (int i = 0; i < sortiert.Length - 1; i++)
      {
        for (int j = 0; j < sortiert.Length - 1 - i; j++)
        {
          if (sortiert[j] > sortiert[j + 1])
          {
            (sortiert[j], sortiert[j + 1]) = (sortiert[j + 1], sortiert[j]);
          }
        }
      }

      return ErgebnisErstellen(original, sortiert, "Bubble Sort");
    }

    private static ArraySortierungErgebnis ErgebnisErstellen(int[] original, int[] sortiert, string methode)
    {
      return new ArraySortierungErgebnis
      {
        Original = original,
        Sortiert = sortiert,
        Min = sortiert[0],
        Max = sortiert[sortiert.Length - 1],
        Durchschnitt = sortiert.Average(),
        SortierMethode = methode
      };
    }
  }
}
