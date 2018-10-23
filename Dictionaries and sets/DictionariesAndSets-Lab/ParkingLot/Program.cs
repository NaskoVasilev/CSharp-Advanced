using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsNumbers = new HashSet<string>();

            string command = "";

            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(", ");

                string direction = tokens[0];
                string carNumber = tokens[1];

                if (direction == "IN")
                {
                    carsNumbers.Add(carNumber);
                }
                else if (direction == "OUT")
                {
                    carsNumbers.Remove(carNumber);
                }
            }

            if (carsNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine,carsNumbers));
            }
        }
    }
}
