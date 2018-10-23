using System;
using System.IO;

namespace ReadFile
{
    class ReadFile
    {
        static void Main(string[] args)
        {
            string fileName = "ReadFile.cs";
            string path = Path.Combine(fileName);

            using (var reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    Console.WriteLine($"Line {++counter}: {line}");

                    line = reader.ReadLine();
                }
            }
        }
    }
}
