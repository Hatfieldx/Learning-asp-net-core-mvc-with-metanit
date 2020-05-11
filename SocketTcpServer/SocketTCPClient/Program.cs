using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace SocketTCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var pointServer = new IPEndPoint(IPAddress.Loopback, 8005);

            var serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            serverSocket.Connect(pointServer);



            serverSocket.Send(Encoding.UTF8.GetBytes("Test message"));

            do
            {

            } while (true);
        }
    }
}
