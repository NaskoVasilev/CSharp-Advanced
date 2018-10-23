using System;
using System.IO;
using System.Net;
using System.Text;

namespace SimpleHttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] prefixes =
            {
                "http://localhost:8000/",
            };

            HttpListener listener = new HttpListener();

            foreach (var prefix in prefixes)
            {
                listener.Prefixes.Add(prefix);
            }

            string indexPath = "./views/index.html";
            string infoPath = "./views/info.html";
            string errorPath = "./views/error.html";
            listener.Start();
            Console.WriteLine("Listening on port 8000 ...");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
               
                string url = context.Request.Url.AbsolutePath;

                if (url == "/")
                {
                    GetHtml(indexPath, response);
                }
                else if (url == "/info")
                {
                    string text = File.ReadAllText(infoPath);
                    text = text.Replace("{0}", DateTime.Now.ToString());
                    text = text.Replace("{1}", Environment.ProcessorCount.ToString());
                    byte[] buffer = Encoding.UTF8.GetBytes(text);

                    using (Stream output = response.OutputStream)
                    {
                        output.Write(buffer, 0, buffer.Length);
                    }
                }
                else
                {
                    GetHtml(errorPath, response);
                }

            }

        }

        private static void GetHtml(string indexPath, HttpListenerResponse response)
        {
            string text = File.ReadAllText(indexPath);
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            using (Stream output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }

        }
    }
}
