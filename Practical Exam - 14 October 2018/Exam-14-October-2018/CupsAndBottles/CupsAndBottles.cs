using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class CupsAndBottles
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] bottlesCapacity = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> bottles = new Stack<int>(bottlesCapacity);
            Queue<int> cups = new Queue<int>(cupsCapacity);
            int wastedWater = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                int bottleCapacity = bottles.Pop();
                int cupCapacity = cups.Peek();

                if (cupCapacity > bottleCapacity)
                {
                    cupCapacity -= bottleCapacity;
                    while (true)
                    {
                        if (bottles.Count == 0 || cupCapacity <= 0)
                        {
                            if (cupCapacity <= 0)
                            {
                                cups.Dequeue();
                                wastedWater += Math.Abs(cupCapacity);
                            }
                            break;
                        }

                        cupCapacity -= bottles.Pop();
                    }
                }
                else if (bottleCapacity >= cupCapacity)
                {
                    wastedWater += bottleCapacity - cupCapacity;
                    cups.Dequeue();
                }
            }

            if (cups.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
