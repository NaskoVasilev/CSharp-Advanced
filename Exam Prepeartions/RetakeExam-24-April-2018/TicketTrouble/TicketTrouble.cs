using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicketTrouble
{
    class TicketTrouble
    {
        static void Main(string[] args)
        {
            string ticketPattern = @"{[^{]*\[([A-Z]{3} [A-Z]{2})\][^{]*\[([A-Z]\d{1,2})\][^{]*}|\[[^\[]*{([A-Z]{3} [A-Z]{2})}[^\[]*{([A-Z]\d{1,2})}[^\[]*\]";
            string location = Console.ReadLine();
            string input = Console.ReadLine();
            List<string> places = new List<string>();

            MatchCollection matches = Regex.Matches(input, ticketPattern);
            string destination = "";
            string place = "";
            string validTicket = "";
            foreach (Match match in matches)
            {
                validTicket = match.Value;
                if (validTicket.StartsWith("{"))
                {
                    destination = match.Groups[1].Value;
                    place = match.Groups[2].Value;
                }
                else
                {
                    destination = match.Groups[3].Value;
                    place = match.Groups[4].Value;
                }
                if (destination == location)
                {
                    places.Add(place);
                }
            }

            if (places.Count > 2)
            {
                for (int i = 0; i < places.Count - 1; i++)
                {
                    for (int j = i + 1; j < places.Count; j++)
                    {
                        if (places[i].Substring(1) == places[j].Substring(1))
                        {
                            Console.WriteLine($"You are traveling to {location} on seats {places[i]} and {places[j]}.");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine($"You are traveling to {location} on seats {places[0]} and {places[1]}.");
        }
    }
}
