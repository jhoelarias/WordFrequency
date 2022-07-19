namespace WordFrequency;

using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Please write your sentense!");
        string sentence = Console.ReadLine().Trim();
        var sentenceWords = sentence.Split();
        Console.WriteLine($"{sentenceWords.Length} words");
        Console.WriteLine($"{sentence.Length} characters");

        var results = OrderedWordOccurrences(sentenceWords);

        foreach (var item in results)
        {
            Console.WriteLine($"{item.Word}: {item.Count}");
        }
        Console.ReadKey();
    }

    private static List<WordOccurence> OrderedWordOccurrences(string[] sentenceWords)
    {
        List<WordOccurence> results = new();
        foreach (var word in sentenceWords)
        {
            if (results.Exists(r => r.Word == word)) continue;
            var matchedItems = Array.FindAll(sentenceWords, x => x == word);
            results.Add(new WordOccurence { Word = word, Count = matchedItems.Length });
        }
        results.OrderByDescending(a => a.Count);
        return results;
    }

    private class WordOccurence
    {
        public string Word { get; set; }
        public int Count { get; set; }
    }
}