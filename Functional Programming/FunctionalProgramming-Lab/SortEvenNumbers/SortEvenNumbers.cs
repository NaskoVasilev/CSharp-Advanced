using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SortEvenNumbers
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ",numbers));
                
        }
    }
}
