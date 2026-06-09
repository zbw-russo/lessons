int[] numbers = [9, 4, 7, 3, 1, 8, 2, 6, 5];
int comparisons = 0;
int swaps = 0;

Console.WriteLine("Bubble Sort without optimizations");
Console.Write("Original: ");
PrintArray(numbers);

BubbleSort(numbers);

Console.Write("Sorted:   ");
PrintArray(numbers);
Console.WriteLine($"Comparisons: {comparisons}");
Console.WriteLine($"Swaps:       {swaps}");

void BubbleSort(int[] values)
{
    for (int pass = 0; pass < values.Length - 1; pass++)
    {
        Console.WriteLine($"Pass {pass + 1}");

        for (int index = 0; index < values.Length - 1; index++)
        {
            comparisons++;

            if (values[index] > values[index + 1])
            {
                (values[index], values[index + 1]) = (values[index + 1], values[index]);
                swaps++;
            }
        }

        PrintArray(values);
    }
}

void PrintArray(int[] values)
{
    Console.WriteLine(string.Join(", ", values));
}
