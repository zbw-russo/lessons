namespace ZbW.ProgrammingFoundation.Lessons.Module12.BinaereSuche
{
  /// <summary>
  ///   Binäre Suche in einem <b>sortierten</b> Array.
  ///   Beide Varianten liefern dieselbe Schrittfolge – einmal mit Schleife, einmal rekursiv.
  ///   Komplexität: O(log n) – bei jedem Schritt wird der Suchbereich halbiert.
  /// </summary>
  public static class BinaereSucheLogik
  {
    /// <summary>
    ///   Iterative Variante mit while-Schleife und drei Zeigern: links, rechts, mitte.
    /// </summary>
    /// <param name="zahlen">Sortiertes Eingabe-Array.</param>
    /// <param name="gesuchterWert">Der zu suchende Wert.</param>
    /// <returns>Liste aller Suchschritte (für die Animation).</returns>
    public static List<BinaereSucheSchritt> SucheIterativ(int[] zahlen, int gesuchterWert)
    {
      var schritte = new List<BinaereSucheSchritt>();
      int links = 0;
      int rechts = zahlen.Length - 1;

      while (links <= rechts)
      {
        int mitte = (links + rechts) / 2; // Mitte des aktuellen Suchbereichs

        string erklaerung;
        bool gefunden = zahlen[mitte] == gesuchterWert;

        if (gefunden)
        {
          erklaerung = $"zahlen[{mitte}] = {zahlen[mitte]} == {gesuchterWert}  →  Gefunden!";
        }
        else if (zahlen[mitte] < gesuchterWert)
        {
          erklaerung = $"zahlen[{mitte}] = {zahlen[mitte]} < {gesuchterWert}  →  links = {mitte + 1}";
        }
        else
        {
          erklaerung = $"zahlen[{mitte}] = {zahlen[mitte]} > {gesuchterWert}  →  rechts = {mitte - 1}";
        }

        schritte.Add(
          new BinaereSucheSchritt
          {
            Links = links,
            Rechts = rechts,
            Mitte = mitte,
            Gefunden = gefunden,
            Erklaerung = erklaerung
          });

        if (gefunden)
        {
          return schritte;
        }

        if (zahlen[mitte] < gesuchterWert)
        {
          links = mitte + 1; // Wert liegt rechts von der Mitte
        }
        else
        {
          rechts = mitte - 1; // Wert liegt links von der Mitte
        }
      }

      schritte.Add(
        new BinaereSucheSchritt
        {
          Links = -1,
          Rechts = -1,
          Mitte = -1,
          Gefunden = false,
          Erklaerung = $"{gesuchterWert} ist nicht im Array vorhanden."
        });

      return schritte;
    }

    /// <summary>
    ///   Rekursive Variante – liefert dieselben Schritte wie die iterative Lösung.
    /// </summary>
    /// <param name="zahlen">Sortiertes Eingabe-Array.</param>
    /// <param name="gesuchterWert">Der zu suchende Wert.</param>
    /// <returns>Liste aller Suchschritte (für die Animation).</returns>
    public static List<BinaereSucheSchritt> SucheRekursiv(int[] zahlen, int gesuchterWert)
    {
      var schritte = new List<BinaereSucheSchritt>();
      SucheRekursivIntern(zahlen, gesuchterWert, 0, zahlen.Length - 1, schritte);
      return schritte;
    }

    private static bool SucheRekursivIntern(int[] zahlen, int gesuchterWert, int links, int rechts, List<BinaereSucheSchritt> schritte)
    {
      if (links > rechts) // Abbruchbedingung: Suchbereich ist leer
      {
        schritte.Add(
          new BinaereSucheSchritt
          {
            Links = -1,
            Rechts = -1,
            Mitte = -1,
            Gefunden = false,
            Erklaerung = $"{gesuchterWert} ist nicht im Array vorhanden."
          });

        return false;
      }

      int mitte = (links + rechts) / 2;
      bool gefunden = zahlen[mitte] == gesuchterWert;

      string erklaerung;
      if (gefunden)
      {
        erklaerung = $"zahlen[{mitte}] = {zahlen[mitte]} == {gesuchterWert}  →  Gefunden!";
      }
      else if (zahlen[mitte] < gesuchterWert)
      {
        erklaerung = $"zahlen[{mitte}] = {zahlen[mitte]} < {gesuchterWert}  →  rekursiv mit links = {mitte + 1}";
      }
      else
      {
        erklaerung = $"zahlen[{mitte}] = {zahlen[mitte]} > {gesuchterWert}  →  rekursiv mit rechts = {mitte - 1}";
      }

      schritte.Add(
        new BinaereSucheSchritt
        {
          Links = links,
          Rechts = rechts,
          Mitte = mitte,
          Gefunden = gefunden,
          Erklaerung = erklaerung
        });

      if (gefunden)
      {
        return true;
      }

      if (zahlen[mitte] < gesuchterWert)
      {
        return SucheRekursivIntern(zahlen, gesuchterWert, mitte + 1, rechts, schritte);
      }

      return SucheRekursivIntern(zahlen, gesuchterWert, links, mitte - 1, schritte);
    }
  }
}