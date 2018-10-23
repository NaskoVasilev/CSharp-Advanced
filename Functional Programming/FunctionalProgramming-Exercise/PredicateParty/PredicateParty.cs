using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = "";

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string criteria = tokens[1];
                string pattern = tokens[2];

                if (tokens[0] == "Remove")
                {
                    guests = guests.Where(n => !isMatching(n, criteria, pattern)).ToList();
                }
                else
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (isMatching(guests[i], criteria, pattern))
                        {
                            guests.Insert(i + 1, guests[i]);
                            i++;
                        }
                    }
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Func<string, string, string, bool> isMatching = (name, criteria, pattern) =>
        {
            bool isMatch = false;

            switch (criteria)
            {
                case "StartsWith":
                    isMatch = name.StartsWith(pattern);
                    break;
                case "EndsWith":
                    isMatch = name.EndsWith(pattern);
                    break;
                case "Length":
                    isMatch = name.Length == int.Parse(pattern);
                    break;
            }
            return isMatch;
        };

    }
}
