using System;
using System.Linq;

namespace KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(editor);
        }

        public static Action<string> editor = (name) => Console.WriteLine("Sir " + name);
    }
}
