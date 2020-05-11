using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TCPServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TcpListener srv = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8091));

            srv.Start();

            while (true)
            {
                var client = srv.AcceptTcpClient();

                await Process(client);
            }            
        }

        static async Task Process(TcpClient client)
        {
            var stream = client.GetStream();

            while (true)
            {

                byte[] data = new byte[64];

                int bytes;

                StringBuilder sb = new StringBuilder();

                do
                {
                    bytes = await stream.ReadAsync(data, 0, data.Length);

                    sb.Append(Encoding.UTF8.GetString(data, 0, bytes));

                } while (client.Available > 0);

                Console.WriteLine(sb);

                await stream.WriteAsync(Encoding.UTF8.GetBytes("RESPONSE: " + sb.ToString().ToUpper()));

            }
        }
    }
}
