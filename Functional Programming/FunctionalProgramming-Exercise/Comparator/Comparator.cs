using System;
using System.Linq;

namespace Comparator
{
    class Comparator
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, Compare);

            Console.WriteLine(string.Join(' ',numbers));
        }

        private static int Compare(int currentElement,int nextElement)
        {
            if (currentElement % 2 != 0 && nextElement % 2 == 0)
            {
                return 1;
            }
            else if ((currentElement + nextElement) % 2 == 0 && currentElement > nextElement)
            {
                return 1;
            }
            return -1;        
        }
    }
}
