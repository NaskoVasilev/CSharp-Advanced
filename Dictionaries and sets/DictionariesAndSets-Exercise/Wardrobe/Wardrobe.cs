using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < lines; i++)
            {
                string[] tokens = Console.ReadLine().Split(" -> ");
                string color = tokens[0];
                string[] clothes = tokens[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var dress in clothes)
                {
                    if (!wardrobe[color].ContainsKey(dress))
                    {
                        wardrobe[color].Add(dress, 0);
                    }
                    wardrobe[color][dress]++;
                }
            }

            string[] targetInfo = Console.ReadLine().Split(' ');
            string targetColor = targetInfo[0];
            string targetDress = targetInfo[1];

            foreach (var pair in wardrobe)
            {
                Console.WriteLine($"{pair.Key} clothes:");
                foreach (var item in pair.Value)
                {
                    if (pair.Key == targetColor && item.Key == targetDress)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
