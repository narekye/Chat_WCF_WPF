using System.Windows;
using Client.Chat;

namespace Client
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                NickName = Nickname.Text,
                UserName = Username.Text,
                Email = Email.Text,
                UserPassword = Password.Text
            };
            MainWindow.proxy.SendMail(user);
            MainWindow.proxy.Register(user);
          
        }
    }
}
