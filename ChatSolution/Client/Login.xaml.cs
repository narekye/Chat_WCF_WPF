using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login
    {
        private static User user;
        public Login()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if ((Login_.Text == string.Empty && Password.Password == string.Empty) || (Password.Password.Length <= 6 && Password.Password.Length >= 15))
            {
                MessageBox.Show("Please correctly enter the Login");
            }

            else
            {
                MessageBox.Show($"Hello {Login_.Text} - a pleasant pastime");
            }
        }


    }
}
