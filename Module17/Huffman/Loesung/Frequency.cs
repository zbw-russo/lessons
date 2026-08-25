namespace ZbW.ProgrammingFoundation.Challenges.Module17.Huffman.Loesung
{
  /// <summary>
  ///   Musterlösung – zählt die Häufigkeit jedes Zeichens in einem Text.
  /// </summary>
  public class Frequency
  {
    /// <summary>
    ///   Zählt für jedes vorkommende Zeichen die Häufigkeit und gibt je Zeichen
    ///   einen Entry (Key = Häufigkeit, Value = Zeichen) zurück.
    /// </summary>
    public List<Entry> CountFrequency(string text)
    {
      var counts = new Dictionary<char, int>();

      foreach (char c in text)
      {
        counts[c] = counts.TryGetValue(c, out int n) ? n + 1 : 1;
      }

      var result = new List<Entry>();
      foreach (var pair in counts)
      {
        result.Add(new Entry(pair.Value, pair.Key));
      }

      return result;
    }
  }
}
