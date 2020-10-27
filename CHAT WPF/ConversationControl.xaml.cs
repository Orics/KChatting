using CHAT_WPF.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CHAT_WPF
{
    /// <summary>
    /// Interaction logic for ConversationControl.xaml
    /// </summary>
    public partial class ConversationControl : UserControl
    {
        public KeyValuePair<string, ConversationModel> Model { get; set; }
        public MainWindow MainWindow { get; set; }

        public ConversationControl()
        {
            InitializeComponent();
        }

        public void LoadContent() { 
            if(Model.Value != null)
            {
                this.Title.Text = Model.Value.Title;
                //--------------------------
            }
        }
       

        private void ShowConversation(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ConversationID: " + Model.Key);
            if (MainWindow != null && Model.Value != null)
            {
                MainWindow.ShowCoversation(Model.Key);
            }

        }

        private void Loaded(object sender, RoutedEventArgs e)
        {
            LoadContent();
        }
    }
}
