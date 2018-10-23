using System;
using System.IO;
using System.Text;

namespace ReadInMemoryString
{
    class ReadInMemoryString
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            using (MemoryStream stream = new MemoryStream(bytes))
            {
                while (true)
                {
                    int readByte = stream.ReadByte();

                    if (readByte == -1)
                    {
                        break;
                    }
                    Console.Write((char)readByte);
                }
            }
            Console.WriteLine();
        }
    }
}
