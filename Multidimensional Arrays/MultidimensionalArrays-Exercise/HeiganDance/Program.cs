using System;

namespace HeiganDance
{
    class Program
    {
        static int rows = 15;
        static int cols = 15;

        static int playerRow = 7;
        static int playerCol = 7;

        static int cloudDamage = 3500;
        static int eruption = 6000;

        static int playerPoints = 18500;
        static double heiganPoints = 3000000;

        static void Main(string[] args)
        {
            double damagePerTurn = double.Parse(Console.ReadLine());
            bool isCloudAttack = false;
            string lastSpell = "";

            while (true)
            {

                if (playerPoints > 0)
                {
                    heiganPoints -= damagePerTurn;
                }

                if (isCloudAttack)
                {
                    playerPoints -= cloudDamage;
                    isCloudAttack = false;
                }

                if (playerPoints <= 0 || heiganPoints <= 0)
                {
                    break;
                }



                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[0];
                int targetRow = int.Parse(tokens[1]);
                int targetCol = int.Parse(tokens[2]);

                if (!IsInImpactArea(targetRow, targetCol, playerRow, playerCol))
                {
                    continue;
                }

                bool canMoveUp = !IsInImpactArea(targetRow, targetCol, playerRow - 1, playerCol) && IsInside(playerRow - 1, playerCol);
                bool canMoveRight = !IsInImpactArea(targetRow, targetCol, playerRow, playerCol + 1) && IsInside(playerRow, playerCol + 1);
                bool canMoveDown = !IsInImpactArea(targetRow, targetCol, playerRow + 1, playerCol) && IsInside(playerRow + 1, playerCol);
                bool canMoveLeft = !IsInImpactArea(targetRow, targetCol, playerRow, playerCol - 1) && IsInside(playerRow, playerCol - 1);

                if (canMoveUp)
                {
                    playerRow--;
                }
                else if (canMoveRight)
                {
                    playerCol++;
                }
                else if (canMoveDown)
                {
                    playerRow++;
                }
                else if (canMoveLeft)
                {
                    playerCol--;
                }
                else
                {
                    if (type == "Cloud")
                    {
                        playerPoints -= cloudDamage;
                        isCloudAttack = true;
                        lastSpell = "Plague Cloud";
                    }
                    else if (type == "Eruption")
                    {
                        playerPoints -= eruption;
                        lastSpell = "Eruption";
                    }
                }
            }

            if (heiganPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganPoints:F2}");
            }

            if (playerPoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {lastSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerPoints}");
            }

            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }

        private static bool IsInImpactArea(int targetRow, int targetCol, int currentPlayerRow, int currentPlayerCol)
        {
            return currentPlayerRow >= targetRow - 1 && currentPlayerRow <= targetRow + 1
                && currentPlayerCol >= targetCol - 1 && currentPlayerCol <= targetCol + 1;
        }
    }
}
