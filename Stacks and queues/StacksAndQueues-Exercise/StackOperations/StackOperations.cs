using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOperations
{
    class StackOperations
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int numberOfElementsToPush = input[0];
            int numberOfElementsToPop = input[1];
            int searchedNumber = input[2];

            int[] inputNumbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .Take(numberOfElementsToPush)
                .ToArray();

            Stack<int> numbers = new Stack<int>(inputNumbers);

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                numbers.Pop();
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
