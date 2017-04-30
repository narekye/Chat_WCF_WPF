using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Chat_Library
{
    [ServiceContract]
    public interface IChatable
    {
        [OperationContract]
        void Send(Message message);
        [OperationContract]
        Task<List<Message>> GetMessages();
        [OperationContract]
        bool LoginAsync(User user);
        [OperationContract]
        void Register(User user);
        [OperationContract]
        void SendMail(User user);
    }
}
