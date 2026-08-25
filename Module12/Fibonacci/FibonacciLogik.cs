namespace ZbW.ProgrammingFoundation.Lessons.Module12.Fibonacci
{
  /// <summary>
  /// Berechnet die Fibonacci-Folge mit drei verschiedenen Algorithmen.
  /// Alle Methoden geben ein Array mit den ersten <c>n</c> Fibonacci-Zahlen zurück.
  /// </summary>
  public static class FibonacciLogik
  {
    /// <summary>
    /// Berechnet F(1)..F(n) iterativ mit einer Schleife.
    /// Zwei Variablen speichern die letzten zwei Werte; bei jedem Schritt wird
    /// der nächste Wert als Summe berechnet und die Variablen weitergeschoben.
    /// Zeitkomplexität: O(n) — sehr schnell, auch für grosse n.
    /// </summary>
    /// <param name="n">Anzahl der zu berechnenden Fibonacci-Zahlen.</param>
    /// <returns>Array mit F(1) bis F(n).</returns>
    public static long[] BerechneIterativ(int n)
    {
      var seq = new long[n];
      long a = 0L, b = 1L;
      for (int i = 0; i < n; i++)
      {
        seq[i] = b;
        long c = a + b;
        a = b;
        b = c;
      }

      return seq;
    }

    /// <summary>
    /// Berechnet F(1)..F(n) mit der klassischen Rekursion F(n) = F(n-1) + F(n-2).
    /// Jede Zahl wird einzeln berechnet; dabei entstehen viele doppelte Aufrufe.
    /// Zeitkomplexität: O(2^n) — für n &gt; 30 deutlich langsamer (lehrreich!).
    /// </summary>
    /// <param name="n">Anzahl der zu berechnenden Fibonacci-Zahlen.</param>
    /// <returns>Array mit F(1) bis F(n).</returns>
    public static long[] BerechneRekursiv(int n)
    {
      var seq = new long[n];
      for (int i = 0; i < n; i++)
      {
        seq[i] = BerechneEinzelRekursiv(i + 1);
      }

      return seq;
    }

    /// <summary>
    /// Berechnet F(1)..F(n) mit dem Fast-Doubling-Algorithmus (Teile &amp; Herrsche).
    /// Nutzt die Identitäten F(2k) = F(k)·(2·F(k+1)−F(k)) und F(2k+1) = F(k)²+F(k+1)².
    /// Zeitkomplexität: O(log n) — extrem effizient.
    /// </summary>
    /// <param name="n">Anzahl der zu berechnenden Fibonacci-Zahlen.</param>
    /// <returns>Array mit F(1) bis F(n).</returns>
    public static long[] BerechneTeilUndHerrsche(int n)
    {
      var seq = new long[n];
      for (int i = 0; i < n; i++)
      {
        seq[i] = BerechneVerdopplung(i + 1).Aktuell;
      }

      return seq;
    }

    private static long BerechneEinzelRekursiv(int n)
    {
      if (n <= 2)
      {
        return 1L;
      }

      return BerechneEinzelRekursiv(n - 1) + BerechneEinzelRekursiv(n - 2);
    }

    private static FibPaar BerechneVerdopplung(int n)
    {
      if (n == 0)
      {
        return new FibPaar(0L, 1L);
      }

      FibPaar halb = BerechneVerdopplung(n / 2);
      long c = halb.Aktuell * (2 * halb.Naechste - halb.Aktuell); // F(2k)
      long d = halb.Aktuell * halb.Aktuell + halb.Naechste * halb.Naechste; // F(2k+1)

      if (n % 2 == 0)
      {
        return new FibPaar(c, d);
      }
      else
      {
        return new FibPaar(d, c + d);
      }
    }
  }
}
