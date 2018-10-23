using System;
using System.Linq;

namespace ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            for (int i = 1; i <= end; i++)
            {
                if (isDivisible(i, dividers))
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }

        static Func<int, int[], bool> isDivisible = (num, dividers) =>
          {
              foreach (int divider in dividers)
              {
                  if (num % divider != 0)
                  {
                      return false;
                  }
              }
              return true;
          };

    }
}
