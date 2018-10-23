using System;
using System.Collections.Generic;
using System.Linq;

namespace Assault
{
    class Assault
    {
        static void Main(string[] args)
        {
            int maxNumber = 1000000;
            var regions = new Dictionary<string, Dictionary<string, long>>();
            string command = "";

            while ((command = Console.ReadLine()) != "Count em all")
            {
                string[] data = command.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string regionName = data[0];
                string type = data[1];
                long soldierCount = long.Parse(data[2]);

                if (!regions.ContainsKey(regionName))
                {
                    regions.Add(regionName, new Dictionary<string, long>());
                    regions[regionName].Add("Red", 0);
                    regions[regionName].Add("Green", 0);
                    regions[regionName].Add("Black", 0);
                }

                regions[regionName][type] += soldierCount;

                long redCount = regions[regionName]["Green"] / maxNumber;
                if (redCount > 0)
                {
                    regions[regionName]["Green"] = regions[regionName]["Green"] % maxNumber;
                    regions[regionName]["Red"] += redCount;
                }

                long blackCount = regions[regionName]["Red"] / maxNumber;
                if (blackCount > 0)
                {
                    regions[regionName]["Red"] = regions[regionName]["Red"] % maxNumber;
                    regions[regionName]["Black"] += blackCount;
                }
            }

            foreach (var region in regions
                .OrderByDescending(x => x.Value["Black"])
                .ThenBy(x => x.Key.Length)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine(region.Key);

                foreach (var pair in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {pair.Key} : {pair.Value}");
                }
            }
        }
    }
}
