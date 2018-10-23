using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    class TargetPractice
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int rowsCount = int.Parse(dimensions[0]);
            int colsCount = int.Parse(dimensions[1]);
            string snake = Console.ReadLine();

            char[][] matrix = new char[rowsCount][];

            FillMatrix(matrix, snake, colsCount);
            Shoot(matrix);
            Collapse(matrix);
            PrintMatrix(matrix);
        }

        private static void Collapse(char[][] matrix)
        {
            Queue<char> colmnElements = new Queue<char>(matrix.Length);

            for (int col = 0; col < matrix[0].Length; col++)
            {
                int spaceCount = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] == ' ')
                    {
                        spaceCount++;
                    }
                    else
                    {
                        colmnElements.Enqueue(matrix[row][col]);
                    }
                }

                for (int i = 0; i < spaceCount; i++)
                {
                    matrix[i][col] = ' ';
                }

                for (int i = spaceCount; i < matrix.Length; i++)
                {
                    matrix[i][col] = colmnElements.Dequeue();
                }
            }
        }

        private static void Shoot(char[][] matrix)
        {
            int[] targetData = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int targetRow = targetData[0];
            int targetCol = targetData[1];
            int radius = targetData[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (Math.Pow(row - targetRow, 2) + Math.Pow(col - targetCol, 2) <= radius * radius)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void FillMatrix(char[][] matrix, string snake, int colsCount)
        {
            int counter = 0;
            bool isLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[colsCount];
                if (isLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        matrix[row][col] = snake[counter % snake.Length];
                        counter++;
                    }

                    isLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = snake[counter % snake.Length];
                        counter++;
                    }

                    isLeft = true;
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}


