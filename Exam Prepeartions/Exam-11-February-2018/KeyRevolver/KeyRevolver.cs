using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            int[] bulletsArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> bullets = new Stack<int>(bulletsArr);

            int[] locksArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> locks = new Queue<int>(locksArr);

            int intelligenceValue = int.Parse(Console.ReadLine());
            int counter = 0;
            while (true)
            {
                counter++;
                int bullet = bullets.Pop();
                int lockPower = locks.Peek();

                if (bullet <= lockPower)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (counter == barrelSize && bullets.Count > 0)
                {
                    counter = 0;
                    Console.WriteLine("Reloading!");
                }

                if (locks.Count == 0)
                {
                    int bulletsLeft = bullets.Count;
                    int moneyEarned = intelligenceValue - (bulletsArr.Length - bulletsLeft) * bulletPrice;
                    Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
                    break;
                }
                else if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }
            }
        }
    }
}
