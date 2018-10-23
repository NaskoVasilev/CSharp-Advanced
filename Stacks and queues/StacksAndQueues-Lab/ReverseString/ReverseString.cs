using System;
using System.Collections.Generic;

namespace ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reverser = new Stack<char>(input.Length);

            foreach (var chracter in input)
            {
                reverser.Push(chracter);
            }

            foreach (var chracter in reverser)
            {
                Console.Write(chracter);
            }
            Console.WriteLine();
        }
    }
}
