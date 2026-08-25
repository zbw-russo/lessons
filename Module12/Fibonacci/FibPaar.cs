namespace ZbW.ProgrammingFoundation.Lessons.Module12.Fibonacci
{
  /// <summary>
  /// Speichert zwei aufeinanderfolgende Fibonacci-Zahlen F(k) und F(k+1).
  /// Wird vom Fast-Doubling-Algorithmus verwendet, um beide Werte auf einmal zurückzugeben.
  /// </summary>
  public class FibPaar
  {
    /// <summary>Fibonacci-Zahl F(k) — der aktuelle Wert.</summary>
    public long Aktuell { get; }

    /// <summary>Fibonacci-Zahl F(k+1) — der nächste Wert in der Folge.</summary>
    public long Naechste { get; }

    /// <summary>
    /// Erstellt ein neues Fibonacci-Paar mit zwei aufeinanderfolgenden Werten.
    /// </summary>
    /// <param name="aktuell">Fibonacci-Zahl F(k).</param>
    /// <param name="naechste">Fibonacci-Zahl F(k+1).</param>
    public FibPaar(long aktuell, long naechste)
    {
      Aktuell = aktuell;
      Naechste = naechste;
    }
  }
}
