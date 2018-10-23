using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParanthesis
{
    class BalancedParanthesis
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<char, char> paranthesisPairs = new Dictionary<char, char>();
            paranthesisPairs['{'] = '}';
            paranthesisPairs['['] = ']';
            paranthesisPairs['('] = ')';

            Stack<char> paranthesis = new Stack<char>(input.Length);

            foreach (var character in input)
            {
                if (paranthesisPairs.ContainsKey(character))
                {
                    paranthesis.Push(character);
                }else
                {
                    if (paranthesis.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    char lastParanthesis = paranthesis.Pop();
                    if (paranthesisPairs[lastParanthesis] != character)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
