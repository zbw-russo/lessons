namespace ZbW.ProgrammingFoundation.Lessons.Module12.Iteration
{
  /// <summary>
  ///   Logik für die Iteration-Übung: Summe und Maximum eines int-Arrays.
  ///   Zwei verschiedene Schleifen-Typen: for und foreach.
  /// </summary>
  public static class IterationLogik
  {
    /// <summary>
    ///   Berechnet die Summe aller Zahlen im Array.
    ///   Verwendet eine <b>for</b>-Schleife, weil der Index bekannt ist.
    /// </summary>
    /// <param name="zahlen">Das Eingabe-Array.</param>
    /// <returns>Summe aller Werte.</returns>
    public static int Summe(int[] zahlen)
    {
      int summe = 0;
      for (int i = 0; i < zahlen.Length; i++) // i läuft von 0 bis zahlen.Length - 1
      {
        summe = summe + zahlen[i];
      }

      return summe;
    }

    /// <summary>
    ///   Gibt den grössten Wert im Array zurück.
    ///   Verwendet eine <b>foreach</b>-Schleife, weil der Index nicht benötigt wird.
    /// </summary>
    /// <param name="zahlen">Das Eingabe-Array (muss mindestens ein Element enthalten).</param>
    /// <returns>Grösster Wert; 0 bei leerem Array.</returns>
    public static int Maximum(int[] zahlen)
    {
      if (zahlen.Length == 0)
      {
        return 0; // leeres Array – kein Maximum definiert
      }

      int maximum = zahlen[0]; // erster Wert als Startwert für den Vergleich

      foreach (int zahl in zahlen)
      {
        if (zahl > maximum)
        {
          maximum = zahl; // neuer Höchstwert gefunden
        }
      }

      return maximum;
    }
  }
}
