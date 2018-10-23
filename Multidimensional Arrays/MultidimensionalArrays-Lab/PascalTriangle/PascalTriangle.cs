using System;

namespace PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascalTringle = new long[n][];

            for (int i = 0; i < pascalTringle.Length; i++)
            {
                pascalTringle[i] = new long[i + 1];
                pascalTringle[i][0] = 1;
                pascalTringle[i][pascalTringle[i].Length - 1] = 1;
            }

            for (int i = 2; i < pascalTringle.Length; i++)
            {
                for (int j = 1; j < pascalTringle[i].Length-1; j++)
                {
                    pascalTringle[i][j] = pascalTringle[i - 1][j - 1] + pascalTringle[i - 1][j];
                }
            }

            foreach (var row in pascalTringle)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
