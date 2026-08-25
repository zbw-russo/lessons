namespace ZbW.ProgrammingFoundation.Challenges.Module17.Flughafen
{
  /// <summary>
  ///   Repräsentiert ein Flugzeug mit Informationen über den Abflughafen und die verbleibende Treibstoffmenge.
  ///   Diese Klasse implementiert IComparable, um Flugzeuge nach ihrer Treibstoffmenge zu vergleichen,
  ///   was für die Priorisierung bei Landungen verwendet wird.
  /// </summary>
  public class Airplane : IComparable
  {
    /// <summary>
    ///   Initialisiert eine neue Instanz der Airplane-Klasse.
    /// </summary>
    /// <param name="departureAirport">Der Abflughafen des Flugzeugs.</param>
    /// <param name="quantityOfPetrol">Die verbleibende Treibstoffmenge in Litern.</param>
    public Airplane(string departureAirport, int quantityOfPetrol)
    {
      DepartureAirport = departureAirport;
      QuantityOfPetrol = quantityOfPetrol;
    }

    /// <summary>
    ///   Ruft den Abflughafen des Flugzeugs ab.
    /// </summary>
    /// <value>Der Name des Abflughafens als Zeichenkette.</value>
    public string DepartureAirport { get; }

    /// <summary>
    ///   Ruft die verbleibende Treibstoffmenge des Flugzeugs ab.
    /// </summary>
    /// <value>Die Treibstoffmenge in Litern als Integer-Wert.</value>
    public int QuantityOfPetrol { get; }

    /// <summary>
    ///   Vergleicht das aktuelle Flugzeug mit einem anderen Objekt basierend auf der Treibstoffmenge.
    ///   Flugzeuge mit weniger Treibstoff haben eine höhere Priorität (niedrigerer Wert).
    /// </summary>
    /// <param name="obj">Das zu vergleichende Objekt.</param>
    /// <returns>
    ///   Ein Wert kleiner als null, wenn das aktuelle Flugzeug weniger Treibstoff hat;
    ///   null, wenn beide die gleiche Treibstoffmenge haben;
    ///   ein Wert grösser als null, wenn das aktuelle Flugzeug mehr Treibstoff hat;
    ///   -1, wenn obj kein Airplane-Objekt ist.
    /// </returns>
    public int CompareTo(object obj)
    {
      var otherAirplane = obj as Airplane;
      if (otherAirplane == null)
      {
        return -1;
      }

      return QuantityOfPetrol.CompareTo(otherAirplane.QuantityOfPetrol);
    }
  }
}