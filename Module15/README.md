# Module 15 - Bubble Sort

This module contains two small C# console apps that show the same sorting algorithm in two variants:

- `BubbleSortWithoutOptimizations/` runs a simple bubble sort with a fixed number of passes.
- `BubbleSortWithOptimizations/` stops early when the array is already sorted and skips the sorted end of the array.

## Learning Goals

- Understand how bubble sort compares neighboring values.
- See how swaps move larger values toward the end of the array.
- Compare an unoptimized implementation with an optimized implementation.
- Count comparisons and swaps to make the difference visible in the console output.

## Bubble Sort Idea

Bubble sort walks through an array and compares each value with the next value.
If the two values are in the wrong order, they are swapped.
After one full pass, the largest value has "bubbled" to the end of the array.

Example:

```text
9, 4, 7, 3
4, 9, 7, 3
4, 7, 9, 3
4, 7, 3, 9
```

## Version 1: Without Optimizations

The unoptimized app always performs the same number of passes and always compares all neighboring pairs.
It keeps working even if parts of the array are already sorted.

For an array with `n` elements:

- Passes: `n - 1`
- Comparisons per pass: `n - 1`
- Total comparisons: `(n - 1) * (n - 1)`

Run it with:

```bash
dotnet run --project Module15/BubbleSortWithoutOptimizations
```

## Version 2: With Optimizations

The optimized app uses two improvements:

- It stops early if a full pass does not swap anything.
- It remembers the last swap position and does not compare values after that position again.

This keeps the same result, but avoids unnecessary work.
The best case is an already sorted array, where the optimized version needs only one pass.

Run it with:

```bash
dotnet run --project Module15/BubbleSortWithOptimizations
```

## Comparison

Both apps sort the same starting array:

```text
9, 4, 7, 3, 1, 8, 2, 6, 5
```

The console output prints every pass, plus the number of comparisons and swaps.
Use those numbers to compare how much work each version performs.
