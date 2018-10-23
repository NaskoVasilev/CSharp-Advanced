using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");

            Stack<string> calculator = new Stack<string>(input.Reverse());

            while (calculator.Count > 1)
            {
                int firstOperand = int.Parse(calculator.Pop());
                string operand = calculator.Pop();
                int secondOperand = int.Parse(calculator.Pop());

                switch (operand)
                {
                    case "+":
                        calculator.Push(firstOperand + secondOperand + "");
                        break;
                    case "-":
                        calculator.Push(firstOperand - secondOperand + "");
                        break;
                }
            }
            Console.WriteLine(calculator.Pop());
        }
    }
}
