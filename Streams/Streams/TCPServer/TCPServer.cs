using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    class TCPServer
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 8000);
            tcpListener.Start();
            Console.WriteLine("Listening on port 8000 ...");

            while (true)
            {
                using (var stream = tcpListener.AcceptTcpClient().GetStream())
                {
                    byte[] request = new byte[4096];
                    int readBytes = stream.Read(request, 0, request.Length);
                    Console.WriteLine(Encoding.UTF8.GetString(request));

                    string text = Console.ReadLine();
                    byte[] response = Encoding.UTF8.GetBytes(text);
                    stream.Write(response, 0, response.Length);
                }

            }
        }
    }
}
