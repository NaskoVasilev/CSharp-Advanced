using System;
using System.Collections.Generic;

namespace UniqueNames
{
    class UniqueNames
    {
        static void Main(string[] args)
        {
            int numberOfNmaes = int.Parse(Console.ReadLine());

            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < numberOfNmaes; i++)
            {
                string name = Console.ReadLine();
                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

        }
    }
}
