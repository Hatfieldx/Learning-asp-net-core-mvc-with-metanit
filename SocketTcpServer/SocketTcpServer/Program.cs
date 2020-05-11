using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketTcpServer
{
    class Program
    {
        static int port = 8005;
        
        static void Main(string[] args)
        {
            IPEndPoint point = new IPEndPoint(IPAddress.Loopback, port);

            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listenSocket.Bind(point);

                listenSocket.Listen(5);

                while (true)
                {
                    Socket handler = listenSocket.Accept();

                    var sb = new StringBuilder();

                    int length;

                    byte[] data = new byte[256];

                    do
                    {
                        length = handler.Receive(data);
                        sb.Append(Encoding.UTF8.GetString(data, 0, length));

                    } while (handler.Available > 0);

                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + sb.ToString());

                    string msg = "msg received";

                    data = Encoding.UTF8.GetBytes(msg);

                    handler.Send(data);

                    handler.Shutdown(SocketShutdown.Both);

                    handler.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadKey();
        }
    }
}
