using System;
using System.Linq;

namespace Bombs
{
    class Bombs
    {
        private static int[][] field;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            field = new int[size][];

            FillField();

            BombField();

            PrintResult();
        }

        private static void BombField()
        {
            string[] cordinates = Console.ReadLine().Split();

            foreach (string cordinate in cordinates)
            {
                string[] rowAndCol = cordinate.Split(',');
                int row = int.Parse(rowAndCol[0]);
                int col = int.Parse(rowAndCol[1]);

                if (field[row][col] > 0)
                {
                    int value = field[row][col];
                    DecreseNeighbourCellsValue(value, row, col);
                }
            }
        }

        private static void DecreseNeighbourCellsValue(int value, int row, int col)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (IsInside(i, j) && field[i][j] > 0)
                    {
                        field[i][j] -= value;
                    }
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < field.Length && col >= 0 && col < field[row].Length;
        }

        private static void PrintResult()
        {
            int aliveCells = 0;
            int sum = 0;

            foreach (var row in field)
            {
                foreach (var cell in row)
                {
                    if (cell > 0)
                    {
                        aliveCells++;
                        sum += cell;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");

            foreach (var row in field)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void FillField()
        {
            for (int i = 0; i < field.Length; i++)
            {
                int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
                field[i] = values;
            }
        }
    }
}
