using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HTTPServer
{
    public static class HTTPServer
    {
        public static void Main(string[] args)
        {
            IHttpServer server = new HttpServer();

            server.Start();
        }
    }

    public interface IHttpServer
    {
        void Start();

        void Stop();
    }

    public class HttpServer : IHttpServer
    {
        private bool isWorking;

        private TcpListener tcpListener;

        public HttpServer()
        {
            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 8000);
        }

        public void Start()
        {
            this.tcpListener.Start();
            this.isWorking = true;
            Console.WriteLine("Started.");

            while (this.isWorking)
            {
                var client = this.tcpListener.AcceptTcpClient();
                var buffer = new byte[10240];
                var stream = client.GetStream();
                var readLength = stream.Read(buffer, 0, buffer.Length);
                var requestText = Encoding.UTF8.GetString(buffer, 0, readLength);
                Console.WriteLine(new string('=', 60));
                Console.WriteLine(requestText);
                string indexPath = "./views/index.html";
                var responseText = File.ReadAllText(indexPath);
                var responseBytes = Encoding.UTF8.GetBytes(
                    "HTTP/1.0 200 Not Found" + Environment.NewLine +
                    "Content-Length: " + responseText.Length + Environment.NewLine + Environment.NewLine +
                    responseText);
                stream.Write(responseBytes, 0, responseBytes.Length);
            }
        }

        public void Stop()
        {
            this.isWorking = false;
        }
    }
}
