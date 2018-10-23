using System;
using System.Text.RegularExpressions;

namespace DataTransfer
{
    class DataTransfer
    {
        static void Main(string[] args)
        {
            int numberOfTransfers = int.Parse(Console.ReadLine());
            string pattern = @"s:([^;]+?);r:([^;]+?);m--(""[A-Za-z ]+"")";
            Regex regex = new Regex(pattern);
            int dataSize = 0;

            for (int i = 0; i < numberOfTransfers; i++)
            {
                string data = Console.ReadLine();
                Match match = regex.Match(data);

                if (match.Success)
                {
                    string sender = match.Groups[1].Value;
                    string receiver = match.Groups[2].Value;
                    string message = match.Groups[3].Value;

                    dataSize += CalculteDataSize(sender);
                    dataSize += CalculteDataSize(receiver);
                    string senderName = ExtractName(sender);
                    string recieverName = ExtractName(receiver);

                    Console.WriteLine($"{senderName} says {message} to {recieverName}");
                }
            }

            Console.WriteLine($"Total data transferred: {dataSize}MB");
        }

        private static string ExtractName(string data)
        {
            string name = "";

            foreach (var letter in data)
            {
                if (char.IsLetter(letter) || letter == ' ')
                {
                    name += letter;
                }
            }

            return name;
        }

        private static int CalculteDataSize(string word)
        {
            int currentDataSize = 0;

            foreach (var character in word)
            {
                if (char.IsDigit(character))
                {
                    currentDataSize += int.Parse(character.ToString());
                }
            }

            return currentDataSize;
        }
    }
}
