using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> counter = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!counter.ContainsKey(number))
                {
                    counter.Add(number, 0);
                }
                counter[number]++;
            }

            int magicNumber = counter.First(x => x.Value % 2 == 0).Key;
            Console.WriteLine(magicNumber);
        }
    }
}
