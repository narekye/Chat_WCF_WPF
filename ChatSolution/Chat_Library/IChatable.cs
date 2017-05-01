namespace Chat_Library
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.Threading.Tasks;

    [ServiceContract]
    public interface IChatable
    {
        [OperationContract]
        void Send(Message message);
        [OperationContract]
        Task<List<Message>> GetMessages();
        [OperationContract]
        Task<bool> LoginAsync(User user);
        [OperationContract]
        Task<bool> RegisterAsync(User user);
        [OperationContract]
        void SendMail(User user);
    }
}
