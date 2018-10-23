using System;
using System.Linq;

namespace MinFunction
{
    class MinFunction
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(Min(nums));
        }

        public static Func<int[], int> Min = nums =>
           {
               int minElement = int.MaxValue;

               foreach (int num in nums)
               {
                   if (minElement > num)
                   {
                       minElement = num;
                   }
               }

               return minElement;
           };
    }
}
