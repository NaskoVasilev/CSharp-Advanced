using System;
using System.IO;
using System.Text;

namespace WriteToFile
{
    class WriteToFile
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            FileStream fs = new FileStream("test.txt", FileMode.Create);

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                fs.Write(bytes, 0, bytes.Length);
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
