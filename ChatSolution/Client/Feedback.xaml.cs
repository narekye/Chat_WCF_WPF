using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Client
{
    public partial class Feedback
    {
        public Feedback()
        {
            InitializeComponent();
        }

        private async void SendFeedback_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                string text = Text.Text;
                string smtpAddress = "smtp.gmail.com";
                string emailFrom = Email.Text;
                string password = Password.Password;
                string emailTo = "chatablenarvan@gmail.com";
                string subject = "FeedBack";
                string body = text;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(smtpAddress, 587))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = true;
                    try
                    {
                        smtp.SendAsync(mail, new object());
                        MessageBox.Show("Your FeedBack Successfully Sent\n \t Thank You");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Input Correct Gmail and/or Password");
                    }
                }
            });
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
