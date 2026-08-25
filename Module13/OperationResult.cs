namespace ZbW.ProgrammingFoundation.Lessons.Module13
{
  /// <summary>
  ///   Ergebnis einer einzelnen Datenstruktur-Operation.
  ///   Wird von den Logik-Klassen zurückgegeben und von den Views zur Anzeige genutzt.
  /// </summary>
  public sealed class OperationResult
  {
    /// <summary>Erstellt ein neues Ergebnisobjekt.</summary>
    /// <param name="message">Statusmeldung für die Anzeige.</param>
    /// <param name="highlightIndex">Index des hervorzuhebenden Knotens; -1 wenn keiner.</param>
    /// <param name="isError"><c>true</c> wenn die Operation fehlgeschlagen ist.</param>
    public OperationResult(string message, int highlightIndex = -1, bool isError = false)
    {
      Message = message;
      HighlightIndex = highlightIndex;
      IsError = isError;
    }

    /// <summary>Index des hervorzuhebenden Knotens, -1 wenn keiner.</summary>
    public int HighlightIndex { get; }

    /// <summary>true wenn die Operation fehlgeschlagen ist (Fehlerfarbe in der View).</summary>
    public bool IsError { get; }

    /// <summary>Statusmeldung für die Anzeige (z. B. "Add("x") → Count = 3").</summary>
    public string Message { get; }
  }
}