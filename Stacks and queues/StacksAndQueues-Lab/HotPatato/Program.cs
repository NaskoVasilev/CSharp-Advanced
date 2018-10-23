using System;
using System.Collections.Generic;

namespace HotPatato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split(" ");
            int number = int.Parse(Console.ReadLine());
            Queue<string> players = new Queue<string>(children);

            while (players.Count != 1)
            {
                for (int i = 1; i < number; i++)
                {
                    players.Enqueue(players.Dequeue());
                }
                Console.WriteLine("Removed "+players.Dequeue());
            }
            Console.WriteLine($"Last is {players.Dequeue()}");
        }
    }
}
