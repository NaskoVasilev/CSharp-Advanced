using System;
using System.Text.RegularExpressions;

namespace TreasureMap
{
    class TreasureMap
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string letter = "";
            string pattern = @"((?<start>#)|!)[^#!]*?(?<![A-Za-z0-9])(?<streetName>[A-Za-z]{4})(?![A-Za-z0-9])[^!#]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{4}|\d{6})(?!\d)[^!#]*?(?(start)!|#)";
            Regex regex = new Regex(pattern);
            string streetName = "";
            string streetNumber = "";
            string password = "";
            for (int i = 0; i < n; i++)
            {
                letter = Console.ReadLine();
                MatchCollection matches = regex.Matches(letter);

                Match match = matches[matches.Count / 2];
                streetName = match.Groups["streetName"].Value;
                streetNumber = match.Groups["streetNumber"].Value;
                password = match.Groups["password"].Value;
                Console.Write($"Go to str. {streetName} {streetNumber}. ");
                Console.WriteLine($"Secret pass: {password}.");
            }
        }
    }
}
