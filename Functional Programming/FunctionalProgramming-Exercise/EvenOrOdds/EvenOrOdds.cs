using System;

namespace EvenOrOdds
{
    class EvenOrOdds
    {
        static Predicate<int> isOdd = num =>num % 2 != 0;

        static Predicate<int> isEven = num => num % 2 == 0;

        static void Main(string[] args)
        {
            string[] bounds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int start = int.Parse(bounds[0]);
            int end = int.Parse(bounds[1]);
            string command = Console.ReadLine();

            if (command == "even")
            {
                for (int i = start; i <= end; i++)
                {
                    if (isEven(i))
                    {
                        Console.Write(i+" ");
                    }
                }
            }
            else
            {
                for (int i = start; i <= end; i++)
                {
                    if (isOdd(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
