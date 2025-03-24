using System;
using System.Diagnostics;
using System.Linq;

public static class Program
{
    public static List<int> PrefixSum(string fullText, string sub)
    {
        int subLength = sub.Length;
        int fullTextLength = fullText.Length;
        int[] overlap = new int[fullTextLength]; // pi
        int k = 0;
        List<int> positions = new List<int>();
        
        for (int i = 1; i < fullTextLength; i++)
        {
            while (k > 0 && fullText[k] != fullText[i])
                k = overlap[k - 1];
            if (fullText[k] == fullText[i])
                k++;
            overlap[i] = k;
            if (overlap[i] == subLength)
            {
                positions.Add(i - (subLength * 2) + 1);
            }
        }
        return positions;
    }

    public static List<int> NaiveSearch(string text, string sub)
    {
        List<int> positions = new List<int>();

        for (int i = 0; i < text.Length; i++)
        {
            int j;
            for (j = 0; j < sub.Length; j++)
            {
                if (i + j >= text.Length) break;
                if (text[i + j] != sub[j])
                {
                    break;
                }
            }
            if (j == sub.Length)
            {
                positions.Add(i);
            }
        }
        return positions;
    }

    private static void Main(string[] args)
    {
        string text = String.Empty;
        string sub = String.Empty;

        for (int i = 0; i < 7; i++)
        {
            text += "rhpbpsrrjifpcmupafhowtfkibgpwtifqotdfgmuniudodyzbarpejloqipdomgajbtoxfzoxupdtsxgtdtxxhakalbzglkoxaklmesziakyworjsovpvmfshzzwhybqzoqbinxvmglydsqrmalyaklacgkfgvvnoxutyypejrtskbuadzscgpcuhkrwzovltxlhognacdofivryqfdsxynlaogdcdiysifrklkytptzoygmevaournaikqkigkbdscztahueincpjbcogdizwahtboxpyamndgirsoxtxwtffphbrsroieheakjcciqawkkdysgwjbxpsqrehiqtwigpwslitfsrdrgmnvcqrskzqyxmsgrkurncwuaisyommlslxarncuclkuyqvagntkbbvszzsxfcngbrebpalngphltyjhrurwlnkiwhjuvwecbrcigfgarahmjhlfkvekifazjushypcakeizmslwgbvbsswltpztlpgoqxhxlftynijdlqyoespzkjjqqlcovdvwveiqyjumchptbnzljndspcpggwsbopzfpllgeeduzqakpngchhdmgemjmosqgnlsgikwbgiktlbftqfjfnmspvalvamlqaclgurccybbjfleuepluceuaqfcgsnmqewhenecodlvwtwjinywdzimqmsqgeshgfeuddndsycddwlhbhgtllbflgbmtsluzzoenrynezokncfbuuevwwovuhrctsxacroswfsxwpikzuhmriltvnmriuvvmwpfhqkenwmxpsizqinhvsdkeyhzhxogkciqsqqnsoplxaggerefbzintbesmfavypubwlqtzqgynfzdxydlekygsgzvbwfpobpsiaiqxmkbwrutfiqteqpasjcjqeaoifppsexqujuktklptsznpagmtagkvktljnvxgadfhphwkltqahnohcigeyfrfidtrsdqxomeabqzemwwmkfwe";
        }

        //for(int i = 0; i < 1000; i++)
        //{
        //    sub += "a";
        //}

        //for(int i = 0; i < 1000; i++)
        //{
        //    sub += "b";
        //}
        sub = text.Substring(0, 70);


        string fullText = sub + "$" + text;

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        List<int> positions = PrefixSum(fullText, sub);
        stopwatch.Stop();

        TimeSpan elapsed = stopwatch.Elapsed;
        Console.WriteLine($"Время поиска с помощью префикс-функции: {elapsed.TotalMilliseconds} ms");

        stopwatch.Reset();
        stopwatch.Start();

        List<int> posN = NaiveSearch(text, sub);
        stopwatch.Stop();

        elapsed = stopwatch.Elapsed;
        Console.WriteLine($"Время поиска с помощью наивного поиска: {elapsed.TotalMilliseconds} ms");
    }
}