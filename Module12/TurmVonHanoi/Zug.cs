namespace ZbW.ProgrammingFoundation.Lessons.Module12.TurmVonHanoi
{
  /// <summary>
  /// Beschreibt einen einzelnen Zug beim Türme-von-Hanoi-Problem:
  /// eine Scheibe wird von einem Stab auf einen anderen verschoben.
  /// Stäbe werden als Zahlen dargestellt: 0 = A, 1 = B, 2 = C.
  /// </summary>
  public class Zug
  {
    /// <summary>Stab, von dem die Scheibe genommen wird (0 = A, 1 = B, 2 = C).</summary>
    public int Von { get; set; }

    /// <summary>Stab, auf den die Scheibe gelegt wird (0 = A, 1 = B, 2 = C).</summary>
    public int Nach { get; set; }

    /// <summary>
    /// Erstellt einen neuen Zug.
    /// </summary>
    /// <param name="von">Quell-Stab (0 = A, 1 = B, 2 = C).</param>
    /// <param name="nach">Ziel-Stab (0 = A, 1 = B, 2 = C).</param>
    public Zug(int von, int nach)
    {
      Von = von;
      Nach = nach;
    }
  }
}
