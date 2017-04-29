﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.Chat {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/Chat_Library")]
    [System.SerializableAttribute()]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MessageIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageSenderField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MessageContent {
            get {
                return this.MessageContentField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageContentField, value) != true)) {
                    this.MessageContentField = value;
                    this.RaisePropertyChanged("MessageContent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MessageId {
            get {
                return this.MessageIdField;
            }
            set {
                if ((this.MessageIdField.Equals(value) != true)) {
                    this.MessageIdField = value;
                    this.RaisePropertyChanged("MessageId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MessageSender {
            get {
                return this.MessageSenderField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageSenderField, value) != true)) {
                    this.MessageSenderField = value;
                    this.RaisePropertyChanged("MessageSender");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/Chat_Library")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NickNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserPasswordField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NickName {
            get {
                return this.NickNameField;
            }
            set {
                if ((object.ReferenceEquals(this.NickNameField, value) != true)) {
                    this.NickNameField = value;
                    this.RaisePropertyChanged("NickName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserPassword {
            get {
                return this.UserPasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.UserPasswordField, value) != true)) {
                    this.UserPasswordField = value;
                    this.RaisePropertyChanged("UserPassword");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Chat.IChatable")]
    public interface IChatable {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatable/Send", ReplyAction="http://tempuri.org/IChatable/SendResponse")]
        void Send(Client.Chat.Message message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatable/Send", ReplyAction="http://tempuri.org/IChatable/SendResponse")]
        System.Threading.Tasks.Task SendAsync(Client.Chat.Message message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatable/GetMessages", ReplyAction="http://tempuri.org/IChatable/GetMessagesResponse")]
        Client.Chat.Message[] GetMessages();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatable/GetMessages", ReplyAction="http://tempuri.org/IChatable/GetMessagesResponse")]
        System.Threading.Tasks.Task<Client.Chat.Message[]> GetMessagesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatable/Login", ReplyAction="http://tempuri.org/IChatable/LoginResponse")]
        bool Login(Client.Chat.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatable/Login", ReplyAction="http://tempuri.org/IChatable/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(Client.Chat.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatable/Register", ReplyAction="http://tempuri.org/IChatable/RegisterResponse")]
        void Register(Client.Chat.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatable/Register", ReplyAction="http://tempuri.org/IChatable/RegisterResponse")]
        System.Threading.Tasks.Task RegisterAsync(Client.Chat.User user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IChatableChannel : Client.Chat.IChatable, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ChatableClient : System.ServiceModel.ClientBase<Client.Chat.IChatable>, Client.Chat.IChatable {
        
        public ChatableClient() {
        }
        
        public ChatableClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ChatableClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatableClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ChatableClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Send(Client.Chat.Message message) {
            base.Channel.Send(message);
        }
        
        public System.Threading.Tasks.Task SendAsync(Client.Chat.Message message) {
            return base.Channel.SendAsync(message);
        }
        
        public Client.Chat.Message[] GetMessages() {
            return base.Channel.GetMessages();
        }
        
        public System.Threading.Tasks.Task<Client.Chat.Message[]> GetMessagesAsync() {
            return base.Channel.GetMessagesAsync();
        }
        
        public bool Login(Client.Chat.User user) {
            return base.Channel.Login(user);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(Client.Chat.User user) {
            return base.Channel.LoginAsync(user);
        }
        
        public void Register(Client.Chat.User user) {
            base.Channel.Register(user);
        }
        
        public System.Threading.Tasks.Task RegisterAsync(Client.Chat.User user) {
            return base.Channel.RegisterAsync(user);
        }
    }
}