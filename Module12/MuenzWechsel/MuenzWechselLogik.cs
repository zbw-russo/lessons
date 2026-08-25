namespace ZbW.ProgrammingFoundation.Lessons.Module12.MuenzWechsel
{
  /// <summary>
  /// Berechnet das Münzwechselproblem mit dem Greedy-Algorithmus.
  /// Greedy bedeutet: immer die grösste passende Münze zuerst wählen.
  /// Achtung: funktioniert nur bei bestimmten Münzsystemen korrekt (z.B. Euro),
  /// nicht aber bei beliebigen Münzsets.
  /// </summary>
  public static class MuenzWechselLogik
  {
    /// <summary>
    /// Berechnet das Wechselgeld für einen Betrag mit dem Greedy-Algorithmus.
    /// Die grösste Münze, die noch passt, wird immer zuerst gewählt.
    /// </summary>
    /// <param name="betrag">Der zu wechselnde Betrag (in Rappen/Cents).</param>
    /// <param name="muenzen">Die verfügbaren Münzwerte (werden absteigend sortiert).</param>
    /// <returns>Liste der gewählten Münzen in der Reihenfolge, in der sie gewählt wurden.</returns>
    public static List<int> BerechneWechselgeld(int betrag, int[] muenzen)
    {
      int[] sortiert = (int[])muenzen.Clone();
      Array.Sort(sortiert, (a, b) => b - a); // absteigend sortieren: grösste zuerst

      var ergebnis = new List<int>();

      foreach (int muenze in sortiert)
      {
        while (betrag >= muenze)
        {
          ergebnis.Add(muenze);
          betrag -= muenze;
        }
      }

      return ergebnis;
    }
  }
}
