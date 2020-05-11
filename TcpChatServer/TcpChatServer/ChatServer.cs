using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Linq;

namespace TcpChatServer
{
    class ChatServer
    {
        List<ChatClient> clients;

        readonly TcpListener server;

        public ChatServer(string ipaddress, int port)
        {
            if (!IPAddress.TryParse(ipaddress, out IPAddress _ip))
            {
                throw new InvalidOperationException("incorrect ip address");
            }
            
            server = new TcpListener(new IPEndPoint(_ip, port));
            
            clients = new List<ChatClient>();            
        }

        public void StartServer()
        {
            server.Start();

            while (true)
            {
                var client = server.AcceptTcpClient();

                var chatClient = new ChatClient(client, this);
            }
        }
        public void AddClient(ChatClient client)
        {
            if (clients.FirstOrDefault(x => x.ClientGuid.Equals(client.ClientGuid)) == null)
            {
                clients.Add(client);
            } 
        }
        public void RemoveClient(ChatClient client)
        {
            if (clients.FirstOrDefault(x => x.ClientGuid.Equals(client.ClientGuid)) != null)
            {
                clients.Remove(client);
            }
        }

        public void BroadCastMsg(string msg, ChatClient sender)
        {
            (from receiver in clients where receiver.ClientGuid != sender.ClientGuid select receiver)
                .AsParallel()
                .ForAll(async x => 
                        await x.Stream.WriteAsync(Encoding.UTF8.GetBytes(msg))); 
        }
    }
}
