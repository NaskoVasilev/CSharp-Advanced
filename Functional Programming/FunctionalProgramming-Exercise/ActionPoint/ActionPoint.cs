using System;
using System.Linq;

namespace ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(printer);
        }

        public static Action<string> printer = (element) => Console.WriteLine(element);
    }
}
