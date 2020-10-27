using CHAT_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_WPF.Services
{
    public class ConversationService : Service
    {
        public static KeyValuePair<string,ConversationModel> GetConversationById(string ID) {

            var conv = Client.Get("Conversations").ResultAs<Dictionary<string, ConversationModel>>()
                             .Where(c => c.Key == ID).FirstOrDefault();

            return conv;
        }


        public static Dictionary<string,ConversationModel> GetListConversation()
        {
            if (!string.IsNullOrEmpty(UserID))
            {
                var conversations = Client.Get("Conversations").ResultAs<Dictionary<string, ConversationModel>>()
                                          .Where(c => c.Value.Members.Any(m => m.Value.ID == UserID))
                                          .ToDictionary(c => c.Key, c => c.Value);

                return conversations;
            }
            return null;
        }

        public static void SendMessage(string ConversationID, string Text) {
            Client.Push("Conversations/" + ConversationID + "/Messages", new MessageModel(){
                    UserID = UserID,
                    Text = Text,
                    SendTime = DateTime.Now,
            });
        }
    }
}
