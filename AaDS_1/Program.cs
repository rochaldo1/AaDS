using AaDS_1;
using System.Diagnostics;

public static class Program
{
    private static void Main(string[] args)
    {
        Stopwatch sw = new();
        TimeSpan elapsed = new();
        RandomListGenerator listGenerator = new RandomListGenerator();

        List<int> numbers = listGenerator.GenerateList(0, 100, 100, 2);

        sw.Start();
        SortingAlgorithms.InsertionSort(numbers);
        sw.Stop();
        elapsed = sw.Elapsed;

        Console.WriteLine($"Метод вставки: \t\t\t{elapsed.TotalMilliseconds} м.сек.");
        sw.Restart();

        sw.Start();
        SortingAlgorithms.QuickSort(numbers);
        sw.Stop();
        elapsed = sw.Elapsed;

        Console.WriteLine($"'Быстрая сортировка': \t\t{elapsed.TotalMilliseconds} м.сек.");
        sw.Restart();

        sw.Start();
        SortingAlgorithms.MergeSort(numbers);
        sw.Stop();
        elapsed = sw.Elapsed;

        Console.WriteLine($"Метод слияния: \t\t\t{elapsed.TotalMilliseconds} м.сек.");
        sw.Restart();

        sw.Start();
        SortingAlgorithms.HeapSort(numbers);
        sw.Stop();
        elapsed = sw.Elapsed;

        Console.WriteLine($"Пирамидальная сортировка: \t{elapsed.TotalMilliseconds} м.сек.");
        sw.Restart();
    }
}