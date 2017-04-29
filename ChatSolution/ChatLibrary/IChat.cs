using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ChatLibrary
{
    [ServiceContract]
    public interface IChat
    {
        [OperationContract]
        string GetData(string name, string message);

        [OperationContract]
        bool Register(User value);

        [OperationContract]
        List<User> GetAllMembers();
    }
}
