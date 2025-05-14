using AaDS_1;
using System.Diagnostics;

public static class Program
{
    private static void Main(string[] args)
    {
        Stopwatch sw = new();
        TimeSpan elapsed = new();

        string a = RandomStringGenerator.GenerateRandomString(10);
        string b = RandomStringGenerator.GenerateRandomString(10);

        sw.Start();
        string lcs = LCS.FindLCS(a, b);
        sw.Stop();
        elapsed = sw.Elapsed;

        Console.WriteLine($"LCS для {a} и {b}: {lcs}");
        Console.WriteLine($"Длина LCS: {lcs.Length}");
        Console.WriteLine($"Время поиска: {elapsed.TotalMilliseconds} м.сек.");
        Console.WriteLine();
        sw.Restart();
    }
}