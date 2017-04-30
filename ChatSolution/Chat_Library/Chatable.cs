using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
           // var Body =
                // $"For finishing your registration please click <a href=\"{message.IsBodyHtml = true}\" title=\"Submit registration\">here</a>";
           
        }

    }
}
