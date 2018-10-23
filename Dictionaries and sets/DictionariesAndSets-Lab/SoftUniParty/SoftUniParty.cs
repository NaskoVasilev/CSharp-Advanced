using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            string command = "";

            while ((command = Console.ReadLine()) != "PARTY")
            {
                guests.Add(command);
            }

            while ((command = Console.ReadLine()) != "END")
            {
                guests.Remove(command);
            }

            Console.WriteLine(guests.Count);

            foreach (var guest in guests)
            {
                if (char.IsDigit(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }

            foreach (var guest in guests)
            {
                if (!char.IsDigit(guest[0]))
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}
