using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_WPF.Models
{
    public class MessageModel
    {
        public string ID { get; set; }
        public string UserID { get; set; }
        public DateTime SendTime { get; set; }
        public string Text { get; set; }
        public string ImgUrl { get; set; }
        public string FileUrl { get; set; }
    }
}
