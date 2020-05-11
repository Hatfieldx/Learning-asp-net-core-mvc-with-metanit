using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Threading.Tasks;

namespace TcpChatServer
{
    class ChatClient
    {
        private string name;
        private readonly TcpClient _client;
        private readonly NetworkStream _stream;
        private readonly Guid _guid;
        private readonly ChatServer _server;
        public string Name => name;

        public Guid ClientGuid => _guid;

        public NetworkStream Stream => _stream;

        public ChatClient(TcpClient client, ChatServer server)
        {
            _client = client;

            _stream = _client.GetStream();

            _guid = new Guid();

            _server = server;
        }

        public async Task Process()
        {
            StringBuilder sb = new StringBuilder();

            byte[] data = new byte[64];

            int bytes;

            while (true)
            {
                sb.Clear();

                do
                {
                    bytes = await _stream.ReadAsync(data, 0, data.Length);

                    sb.Append(Encoding.UTF8.GetString(data, 0, bytes));

                } while (_stream.DataAvailable);

                _server.BroadCastMsg(sb.ToString(), this);
            }
        }
    }
}
