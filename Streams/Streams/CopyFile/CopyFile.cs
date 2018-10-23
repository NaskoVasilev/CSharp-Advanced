using System;
using System.IO;

namespace CopyFile
{
    class CopyFile
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream("source.txt", FileMode.Open))
            {
                using (var writer = new FileStream("sourceCopy.txt", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] bytes = new byte[4096];
                        int readBytes = reader.Read(bytes, 0, bytes.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }

                        writer.Write(bytes, 0, readBytes);
                    }
                }
            }
        }
    }
}
