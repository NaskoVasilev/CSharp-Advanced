using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxElement
{
    class MaxElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>(n);

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string command = tokens[0];

                switch (command)
                {
                    case "1":
                        int element = int.Parse(tokens[1].ToString());
                        numbers.Push(element);
                        break;
                    case "2":
                        numbers.Pop();
                        break;
                    case "3":
                        if (numbers.Count > 0)
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;
                }
                  
            }
        }
    }
}
