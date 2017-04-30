using System.Windows;
using Client.Chat;
using System.Windows.Input;

namespace Client
{
    public partial class Login
    {
        private static User user;
        private static ChatableClient chat = MainWindow.proxy;
        public Login()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if ((Login_.Text == string.Empty && Password.Password == string.Empty) || (Password.Password.Length <= 6 && Password.Password.Length >= 15))
               MessageBox.Show("Please correctly enter the Login or password..");
            else
                MessageBox.Show($"Hello {Login_.Text} - a pleasant pastime...");
            user = new User()
            {
                NickName = Login_.Text,
                UserPassword = Password.Password
            };
            if (await chat.LoginAsync(user))
            {
                MainWindow.user = user;
                MessageBox.Show("Logged in as: " + user.NickName);
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
    }
}
