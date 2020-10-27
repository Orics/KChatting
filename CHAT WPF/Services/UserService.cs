using CHAT_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHAT_WPF.Services
{
    class UserService : Service
    {
        public UserService(): base()
        {

        }

        public static UserModel Login(string Username, string Password) {
            if(!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                var node = Client.Get("Users").ResultAs<Dictionary<string, UserModel>>()
                                 .Where(u => u.Value.Username == Username && u.Value.Password == Password).FirstOrDefault();
                                
                if (node.Value != null)
                {
                    UserID = node.Value.ID;
                    return node.Value;
                }
            }
            return null;
        }

        public static UserModel GetUserInfo()
        {
            if (!string.IsNullOrEmpty(UserID))
            {
                var node = Client.Get("Users").ResultAs<Dictionary<string, UserModel>>()
                                 .Where(u => u.Value.ID == UserID).FirstOrDefault();

                if (node.Value != null)
                {
                    return node.Value;
                }
            }
            return null;
        }
    }
}
