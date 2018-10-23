using System.IO;
using System.Linq;

namespace ReverseAndWrite
{
    class ReverseAndWrite
    {
        static void Main(string[] args)
        {
            string path = "ReverseAndWrite.cs";
            string fileName = "reversed.txt";
            using (var reader = new StreamReader(path))
            {
                using (var writer = new StreamWriter(fileName))
                {
                    string line = "";

                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(string.Join("", line.Reverse()));
                    }
                }
            }
        }
    }
}
