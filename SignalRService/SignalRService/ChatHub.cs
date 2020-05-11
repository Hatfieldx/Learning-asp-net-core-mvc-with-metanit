using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRService
{
    public class ChatHub : Hub
    {
        public async Task Send(string username, string message)
        {
            await this.Clients.All.SendAsync("Receive", username, message);
        }
    }
}
