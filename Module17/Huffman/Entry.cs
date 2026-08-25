namespace ZbW.ProgrammingFoundation.Challenges.Module17.Huffman
{
  public class Entry
  {
    public Entry(int key, char? value)
    {
      Key = key;
      Value = value;
    }

    public int Key { get; }

    public char? Value { get; }
  }
}