using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Library
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Chatable" in both code and config file together.
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
    }
}
