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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChattingModel Model { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ShowCoversation(string id) {
            var conv = ConversationService.GetConversationById(id);
            if(!string.IsNullOrEmpty(conv.Key) && conv.Value != null)
            {
                Model.ShowedConversation = conv;

                this.ConversationTitle.Text = conv.Value.Title;
                this.ConversationMessageBox.Children.Clear();

                var messages = conv.Value.Messages.OrderBy(m => m.Value.SendTime).ToDictionary(m=> m.Key, m=> m.Value).Values;
                foreach (var message in messages)
                {
                    if (message.UserID == UserService.UserID)
                    {
                        this.ConversationMessageBox.Children.Add(new UserControlMessageSent()
                        {
                            Model = message
                        });
                    }
                    else
                    {
                        this.ConversationMessageBox.Children.Add(new UserControlMessageReceived()
                        {
                            Model = message
                        });
                    }
                }
            }
            else
            {
                MessageBox.Show("Conversation is NULL");
            }
            
        }

        private void LoadContent()
        {
            var conversations = ConversationService.GetListConversation();
            ConversationListBox.Children.Clear();
            foreach(var conversation in conversations)
            {
                this.ConversationListBox.Children.Add(new ConversationControl()
                {
                    Model = conversation,
                    MainWindow = this
                }); ;
            }
        }

        private void Loaded(object sender, RoutedEventArgs e)
        {
            LoadContent();
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Da send");
            if (!string.IsNullOrEmpty(ConversationInput.Text))
            {
                ConversationService.SendMessage(Model.ShowedConversation.Key, ConversationInput.Text);
                ShowCoversation(Model.ShowedConversation.Key);
            }

        }
    }
}
