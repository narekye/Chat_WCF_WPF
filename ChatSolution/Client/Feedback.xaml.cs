using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : Window
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private void SendFeedback_Click(object sender, RoutedEventArgs e)
        {
            string text = Text.Text;
            NetworkCredential cre = new NetworkCredential(Email.Text, Password.Password);
            MailMessage msg = new MailMessage(Email.Text, "vanhakobyan1996@gmail.com", "FeedBack", text);
            SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
            sc.UseDefaultCredentials = false;
            sc.Credentials = cre;
            sc.EnableSsl = true;
            sc.Send(msg);
        }
        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendFeedback_Click(null, null);
            }
        }

      
    }
}
