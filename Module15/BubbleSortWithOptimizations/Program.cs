int[] numbers = [9, 4, 7, 3, 1, 8, 2, 6, 5];
int comparisons = 0;
int swaps = 0;

Console.WriteLine("Bubble Sort with optimizations");
Console.Write("Original: ");
PrintArray(numbers);

BubbleSort(numbers);

Console.Write("Sorted:   ");
PrintArray(numbers);
Console.WriteLine($"Comparisons: {comparisons}");
Console.WriteLine($"Swaps:       {swaps}");

void BubbleSort(int[] values)
{
    int unsortedUntil = values.Length - 1;
    bool swapped = true;
    int pass = 1;

    while (swapped && unsortedUntil > 0)
    {
        swapped = false;
        int lastSwapIndex = 0;

        Console.WriteLine($"Pass {pass}");

        for (int index = 0; index < unsortedUntil; index++)
        {
            comparisons++;

            if (values[index] > values[index + 1])
            {
                (values[index], values[index + 1]) = (values[index + 1], values[index]);
                swaps++;
                swapped = true;
                lastSwapIndex = index;
            }
        }

        unsortedUntil = lastSwapIndex;
        pass++;
        PrintArray(values);
    }
}

void PrintArray(int[] values)
{
    Console.WriteLine(string.Join(", ", values));
}
