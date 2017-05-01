namespace Chat_Library
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class Chatable : IChatable
    {
        private readonly MessagesContext_ _db = new MessagesContext_();
        private static List<User> connectedUsers = new List<User>();
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
            connectedUsers.Add(list);
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

        public List<User> GetAllUsersAsync()
        {
            return connectedUsers;
        }

        /// <inheritdoc />
        public async Task<List<User>> GetAllUsersAsyncFromDb()
        {
            return await _db.Users.ToListAsync();
        }

        /// <inheritdoc />
        public void RemoveFromList(User user)
        {
            var us = connectedUsers.FindLast(p => p.NickName == user.NickName);
            connectedUsers.Remove(us);
        }
    }
}
