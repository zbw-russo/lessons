namespace ZbW.ProgrammingFoundation.Lessons.Module12.TurmVonHanoi
{
  /// <summary>
  /// Generiert die Zugfolge für das Türme-von-Hanoi-Problem mit drei Algorithmen.
  /// Alle Methoden geben eine Liste von <see cref="Zug"/>-Objekten zurück,
  /// die nacheinander ausgeführt werden müssen, um alle Scheiben von Stab A nach Stab C zu verschieben.
  /// </summary>
  public static class HanoiLogik
  {
    /// <summary>
    /// Löst das Problem rekursiv nach dem klassischen Divide-and-Conquer-Prinzip:
    /// n-1 Scheiben auf den Hilfsstab, unterste Scheibe ans Ziel, n-1 Scheiben ans Ziel.
    /// Zeitkomplexität: O(2^n – 1).
    /// </summary>
    /// <param name="n">Anzahl der Scheiben.</param>
    /// <param name="von">Quell-Stab (0 = A, 1 = B, 2 = C).</param>
    /// <param name="nach">Ziel-Stab (0 = A, 1 = B, 2 = C).</param>
    /// <param name="hilfs">Hilfs-Stab (0 = A, 1 = B, 2 = C).</param>
    /// <returns>Liste aller Züge in der richtigen Reihenfolge.</returns>
    public static List<Zug> GeneriereRekursiv(int n, int von, int nach, int hilfs)
    {
      var zuege = new List<Zug>();
      RekursivIntern(n, von, nach, hilfs, zuege);
      return zuege;
    }

    /// <summary>
    /// Löst das Problem iterativ mit dem Rotationsmuster der kleinsten Scheibe.
    /// Die kleinste Scheibe rotiert bei jedem ungeraden Schritt immer in dieselbe Richtung;
    /// bei jedem geraden Schritt gibt es genau einen legalen Zug ohne die kleinste Scheibe.
    /// Zeitkomplexität: O(2^n – 1).
    /// </summary>
    /// <param name="n">Anzahl der Scheiben.</param>
    /// <returns>Liste aller Züge in der richtigen Reihenfolge.</returns>
    public static List<Zug> GeneriereIterativ(int n)
    {
      var zuege = new List<Zug>();

      var staebe = new Stack<int>[3];
      for (int i = 0; i < 3; i++)
      {
        staebe[i] = new Stack<int>();
      }

      for (int i = n; i >= 1; i--)
      {
        staebe[0].Push(i);
      }

      int anzahlZuege = (int)Math.Pow(2, n) - 1; // n Scheiben brauchen immer genau 2^n - 1 Züge
      // Die Richtung kehrt sich mit jeder Scheibe um — durch Ausprobieren (n=1,2,3) selbst nachvollziehbar:
      //   n=1 (ungerade): A→C→B→A  →  {0, 2, 1}
      //   n=2 (gerade):   A→B→C→A  →  {0, 1, 2}
      //   n=3 (ungerade): A→C→B→A  →  {0, 2, 1}
      int[] rotation = (n % 2 != 0) ? new[] { 0, 2, 1 } : new[] { 0, 1, 2 };
      int rotationsPosition = 0;

      for (int schritt = 1; schritt <= anzahlZuege; schritt++)
      {
        if (schritt % 2 == 1)
        {
          // Ungerader Schritt: kleinste Scheibe in Rotationsrichtung verschieben
          int von = rotation[rotationsPosition % 3];
          int nach = rotation[(rotationsPosition + 1) % 3];
          zuege.Add(new Zug(von, nach));
          staebe[nach].Push(staebe[von].Pop());
          rotationsPosition++;
        }
        else
        {
          // Gerader Schritt: einziger legaler Zug zwischen den beiden anderen Stäben
          int kleinerStab = rotation[rotationsPosition % 3];
          int stab1 = (kleinerStab + 1) % 3; // die anderen zwei Stäbe via Modulo ermitteln
          int stab2 = (kleinerStab + 2) % 3;

          // Leerer Stab zählt als "unendlich gross" — so gewinnt immer der kleinere Wert
          int obersteStab1 = staebe[stab1].Count > 0 ? staebe[stab1].Peek() : int.MaxValue;
          int obersteStab2 = staebe[stab2].Count > 0 ? staebe[stab2].Peek() : int.MaxValue;

          int von = obersteStab1 < obersteStab2 ? stab1 : stab2;
          int nach = obersteStab1 < obersteStab2 ? stab2 : stab1;
          zuege.Add(new Zug(von, nach));
          staebe[nach].Push(staebe[von].Pop());
        }
      }

      return zuege;
    }

    /// <summary>
    /// Löst das Problem mit einem expliziten Work-Stack statt echter Rekursion.
    /// Macht die Teile-und-Herrsche-Struktur sichtbar: Teilprobleme werden als
    /// <see cref="Teilaufgabe"/>-Objekte auf einen Stack gelegt und nacheinander abgearbeitet.
    /// Zeitkomplexität: O(2^n – 1).
    /// </summary>
    /// <param name="n">Anzahl der Scheiben.</param>
    /// <param name="von">Quell-Stab (0 = A, 1 = B, 2 = C).</param>
    /// <param name="nach">Ziel-Stab (0 = A, 1 = B, 2 = C).</param>
    /// <param name="hilfs">Hilfs-Stab (0 = A, 1 = B, 2 = C).</param>
    /// <returns>Liste aller Züge in der richtigen Reihenfolge.</returns>
    public static List<Zug> GeneriereTeilUndHerrsche(int n, int von, int nach, int hilfs)
    {
      var zuege = new List<Zug>();
      var warteschlange = new Stack<Teilaufgabe>();
      warteschlange.Push(new Teilaufgabe(n, von, nach, hilfs));

      while (warteschlange.Count > 0)
      {
        Teilaufgabe aufgabe = warteschlange.Pop();

        if (aufgabe.AnzahlScheiben == 1)
        {
          zuege.Add(new Zug(aufgabe.Von, aufgabe.Nach));
          continue;
        }

        // Teilprobleme in umgekehrter Reihenfolge einreihen (Stack = LIFO):
        warteschlange.Push(new Teilaufgabe(aufgabe.AnzahlScheiben - 1, aufgabe.Hilfs, aufgabe.Nach, aufgabe.Von));
        warteschlange.Push(new Teilaufgabe(1, aufgabe.Von, aufgabe.Nach, aufgabe.Hilfs));
        warteschlange.Push(new Teilaufgabe(aufgabe.AnzahlScheiben - 1, aufgabe.Von, aufgabe.Hilfs, aufgabe.Nach));
      }

      return zuege;
    }

    private static void RekursivIntern(int n, int von, int nach, int hilfs, List<Zug> zuege)
    {
      if (n <= 0)
      {
        return;
      }

      RekursivIntern(n - 1, von, hilfs, nach, zuege);
      zuege.Add(new Zug(von, nach));
      RekursivIntern(n - 1, hilfs, nach, von, zuege);
    }

    private class Teilaufgabe
    {
      public int AnzahlScheiben { get; }
      public int Von { get; }
      public int Nach { get; }
      public int Hilfs { get; }

      public Teilaufgabe(int anzahlScheiben, int von, int nach, int hilfs)
      {
        AnzahlScheiben = anzahlScheiben;
        Von = von;
        Nach = nach;
        Hilfs = hilfs;
      }
    }
  }
}
