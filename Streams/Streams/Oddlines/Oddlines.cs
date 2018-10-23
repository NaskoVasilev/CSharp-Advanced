using System;
using System.IO;

namespace Oddlines
{
    class Oddlines
    {
        static void Main(string[] args)
        {
            string filePath = "../../files/text.txt";
            int counter = 0;

            using(var reader = new StreamReader(filePath))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    line = reader.ReadLine();
                    counter++;
                }
            }
            
        }
    }
}
