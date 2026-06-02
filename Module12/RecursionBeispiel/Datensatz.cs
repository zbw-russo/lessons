namespace ZbW.ProgrammingFoundation.Lessons.Module12.RecursionBeispiel
{
  /// <summary>
  ///   Repräsentiert einen Datensatz mit hierarchischer Struktur für Rekursionsbeispiele.
  ///   Diese Klasse wird verwendet, um Baumstrukturen darzustellen, bei denen jeder Datensatz
  ///   einen optionalen Parent-Verweis haben kann.
  /// </summary>
  public class Datensatz
  {
    /// <summary>
    ///   Eindeutige Identifikation des Datensatzes.
    /// </summary>
    /// <value>Die eindeutige ID des Datensatzes.</value>
    public int Id { get; set; }

    /// <summary>
    ///   Der Name oder Bezeichnung des Datensatzes.
    /// </summary>
    /// <value>Der Name des Datensatzes.</value>
    public string Name { get; set; }

    /// <summary>
    ///   Die ID des übergeordneten Datensatzes. Null bedeutet, dass es sich um einen Wurzelknoten handelt.
    /// </summary>
    /// <value>Die ID des übergeordneten Datensatzes oder null für Wurzelknoten.</value>
    public int? ParentId { get; set; }
  }
}