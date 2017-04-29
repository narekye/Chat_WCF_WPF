using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatLibrary
{
    public class Chat : IChat
    {
        private List<User> users;
        public string GetData(string name, string message)
        {
            return "Sended from: " + name + " - " + message + " At: " + DateTime.Now.ToShortTimeString();
        }

        public bool Register(User user)
        {
            if (users.Exists(x => x.Name == user.Name))
            {
                return false;
            }
            users.Add(user);
            return true;
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
