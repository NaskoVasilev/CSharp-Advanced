using System;

namespace RubikMatrix
{
    class RubikMatrix
    {
        static void Main(string[] args)
        {
            string[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int rowsCount = int.Parse(sizes[0]);
            int colsCount = int.Parse(sizes[1]);
            int[][] rubikMatrix = new int[rowsCount][];
            FillMatrix(colsCount, rubikMatrix);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int rowColIndex = int.Parse(tokens[0]);
                string direction = tokens[1];
                int moves = int.Parse(tokens[2]);

                switch (direction)
                {
                    case "up":
                        MoveUp(rubikMatrix, rowColIndex, moves);
                        break;
                    case "down":
                        MoveDown(rubikMatrix, rowColIndex, moves);
                        break;
                    case "left":
                        MoveLeft(rubikMatrix, rowColIndex, moves);
                        break;
                    case "right":
                        MoveRight(rubikMatrix, rowColIndex, moves);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;

                }
            }

            Rearrenge(rubikMatrix);
        }

        private static void Rearrenge(int[][] rubikMatrix)
        {
            int counter = 1;

            for (int row = 0; row < rubikMatrix.Length; row++)
            {
                for (int col = 0; col < rubikMatrix[row].Length; col++)
                {
                    if (rubikMatrix[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        SwapElements(rubikMatrix, row, col, counter);
                    }

                    counter++;
                }
            }
        }

        private static void SwapElements(int[][] rubikMatrix, int row, int col, int counter)
        {
            for (int i = 0; i < rubikMatrix.Length; i++)
            {
                for (int j = 0; j < rubikMatrix[i].Length; j++)
                {
                    if (rubikMatrix[i][j] == counter)
                    {
                        rubikMatrix[i][j] = rubikMatrix[row][col];
                        rubikMatrix[row][col] = counter;
                        Console.WriteLine($"Swap ({row}, {col}) with ({i}, {j})");
                        return;
                    }
                }
            }
        }

        private static void MoveRight(int[][] rubikMatrix, int row, int moves)
        {
            moves = moves % rubikMatrix[row].Length;

            for (int i = 0; i < moves; i++)
            {
                int lastElement = rubikMatrix[row][rubikMatrix[row].Length - 1];

                for (int col = rubikMatrix[row].Length - 1; col > 0; col--)
                {
                    rubikMatrix[row][col] = rubikMatrix[row][col - 1];
                }

                rubikMatrix[row][0] = lastElement;
            }
        }

        private static void MoveLeft(int[][] rubikMatrix, int row, int moves)
        {
            moves = moves % rubikMatrix[row].Length;

            for (int i = 0; i < moves; i++)
            {
                int firstElement = rubikMatrix[row][0];

                for (int col = 0; col < rubikMatrix[row].Length - 1; col++)
                {
                    rubikMatrix[row][col] = rubikMatrix[row][col + 1];
                }

                rubikMatrix[row][rubikMatrix[row].Length - 1] = firstElement;
            }
        }

        private static void MoveDown(int[][] rubikMatrix, int col, int moves)
        {
            moves = moves % rubikMatrix.Length;

            for (int i = 0; i < moves; i++)
            {
                int lastElement = rubikMatrix[rubikMatrix.Length - 1][col];

                for (int row = rubikMatrix.Length - 1; row > 0; row--)
                {
                    rubikMatrix[row][col] = rubikMatrix[row - 1][col];
                }

                rubikMatrix[0][col] = lastElement;
            }
        }

        private static void MoveUp(int[][] rubikMatrix, int col, int moves)
        {
            moves = moves % rubikMatrix.Length;

            for (int i = 0; i < moves; i++)
            {
                //Get first elemnt in the column
                int firstElement = rubikMatrix[0][col];
                //Move elements one up
                for (int row = 0; row < rubikMatrix.Length - 1; row++)
                {
                    rubikMatrix[row][col] = rubikMatrix[row + 1][col];
                }

                //Put first elemnt in the end of collumn
                rubikMatrix[rubikMatrix.Length - 1][col] = firstElement;
            }
        }

        private static void FillMatrix(int colsCount, int[][] rubikMatrix)
        {
            int counter = 1;

            for (int row = 0; row < rubikMatrix.Length; row++)
            {
                rubikMatrix[row] = new int[colsCount];

                for (int col = 0; col < rubikMatrix[row].Length; col++)
                {
                    rubikMatrix[row][col] = counter++;
                }
            }
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (int[] arr in matrix)
            {
                Console.WriteLine(string.Join(' ', arr));
            }
        }
    }
}
