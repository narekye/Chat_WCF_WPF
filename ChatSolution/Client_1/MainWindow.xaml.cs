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
using Client_1.Chat;

namespace Client_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ChatClient chat = new ChatClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AllMembers(object sender, RoutedEventArgs e)
        {
            var list = chat.GetAllMembers();
            foreach (Chat.User user in list)
            {
                result.Text = user.Name + "\t" + user.Password + "\n";
            }
        }

        private void Send(object sender, RoutedEventArgs e)
        {

        }

        private void Reg_OnClick(object sender, RoutedEventArgs e)
        {
            Chat.User us = new Chat.User()
            {
                Name = log.Text,
                Password = pass.Text
            };

            chat.Register(us);
            // MessageBox.Show("completed");
        }
    }
}
