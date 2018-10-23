using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ParkingFeud
{
    class ParkingFeud
    {
        static void Main(string[] args)
        {
            int[] rowCol = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = rowCol[0];
            int cols = rowCol[1];
            int entrance = int.Parse(Console.ReadLine());
            int totalSteps = 0;
            string targetSpot = "";

            while (true)
            {
                string[] parkingSpots = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                targetSpot = parkingSpots[entrance - 1];

                int currentSteps = CalculetDistance(rows, cols, targetSpot, entrance);
                int equalPatkingSpots = parkingSpots.Count(x => x == targetSpot);

                if (equalPatkingSpots > 1)
                {
                    int otherDriverEntrance = Array.IndexOf(parkingSpots, targetSpot) + 1;
                    if (otherDriverEntrance == entrance)
                    {
                        otherDriverEntrance = Array.LastIndexOf(parkingSpots, targetSpot) + 1;
                    }
                    int otherDriverSteps = CalculetDistance(rows, cols, targetSpot, otherDriverEntrance);

                    if (otherDriverSteps < currentSteps)
                    {
                        totalSteps += currentSteps * 2;
                    }
                    else
                    {
                        totalSteps += currentSteps;
                        break;
                    }
                }
                else
                {
                    totalSteps += currentSteps;
                    break;
                }
            }

            Console.WriteLine($"Parked successfully at {targetSpot}.");
            Console.WriteLine($"Total Distance Passed: {totalSteps}");
        }

        private static int CalculetDistance(int rows, int cols, string targetSpot, int entrance)
        {
            int steps = 0;
            int targgetRow = int.Parse(targetSpot[targetSpot.Length - 1].ToString());
            int targetCol = (int)targetSpot[0] - (int)'A' + 1;
            bool isRight = true;

            while (targgetRow != entrance && targgetRow - 1 != entrance)
            {
                steps += cols + 3;
                if (entrance > targgetRow)
                {
                    entrance--;
                }
                else
                {
                    entrance++;
                }

                isRight = !isRight;
            }

            if (!isRight)
            {
                steps += cols - targetCol + 1;
            }
            else
            {
                steps += targetCol;
            }

            return steps;
        }
    }
}
