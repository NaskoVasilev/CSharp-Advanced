using System;
using System.Linq;

namespace MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            const int squareSize = 3;
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] elemnts = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elemnts[col];
                }
            }
            int maxSum = 0;
            int targetRowIndex = 0;
            int targetColIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - squareSize + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - squareSize + 1; col++)
                {
                    int sum = 0;
                    for (int i = row; i < row + squareSize; i++)
                    {
                        for (int j = col; j < col + squareSize; j++)
                        {
                            sum += matrix[i, j];
                        }
                    }

                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        targetColIndex = col;
                        targetRowIndex = row;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = targetRowIndex; row < targetRowIndex + squareSize; row++)
            {
                for (int col = targetColIndex; col < targetColIndex + squareSize; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
