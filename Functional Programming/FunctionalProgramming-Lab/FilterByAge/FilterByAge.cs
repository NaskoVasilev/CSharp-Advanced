using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class FilterByAge
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            List<KeyValuePair<string, int>> people = new List<KeyValuePair<string, int>>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] person = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = person[0];
                int age = int.Parse(person[1]);

                people.Add(new KeyValuePair<string, int>(name, age));
            }

            string condition = Console.ReadLine();
            int years = int.Parse(Console.ReadLine());

            people = people
                .Where(p => condition == "older" ? p.Value >= years : p.Value < years)
                .ToList();

            string[] formats = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<KeyValuePair<string, int>> print = person =>
            {
                if (formats.Length == 2)
                {
                    Console.WriteLine($"{person.Key} - {person.Value}");
                }
                else
                {
                    if (formats[0] == "name")
                    {
                        Console.WriteLine($"{person.Key}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Value}");
                    }
                }
            };

            people.ForEach(print);
        }
    }
}
