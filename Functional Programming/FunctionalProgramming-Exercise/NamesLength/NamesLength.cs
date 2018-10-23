using System;
using System.Linq;

namespace NamesLength
{
    class NamesLength
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(n => n.Length <= length)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
