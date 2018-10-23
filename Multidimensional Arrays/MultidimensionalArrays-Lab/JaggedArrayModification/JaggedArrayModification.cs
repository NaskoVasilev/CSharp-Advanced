using System;
using System.Linq;

namespace JaggedArrayModification
{
    class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rowsCount][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] elements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = elements;
            }

            string command = "";

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] tokens =command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0].ToLower();
                int rowIndex = int.Parse(tokens[1]);
                int colIndex = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (rowIndex < 0 || rowIndex >= jaggedArray.Length
                    || colIndex < 0 || colIndex>=jaggedArray[rowIndex].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                if (action == "add")
                {
                    jaggedArray[rowIndex][colIndex] += value;
                }
                else if (action == "subtract")
                {
                    jaggedArray[rowIndex][colIndex] -= value;
                }
            }

            foreach (var arr in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', arr));
            }
        }
    }
}
