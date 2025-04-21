using AaDS_1;

public static class Program
{
    private static void Main(string[] args)
    {
        string a = "ABCBABD";
        string b = "BDCABA";

        string lcs = LCS.FindLCS(a, b);
        Console.WriteLine($"LCS для {a} и {b}: {lcs}");
        Console.WriteLine($"Длина LCS: {lcs.Length}");
    }
}