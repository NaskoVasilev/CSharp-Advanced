using System;
using System.Linq;

namespace SumMatrix
{
    class SumMatrix
    {
        static void Main(string[] args)
        {
            string[] sizes = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int rowsCount = int.Parse(sizes[0]);
            int colsCount = int.Parse(sizes[1]);
            int[,] matrix = new int[rowsCount, colsCount];
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowElements = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                    sum += rowElements[col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
