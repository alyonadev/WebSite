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

        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public async Task Send(string from, string toUserId, string message)
        {
            foreach (var connectionId in _connections.GetConnections(toUserId))
            {
                await Clients.Client(Context.ConnectionId).sendMessageAsync(from, message);
                await Clients.Client(connectionId).sendMessageAsync(from, message);
            }
        }

        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
            _connections.Add(name, Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string name = Context.User.Identity.Name;
            _connections.Remove(name, Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;
            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }
            return base.OnReconnected();
        }

    }
}