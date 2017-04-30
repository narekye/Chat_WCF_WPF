namespace Chat_Library
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class Chatable : IChatable
    {
        private readonly MessagesContext_ _db = new MessagesContext_();
        public void Send(Message message)
        {
            _db.Messages.Add(message);
            _db.SaveChanges();
        }
        public async Task<List<Message>> GetMessages()
        {
            return await _db.Messages.ToListAsync();
        }
        public async Task<bool> LoginAsync(User user)
        {
            User list = await (from d in _db.Users
                               where d.NickName == user.NickName && d.UserPassword == user.UserPassword
                               select d).FirstOrDefaultAsync();
            return !ReferenceEquals(list, null);
        }
        public async Task<bool> RegisterAsync(User user)
        {
            User member = await (from u in _db.Users
                                 where u.NickName == user.NickName
                                 select u).FirstOrDefaultAsync();
            if (ReferenceEquals(member, null))
            {
                _db.Users.Add(user);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public void SendMail(User user)
        {

        }

    }
}
