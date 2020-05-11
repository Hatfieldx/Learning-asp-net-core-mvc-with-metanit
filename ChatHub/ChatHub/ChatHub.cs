using ChatHub.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatHub
{
    public class ChatHub : Hub
    {
        public async Task Send(string message, string username)
        {
            await Clients.All.SendAsync("Send", message, username);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"Client {Context.ConnectionId} with name {Context.UserIdentifier} connected");

            await base.OnConnectedAsync();
        }

        public async Task ChangeAge(UserViewModel user)
        {
            user.Age = user.Age + 22;

            await Clients.Caller.SendAsync("AgeChanged", user);
        }
    }
}
