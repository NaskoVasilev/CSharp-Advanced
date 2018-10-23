using System;
using System.Linq;

namespace ReverseEndExclude
{
    class ReverseEndExclude
    {

        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divider = int.Parse(Console.ReadLine());

            numbers = numbers
                .Where(num => num % divider != 0)
                .Reverse()
                .ToArray();

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
