using System;
using System.Collections.Generic;

namespace StoreCities
{
    class StoreCities
    {
        static void Main(string[] args)
        {
            int numberOfCites = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> cities = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < numberOfCites; i++)
            {
                string[] cityInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = cityInfo[0];
                string country = cityInfo[1];
                string city = cityInfo[2];

                if (cities.ContainsKey(continent) == false)
                {
                    cities.Add(continent, new Dictionary<string, List<string>>());
                }

                if (cities[continent].ContainsKey(country) == false)
                {
                    cities[continent].Add(country, new List<string>());
                }
                cities[continent][country].Add(city);
            }

            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Key}:");
                foreach (var pair in city.Value)
                {
                    Console.WriteLine($"\t{pair.Key} -> {string.Join(", ",pair.Value)}");
                }
            }
        }
    }
}
