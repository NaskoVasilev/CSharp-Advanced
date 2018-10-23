using System;
using System.Collections.Generic;
using System.Linq;

namespace Inferno
{
    class Inferno
    {
        static List<int> initialNumbers;

        static void Main(string[] args)
        {
            initialNumbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string command = "";
            Queue<KeyValuePair<string, int>> filters = new Queue<KeyValuePair<string, int>>();

            while ((command = Console.ReadLine()) != "Forge")
            {
                string[] tokens = command
                .Split(';', StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[1];
                int value = int.Parse(tokens[2]);

                if (tokens[0] == "Exclude")
                {
                    filters.Enqueue(new KeyValuePair<string, int>(type, value));
                }
                else
                {
                    filters.Dequeue();
                }
            }

            foreach (var filter in filters.Reverse())
            {
                for (int i = 0; i < initialNumbers.Count; i++)
                {
                    if (IsEqualToValue(i, filter.Value, filter.Key))
                    {
                        initialNumbers.RemoveAt(i);
                        i--;
                    }
                }
            }

            Console.WriteLine(string.Join(' ',initialNumbers));
        }

        private static bool IsEqualToValue(int index, int value, string type)
        {
            bool isEqual = false;
            switch (type)
            {
                case "Sum Right":
                    if (index == initialNumbers.Count - 1)
                    {
                        isEqual = initialNumbers[index] == value;
                    }
                    else
                    {
                        isEqual = initialNumbers[index] + initialNumbers[index + 1] == value;
                    }
                    break;
                case "Sum Left":
                    if (index == 0)
                    {
                        isEqual = initialNumbers[index] == value;
                    }
                    else
                    {
                        isEqual = initialNumbers[index] + initialNumbers[index - 1] == value;
                    }
                    break;
                case "Sum Left Right":
                    if (initialNumbers.Count == 1)
                    {
                        isEqual = initialNumbers[0] == value;
                    }
                    else if (index == 0)
                    {
                        isEqual = initialNumbers[index] + initialNumbers[index + 1] == value;
                    }
                    else if (index == initialNumbers.Count - 1)
                    {
                        isEqual = initialNumbers[index] + initialNumbers[index - 1] == value;
                    }
                    else
                    {
                        isEqual = initialNumbers[index - 1] + initialNumbers[index] + initialNumbers[index + 1] == value;
                    }
                    break;
            }
            return isEqual;
        }
    }
}
