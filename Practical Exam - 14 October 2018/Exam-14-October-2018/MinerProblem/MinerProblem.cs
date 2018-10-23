using System;
using System.Linq;

namespace MinerProblem
{
    class MinerProblem
    {
        static char[][] field;
        static int playerRow = 0;
        static int playerCol = 0;
        static int coalsCount = 0;

        static void Main(string[] args)
        {
            int squareSize = int.Parse(Console.ReadLine());
            field = new char[squareSize][];
            string[] directions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            FillField();
            MovePlayer(directions);

            if (coalsCount > 0 && field[playerRow][playerCol] != 'e')
            {
                Console.WriteLine($"{coalsCount} coals left. ({playerRow}, {playerCol})");
            }
        }

        private static void MovePlayer(string[] directions)
        {
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                }

                if (coalsCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                    break;
                }

                if (field[playerRow][playerCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({playerRow}, {playerCol})");
                    break;
                }
            }
        }

        private static void Move(int row, int col)
        {
            int targerRow = playerRow + row;
            int targerCol = playerCol + col;

            if (IsInside(targerRow, targerCol))
            {
                if (field[targerRow][targerCol] == 'c')
                {
                    field[targerRow][targerCol] = '*';
                    coalsCount--;
                }

                playerRow += row;
                playerCol += col;
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && field.Length > row
                && col >= 0 && field.Length > col;
        }

        private static void FillField()
        {
            for (int row = 0; row < field.Length; row++)
            {
                field[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'c')
                    {
                        coalsCount++;
                    }
                    else if (field[row][col] == 's')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
