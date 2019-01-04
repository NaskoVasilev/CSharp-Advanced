using System;
using System.Collections.Generic;
using System.Linq;

namespace Kitchen
{
    class Kitchen
    {
        static void Main(string[] args)
        {
            int[] knivesArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> knives = new Stack<int>(knivesArr);

            int[] forksArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> forks = new Queue<int>(forksArr);

            List<int> sets = new List<int>();

            while (forks.Count > 0 && knives.Count > 0)
            {
                int knife = knives.Pop();
                int fork = forks.Peek();

                if (knife > fork)
                {
                    sets.Add(knife + fork);
                    forks.Dequeue();
                }
                else if (knife == fork)
                {
                    forks.Dequeue();
                    knives.Push(knife + 1);
                }
            }

            Console.WriteLine($"The biggest set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
