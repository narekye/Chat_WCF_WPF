using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
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
using Client.Chat;

namespace Client
{
    /// <summary>
    /// Interaction logic for PersonalMessages.xaml
    /// </summary>
    public partial class PersonalMessages : Window
    {
        private static ChatableClient proxy = MainWindow._proxy;
        private User us = MainWindow.user;
        private int? roomid;
        // private User sec = proxy.GetAllUsersAsync().ToList().FindLast(p => p.NickName == "narekye");
        public PersonalMessages()
        {
            InitializeComponent();
        }

        private void Personal_Message(object sender, RoutedEventArgs e)
        {
            

            var message = new Message()
            {
                MessageSender = us.NickName,
                MessageContent = Box.Text
            };
            proxy.Send(message);
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            foreach (var room in proxy.GetAllRooms())
            {
                res.Text += room.Users[0].NickName;
            }
        }

        public void Func()
        {
            
        }
    }
}
