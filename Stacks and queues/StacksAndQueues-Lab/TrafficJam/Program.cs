using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int passedCars = 0;
            int number = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    int carsCount=cars.Count;
                    for (int i = 0; i < Math.Min(carsCount, number); i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        passedCars++;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
