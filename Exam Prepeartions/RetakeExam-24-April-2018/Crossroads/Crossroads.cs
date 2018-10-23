using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string command = "";
            int tottalCarsPassed = 0;
            int seconds = 0;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    seconds = greenLightDuration;

                    while (cars.Count > 0)
                    {
                        if (cars.Peek().Length < seconds)
                        {
                            seconds -= cars.Peek().Length;
                            cars.Dequeue();
                            tottalCarsPassed++;
                        }
                        else
                        {
                            string curretntCar = cars.Dequeue();
                            if (curretntCar.Length <= seconds + freeWindowDuration)
                            {
                                tottalCarsPassed++;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{curretntCar} was hit at {curretntCar[seconds + freeWindowDuration]}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{tottalCarsPassed} total cars passed the crossroads.");
        }
    }
}
