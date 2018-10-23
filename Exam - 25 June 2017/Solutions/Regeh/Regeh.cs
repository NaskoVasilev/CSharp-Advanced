using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Regeh
{
    class Regeh
    {
        static void Main(string[] args)
        {
            string pattern = @"\[[^ []+?<(\d+)REGEH(\d+)>[^] ]+?\]";
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                int leftNum = int.Parse(match.Groups[1].Value);
                int rightNum = int.Parse(match.Groups[2].Value);
                numbers.Add(leftNum);
                numbers.Add(rightNum);
            }

            int sum = 0;
            int[] targetIndexes = new int[numbers.Count];

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
                targetIndexes[i] = sum % input.Length;
            }

            string magicWord = "";

            for (int i = 0; i < targetIndexes.Length; i++)
            {
                magicWord += input[targetIndexes[i]];
            }
            Console.WriteLine(magicWord);
        }
    }
}
