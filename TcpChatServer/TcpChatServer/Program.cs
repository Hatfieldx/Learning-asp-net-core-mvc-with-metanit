using System;

namespace TcpChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new ChatServer("127.0.0.1", 8099);

            server.StartServer();
        }
    }
}
