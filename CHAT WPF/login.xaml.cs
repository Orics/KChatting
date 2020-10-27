using CHAT_WPF.Models;
using CHAT_WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CHAT_WPF
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void close_login_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Login(object sender, RoutedEventArgs e)
        {
            var username = this.Username.Text;
            var password = this.Password.Password;

            new UserService();

            var user =  UserService.Login(username, password);
            if (user != null)
            {
                this.Hide();
                new MainWindow()
                {
                    Model = new ChattingModel()
                    {
                        ListConversations = ConversationService.GetListConversation()
                    }

                }.Show();

            }
            
        }
    }
}
