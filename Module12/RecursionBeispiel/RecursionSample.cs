namespace ZbW.ProgrammingFoundation.Lessons.Module12.RecursionBeispiel
{
  /// <summary>
  ///   Demonstriert die Anwendung von Rekursion für die Darstellung hierarchischer Datenstrukturen.
  ///   Diese Klasse erstellt eine Baumstruktur aus Datensätzen und zeigt diese rekursiv auf der Konsole an.
  /// </summary>
  public class RecursionSample
  {
    /// <summary>
    ///   Initialisiert eine neue Instanz der RecursionSample-Klasse und erstellt eine Beispiel-Datenstruktur.
    ///   Die Datenstruktur repräsentiert einen hierarchischen Baum mit verschiedenen Ebenen.
    /// </summary>
    public RecursionSample()
    {
      List = new List<Datensatz>();

      List.Add(new Datensatz { Id = 1, Name = "A", ParentId = null });
      List.Add(new Datensatz { Id = 2, Name = "B", ParentId = 1 });
      List.Add(new Datensatz { Id = 3, Name = "C", ParentId = 1 });
      List.Add(new Datensatz { Id = 4, Name = "D", ParentId = 2 });
      List.Add(new Datensatz { Id = 5, Name = "E", ParentId = 2 });
      List.Add(new Datensatz { Id = 6, Name = "F", ParentId = 4 });
      List.Add(new Datensatz { Id = 7, Name = "G", ParentId = 4 });
      List.Add(new Datensatz { Id = 8, Name = "H", ParentId = 3 });
    }

    /// <summary>
    ///   Die Liste aller Datensätze, die die hierarchische Struktur repräsentieren.
    /// </summary>
    /// <value>Eine Liste von Datensatz-Objekten mit Parent-Child-Beziehungen.</value>
    private List<Datensatz> List { get; }

    /// <summary>
    ///   Erstellt und gibt die Baumstruktur auf der Konsole aus.
    ///   Verwendet Rekursion, um die hierarchische Struktur darzustellen.
    /// </summary>
    public void BuildTree()
    {
      PrintTree(List, null, 1);
    }

    /// <summary>
    ///   Gibt rekursiv einen Teil des Baums auf der Konsole aus.
    ///   Diese Methode ruft sich selbst für jeden Kindknoten auf.
    /// </summary>
    /// <param name="list">Die vollständige Liste aller Datensätze.</param>
    /// <param name="parentId">Die ID des übergeordneten Knotens oder null für Wurzelknoten.</param>
    /// <param name="level">Die aktuelle Einrückungsebene für die Darstellung.</param>
    private void PrintTree(List<Datensatz> list, int? parentId, int level)
    {
      // select * from list where ParentId = parentId
      var filteredList = list.Where(x => x.ParentId == parentId);

      foreach (var ds in filteredList)
      {
        Console.WriteLine("".PadRight(level) + "|-" + ds.Name);
        PrintTree(list, ds.Id, level + 1);
      }
    }
  }
}