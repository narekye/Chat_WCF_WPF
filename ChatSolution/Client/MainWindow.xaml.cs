using System;
using System.Windows;
using Client.Chat;
using System.Diagnostics;
using System.Windows.Controls;

namespace Client
{
    public partial class MainWindow
    {
        public static User user;
        public static ChatableClient proxy = new ChatableClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Send_Message(object sender, RoutedEventArgs e)
        {
            if (ReferenceEquals(user, null))
            {
                MessageBox.Show("You must logged in at first...");
                return;
            }
            Message msg = new Message()
            {
                MessageContent = message.Text
            };
            proxy.Send(msg);
            Refresh_Block(null, null);
        }
        private async void Refresh_Block(object sender, EventArgs e)
        {
            if (ReferenceEquals(user, null)) return;
            res.Text = "";
            var list = await proxy.GetMessagesAsync();
            Dispatcher.Invoke(() =>
            {
                foreach (Message message in list)
                {
                    res.Text += message.MessageSender + "\t" + message.MessageContent + "\n";
                }
            });
            Label.Text = user.NickName;
        }

        private void Reg_of_Show(object sender, RoutedEventArgs e) => new Registration().Show();
        private void Sign_of_Show(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            if (user != null)
            {
                SignOUT.IsEnabled = true;
            }
        }

        private void Out_of_Show(object sender, RoutedEventArgs e)
        {
            user = null;
            MessageBox.Show("You have successfully signed out...");
        }

        private void NarGithub_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/narekye");
        }

        private void VanGithub_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/vanhakobyan");

        }

        private void NarFB_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.facebook.com/yegoryan.narek");
        }

        private void VanFB_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.facebook.com/VANHAKOBYAN");
        }

        private void Feed_Click(object sender, RoutedEventArgs e) => new Feedback().Show();

    }
}
