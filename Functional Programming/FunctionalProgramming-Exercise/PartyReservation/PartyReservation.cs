using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservation
{
    class PartyReservation
    {
        static void Main(string[] args)
        {
            List<string> initialNames = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> filteredNames = new List<string>(initialNames);
            string command = "";

            while ((command = Console.ReadLine()) != "Print")
            {
                string[] tokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string filterType = tokens[0];
                string criteria = tokens[1];
                string pattern = tokens[2];

                Func<string, bool> isMatching = IsMatch(criteria, pattern);

                if (filterType.StartsWith("Add"))
                {
                    filteredNames = filteredNames.Where(isMatching).ToList();
                }
                else
                {
                    filteredNames = initialNames
                        .Where(n => !isMatching(n) || filteredNames.Contains(n))
                        .ToList();
                }
            }

            Console.WriteLine(string.Join(" ",filteredNames));
        }

        private static Func<string, bool> IsMatch(string criteria, string pattern)
        {
            switch (criteria)
            {
                case "Starts with":
                    return (name) => !name.StartsWith(pattern);
                case "Ends with":
                    return (name) => !name.EndsWith(pattern);
                case "Length":
                    return (name) => name.Length != int.Parse(pattern);
                case "Contains":
                    return (name) => !name.Contains(pattern);
                default:
                    return (name) => true;
            }
        }
    }
}
