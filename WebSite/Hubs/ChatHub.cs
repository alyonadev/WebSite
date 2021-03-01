using Microsoft.AspNet.SignalR;
using Services;
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

        private readonly IMessageService _messageService;

        public ChatHub()
        {
            _messageService = new MessageService();
        }

        public async Task Send(string fromUserId, string toUserId, string from, string message)
        {
            _messageService.AddService(new DBModels.Message
            {
                From = int.Parse(fromUserId),
                To = int.Parse(toUserId),
                Date = DateTime.Now,
                Text = message,
                Status = false
            });
            
            var cids = _connections.GetConnections(toUserId);

            foreach (var connectionId in cids)
            {
                await Clients.Client(connectionId).sendMessageAsync(from, message);
            }
            await Clients.Client(Context.ConnectionId).sendMessageAsync(from, message);

            if (cids.Count() == 0) 
            {
                await Clients.Client(Context.ConnectionId).sendMessageAsync(from, message);
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