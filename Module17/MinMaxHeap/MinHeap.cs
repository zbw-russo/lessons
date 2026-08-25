namespace ZbW.ProgrammingFoundation.Challenges.Module17.MinMaxHeap
{
  using System.Collections;
  using System.Text;

  /// <summary>
  ///   MinHeap – das kleinste Element soll immer oben (Index 0) liegen.
  ///   Intern als ArrayList gespeichert. Die Beziehungen zwischen Eltern und Kindern
  ///   werden über folgende Formeln berechnet:
  ///
  ///     Parent : (idx - 1) / 2
  ///     Links  : 2 * idx + 1
  ///     Rechts : 2 * idx + 2
  ///
  ///   Implementiere die mit TODO markierten Stellen.
  ///   Musterlösung: MinMaxHeap/Loesung/MinHeap.cs
  /// </summary>
  public class MinHeap
  {
    private readonly ArrayList data;

    public MinHeap(ICollection data) : this()
    {
      foreach (var item in data)
      {
        Add(item);
      }
    }

    public MinHeap()
    {
      data = new ArrayList();
    }

    public bool Empty
    {
      get
      {
        return data.Count <= 0;
      }
    }

    public int Size
    {
      get
      {
        return data.Count;
      }
    }

    /// <summary>Fügt ein Element ein und stellt die Heap-Eigenschaft durch SiftUp wieder her.</summary>
    public void Add(object item)
    {
      // TODO: Element ans Ende anhängen (data.Add) und anschliessend SiftUp aufrufen.
      throw new NotImplementedException("TODO: Add implementieren");
    }

    /// <summary>Gibt das kleinste Element zurück, ohne es zu entfernen.</summary>
    public object Peek()
    {
      // TODO: Prüfe ob der Heap leer ist und gib das Wurzelelement (Index 0) zurück.
      throw new NotImplementedException("TODO: Peek implementieren");
    }

    /// <summary>Entfernt das kleinste Element und stellt die Heap-Eigenschaft durch SiftDown wieder her.</summary>
    public object Pop()
    {
      // TODO:
      //   1. Prüfe ob der Heap leer ist
      //   2. Minimum (Index 0) merken
      //   3. Letztes Element an Index 0 verschieben und entfernen
      //   4. SiftDown(0) aufrufen
      //   5. Minimum zurückgeben
      throw new NotImplementedException("TODO: Pop implementieren");
    }

    public void PrintHeap()
    {
      int iMax = data.Count - 1, i;
      if (iMax < 0)
      {
        Console.WriteLine("[]");
        return;
      }

      var b = new StringBuilder();
      b.Append('[');
      for (i = 0; i < iMax; i++)
      {
        b.Append(data[i]);
        b.Append(", ");
      }

      Console.WriteLine(b.Append(data[i]).Append(']'));
    }

    private static int GetLeftIndex(int idx)
    {
      // TODO: return 2 * idx + 1;
      throw new NotImplementedException("TODO: GetLeftIndex implementieren");
    }

    private static int GetParentIndex(int idx)
    {
      // TODO: return (idx - 1) / 2;
      throw new NotImplementedException("TODO: GetParentIndex implementieren");
    }

    private static int GetRightIndex(int idx)
    {
      // TODO: return 2 * idx + 2;
      throw new NotImplementedException("TODO: GetRightIndex implementieren");
    }

    private void SiftUp(int idx)
    {
      // TODO: Solange das Element kleiner als sein Elternteil ist, mit dem Elternteil tauschen
      //       und nach oben wandern. Tipp: GetParentIndex(idx), Swap(a, b) und
      //       ((IComparable)data[idx]).CompareTo(data[parentIdx]) < 0.
      throw new NotImplementedException("TODO: SiftUp implementieren");
    }

    private void SiftDown(int idx)
    {
      // TODO: Das kleinste der beiden Kinder suchen; ist ein Kind kleiner als idx,
      //       tauschen und nach unten wandern, bis die Heap-Eigenschaft gilt.
      //       Tipp: GetLeftIndex/GetRightIndex, Swap und CompareTo(...) < 0.
      throw new NotImplementedException("TODO: SiftDown implementieren");
    }

    private void Swap(int a, int b)
    {
      object temp = data[a];
      data[a] = data[b];
      data[b] = temp;
    }
  }
}
