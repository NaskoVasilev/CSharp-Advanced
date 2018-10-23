using System;
using System.Linq;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                primaryDiagonal += matrix[row][row];
                secondaryDiagonal += matrix[row][matrix[row].Length - 1 - row];
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}
