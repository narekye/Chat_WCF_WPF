using System;
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
            return !ReferenceEquals(list, null);
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
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;
            string emailFrom = "chatablenarvan@gmail.com";
            string password = "CHAT2017";
            string emailTo = user.Email;
            MailMessage mail = new MailMessage();
            string subject = "Finishing your registration";
            string body = $"For finishing your registration please click <a href=\"{mail.IsBodyHtml = true}\" title=\"Submit registration\">here</a>";
            mail.From = new MailAddress(emailFrom);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            //mail.IsBodyHtml = true;
            using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            {
                smtp.Credentials = new NetworkCredential(emailFrom, password);
                smtp.EnableSsl = enableSSL;
                try
                {
                    smtp.Send(mail);
                    Console.WriteLine("Your FeedBack Successfully Sent\n \t Thank You");
                }
                catch (Exception)
                {
                    Console.WriteLine("Input Correct Gmail and/or Password");
                }
            }
        }

    }

}