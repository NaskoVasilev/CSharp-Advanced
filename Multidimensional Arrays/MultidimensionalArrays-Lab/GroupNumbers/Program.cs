using System;
using System.Linq;

namespace GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[3][];

            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < 3; i++)
            {
                jaggedArray[i] = numbers
                    .Where(n => Math.Abs(n) % 3 == i)
                    .ToArray();
            }

            foreach (var group in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', group));
            }

            //Other solution

            //int[][] jaggedArray = new int[3][];

            //int[] numbers = Console.ReadLine()
            //    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            //int[] sizes = new int[3];

            //foreach (var num in numbers)
            //{
            //    int remainder = Math.Abs(num) % 3;
            //    sizes[remainder]++;
            //}

            //for (int i = 0; i < sizes.Length; i++)
            //{
            //    jaggedArray[i] = new int[sizes[i]];
            //}
            //int[] offset = new int[3];
            //foreach (var num in numbers)
            //{
            //    int remainder = Math.Abs(num) % 3;
            //    jaggedArray[remainder][offset[remainder]] = num;
            //    offset[remainder]++;
            //}

            //foreach (var group in jaggedArray)
            //{
            //    Console.WriteLine(string.Join(' ', group));
            //}

        }
    }
}
