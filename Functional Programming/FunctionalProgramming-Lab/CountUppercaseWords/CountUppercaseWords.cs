using System;
using System.Linq;

namespace CountUppercaseWords
{
    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUppercase = word => char.IsUpper(word[0]);

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(isUppercase)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
