namespace ZbW.ProgrammingFoundation.Challenges.Module17.Flughafen.Loesung
{
  /// <summary>
  ///   Musterlösung – verwaltet die Landereihenfolge der Flugzeuge.
  ///   Flugzeuge mit dem wenigsten Treibstoff landen zuerst (MinHeap / Priorityqueue).
  /// </summary>
  public class LandingOrder
  {
    // .NET bietet seit 6.0 eine eingebaute PriorityQueue<TElement, TPriority>.
    // Hier verwenden wir sie direkt: Priorität = Treibstoffmenge (kleinster Wert = höchste Priorität).
    private readonly PriorityQueue<Airplane, int> _queue = new PriorityQueue<Airplane, int>();

    /// <summary>Fügt ein Flugzeug in die Prioritätswarteschlange ein.</summary>
    public void AddAirplane(Airplane airplane)
    {
      _queue.Enqueue(airplane, airplane.QuantityOfPetrol);
    }

    /// <summary>Gibt das Flugzeug mit dem wenigsten Treibstoff zurück und entfernt es.</summary>
    public Airplane GetNextAirplane()
    {
      if (_queue.Count == 0)
      {
        throw new InvalidOperationException("Keine Flugzeuge in der Warteschlange.");
      }

      return _queue.Dequeue();
    }
  }
}
