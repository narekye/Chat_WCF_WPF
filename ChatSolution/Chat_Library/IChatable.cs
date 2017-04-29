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
    }
}
