using System;
using System.Linq;

namespace SumMatrixColumns
{
    class SumMatrixColumns
    {
        static void Main(string[] args)
        {
            string[] sizes = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int rowsCount = int.Parse(sizes[0]);
            int colsCount = int.Parse(sizes[1]);
            int[,] matrix = new int[rowsCount, colsCount];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowElements = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
