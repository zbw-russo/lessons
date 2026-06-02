namespace ZbW.ProgrammingFoundation.Lessons.Module13.SinglyLinkedList.Loesung
{
  /// <summary>Einzelner Knoten der einfach verketteten Liste.</summary>
  public class Node
  {
    /// <summary>Der im Knoten gespeicherte Wert.</summary>
    public object Data { get; set; }

    /// <summary>Zeiger auf den nächsten Knoten; <c>null</c> beim letzten Element.</summary>
    public Node Link { get; set; }
  }
}