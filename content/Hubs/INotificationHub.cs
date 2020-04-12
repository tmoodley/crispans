using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Vue2Spa.Hubs
{
    //public class INotificationHub
    //{
    //}

    public interface INotificationHub
    {
        // here place some method(s) for message from server to client
        Task SendNoticeEventToClient(string message);
    }

    public class NotificationHub : Hub<INotificationHub>
    {
        // here place some method(s) for message from client to server
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public async Task Send(string bidder, string message)
        {
            Debug.Print("Server Received message "+message);
            string response = string.Format("Received The message at {0}", DateTime.Now);
            await Clients.Caller.SendNoticeEventToClient(response);
        }


        

        public async Task SendResponse( string message)
        {
            Debug.Print("Server Received message " + message);
            //await Clients.All.InvokeAsync("Send", nick, message);
        }


        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;

            _connections.Add(name, Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }


    }
}
