using System;

class Program
{
    static string Normalize(string s)
    {
        s = s.Trim();
        while (s.Contains("  ")) s = s.Replace("  ", " ");
        string[] parts = s.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string result = "";
        foreach (string p in parts)
        {
            string t = p.Trim();
            if (t.Length > 0) result += char.ToUpper(t[0]) + (t.Length > 1 ? t.Substring(1).ToLower() : "") + ". ";
        }
        return result.Trim();
    }

    static string[] SplitWords(string s)
    {
        char[] sep = { ' ', '.', ',', '!', '?', ';', ':' };
        return s.ToLower().Split(sep, StringSplitOptions.RemoveEmptyEntries);
    }

    static void Statistics(string s)
    {
        string[] words = SplitWords(s);
        Console.WriteLine("Tong tu: " + words.Length);

        var distinctWords = new System.Collections.Generic.HashSet<string>(words);
        Console.WriteLine("Tu khac nhau: " + distinctWords.Count);

        var frequency = new System.Collections.Generic.Dictionary<string, int>();
        foreach (var word in words)
        {
            if (frequency.ContainsKey(word))
                frequency[word]++;
            else
                frequency[word] = 1;
        }

        Console.WriteLine("Tan suat tu:");
        foreach (var pair in frequency)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }
    }

    static void Main()
    {
        Console.WriteLine("Nhap van ban:");
        string text = Console.ReadLine();
        string norm = Normalize(text);
        Console.WriteLine("\nVan ban chuan hoa:");
        Console.WriteLine(norm);
        Console.WriteLine();
        Statistics(norm);
    }
}