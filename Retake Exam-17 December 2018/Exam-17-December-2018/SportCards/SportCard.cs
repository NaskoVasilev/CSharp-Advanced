using System;
using System.Collections.Generic;
using System.Linq;

namespace SportCards
{
    class SportCard
    {
        static void Main(string[] args)
        {
            var cards = new Dictionary<string, Dictionary<string, decimal>>();

            string command = "";

            while ((command = Console.ReadLine()) != "end")
            {
                string[] tokens = command.Split(" - ");

                if (tokens.Length < 2)
                {
                    string card = tokens[0].Substring(6);

                    if (cards.ContainsKey(card))
                    {
                        Console.WriteLine($"{card} is available!");
                    }
                    else
                    {
                        Console.WriteLine($"{card} is not available!");
                    }
                }
                else
                {
                    string card = tokens[0];
                    string sport = tokens[1];
                    decimal price = decimal.Parse(tokens[2]);

                    if (!cards.ContainsKey(card))
                    {
                        cards.Add(card, new Dictionary<string, decimal>());
                        cards[card].Add(sport, price);
                    }
                    else
                    {
                        if (!cards[card].ContainsKey(sport))
                        {
                            cards[card].Add(sport, price);
                        }
                        else
                        {
                            cards[card][sport] = price;
                        }
                    }
                }
            }

            PrintResult(cards);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, decimal>> cards)
        {
            foreach (var card in cards.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{card.Key}:");

                foreach (var sport in card.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{sport.Key} - {sport.Value:F2}");
                }
            }
        }
    }
}
