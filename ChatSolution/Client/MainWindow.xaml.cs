﻿using System;
using System.Windows;
using Client.Chat;
using System.Diagnostics;

namespace Client
{
    public partial class MainWindow
    {
        public static User user;
        public static ChatableClient _proxy = new ChatableClient();
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
                MessageSender = user.NickName,
                MessageContent = message.Text
            };
            _proxy.Send(msg);
            Refresh_Block(null, null);
        }
        private async void Refresh_Block(object sender, EventArgs e)
        {
            if (ReferenceEquals(user, null))
            {
                SignOUT.IsEnabled = false;
                signin.IsEnabled = true;
                reg.IsEnabled = true;
                return;
            }
            {
                signin.IsEnabled = false;
                SignOUT.IsEnabled = true;
                reg.IsEnabled = false;
            }
            res.Text = "";
            var list = await _proxy.GetMessagesAsync();
            Dispatcher.Invoke(() =>
            {
                foreach (Message message1 in list)
                {
                    res.Text += message1.MessageSender + " : " + "\t" + message1.MessageContent + "\n";
                }
            });
            Label.Text = "Logged in as: " + user.NickName;
            message.Text = "TYPE YOUR MESSAGE HERE: ";
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
            Label.Text = "";
        }
        #region BTNCLICKS
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
        #endregion
        private void Feed_Click(object sender, RoutedEventArgs e) => new Feedback().Show();

    }
}
