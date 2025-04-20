using AaDS_1.AsArr;
using AaDS_1.AsList;
using System.Diagnostics;

public static class Program
{
    private static void Main(string[] args)
    {
        Stopwatch sw = new();
        TimeSpan elapsed = new();

        TrieAsArr trieAsArr = new();
        TrieAsList trieAsList = new();

        string[] dict = WordArrayGenerator.GenerateWordsWithStats(18000);

        long memoryBefore = GC.GetTotalMemory(true);
        sw.Start();
        foreach (string str in dict)
        {
            trieAsArr.Insert(str);
        }
        sw.Stop();
        long memoryAfter = GC.GetTotalMemory(true);

        elapsed = sw.Elapsed;
        long usedMemory = memoryAfter - memoryBefore;

        Console.WriteLine("Массив (первый вариант): ");
        Console.WriteLine($"Время построения дерева (t): {elapsed.TotalMilliseconds} м.сек.");
        Console.WriteLine($"Объём затраченной памяти (p): {usedMemory / 1024.0:F2} Кб ");
        //trieAsArr.PrintTree();
        Console.WriteLine();

        sw.Restart();
        memoryBefore = GC.GetTotalMemory(true);
        sw.Start();
        foreach (string str in dict)
        {
            trieAsList.Insert(str);
        }
        sw.Stop();
        memoryAfter = GC.GetTotalMemory(true);

        elapsed = sw.Elapsed;
        usedMemory = memoryAfter - memoryBefore;

        Console.WriteLine("Список (второй вариант): ");
        Console.WriteLine($"Время построения дерева (t): {elapsed.TotalMilliseconds} м.сек.");
        Console.WriteLine($"Объём затраченной памяти (p): {usedMemory / 1024.0:F2} Кб");
        //trieAsList.PrintTree();
    }
}