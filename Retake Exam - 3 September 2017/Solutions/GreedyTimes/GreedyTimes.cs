using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedyTimes
{
    class GreedyTimes
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            var bag = new Dictionary<string, Dictionary<string, long>>();
            bag.Add("Gold", new Dictionary<string, long>());
            bag.Add("Gem", new Dictionary<string, long>());
            bag.Add("Cash", new Dictionary<string, long>());
            long goldPrice = 0;
            long gemPrice = 0;
            long totalCash = 0;
            string groupKey = "";
            string[] pairs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < pairs.Length; i += 2)
            {
                string name = pairs[i];
                long value = long.Parse(pairs[i + 1]);
                bool canNotPutMoreMoney = gemPrice + goldPrice + totalCash + value > bagCapacity;
                if (canNotPutMoreMoney)
                {
                    continue;
                }

                if (name.ToLower() == "gold")
                {
                    goldPrice += value;
                    groupKey = "Gold";
                }
                else if (name.Length == 3 && totalCash + value <= gemPrice)
                {
                    totalCash += value;
                    groupKey = "Cash";
                }
                else if (name.ToLower().EndsWith("gem") && name.Length >= 4 && gemPrice + value <= goldPrice)
                {
                    gemPrice += value;
                    groupKey = "Gem";
                }
                else
                {
                    continue;
                }

                if (!bag[groupKey].ContainsKey(name))
                {
                    bag[groupKey].Add(name, value);
                }
                else
                {
                    bag[groupKey][name] += value;
                }
            }

            foreach (var group in bag.Where(x => x.Value.Count > 0))
            {
                Console.WriteLine($"<{group.Key}> ${group.Value.Values.Sum()}");

                foreach (var item in group.Value.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }


}

