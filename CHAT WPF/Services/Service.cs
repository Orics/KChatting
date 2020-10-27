using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_WPF.Services
{
    public class Service
    {
        protected static FirebaseClient Client { get; set; }
        public static string UserID { get; set; }

        public Service()
        {
            Client = new FirebaseClient(new FirebaseConfig()
            {
                AuthSecret = "6zRmtx6gE2vTBgE8kWDsiqgjwCItaJetGK6dkAdg",
                BasePath = "https://kchat-b7025.firebaseio.com/"
            });

        }
    }
}
