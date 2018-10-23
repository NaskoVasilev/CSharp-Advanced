using System;
using System.Collections.Generic;

namespace CalculateSequences
{
    class CalculateSequences
    {
        static void Main(string[] args)
        {
            long startNumber = long.Parse(Console.ReadLine());
            Queue<long> numbers = new Queue<long>();
            numbers.Enqueue(startNumber);
            numbers.Enqueue(startNumber + 1);

            for (int i = 0; i < 16; i++)
            {
                numbers.Enqueue(2 * numbers.Peek() + 1);
                long removedNumber = numbers.Dequeue();
                Console.Write(removedNumber + " ");
                numbers.Enqueue(removedNumber + 2);
                numbers.Enqueue(numbers.Peek() + 1);
            }

            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
        }
    }
}
