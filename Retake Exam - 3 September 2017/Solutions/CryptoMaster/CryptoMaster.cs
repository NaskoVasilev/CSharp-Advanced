using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoMaster
{
    class CryptoMaster
    {
        static void Main(string[] args)
        {
            int maxLength = 0;
            int[] numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int currentIndex = 0;
            int nextIndex = 0;
            int currentLength = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int step = 1; step < numbers.Length; step++)
                {
                    currentLength = 1;
                    currentIndex = i;
                    nextIndex = (currentIndex + step) % numbers.Length;
                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentLength++;
                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % numbers.Length;
                    }

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
            }

            Console.WriteLine(maxLength);
        }
    }
}
