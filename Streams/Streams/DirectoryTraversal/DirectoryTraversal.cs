using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class DirectoryTraversal
    {
        static void Main(string[] args)
        {
            var directory = new Dictionary<string, Dictionary<string, double>>();

            string[] files = Directory.GetFiles("./", "*.*", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;
                string name = fileInfo.Name;
                double size = (double)fileInfo.Length / 1024;

                if (directory.ContainsKey(extension) == false)
                {
                    directory.Add(extension, new Dictionary<string, double>());
                }

                if (directory[extension].ContainsKey(name) == false)
                {
                    directory[extension].Add(name, size);
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/result.txt";

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var pair in directory.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    writer.WriteLine(pair.Key);

                    foreach (var file in pair.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value:F3}kb");
                    }
                }
            }
        }
    }
}
