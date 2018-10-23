using System;
using System.Collections.Generic;
using System.Linq;

namespace CountOccurances
{
    class CountOccurances
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> counter = new Dictionary<double, int>();

            double[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var num in nums)
            {
                if (counter.ContainsKey(num) == false)
                {
                    counter.Add(num, 0);
                }
                counter[num]++;
            }

            foreach (var pair in counter)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }

        }

    }
}
