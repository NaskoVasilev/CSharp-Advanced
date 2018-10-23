using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CubicArtillery
{
    class CubicArtillery
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            var bunkers = new Queue<KeyValuePair<string, Queue<int>>>();

            string input = "";

            while ((input = Console.ReadLine()) != "Bunker Revision")
            {
                string[] data = input.Split(' ');

                for (int i = 0; i < data.Length; i++)
                {
                    int number = 0;

                    if (int.TryParse(data[i], out number))
                    {
                        if (bunkers.Peek().Value.Sum() + number <= capacity)
                        {
                            bunkers.Peek().Value.Enqueue(number);
                            continue;
                        }

                        if (bunkers.Count > 1)
                        {
                            var bunkerToRemove = bunkers.Dequeue();
                            if (bunkerToRemove.Value.Count == 0)
                            {
                                Console.WriteLine($"{bunkerToRemove.Key} -> Empty");
                            }
                            else
                            {
                                Console.WriteLine($"{bunkerToRemove.Key} -> {string.Join(", ", bunkerToRemove.Value)}");
                            }
                            i--;
                            continue;
                        }

                        if (number > capacity)
                        {
                            continue;
                        }

                        if (bunkers.Count == 1)
                        {
                            while (bunkers.Peek().Value.Sum() + number > capacity)
                            {
                                bunkers.Peek().Value.Dequeue();
                            }
                            bunkers.Peek().Value.Enqueue(number);
                        }
                    }
                    else
                    {
                        bunkers.Enqueue(new KeyValuePair<string, Queue<int>>(data[i], new Queue<int>()));
                    }
                }
            }
        }
    }
}
