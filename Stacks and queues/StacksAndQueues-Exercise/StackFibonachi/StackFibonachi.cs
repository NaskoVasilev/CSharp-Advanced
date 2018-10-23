using System;
using System.Collections.Generic;

namespace StackFibonachi
{
    class StackFibonachi
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < n-1; i++)
            {
                long currentNum = stack.Pop();
                long nextNum = currentNum + stack.Pop();
                stack.Push(currentNum);
                stack.Push(nextNum);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
