using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace SlicingFile
{
    class SlicingFile
    {
        static List<string> files;

        static void Main(string[] args)
        {
            files = new List<string>();
            string pathName = "../../files/sliceMe.mp4";
            string destinationDirectory = "../../files/";
            int parts = 4;

            Slice(pathName, destinationDirectory, parts);
            Assemble(files, destinationDirectory);

        }

        private static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                int fileSize = (int)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    string filePath = destinationDirectory + $"part{i + 1}.mp4.gz";
                    files.Add(filePath);

                    using (GZipStream zipStream = new GZipStream(new FileStream(filePath, FileMode.Create),
                        CompressionMode.Compress, false))
                    {
                        byte[] buffer = new byte[fileSize];

                        int readBytes = reader.Read(buffer, 0, buffer.Length);
                        zipStream.Write(buffer, 0, readBytes);
                    }
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            string fileName = destinationDirectory + "assemble.mp4";

            using (FileStream writer = new FileStream(fileName, FileMode.Create))
            {
                foreach (var file in files)
                {
                    using (GZipStream zipStream = new GZipStream(new FileStream(file, FileMode.Open)
                    , CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[4096];

                        while (true)
                        {
                            int readBytes = zipStream.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                            {
                                break;
                            }
                            writer.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}
