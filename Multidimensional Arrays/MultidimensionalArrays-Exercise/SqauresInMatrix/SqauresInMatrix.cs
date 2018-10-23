using System;
using System.Linq;

namespace SqauresInMatrix
{
    class SqauresInMatrix
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int rowsCount = int.Parse(dimensions[0]);
            int colsCount = int.Parse(dimensions[1]);
            char[,] matrix = new char[rowsCount, colsCount];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] elements = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
