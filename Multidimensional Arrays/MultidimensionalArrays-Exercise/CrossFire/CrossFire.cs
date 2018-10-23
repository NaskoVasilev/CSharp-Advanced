using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossFire
{
    class CrossFire
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            List<List<int>> matrix = new List<List<int>>();

            FillMatrix(rows, cols, matrix);

            string command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                int[] coordinates = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int targetRow = coordinates[0];
                int targetCol = coordinates[1];
                int radius = coordinates[2];

                Attack(targetRow, targetCol, radius, matrix);

                command = Console.ReadLine();
            }

            Print(matrix);

        }

        private static void Attack(int targetRow, int targetCol, int radius, List<List<int>> matrix)
        {
            for (int col = targetCol - radius; col <= targetCol + radius; col++)
            {
                if (IsInside(targetRow, col, matrix))
                {
                    matrix[targetRow][col] = 0;
                }
            }

            for (int row = targetRow - radius; row <= targetRow + radius; row++)
            {
                if (IsInside(row, targetCol, matrix))
                {
                    matrix[row][targetCol] = 0;
                }
            }

            for (int row = 0; row < matrix.Count; row++)
            {
                matrix[row].RemoveAll(x => x == 0);

                if (matrix[row].Count == 0)
                {
                    matrix.RemoveAt(row);
                    row--;
                }
            }
        }

        private static bool IsInside(int row, int col, List<List<int>> matrix)
        {
            return row >= 0 && row <= matrix.Count - 1 && col >= 0 && col <= matrix[row].Count - 1;
        }

        private static void Print(List<List<int>> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }

        private static void FillMatrix(int rows, int cols, List<List<int>> matrix)
        {
            int counter = 1;

            for (int row = 0; row < rows; row++)
            {
                List<int> elements = new List<int>();

                for (int col = 0; col < cols; col++)
                {
                    elements.Add(counter++);
                }
                matrix.Add(elements);
            }
        }
    }
}



//Other solution with matrix

//{

//    string[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

//    int rows = int.Parse(dimensions[0]);
//    int cols = int.Parse(dimensions[1]);
//    int[,] matrix = new int[rows, cols];

//    int counter = 1;

//    for (int row = 0; row < matrix.GetLength(0); row++)
//    {
//        for (int col = 0; col < matrix.GetLength(1); col++)
//        {
//            matrix[row, col] = counter++;
//        }
//    }

//    string command = Console.ReadLine();

//    while (command != "Nuke it from orbit")
//    {
//        int[] target =
//            command.Split(' ', StringSplitOptions.RemoveEmptyEntries)
//            .Select(int.Parse)
//            .ToArray();
//        int rowIndex = target[0];
//        int colIndex = target[1];
//        int radius = target[2];
//        RemoveElements(rowIndex, colIndex, radius, matrix);
//        RearrangeMatrix(matrix);

//        command = Console.ReadLine();
//    }

//    PrintMatrix(matrix);
//}

//    private static void RearrangeMatrix(int[,] matrix)
//    {
//        Queue<int> rowElements = new Queue<int>(matrix.GetLength(1));

//        for (int row = 0; row < matrix.GetLength(0); row++)
//        {
//            for (int col = 0; col < matrix.GetLength(1); col++)
//            {
//                if (matrix[row, col] != 0)
//                {
//                    rowElements.Enqueue(matrix[row, col]);
//                }
//            }
//            int validElemntsCount = rowElements.Count;

//            if (validElemntsCount == 0)
//            {
//                for (int i = 0; i < matrix.GetLength(1); i++)
//                {
//                    for (int j = row; j < matrix.GetLength(0) - 1; j++)
//                    {
//                        matrix[j, i] = matrix[j + 1, i];
//                    }
//                }

//                for (int i = 0; i < matrix.GetLength(1); i++)
//                {
//                    matrix[matrix.GetLength(0) - 1, i] = 0;
//                }
//            }
//            else
//            {
//                for (int col = 0; col < validElemntsCount; col++)
//                {
//                    matrix[row, col] = rowElements.Dequeue();
//                }

//                for (int col = validElemntsCount; col < matrix.GetLength(1); col++)
//                {
//                    matrix[row, col] = 0;
//                }
//            }
//        }
//    }

//    private static void PrintMatrix(int[,] matrix)
//    {
//        for (int row = 0; row < matrix.GetLength(0); row++)
//        {
//            for (int col = 0; col < matrix.GetLength(1); col++)
//            {
//                if (matrix[row, col] != 0)
//                {
//                    Console.Write(matrix[row, col] + " ");
//                }
//            }
//            Console.WriteLine();
//        }
//    }

//    private static void RemoveElements(int targetRow, int targetCol, int radius, int[,] matrix)
//    {
//        for (int col = targetCol - radius; col <= targetCol + radius; col++)
//        {
//            if (IsInside(targetRow, col, matrix))
//            {
//                matrix[targetRow,col] = 0;
//            }
//        }

//        for (int row = targetRow - radius; row <= targetRow + radius; row++)
//        {
//            if (IsInside(row, targetCol, matrix))
//            {
//                matrix[row,targetCol] = 0;
//            }
//        }
//    }

//    private static bool IsInside(int row, int col, int[,] matrix)
//    {
//        return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
//    }
//}
