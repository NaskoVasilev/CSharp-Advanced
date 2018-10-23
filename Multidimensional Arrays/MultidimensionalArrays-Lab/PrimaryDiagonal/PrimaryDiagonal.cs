using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class PrimaryDiagonal
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowElemets = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElemets[col];
                }
            }

            int primaryDiagonalSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primaryDiagonalSum += matrix[i, i];
            }

            Console.WriteLine(primaryDiagonalSum);
        }
    }
}
