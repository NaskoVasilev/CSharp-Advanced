using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    class PoisonousPlants
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            List<int> indexes = new List<int>();
            List<int> amountOfPesticide = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int days = 0;

            while (true)
            {
                for (int i = 1; i < amountOfPesticide.Count; i++)
                {
                    if (amountOfPesticide[i - 1] < amountOfPesticide[i])
                    {
                        indexes.Add(i);
                    }
                }

                if (indexes.Count == 0)
                {
                    break;
                }

                for (int i = indexes.Count - 1; i >= 0; i--)
                {
                    amountOfPesticide.RemoveAt(indexes[i]);
                }

                days++;
                indexes.Clear();
            }

            Console.WriteLine(days);
        }
    }
}
