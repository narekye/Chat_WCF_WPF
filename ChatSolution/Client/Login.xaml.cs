namespace Client
{
    using System;
    using System.Windows;
    using Chat;
    using System.Windows.Input;

    public partial class Login
    {
        private static User user;
        private static ChatableClient chat = MainWindow._proxy;
        public Login()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if ((Login_.Text == string.Empty && Password.Password == string.Empty) || (Password.Password.Length <= 6 && Password.Password.Length >= 15))
                MessageBox.Show("Please correctly enter the Login or password..");
            user = new User()
            {
                NickName = Login_.Text,
                UserPassword = Password.Password
            };
            if (await chat.LoginAsync(user))
            {
                MainWindow.user = user;
                MessageBox.Show("Logged in as: " + user.NickName);
                Close();
                return;
            }
            MessageBox.Show("UserName or password incorrect..");
            Close();
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                button_Click(null, null);
            }
        }

        private async void ComboBox(object sender, EventArgs e)
        {
            Login_.Items.Clear();
            var list = await chat.GetAllUsersAsyncFromDbAsync();
            foreach (User user1 in list)
            {
                Login_.Items.Add(user1.NickName);
            }
        }
    }
}
