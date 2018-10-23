using System;
using System.Linq;

namespace Arithmetics
{
    class Arithmetics
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(n => n + 1).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => 2 * n).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => n - 1).ToArray();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;

                }

            }
        }
    }
}
