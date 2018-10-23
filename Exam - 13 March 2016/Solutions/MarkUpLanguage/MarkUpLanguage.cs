using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarkUpLanguage
{
    class MarkUpLanguage
    {
        static void Main(string[] args)
        {
            string pattern = "<\\s*(inverse|reverse)\\s*content\\s*=\\s*\"(.+?)\"\\s*\\/\\s*>";
            string repeatPattern = "<\\s*repeat\\s*value\\s*=\\s*\"(\\d+)\"\\s*content\\s*=\\s*\"(.+?)\"\\s*\\/\\s*>";
            string command = "";
            Regex regex = new Regex(pattern);
            Regex repeatRegex = new Regex(repeatPattern);
            int counter = 1;
            string output = "";

            while ((command = Console.ReadLine()) != "<stop/>")
            {
                Match match = regex.Match(command);
                Match repeatMatch = repeatRegex.Match(command);

                if (match.Success)
                {
                    if (match.Groups[1].Value == "inverse")
                    {
                        Console.WriteLine(output = $"{counter++}. {Inverse(match.Groups[2].Value)}");
                    }
                    else
                    {
                        Console.WriteLine(output = $"{counter++}. {string.Join("", match.Groups[2].Value.Reverse())}");
                    }
                }
                else if (repeatMatch.Success)
                {
                    int count = int.Parse(repeatMatch.Groups[1].Value);
                    string word = repeatMatch.Groups[2].Value;

                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine(output = $"{counter++}. {word}");
                    }
                }
            }
        }

        private static string Inverse(string word)
        {
            string inversedWord = "";

            foreach (var item in word)
            {
                if (char.IsLower(item))
                {
                    inversedWord += char.ToUpper(item);
                }
                else if (char.IsUpper(item))
                {
                    inversedWord += char.ToLower(item);
                }
                else
                {
                    inversedWord += item;
                }
            }

            return inversedWord;
        }
    }
}
