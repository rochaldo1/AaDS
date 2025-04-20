public class WordArrayGenerator
{
    private static readonly Random _random = new Random();
    private const string Chars = "abcdefghijklmnopqrstuvwxyz";

    public static string[] GenerateWordsWithStats(int wordCount)
    {
        var uniqueWords = new HashSet<string>();
        while (uniqueWords.Count < wordCount)
        {
            int length = _random.Next(2, 13);
            var word = new string(Enumerable.Repeat(Chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
            uniqueWords.Add(word);
        }

        string[] words = uniqueWords.ToArray();
        var stats = CalculateStats(words);
        PrintStats(stats);

        return words;
    }

    private static Dictionary<string, object> CalculateStats(string[] words)
    {
        var prefixCounts = new Dictionary<string, int>();
        var branchStats = new Dictionary<string, int>();
        int totalChars = words.Sum(w => w.Length);

        foreach (var word in words)
        {
            for (int i = 1; i <= word.Length; i++)
            {
                string prefix = word[..i];
                prefixCounts[prefix] = prefixCounts.GetValueOrDefault(prefix, 0) + 1;

                if (i > 1 && prefixCounts[prefix] > 1)
                {
                    string parentPrefix = word[..(i - 1)];
                    branchStats[parentPrefix] = branchStats.GetValueOrDefault(parentPrefix, 1) + 1;
                }
            }
        }

        int internalNodes = prefixCounts.Keys
            .Select(p => p.Length > 1 ? p[..^1] : "")
            .Distinct().Count() - 1;

        int branchingNodes = branchStats.Count;
        double avgBranching = branchingNodes > 0 ? branchStats.Values.Average() : 0;

        return new Dictionary<string, object>
        {
            ["n"] = totalChars,
            ["m"] = words.Length,
            ["x1"] = internalNodes,
            ["x2"] = branchingNodes,
            ["x3"] = avgBranching
        };
    }

    private static void PrintStats(Dictionary<string, object> stats)
    {
        Console.WriteLine($"Общее количество символов (n): {stats["n"]}");
        Console.WriteLine($"Количество слов (m): {stats["m"]}");
        Console.WriteLine($"Количество внутренних вершин (x1): {stats["x1"]}");
        Console.WriteLine($"Количество ветвлений (x2): {stats["x2"]}");
        Console.WriteLine($"Среднее количество путей в вершинах ветвлений (x3): {stats["x3"]:F2}");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine();
    }
}