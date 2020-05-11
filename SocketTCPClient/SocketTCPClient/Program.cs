using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketTCPClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Connect(IPAddress.Loopback, 8005);

            int bytes;

            byte[] data = new byte [256];

            while (true)
            {
                string msg = Console.ReadLine();

                if (msg.ToLower() == "exit")
                {
                    break;
                }

                server.Send(Encoding.UTF8.GetBytes(msg));

                do
                {
                    bytes = server.Receive(data);
                    Console.WriteLine(Encoding.UTF8.GetString(data, 0, bytes));

                } while (server.Available > 0);
            }

            server.Shutdown(SocketShutdown.Both);
            server.Close();

            Console.ReadKey();
        }
    }
}
