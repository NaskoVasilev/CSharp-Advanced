using System;
using System.Linq;

namespace ArrangeNumbers
{
    class ArrangeNumbers
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new[] { ", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            numbers = numbers.OrderBy(x => GetNumberName(x)).ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static string GetNumberName(int number)
        {
            string name = "";

            for (int i = 0; i < number.ToString().Length; i++)
            {
                if (i > 0)
                {
                    name += '-';
                }
                switch (number.ToString()[i])
                {
                    case '0':
                        name += "zero";
                        break;
                    case '1':
                        name += "one";
                        break;
                    case '2':
                        name += "two";
                        break;
                    case '3':
                        name += "three";
                        break;
                    case '4':
                        name += "four";
                        break;
                    case '5':
                        name += "five";
                        break;
                    case '6':
                        name += "six";
                        break;
                    case '7':
                        name += "seven";
                        break;
                    case '8':
                        name += "eight";
                        break;
                    case '9':
                        name += "nine";
                        break;
                }
            }
            return name;
        }
    }
}
