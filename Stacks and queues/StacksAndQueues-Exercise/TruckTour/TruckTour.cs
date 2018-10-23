using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> trucksInfo = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] info = Console.ReadLine().Split().Select(int.Parse).ToArray();
                trucksInfo.Enqueue(info);
            }
            int totalFuel = 0;
            int index = 0;
            while (true)
            {
                totalFuel = 0;
                foreach (var truckInfo in trucksInfo)
                {
                    int fuel = truckInfo[0];
                    int distance = truckInfo[1];
                    totalFuel += fuel - distance;

                    if (totalFuel < 0)
                    {
                        trucksInfo.Enqueue(trucksInfo.Dequeue());
                        index++;
                        break;
                    }
                }

                if (totalFuel >= 0)
                {
                    Console.WriteLine(index);
                    break;
                }
            }


            //Other solution

            //int n = int.Parse(Console.ReadLine());
            //int index = 0;
            //long fuel = 0;

            //for (int i = 0; i < n; i++)
            //{
            //    string[] tokens = Console.ReadLine().Split(" ");
            //    long amountOfPetrol = long.Parse(tokens[0]);
            //    long distance = long.Parse(tokens[1]);
            //    fuel += amountOfPetrol;
            //    if (fuel < distance)
            //    {
            //        fuel = 0;
            //        index = i+1;
            //    }
            //    else
            //    {
            //        fuel -= distance;
            //    }
            //}

            //Console.WriteLine(index);
        }
    }
}
