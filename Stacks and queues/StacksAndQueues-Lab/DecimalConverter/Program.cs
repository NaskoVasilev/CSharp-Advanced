using System;
using System.Collections.Generic;

namespace DecimalConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            if (number == 0)
            {
                Console.WriteLine(number);
                return;
            }

            Stack<int> decimalRepresentation = new Stack<int>();

            while (number > 0)
            {
                decimalRepresentation.Push(number % 2);
                number /= 2;
            }

            foreach (var digit in decimalRepresentation)
            {
                Console.Write(digit);
            }
            Console.WriteLine();
        }
    }
}
