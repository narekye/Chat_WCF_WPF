using System;

namespace Chat_Library
{
    using System.Windows;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class Chatable : IChatable
    {
        private readonly MessagesContext_ _db = new MessagesContext_();
        private static List<User> connectedUsers = new List<User>();
        // for PM
        private static List<PersonalRoom> _room = new List<PersonalRoom>();

        

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

        public async Task<List<User>> GetAllUsersAsyncFromDb()
        {
            return await _db.Users.ToListAsync();
        }

        public void RemoveFromList(User user)
        {
            var us = connectedUsers.FindLast(p => p.NickName == user.NickName);
            connectedUsers.Remove(us);
        }
        // TODO: PM messaging methods not completed
        public int CreateRoom(User first)
        {
            List<User> list = new List<User>(2)
            {
                first
               
            };
            _room.Add(new PersonalRoom()
            {
                Users = list,
                Messages = new List<Message>()
            });
            return _room.Count - 1;
        }

        public void SendToRoom(int roomindex, Message message)
        {
            _room[roomindex].Messages.Add(message);
        }

        public List<Message> GetRoomMessages(int index)
        {
            return _room[index].Messages;
        }

        public List<PersonalRoom> GetAllRooms()
        {
            return _room;
        }

        public bool EnterExsitingRoom(User sender, User enter)
        {
            PersonalRoom current = new PersonalRoom();
            foreach (PersonalRoom personalRoom in _room)
            {
                if (personalRoom.Users.Contains(sender))
                {
                    current = personalRoom;
                    break;
                }
                current = null;
            }
            if (ReferenceEquals(current, null))
                return false;


            current.Users.Add(enter);
            return true;
        }

        public int GetIndex(User us)
        {
            for (int i = 0; i < _room.Count; i++)
            {
                if (_room[i].Users.Contains(us))
                {
                    return i;
                }
            }
            return 0;
        }

        public bool InviteToChat(User sender)
        {
            CreateRoom(sender);
            return true;
        }
    }
}
