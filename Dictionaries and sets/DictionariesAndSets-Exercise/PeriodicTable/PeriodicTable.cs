using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            SortedSet<string> periodicTable = new SortedSet<string>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in elements)
                {
                    periodicTable.Add(element);
                }
            }

            Console.WriteLine(string.Join(' ', periodicTable));
        }
    }
}
