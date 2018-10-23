using System;

namespace Monopoly
{
    class Monopoly
    {
        static int money = 50;
        static int totalHotels = 0;
        static int turns = 0;
        static void Main(string[] args)
        {
            string[] rowCol = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int rows = int.Parse(rowCol[0]);
            int cols = int.Parse(rowCol[1]);
            char[][] monopoly = new char[rows][];

            FillMatrix(monopoly);

            MovePlayer(monopoly);

            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }

        private static void MovePlayer(char[][] monopoly)
        {
            bool isRight = true;
            for (int row = 0; row < monopoly.Length; row++)
            {
                if (isRight)
                {
                    for (int col = 0; col < monopoly[row].Length; col++)
                    {
                        CheckCurrentObject(monopoly[row][col], row, col);
                    }
                }
                else
                {
                    for (int col = monopoly[row].Length - 1; col >= 0; col--)
                    {
                        CheckCurrentObject(monopoly[row][col], row, col);
                    }
                }
                isRight = !isRight;
            }
        }

        private static void CheckCurrentObject(char currentObject, int row, int col)
        {
            turns++;
            switch (currentObject)
            {
                case 'H':
                    totalHotels++;
                    Console.WriteLine($"Bought a hotel for {money}. Total hotels: {totalHotels}.");
                    money = 0;
                    break;
                case 'J':
                    Console.WriteLine($"Gone to jail at turn {turns - 1}.");
                    turns += 2;
                    money += 2 * totalHotels * 10;
                    break;
                case 'S':
                    int spendedMoney = Math.Min((row + 1) * (col + 1), money);
                    money -= spendedMoney;
                    Console.WriteLine($"Spent {spendedMoney} money at the shop.");
                    break;
            }


            money += totalHotels * 10;
        }

        private static void FillMatrix(char[][] monopoly)
        {
            for (int i = 0; i < monopoly.Length; i++)
            {
                monopoly[i] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
