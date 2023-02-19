using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Models
{
    public class ChatModel
    {
        public void massegesavetodb(Inbox_Chats inbox_Chats )
        {
            using(ChatDbEntities3 db = new ChatDbEntities3())
            {
                try
                {
                    //db.Inboxes.Add(inbox);
                    db.Inbox_Chats.Add(inbox_Chats);
                    db.SaveChanges();
                   
                        
                }
                catch (Exception ex)
                {
                    throw;
                    
                }
            }
        }
        public int GetUserIdByName(string Name)
        {
            using(ChatDbEntities3 db = new ChatDbEntities3())
            {
                try
                {
                    var result = db.Users.Where(x => x.Name == Name).FirstOrDefault();
                    if (result != null)
                    {
                        return result.id;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                   
                }
            }
        }
    }
}