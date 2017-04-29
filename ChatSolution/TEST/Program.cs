using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.ServiceReference1;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Message mes = new Message()
            {
                MessageContent = "Hello... !!",
                MessageSender = "Narek"
            };
            ServiceReference1.ChatableClient client = new ChatableClient();
            // client.Send(mes);
            var list = client.GetMessages();
            foreach (Message message in list)
            {
                Console.WriteLine(message.MessageSender);
            }

            Console.Read();
        }
    }
}
