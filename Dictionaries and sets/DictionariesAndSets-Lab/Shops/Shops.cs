using System;
using System.Collections.Generic;

namespace Shops
{
    class Shops
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();

            string command = "";

            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shopName = tokens[0];
                string productName = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }

                if (!shops[shopName].ContainsKey(productName))
                {
                    shops[shopName].Add(productName, price);
                }
                else
                {
                    shops[shopName][productName] = price;
                }
            }

            foreach (var shop in shops)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
