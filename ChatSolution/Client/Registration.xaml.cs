﻿namespace Client
{
    using System.Windows;
    using Chat;

    public partial class Registration
    {
        public Registration()
        {
            InitializeComponent();
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            if ((Username.Text == null || Username.Text.Length < 3) && (Password.Text == null || Password.Text.Length < 6) && Nickname == null )
            {
                MessageBox.Show("Input correctly Credential \nPassword must by more than 6 symbol !!!");
            }
            User user = new User
            {
                NickName = Nickname.Text,
                UserName = Username.Text,
                Email = Email.Text,
                UserPassword = Password.Text
            };
            
            MainWindow._proxy.SendMail(user);
            if (await MainWindow._proxy.RegisterAsync(user))
            {
                MessageBox.Show("User successfully registered...");
                Close();
                return;
            }
            MessageBox.Show("User with the same nickname was founded, try another nickname...");
            Close();
        }
    }
}
