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
        [OperationContract]
        List<User> GetAllUsersAsync();
        [OperationContract]
        Task<List<User>> GetAllUsersAsyncFromDb();
        [OperationContract]
        void RemoveFromList(User users);
        // added 
        [OperationContract]
        bool EnterExsitingRoom();
        [OperationContract]
        List<PersonalRoom> GetAllRooms();
        [OperationContract]
        int CreateRoom(User first, User second);
        [OperationContract]
        void SendToRoom(int roomindex, Message message);
        [OperationContract]
        List<Message> GetRoomMessages(int index);
    }
}
