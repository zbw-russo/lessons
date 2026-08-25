namespace ZbW.ProgrammingFoundation.Challenges.Module17.MinMaxHeap.Loesung
{
  using System.Collections;
  using System.Text;

  /// <summary>
  ///   MinHeap – Musterlösung. Das kleinste Element liegt immer oben (Index 0).
  ///   Intern als ArrayList gespeichert.
  ///   Hinweis: Es wurde bewusst auf eine abstrakte Basisklasse verzichtet.
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
      data.Add(item);
      SiftUp(data.Count - 1);
    }

    /// <summary>Gibt das kleinste Element zurück, ohne es zu entfernen.</summary>
    public object Peek()
    {
      if (Empty)
      {
        throw new InvalidOperationException("Heap ist leer.");
      }

      return data[0];
    }

    /// <summary>Entfernt das kleinste Element und stellt die Heap-Eigenschaft durch SiftDown wieder her.</summary>
    public object Pop()
    {
      if (Empty)
      {
        throw new InvalidOperationException("Heap ist leer.");
      }

      object minimum = data[0];
      data[0] = data[data.Count - 1];
      data.RemoveAt(data.Count - 1);

      if (!Empty)
      {
        SiftDown(0);
      }

      return minimum;
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
      return 2 * idx + 1;
    }

    private static int GetParentIndex(int idx)
    {
      return (idx - 1) / 2;
    }

    private static int GetRightIndex(int idx)
    {
      return 2 * idx + 2;
    }

    private void SiftUp(int idx)
    {
      while (idx > 0)
      {
        int parentIdx = GetParentIndex(idx);

        if (((IComparable)data[idx]).CompareTo(data[parentIdx]) < 0)
        {
          Swap(idx, parentIdx);
          idx = parentIdx;
        }
        else
        {
          break;
        }
      }
    }

    private void SiftDown(int idx)
    {
      while (true)
      {
        int smallest = idx;
        int left     = GetLeftIndex(idx);
        int right    = GetRightIndex(idx);

        if (left < data.Count && ((IComparable)data[left]).CompareTo(data[smallest]) < 0)
        {
          smallest = left;
        }

        if (right < data.Count && ((IComparable)data[right]).CompareTo(data[smallest]) < 0)
        {
          smallest = right;
        }

        if (smallest == idx)
        {
          break;
        }

        Swap(idx, smallest);
        idx = smallest;
      }
    }

    private void Swap(int a, int b)
    {
      object temp = data[a];
      data[a] = data[b];
      data[b] = temp;
    }
  }
}
