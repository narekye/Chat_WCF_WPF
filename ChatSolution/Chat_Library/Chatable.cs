using System.Collections.Generic;
using System.Data.Entity;
using System.Net.Mail;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Chat_Library
{
    public class Chatable : IChatable
    {
        private readonly MessagesContext db = new MessagesContext();
        public void Send(Message message)
        {
            db.Messages.Add(message);
            db.SaveChanges();
        }
        public async Task<List<Message>> GetMessages()
        {
            return await db.Messages.ToListAsync();
        }
        public async Task<bool> LoginAsync(User user)
        {
            return await db.Users.ContainsAsync(user);
        }
        public void Register(User user)
        {
            db.Users.Add(user);
            db.SaveChangesAsync();
        }
        public void SendMail(User user)
        {
            var fromAddress = new MailAddress("yegoryan.narek@yandex.ru", "WCF_Web_Api_Verify Form");
            var toAddress = new MailAddress(user.Email, user.UserName);
            var smtp = new SmtpClient();
            var message = new MailMessage();
            message.To.Add(toAddress);
            message.From = fromAddress;
            message.Subject = "Activation beta version";
            message.Body =
                $"For finishing your registration please click <a href=\"{message.IsBodyHtml = true}\" title=\"Submit registration\">here</a>";
            smtp.Send(message);
        }
    }
}
