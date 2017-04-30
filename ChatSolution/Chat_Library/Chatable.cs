using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Chat_Library
{
    public class Chatable : IChatable
    {
        private readonly MessagesContext_ db = new MessagesContext_();
        private static User loggedUser;
        public void Send(Message message)
        {
            db.Messages.Add(message);
            db.SaveChanges();
        }
        public async Task<List<Message>> GetMessages()
        {
            return await db.Messages.ToListAsync();
        }
        public bool LoginAsync(User user)
        {
            var list = (from d in db.Users
                where d.NickName == user.NickName && d.UserPassword == user.UserPassword
                select d).FirstOrDefault();
            if (ReferenceEquals(list, null)) return false;
            return true;
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
