using System;
using System.Linq;

namespace Sneaking
{
    class Sneaking
    {
        static int playerRow = 0;
        static int palyerCol = 0;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] room = new char[rows][];
            FillMatrx(room);
            string directions = Console.ReadLine();

            foreach (var direction in directions)
            {
                MoveEnemy(room);

                string result = EnemyTryKillSam(room);
                if (result != null)
                {
                    Console.WriteLine(result);
                    break;
                }

                MoveSam(room, direction);
                int colOfNikoladze = Array.IndexOf(room[playerRow], 'N');
                if (colOfNikoladze != -1)
                {
                    Console.WriteLine("Nikoladze killed!");
                    room[playerRow][colOfNikoladze] = 'X';
                    break;
                }
            }

            PrintRoom(room);
        }

        private static void MoveSam(char[][] room, char direction)
        {
            room[playerRow][palyerCol] = '.';
            switch (direction)
            {
                case 'U': playerRow--; break;
                case 'D': playerRow++; break;
                case 'L': palyerCol--; break;
                case 'R': palyerCol++; break;
            }
            room[playerRow][palyerCol] = 'S';
        }

        private static string EnemyTryKillSam(char[][] room)
        {
            int enemyBIndex = Array.IndexOf(room[playerRow], 'b');
            int enemyDIndex = Array.IndexOf(room[playerRow], 'd');

            if (enemyBIndex >= 0 && enemyBIndex < palyerCol)
            {
                room[playerRow][palyerCol] = 'X';
                return $"Sam died at {playerRow}, {palyerCol}";
            }
            else if (enemyDIndex >= 0 && enemyDIndex > palyerCol)
            {
                room[playerRow][palyerCol] = 'X';
                return $"Sam died at {playerRow}, {palyerCol}";
            }

            return null;
        }

        private static void MoveEnemy(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                int enemyBIndex = Array.IndexOf(room[row], 'b');
                int enemyDIndex = Array.IndexOf(room[row], 'd');

                if (enemyBIndex >= 0)
                {
                    if (enemyBIndex == room[row].Length - 1)
                    {
                        room[row][enemyBIndex] = 'd';
                    }
                    else
                    {
                        room[row][enemyBIndex] = '.';
                        room[row][enemyBIndex + 1] = 'b';
                    }
                }
                else if (enemyDIndex >= 0)
                {
                    if (enemyDIndex == 0)
                    {
                        room[row][enemyDIndex] = 'b';
                    }
                    else
                    {
                        room[row][enemyDIndex] = '.';
                        room[row][enemyDIndex - 1] = 'd';
                    }
                }
            }
        }

        private static void PrintRoom(char[][] room)
        {
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void FillMatrx(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();

                int playerIndex = Array.IndexOf(room[row], 'S');
                if (playerIndex >= 0)
                {
                    playerRow = row;
                    palyerCol = playerIndex;
                }
            }
        }
    }
}
