using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string relativePath = "../../files";
            string fileName = "text.txt";
            string outputFileName = "../../files/output.txt";
            int counter = 0;
            string path = Path.Combine(relativePath, fileName);

            using(StreamReader reader =new StreamReader(path))
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine($"Line {++counter}: {line}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
