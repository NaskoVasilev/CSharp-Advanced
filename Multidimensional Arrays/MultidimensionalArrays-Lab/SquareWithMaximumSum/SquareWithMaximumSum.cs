using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    class SquareWithMaximumSum
    {

        static void Main(string[] args)
        {
            string[] sizes = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            int rowsCount = int.Parse(sizes[0]);
            int colsCount = int.Parse(sizes[1]);
            int[,] matrix = new int[rowsCount, colsCount];
            const int squareSize = 2;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowElements = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            int maxSum = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;

            for (int row = 0; row < matrix.GetLength(0) - squareSize +1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - squareSize + 1; col++)
                {
                    int sum = 0;
                    for (int i = row; i < squareSize + row; i++)
                    {
                        for (int j = col; j < squareSize + col; j++)
                        {
                            sum += matrix[i, j];
                        }
                    }

                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            for (int i = rowIndex; i < squareSize + rowIndex; i++)
            {
                for (int j = colIndex; j < squareSize + colIndex; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
