using System;
using System.Collections.Generic;

namespace MatrixRotations
{
    class MatrixRotations
    {
        static void Main(string[] args)
        {
            string rotation = Console.ReadLine();
            int degree = int.Parse(rotation.Substring(7, rotation.Length - 8));

            string command = Console.ReadLine();
            List<string> words = new List<string>();
            int maxLength = 0;

            while (command != "END")
            {
                words.Add(command);
                if (maxLength < command.Length)
                {
                    maxLength = command.Length;
                }
                command = Console.ReadLine();
            }

            int cols = maxLength;
            int rows = words.Count;

            char[,] initialMatrix = new char[rows, cols];

            for (int row = 0; row < initialMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < initialMatrix.GetLength(1); col++)
                {
                    initialMatrix[row, col] = ' ';
                }
            }

            for (int row = 0; row < initialMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < words[row].Length; col++)
                {
                    initialMatrix[row, col] = words[row][col];
                }
            }

            if (degree % 360 == 0)
            {
                PrintMatrix(initialMatrix);
            }
            else if ((degree - 270) % 360 == 0)
            {
                char[,] rotatedMatrix = new char[cols, rows];

                for (int col = initialMatrix.GetLength(1) - 1; col >= 0; col--)
                {
                    for (int row = 0; row < initialMatrix.GetLength(0); row++)
                    {
                        rotatedMatrix[initialMatrix.GetLength(1) - 1 - col, row] = initialMatrix[row, col];
                    }
                }
                PrintMatrix(rotatedMatrix);
            }
            else if (degree % 180 == 0)
            {
                char[,] rotatedMatrix = new char[rows, cols];

                for (int row = initialMatrix.GetLength(0) - 1; row >= 0; row--)
                {
                    for (int col = initialMatrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        rotatedMatrix[initialMatrix.GetLength(0) - 1 - row, initialMatrix.GetLength(1) - 1 - col] = initialMatrix[row, col];
                    }
                }
                PrintMatrix(rotatedMatrix);
            }
            else
            {
                char[,] rotatedMatrix = new char[cols, rows];

                for (int col = 0; col < initialMatrix.GetLength(1); col++)
                {
                    for (int row = initialMatrix.GetLength(0) - 1; row >= 0; row--)
                    {
                        rotatedMatrix[col, initialMatrix.GetLength(0) - 1 - row] = initialMatrix[row, col];
                    }
                }

                PrintMatrix(rotatedMatrix);
            }
        }

        private static void PrintMatrix(char[,] initialMatrix)
        {
            for (int row = 0; row < initialMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < initialMatrix.GetLength(1); col++)
                {
                    Console.Write(initialMatrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
