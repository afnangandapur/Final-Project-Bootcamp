using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRChat.Models
{
    public class ChatHub : Hub
    {
        ChatDbEntities3 db = new ChatDbEntities3();
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
            ChatModel model = new ChatModel();
            Inbox_Chats inbox_Chats = new Inbox_Chats();
            inbox_Chats.InboxID = model.GetUserIdByName(name);
            inbox_Chats.SentBy = name;
            inbox_Chats.Message = message;
            inbox_Chats.CreatedDate = DateTime.Now;
            model.massegesavetodb(inbox_Chats);




        }

    }
}