namespace ZbW.ProgrammingFoundation.Lessons.Module15.ArraySortierung
{
  /// <summary>
  ///   Hält das Ergebnis einer Array-Generierung: Original, sortierte Kopie und Statistik.
  /// </summary>
  public sealed class ArraySortierungErgebnis
  {
    public int[] Original { get; init; } = Array.Empty<int>();
    public int[] Sortiert { get; init; } = Array.Empty<int>();
    public int Min { get; init; }
    public int Max { get; init; }
    public double Durchschnitt { get; init; }
    public string SortierMethode { get; init; } = string.Empty;
  }
}
