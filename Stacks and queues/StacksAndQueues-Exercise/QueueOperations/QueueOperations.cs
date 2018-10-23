using System;
using System.Linq;
using System.Collections.Generic;

namespace QueueOperations
{
    class QueueOperations
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int numberOfElementsToAdd = input[0];
            int numberOfElementsToRemove = input[1];
            int searchedNumber = input[2];

            int[] inputNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .Take(numberOfElementsToAdd)
                .ToArray();

            Queue<int> numbers = new Queue<int>(inputNumbers);

            for (int i = 0; i < numberOfElementsToRemove; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Contains(searchedNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
        }
    }
}
