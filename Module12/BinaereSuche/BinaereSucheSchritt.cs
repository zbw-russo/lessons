namespace ZbW.ProgrammingFoundation.Lessons.Module12.BinaereSuche
{
  /// <summary>
  ///   Beschreibt einen einzelnen Schritt der binären Suche.
  ///   Enthält die aktuellen Zeigerpositionen und eine Erklärung.
  /// </summary>
  public class BinaereSucheSchritt
  {
    /// <summary>Linke Grenze des aktuellen Suchbereichs (Index).</summary>
    public int Links { get; set; }

    /// <summary>Rechte Grenze des aktuellen Suchbereichs (Index).</summary>
    public int Rechts { get; set; }

    /// <summary>Mittlerer Index: (links + rechts) / 2.</summary>
    public int Mitte { get; set; }

    /// <summary>True, wenn der gesuchte Wert bei Mitte gefunden wurde.</summary>
    public bool Gefunden { get; set; }

    /// <summary>Lesbare Erklärung dieses Schritts (für die Statusanzeige).</summary>
    public string Erklaerung { get; set; }
  }
}
