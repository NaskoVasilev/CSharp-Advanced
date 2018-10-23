using System;
using System.Linq;

namespace CubicRube
{
    class CubicRube
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string input = "";
            int countOfAllCells = size * size * size;
            long sum = 0;

            while ((input = Console.ReadLine()) != "Analyze")
            {
                int[] coordinates = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
                int length = coordinates[0];
                int width = coordinates[1];
                int height = coordinates[2];
                int value = coordinates[3];

                if (IsInside(size, length, width, height) && value != 0)
                {
                    sum += value;
                    countOfAllCells--;
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(countOfAllCells);
        }

        private static bool IsInside(int size, int length, int width, int height)
        {
            return length >= 0 && length < size
                && width >= 0 && width < size
                && height >= 0 && height < size;
        }
    }
}
