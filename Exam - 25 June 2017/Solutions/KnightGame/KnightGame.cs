using System;

namespace KnightGame
{
    class KnightGame
    {
        static char[][] board;
        static int knightsToRemoveCount;
        static int[] indexes;
        static int maxKilledHorses = 0;

        static void Main(string[] args)
        {
            int boardSize = int.Parse(Console.ReadLine());
            indexes = new int[] { 0, 0, 0 };
            board = new char[boardSize][];

            for (int row = 0; row < board.Length; row++)
            {
                board[row] = Console.ReadLine().ToCharArray();
            }

            FindMostDangerousKnight();

            if (indexes[0] == 0)
            {
                Console.WriteLine(0);
                return;
            }
            else
            {
                board[indexes[1]][indexes[2]] = '0';
                knightsToRemoveCount++;

                while (true)
                {
                    indexes[0] = 0;
                    FindMostDangerousKnight();

                    if (indexes[0] > 0)
                    {
                        board[indexes[1]][indexes[2]] = '0';
                        knightsToRemoveCount++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(knightsToRemoveCount);
        }

        private static void FindMostDangerousKnight()
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == 'K')
                    {
                        maxKilledHorses = 0;

                        RemoveKnight(row - 2, col + 1);
                        RemoveKnight(row + 2, col - 1);
                        RemoveKnight(row - 2, col - 1);
                        RemoveKnight(row + 2, col + 1);
                        RemoveKnight(row + 1, col + 2);
                        RemoveKnight(row + 1, col - 2);
                        RemoveKnight(row - 1, col - 2);
                        RemoveKnight(row - 1, col + 2);

                        if (maxKilledHorses > indexes[0])
                        {
                            indexes[0] = maxKilledHorses;
                            indexes[1] = row;
                            indexes[2] = col;
                        }
                    }
                }
            }
        }

        private static bool IsInside(int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < board.Length && targetCol >= 0 && targetCol < board.Length;
        }

        private static void RemoveKnight(int targetRow, int targetCol)
        {
            if (IsInside(targetRow, targetCol) && board[targetRow][targetCol] == 'K')
            {
                maxKilledHorses++;
            }
        }

        private static void Print()
        {
            foreach (var row in board)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
