using System;
using System.Linq;

namespace AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(p => p * 1.2)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p:F2}"));
        }
    }
}
