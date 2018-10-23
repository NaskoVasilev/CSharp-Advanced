using System;
using System.Linq;

namespace SumNumbers
{
    class SumNumbers
    {
        static void Main(string[] args)
        {
            Func<string, int> intParser = (n) => int.Parse(n);

            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(intParser)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}
