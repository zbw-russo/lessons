namespace ZbW.ProgrammingFoundation.Lessons.Module13.DoublyLinkedList.Loesung
{
  /// <summary>Einzelner Knoten der doppelt verketteten Liste.</summary>
  public class Node
  {
    /// <summary>Der im Knoten gespeicherte Wert.</summary>
    public object Data { get; set; }

    /// <summary>Zeiger auf den nächsten Knoten; <c>null</c> beim letzten Element.</summary>
    public Node Link { get; set; }

    /// <summary>Zeiger auf den vorherigen Knoten; <c>null</c> beim ersten Element.</summary>
    public Node PrevLink { get; set; }
  }
}