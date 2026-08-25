namespace ZbW.ProgrammingFoundation.Lessons.Module17.Loesung
{
  /// <summary>
  ///   MinHeap – vollständige Musterlösung.
  ///   Das kleinste Element liegt immer an Index 0 (Wurzel).
  /// </summary>
  public class MinHeap
  {
    private readonly List<int> _data = new List<int>();

    public int Count
    {
      get
      {
        return _data.Count;
      }
    }

    public bool IsEmpty
    {
      get
      {
        return _data.Count == 0;
      }
    }

    // =========================================================================
    // Aufgabe 1 – Add
    // =========================================================================

    public void Add(int value)
    {
      // TODO 1a – Lösung:
      _data.Add(value);

      // TODO 1b – Lösung:
      SiftUp(_data.Count - 1);
    }

    private void SiftUp(int idx)
    {
      // TODO 1c – Lösung:
      while (idx > 0)
      {
        int parentIdx = GetParentIndex(idx);

        if (_data[idx] < _data[parentIdx])
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

    // =========================================================================
    // Aufgabe 2 – Peek
    // =========================================================================

    public int Peek()
    {
      // TODO 2 – Lösung:
      if (IsEmpty)
      {
        throw new InvalidOperationException("Heap ist leer.");
      }

      return _data[0];
    }

    // =========================================================================
    // Aufgabe 3 – Pop
    // =========================================================================

    public int Pop()
    {
      // TODO 3 – Lösung:
      if (IsEmpty)
      {
        throw new InvalidOperationException("Heap ist leer.");
      }

      int minimum = _data[0];                      // 3b: Minimum merken
      _data[0] = _data[_data.Count - 1];           // 3c: Letztes Element nach oben
      _data.RemoveAt(_data.Count - 1);             // 3d: Letztes Element entfernen

      if (!IsEmpty)
      {
        SiftDown(0);                               // 3e: Heap-Eigenschaft wiederherstellen
      }

      return minimum;                              // 3f: Minimum zurückgeben
    }

    private void SiftDown(int idx)
    {
      // TODO 3g – Lösung:
      while (true)
      {
        int smallest = idx;
        int left     = GetLeftIndex(idx);
        int right    = GetRightIndex(idx);

        if (left < Count && _data[left] < _data[smallest])
        {
          smallest = left;
        }

        if (right < Count && _data[right] < _data[smallest])
        {
          smallest = right;
        }

        if (smallest == idx)
        {
          break; // Heap-Eigenschaft erfüllt
        }

        Swap(idx, smallest);
        idx = smallest;
      }
    }

    // =========================================================================
    // Aufgabe 4 – Index-Hilfsmethoden
    // =========================================================================

    private static int GetParentIndex(int idx)
    {
      // TODO 4a – Lösung:
      return (idx - 1) / 2;
    }

    private static int GetLeftIndex(int idx)
    {
      // TODO 4b – Lösung:
      return 2 * idx + 1;
    }

    private static int GetRightIndex(int idx)
    {
      // TODO 4c – Lösung:
      return 2 * idx + 2;
    }

    // =========================================================================
    // Hilfsmethoden
    // =========================================================================

    private void Swap(int a, int b)
    {
      int temp = _data[a];
      _data[a] = _data[b];
      _data[b] = temp;
    }

    public override string ToString()
    {
      return "[" + string.Join(", ", _data) + "]";
    }
  }
}
