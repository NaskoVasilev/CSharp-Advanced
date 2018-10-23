using System;
using System.Collections.Generic;

namespace SetsOfElements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split(" ");
            int n = int.Parse(tokens[0]);
            int m = int.Parse(tokens[1]);

            HashSet<int> firstSet = new HashSet<int>(n);
            HashSet<int> secondSet = new HashSet<int>(m);

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }

            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ",firstSet));
        }
    }
}
