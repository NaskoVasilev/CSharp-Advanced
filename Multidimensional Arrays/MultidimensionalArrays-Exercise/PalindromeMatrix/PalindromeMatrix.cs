using System;

namespace PalindromeMatrix
{
    class PalindromeMatrix
    {
        static void Main(string[] args)
        {
            string[] dimensions= Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int rowsCount = int.Parse(dimensions[0]);
            int colsCount = int.Parse(dimensions[1]);
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[,] matrix = new string[rowsCount, colsCount];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char firstLetter = alphabet[row];
                    char middleLetter = alphabet[row + col];
                    matrix[row, col] = $"{firstLetter}{middleLetter}{firstLetter}";

                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
