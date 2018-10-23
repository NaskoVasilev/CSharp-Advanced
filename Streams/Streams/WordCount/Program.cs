using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string relativePath = "../../files";
            string wordsFileName = "words.txt";
            string sourceFileName = "text.txt";
            string resultFileName = "result.txt";

            string wordsPath = Path.Combine(relativePath, wordsFileName);
            string sourcePath = Path.Combine(relativePath, sourceFileName);
            Dictionary<string, int> counter = new Dictionary<string, int>();

            string line = "";
            using (var reader = new StreamReader(wordsPath))
            {
                line = reader.ReadLine();

                while (line != null)
                {
                    line = line.ToLower();
                    if (!counter.ContainsKey(line))
                    {
                        counter.Add(line, 0);
                    }
                    line = reader.ReadLine();
                }
            }

            string text = "";
            using (var reader = new StreamReader(sourcePath))
            {
                line = reader.ReadLine();

                while (line != null)
                {
                    text += line.ToLower();
                    line = reader.ReadLine();
                }
            }

            string[] allWords = Regex.Split(text, @"[^a-zA-Z]");

            foreach (var word in allWords)
            {
                if (counter.ContainsKey(word))
                {
                    counter[word]++;
                }
            }

            using (var writer = new StreamWriter(resultFileName))
            {
                foreach (var pair in counter.OrderByDescending(x => x.Value))
                {
                    line = $"{pair.Key} - {pair.Value}";
                    writer.WriteLine(line);
                }
            }
        }
    }
}
