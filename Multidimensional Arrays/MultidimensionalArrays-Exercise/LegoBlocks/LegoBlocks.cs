using System;
using System.Linq;

namespace LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int[][] firstJaggedArray = new int[rowsCount][];
            int[][] secondJaggedArray = new int[rowsCount][];

            FillMatrix(firstJaggedArray);
            FillMatrix(secondJaggedArray);
            ReversMatrix(secondJaggedArray);
            bool isFitting = TwoArraysFit(firstJaggedArray, secondJaggedArray);

            if (isFitting)
            {
                int lenght = firstJaggedArray[0].Length + secondJaggedArray[0].Length;
                int[][] matrix = new int[rowsCount][];

                for (int row = 0; row < firstJaggedArray.Length; row++)
                {
                    matrix[row] = new int[lenght];
                    for (int col = 0; col < firstJaggedArray[row].Length; col++)
                    {
                        matrix[row][col] = firstJaggedArray[row][col];
                    }

                    for (int col = 0; col < secondJaggedArray[row].Length; col++)
                    {
                        matrix[row][col + firstJaggedArray[row].Length] = secondJaggedArray[row][col];
                    }
                    Console.Write('[');
                    Console.Write(string.Join(", ", matrix[row]));
                    Console.WriteLine(']');
                }
            }
            else
            {
                int cellsCount = 0;
                for (int row = 0; row < secondJaggedArray.Length; row++)
                {
                    cellsCount += secondJaggedArray[row].Length;
                    cellsCount += firstJaggedArray[row].Length;
                }
                Console.WriteLine($"The total number of cells is: {cellsCount}");
            }
        }

        private static bool TwoArraysFit(int[][] firstJaggedArray, int[][] secondJaggedArray)
        {
            int length = firstJaggedArray[0].Length + secondJaggedArray[0].Length;

            for (int row = 0; row < secondJaggedArray.Length; row++)
            {
                if (firstJaggedArray[row].Length + secondJaggedArray[row].Length != length)
                {
                    return false;
                }
            }
            return true;
        }

        private static void ReversMatrix(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = jaggedArray[row].Reverse().ToArray();
            }
        }

        private static void FillMatrix(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
        }
    }
}
