using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    class ParkingSystem
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            Dictionary<int, List<int>> parking = new Dictionary<int, List<int>>();

            for (int row = 0; row < rows; row++)
            {
                parking.Add(row, new List<int>() { 0 });
            }

            string command = Console.ReadLine();

            while (command != "stop")
            {
                int[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int entryRow = tokens[0];
                int targetRow = tokens[1];
                int targetCol = tokens[2];

                if (!parking[targetRow].Contains(targetCol))
                {
                    parking[targetRow].Add(targetCol);
                    CalculteDistance(targetRow, targetCol, entryRow);
                }
                else if (parking[targetRow].Count == cols)
                {
                    Console.WriteLine($"Row {targetRow} full");
                }
                else
                {
                    int counter = 1;

                    while (true)
                    {
                        int index = targetCol - counter;

                        if (!parking[targetRow].Contains(index) && index >= 1)
                        {
                            parking[targetRow].Add(index);
                            CalculteDistance(targetRow, index, entryRow);
                            break;
                        }

                        index = targetCol + counter;

                        if (!parking[targetRow].Contains(index) && index < cols)
                        {
                            parking[targetRow].Add(index);
                            CalculteDistance(targetRow, index, entryRow);
                            break;
                        }

                        counter++;
                    }
                }

                command = Console.ReadLine();

            }
        }

        private static void CalculteDistance(int targetRow, int targetCol, int entryRow)
        {
            int distance = Math.Abs(entryRow - targetRow) + 1 + targetCol;
            Console.WriteLine(distance);
        }
    }
}



// main method comes here
//{
//    string[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

//    int rows = int.Parse(dimensions[0]);
//    int cols = int.Parse(dimensions[1]);

//    int[,] matrix = new int[rows, cols];

//    string command = Console.ReadLine();

//    while (command != "stop")
//    {
//        int[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)
//            .Select(int.Parse)
//            .ToArray();

//        int entranceRow = data[0];
//        int targetRow = data[1];
//        int targetCol = data[2];
//        int distance = 0;

//        if (matrix[targetRow, targetCol] == 0)
//        {
//            matrix[targetRow, targetCol] = 1;
//            distance = CalculateDistance(entranceRow, targetRow, targetCol);
//        }
//        else
//        {
//            for (int i = 1; i < matrix.GetLength(1) - 1; i++)
//            {
//                if (targetCol - i > 0)
//                {
//                    if (matrix[targetRow, targetCol - i] == 0)
//                    {
//                        matrix[targetRow, targetCol - i] = 1;
//                        distance = CalculateDistance(entranceRow, targetRow, targetCol - i);
//                        break;
//                    }
//                }
//                if (targetCol + i < matrix.GetLength(1))
//                {
//                    if (matrix[targetRow, targetCol + i] == 0)
//                    {
//                        matrix[targetRow, targetCol + i] = 1;
//                        distance = CalculateDistance(entranceRow, targetRow, targetCol + i);
//                        break;
//                    }
//                }
//            }
//        }

//        if (distance == 0)
//        {
//            Console.WriteLine($"Row {targetRow} full");
//        }
//        else
//        {
//            Console.WriteLine(distance);
//        }

//        command = Console.ReadLine();
//    }
//}

//private static int CalculateDistance(int entranceRow, int targetRow, int targetCol)
//{
//    int distance = 0;
//    if (entranceRow == targetRow)
//    {
//        distance = targetCol + 1;
//    }
//    else
//    {
//        distance = Math.Abs(entranceRow - targetRow) + 1 + targetCol;
//    }
//    return distance;
//}
