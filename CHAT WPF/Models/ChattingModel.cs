using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_WPF.Models
{
    public class ChattingModel
    {
        public KeyValuePair<string,ConversationModel> ShowedConversation { get; set; }
        public Dictionary<string, ConversationModel> ListConversations { get; set; }
    }
}
