namespace ZbW.ProgrammingFoundation.Challenges.Module17.Flughafen
{
  /// <summary>
  ///   Verwaltet die Landereihenfolge der Flugzeuge.
  ///   Flugzeuge mit dem wenigsten Treibstoff sollen zuerst landen (MinHeap / Priorityqueue).
  ///
  ///   Implementiere die mit TODO markierten Stellen.
  ///   Tipp: Als Warteschlange eignet sich eine Prioritätswarteschlange – entweder dein
  ///   eigener MinHeap (siehe MinMaxHeap) oder die eingebaute PriorityQueue&lt;TElement, TPriority&gt;.
  ///   Musterlösung: Flughafen/Loesung/LandingOrder.cs
  /// </summary>
  public class LandingOrder
  {
    // TODO: Wähle und initialisiere hier eine geeignete Prioritätswarteschlange als Feld.

    /// <summary>Fügt ein Flugzeug in die Prioritätswarteschlange ein.</summary>
    public void AddAirplane(Airplane airplane)
    {
      // TODO: Flugzeug mit seiner Treibstoffmenge als Priorität in die Warteschlange einfügen.
      throw new NotImplementedException("TODO: AddAirplane implementieren");
    }

    /// <summary>Gibt das Flugzeug mit dem wenigsten Treibstoff zurück und entfernt es.</summary>
    public Airplane GetNextAirplane()
    {
      // TODO: Ist die Warteschlange leer, eine InvalidOperationException werfen.
      //       Sonst das Flugzeug mit der höchsten Priorität (wenigster Treibstoff) entfernen
      //       und zurückgeben.
      throw new NotImplementedException("TODO: GetNextAirplane implementieren");
    }
  }
}
