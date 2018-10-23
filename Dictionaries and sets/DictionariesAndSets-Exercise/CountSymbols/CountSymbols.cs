using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> counter = new SortedDictionary<char, int>();

            string sentence = Console.ReadLine();

            foreach (char character in sentence)
            {
                if (counter.ContainsKey(character) == false)
                {
                    counter.Add(character, 0);
                }
                counter[character]++;
            }

            foreach (var pair in counter)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
