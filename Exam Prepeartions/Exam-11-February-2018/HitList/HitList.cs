using System;
using System.Collections.Generic;

namespace HitList
{
    class HitList
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, SortedDictionary<string, string>>();
            int targetInfoIndex = int.Parse(Console.ReadLine());
            string input = "";

            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] tokens = input.Split('=', StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                string[] kvps = tokens[1].Split(';', StringSplitOptions.RemoveEmptyEntries);

                if (data.ContainsKey(name) == false)
                {
                    data.Add(name, new SortedDictionary<string, string>());
                }

                foreach (var kvp in kvps)
                {
                    string[] keyValue = kvp.Split(':');
                    string key = keyValue[0];
                    string value = keyValue[1];

                    if (!data[name].ContainsKey(key))
                    {
                        data[name].Add(key, value);
                    }
                    else
                    {
                        data[name][key] = value;
                    }
                }
            }

            input = Console.ReadLine();
            input = input.Remove(0, 5);
            Console.WriteLine($"Info on {input}:");
            int infoIndex = 0;

            foreach (var kvp in data[input])
            {
                infoIndex += kvp.Key.Length + kvp.Value.Length;
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex-infoIndex} more info.");
            }
        }
    }
}
