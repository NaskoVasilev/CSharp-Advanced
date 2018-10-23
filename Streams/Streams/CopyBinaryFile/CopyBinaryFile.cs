using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../files/copyMe.png";
            string destinationPath = "../../files/copyMe-copy.png";

            using (FileStream reader = new FileStream(path, FileMode.Open))
            {
                using (FileStream writer = new FileStream(destinationPath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int byteCount = reader.Read(buffer, 0, buffer.Length);

                        if (byteCount == 0)
                        {
                            break;
                        }
                        writer.Write(buffer, 0, byteCount);
                    }
                }
            }
        }
    }
}
