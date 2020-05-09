using HelpingHands.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Vue2Spa.Models;

namespace Vue2Spa.Hubs
{
    //public class INotificationHub
    //{
    //}

    public interface INotificationHub
    {
        // here place some method(s) for message from server to client
        Task SendNoticeEventToClient(string message);
        Task SendReceiveReceipt(string message,Question question);
    }

    public class NotificationHub : Hub<INotificationHub>
    {
        // here place some method(s) for message from client to server
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        private ApplicationDbContext _context;
        public NotificationHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendPOQuestion(string bidderId,string purchaseOrderId, string title, string message)
        {
            Debug.Print("Server Received message "+message);

            var bidderObject = _context.Bidders.Where(a => a.Id == Guid.Parse(bidderId)).FirstOrDefault();//(a => a.EmailAddress== bidderEmailAddress).FirstOrDefault();
            var purchaseOrderObject = _context.PurchaseOrder.Where(a => a.Id == Guid.Parse(purchaseOrderId)).FirstOrDefault();
            //var bidQuestion = _context.POQuestion

            var purchaseOrderOwner = purchaseOrderObject.Email;

            var question = new Question()
            {
                Title = title,
                Body = message,
                Score = 0,
                Id = Guid.NewGuid(),
                CreationTime = DateTime.Now
            };

            var poquestion = new POQuestion() {
                Question = question,
                QuestionId = question.Id,
                 BidderId = bidderObject.Id,
                 PurchaseOrderId = Guid.Parse(purchaseOrderId)
            
            };

            _context.Add(poquestion);
            await _context.SaveChangesAsync();

            var connectionId = _connections.GetConnections(purchaseOrderOwner);

            if (connectionId!=null)
            {
                foreach(var connection in connectionId)
                {
                    string response = string.Format("A new question has been asked about your purchase order {0}", DateTime.Now);


                    await Clients.Client(connection).SendNoticeEventToClient(response);
                }
                
            }


            // for the sender we need a receipt that we 
            await Clients.Caller.SendReceiveReceipt("Question Received and forwarded to Purchase order owner", question);

            //await Clients.Caller.SendNoticeEventToClient(response);



        }


        

        //public async Task SendResponse( string message)
        //{
        //    Debug.Print("Server Received message " + message);
        //    //await Clients.All.InvokeAsync("Send", nick, message);
        //}


        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;

            _connections.Add(name, Context.ConnectionId);

            Debug.Print("New Connection Added");


            //await Clients.All.SendNoticeEventToClient("This is a message from the server");

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
