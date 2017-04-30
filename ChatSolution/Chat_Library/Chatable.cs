using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Chat_Library
{
    public class Chatable : IChatable
    {
        private readonly MessagesContext_ db = new MessagesContext_();
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
            return ReferenceEquals(list, null);
        }
        public void Register(User user)
        {
            var member = (from u in db.Users
                where u.NickName == user.NickName
                select u).FirstOrDefaultAsync().Result;
            if (ReferenceEquals(member, null))
            {
                db.Users.Add(user);
                db.SaveChangesAsync();
            }
        }
        public void SendMail(User user)
        {
            var address = "yegoryan.narek@gmail.com";
            var fromAddress = new MailAddress("yegoryan.narek@gmail.com", "WCF_Web_Api_Verify Form");
            var toAddress = new MailAddress(user.Email, user.UserName);
            var smtp = new SmtpClient("aspmx.l.google.com", 25);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(address, "narek753159");
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
