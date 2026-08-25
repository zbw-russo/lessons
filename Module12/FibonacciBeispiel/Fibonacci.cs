namespace ZbW.ProgrammingFoundation.Lessons.Module12.FibonacciBeispiel
{
  /// <summary>
  ///   Stellt Methoden zur Berechnung der Fibonacci-Zahlen bereit.
  ///   Die Fibonacci-Folge ist eine Zahlenfolge, bei der jede Zahl die Summe der beiden vorhergehenden ist.
  /// </summary>
  public static class Fibonacci
  {
    /// <summary>
    ///   Berechnet die n-te Fibonacci-Zahl mit einer iterativen Methode.
    ///   Diese Implementierung ist effizienter als die rekursive Variante für grössere Werte.
    /// </summary>
    /// <param name="n">Die Position in der Fibonacci-Folge (0-basiert).</param>
    /// <returns>Die n-te Fibonacci-Zahl.</returns>
    /// <remarks>Diese Methode ist noch nicht vollständig implementiert.</remarks>
    public static int FibIterativ(int n)
    {
      //hier iterative Methode implementieren

      return 1;
    }

    /// <summary>
    ///   Berechnet die n-te Fibonacci-Zahl mit einer rekursiven Methode.
    ///   Diese Implementierung ist mathematisch elegant, aber für grössere Werte ineffizient.
    /// </summary>
    /// <param name="n">Die Position in der Fibonacci-Folge (0-basiert).</param>
    /// <returns>Die n-te Fibonacci-Zahl.</returns>
    /// <remarks>Für n > 40 kann diese Methode sehr langsam werden aufgrund der exponentiellen Zeitkomplexität.</remarks>
    public static int FibRecursiv(int n)
    {
      if (n <= 1)
      {
        return n;
      }

      return FibRecursiv(n - 1) + FibRecursiv(n - 2);
    }
  }
}