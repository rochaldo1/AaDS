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

        string[] dict = {"acacg", "ab", "acaeg", "acac", "egca"};

        sw.Start();
        foreach (string str in dict)
        {
            trieAsArr.Insert(str);
        }
        sw.Stop();
        elapsed = sw.Elapsed;

        Console.Write("Отображение (первый вариант): ");
        Console.WriteLine(elapsed.TotalMilliseconds);
        trieAsArr.PrintTree();
        Console.WriteLine();

        sw.Restart();
        sw.Start();
        foreach (string str in dict)
        {
            trieAsList.Insert(str);
        }
        sw.Stop();
        elapsed = sw.Elapsed;

        Console.Write("Указатель на начало (второй вариант): ");
        Console.WriteLine(elapsed.TotalMilliseconds);
        trieAsList.PrintTree();
    }
}