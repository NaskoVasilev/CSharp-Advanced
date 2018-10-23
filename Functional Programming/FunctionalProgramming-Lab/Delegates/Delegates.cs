using System;
using System.Linq;

namespace Delegates
{
    class Delegates
    {
        //public delegate int BinaryOperator(int x, int y);

        static void Main(string[] args)
        {
            Func<int, int, int> sum = SumNumbers;
            Console.WriteLine(sum(12, 18));

            Console.WriteLine(Calculator(5, 6, SumNumbers));
            Console.WriteLine(Calculator(5, 6, Multiply));
            Console.WriteLine(Calculator(12, 6, Divide));
            Console.WriteLine(Calculator(5, 6, Subtraction));
        }
        private static int Calculator(int x, int y, Func<int, int, int> opr)
        {
            return opr(x, y);
        }

        private static int Multiply(int x, int y)
        {
            return x * y;
        }

        private static int SumNumbers(int x, int y)
        {
            return x + y;
        }

        private static int Subtraction(int x, int y)
        {
            return x - y;
        }

        private static int Divide(int x, int y)
        {
            return x / y;
        }
    }
}
