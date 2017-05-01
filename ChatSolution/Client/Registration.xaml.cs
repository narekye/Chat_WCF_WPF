using System.Windows;
using Client.Chat;

namespace Client
{
    public partial class Registration
    {
        public Registration()
        {
            InitializeComponent();
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
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
                MessageBox.Show("User successfully registered..");
                Close();
                return;
            }
            MessageBox.Show("User with the same nickname was founded, try another nickname...");
            Close();
        }
    }
}
