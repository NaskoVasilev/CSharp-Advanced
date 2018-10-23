using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumber
{
    class ReverseNumber
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Stack<int> reversedNumbers = new Stack<int>(numbers);

            while (reversedNumbers.Count > 0)
            {
                Console.Write(reversedNumbers.Pop() + " ");
            }
            Console.WriteLine();
        }
    }
}
