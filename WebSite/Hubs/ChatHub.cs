using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {

            Clients.All.addMessage(name, message);
        }

    }
}