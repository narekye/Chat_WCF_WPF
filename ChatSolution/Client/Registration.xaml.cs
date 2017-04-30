using System.Threading.Tasks;
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
            await Task.Run(() =>
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
            });
        }
    }
}
