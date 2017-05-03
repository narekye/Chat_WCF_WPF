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
        public PersonalMessages()
        {
            InitializeComponent();
            this.FillCombo();
            roomid = proxy.CreateRoom(us);
        }

        private void Personal_Message(object sender, RoutedEventArgs e)
        {
            var uss = proxy.GetAllUsersAsync().FirstOrDefault(p => p.NickName == combo.Text);
            var arax = proxy.GetIndex(uss);
            if (proxy.EnterExsitingRoom(us, uss))
            {
                
            }
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            foreach (var room in proxy.GetAllRooms())
            {
                res.Text += room.Users[0].NickName;
            }
        }

        public async void FillCombo()
        {
            var list = await proxy.GetAllUsersAsyncFromDbAsync();
            foreach (User user1 in list)
            {
                combo.Items.Add(user1.NickName);
            }
        }
    }
}
