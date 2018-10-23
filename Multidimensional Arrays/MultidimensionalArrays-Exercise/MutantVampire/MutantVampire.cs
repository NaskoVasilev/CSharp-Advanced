using System;

namespace MutantVampire
{
    class MutantVampire
    {
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int rowsCount = int.Parse(dimensions[0]);
            int colsCount = int.Parse(dimensions[1]);

            char[][] lair = new char[rowsCount][];

            for (int row = 0; row < lair.Length; row++)
            {
                lair[row] = Console.ReadLine().ToCharArray();
            }

            char[] commands = Console.ReadLine().ToCharArray();
            int[] playerLocation = FindPlayer(lair);

            foreach (var command in commands)
            {
                string state = "";
                switch (command)
                {
                    case 'U':
                        state = moveUp(playerLocation, lair);
                        break;
                    case 'D':
                        state = moveDown(playerLocation, lair);
                        break;
                    case 'L':
                        state = moveLeft(playerLocation, lair);
                        break;
                    case 'R':
                        state = moveRight(playerLocation, lair);
                        break;
                }

                if (state == "win")
                {
                    Print(lair);
                    Console.WriteLine($"won: {playerLocation[0]} {playerLocation[1]}");
                    return;
                }
                else if (state == "dead")
                {
                    Print(lair);
                    Console.WriteLine($"dead: {playerLocation[0]} {playerLocation[1]}");
                    return;
                }
            }

        }

        private static void Print(char[][] lair)
        {
            foreach (char[] row in lair)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static string moveRight(int[] playerLocation, char[][] lair)
        {
            int row = playerLocation[0];
            int col = playerLocation[1];

            if (col == lair[0].Length - 1)
            {
                lair[row][col] = '.';
                SpreadBunnies(lair);
                return "win";
            }

            if (lair[row][col + 1] == 'B')
            {
                lair[row][col] = '.';
                playerLocation[1] = col + 1;
                SpreadBunnies(lair);
                return "dead";
            }
            lair[row][col + 1] = 'P';
            lair[row][col] = '.';
            playerLocation[1] = col + 1;
            return SpreadBunnies(lair);
        }

        private static string moveLeft(int[] playerLocation, char[][] lair)
        {
            int row = playerLocation[0];
            int col = playerLocation[1];

            if (col == 0)
            {
                lair[row][col] = '.';
                SpreadBunnies(lair);
                return "win";
            }

            if (lair[row][col - 1] == 'B')
            {
                lair[row][col] = '.';
                playerLocation[1] = col - 1;
                SpreadBunnies(lair);
                return "dead";
            }
            lair[row][col - 1] = 'P';
            lair[row][col] = '.';
            playerLocation[1] = col - 1;
            return SpreadBunnies(lair);
        }

        private static string moveDown(int[] playerLocation, char[][] lair)
        {
            int row = playerLocation[0];
            int col = playerLocation[1];

            if (row == lair.Length - 1)
            {
                lair[row][col] = '.';
                SpreadBunnies(lair);
                return "win";
            }

            if (lair[row + 1][col] == 'B')
            {
                lair[row][col] = '.';
                playerLocation[0] = row + 1;
                SpreadBunnies(lair);
                return "dead";
            }
            lair[row + 1][col] = 'P';
            lair[row][col] = '.';
            playerLocation[0] = row + 1;
            return SpreadBunnies(lair);
        }

        private static string moveUp(int[] playerLocation, char[][] lair)
        {
            int row = playerLocation[0];
            int col = playerLocation[1];

            if (row == 0)
            {
                lair[row][col] = '.';
                SpreadBunnies(lair);
                return "win";
            }

            if (lair[row - 1][col] == 'B')
            {
                lair[row][col] = '.';
                playerLocation[0] = row - 1;
                SpreadBunnies(lair);
                return "dead";
            }
            lair[row - 1][col] = 'P';
            lair[row][col] = '.';
            playerLocation[0] = row - 1;
            return SpreadBunnies(lair);
        }

        private static string SpreadBunnies(char[][] lair)
        {
            int rowsCount = lair.Length;
            int colsCount = lair[0].Length;
            string state = "";

            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col] == 'B')
                    {
                        if (col - 1 >= 0)
                        {
                            spreadBunny(row, col - 1, lair, ref state);
                        }

                        if (col + 1 < colsCount)
                        {
                            spreadBunny(row, col + 1, lair, ref state);
                        }

                        if (row + 1 < rowsCount)
                        {
                            spreadBunny(row + 1, col, lair, ref state);
                        }

                        if (row - 1 >= 0)
                        {
                            spreadBunny(row - 1, col, lair, ref state);
                        }
                    }
                }
            }

            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    lair[row][col] = char.ToUpper(lair[row][col]);
                }
            }
            return state;
        }

        private static void spreadBunny(int row, int col, char[][] lair, ref string state)
        {
            if (lair[row][col] == '.')
            {
                lair[row][col] = 'b';
            }
            else if (lair[row][col] == 'P')
            {
                lair[row][col] = 'b';
                state = "dead";
            }
        }


        private static int[] FindPlayer(char[][] lair)
        {
            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < lair.Length; row++)
            {
                for (int col = 0; col < lair[row].Length; col++)
                {
                    if (lair[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                        return new int[] { playerRow, playerCol };
                    }
                }
            }
            return new int[] { playerRow, playerCol };
        }
    }
}
