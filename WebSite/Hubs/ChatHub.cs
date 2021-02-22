using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebSite.Models;

namespace WebSite.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string from, string toUserId, string message)
        {
            ///string to = toUserId.Get;
            await Clients.Client(toUserId).sendMessageAsync(from, message);
            //await Clients.User(Context.ConnectionId).sendMessageAsync(from, message);
        }

        public string GetConnectionId() => Context.ConnectionId;
    }
}