using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Threading; //for WPF Dispatcher

using Common;

namespace WPFChatter
{
    #region ChatControl class
    /// <summary>
    /// This class represents a chat control, which may be used to chat with fellow
    /// chatters. There are buttons for Say/Whisper/Close and a text box for entering
    /// new chat messages, and also a larger textbox for displaying incoming chat
    /// messages to this chatter
    /// 
    /// This provides the logic for the user control, whilst the ChatControl.xaml
    /// provides the WPF UI design.
    /// </summary>
    public partial class ChatControl
    {

        #region Instance Fields
        Person currentPerson;
        Person otherPerson;
        private Proxy_Singleton ProxySingleton = Proxy_Singleton.GetInstance();
        #endregion
        #region Routed Events

        /// <summary>
        /// CloseClickEvent event, occurs when the user clicks the close button
        /// </summary>
        public static readonly RoutedEvent CloseClickEvent = EventManager.RegisterRoutedEvent(
            "CloseClickEvent", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChatControl));

        /// <summary>
        /// Expose the CloseClickEvent to external sources
        /// </summary>
        public event RoutedEventHandler CloseClick
        {
            add { AddHandler(CloseClickEvent, value); }
            remove { RemoveHandler(CloseClickEvent, value); }
        }

        #endregion
        #region Ctor
        /// <summary>
        /// Wires up the UI Element events
        /// </summary>
        public ChatControl()
		{
			this.InitializeComponent();
            this.lblExit.MouseDown += new System.Windows.Input.MouseButtonEventHandler(lblExit_MouseDown);
            this.btnSay.Click += new RoutedEventHandler(btnSay_Click);
            this.btnWhisper.Click += new RoutedEventHandler(btnWhisper_Click);

        }
        #endregion
        #region Public Methods/Properties
        /// <summary>
        /// When called will append the text input parameter to
        /// the text of incoming messages
        /// </summary>
        /// <param name="text">The text to append</param>
        public void AppendText(string text)
        {
            this.txtMessages.AppendText(text);
        }

        /// <summary>
        /// Gets/Sets the current <see cref="Common.Person">chatter</see> 
        /// which ensures that the current chatter's image (Avatar) and name
        /// can be shown
        /// </summary>
        public Person CurrentPerson
        {
            get { return currentPerson; }
            set
            {
                currentPerson = value;
                if (currentPerson != null)
                {
                    this.imgMine.Source = new BitmapImage(new Uri(currentPerson.ImageURL));
                    this.lblCurrPersonName.Content = currentPerson.Name;
                }
            }
        }

        /// <summary>
        /// Gets/Sets the other <see cref="Common.Person">chatter</see> 
        /// which ensures that the other chatter's image (Avatar) and name
        /// can be shown
        /// </summary>
        public Person OtherPerson
        {
            get { return otherPerson; }
            set
            {
                otherPerson = value;
                if (otherPerson != null)
                {
                    this.imgOther.Source = new BitmapImage(new Uri(otherPerson.ImageURL));
                    this.lblOtherPersonName.Content = otherPerson.Name;
                }
            }
        }

        /// <summary>
        /// This method is called when ever the <see cref="Proxy_Singleton">
        /// Proxy</see> ProxyCallBackEvent is raised, in response to an incoming message
        /// When this method is called it will examine the events 
        /// ProxyCallBackEventArgs to see what type of message is being recieved, 
        /// and will then call the correspoding method. 
        /// <see cref="ChatProxy">UserEnter/UserLeave</see> are not dealt with 
        /// as they are not relevant to this control. They are dealt with by
        /// <see cref="Window1">the main WPF window</see>
        /// </summary>
        /// <param name="sender">the sender, which is not used</param>
        /// <param name="e">The ChatEventArgs</param>
        public void ProxySingleton_ProxyCallBackEvent(object sender, ProxyCallBackEventArgs e)
        {
            switch (e.callbackType)
            {
                case CallBackType.Receive:
                    Receive(e.person.Name, e.message);
                    break;
                case CallBackType.ReceiveWhisper:
                    ReceiveWhisper(e.person.Name, e.message);
                    break;
                case CallBackType.UserEnter:
                    break;
                case CallBackType.UserLeave:
                    break;

            }
        }

        /// <summary>
        /// Appends the incoming <see cref="ChatProxy">Receive</see> message
        /// using the AppendText() method. 
        /// </summary>
        /// <param name="senderName">the senders chat name</param>
        /// <param name="message">the send message</param>
        public void Receive(string senderName, string message)
        {
            AppendText(senderName + ": " + message + Environment.NewLine);
        }

        public void ReceiveWhisper(string senderName, string message)
        {
            AppendText(senderName + " whisper: " + message + Environment.NewLine);
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// The Whisper button has been clicked, so conduct a
        /// private message send between the currentPerson and
        /// the otherPerson.
        /// Calls the SayAndClear() method passing True for the
        /// "pvt" input parameter
        /// </summary>
        /// <param name="sender">btnWhisper</param>
        /// <param name="e">The event args</param>
        private void btnWhisper_Click(object sender, RoutedEventArgs e)
        {
            if (txtMessage.Text == "")
                return;

            Person to = otherPerson;
            if (to != null)
            {
                string receiverName = to.Name;
                AppendText("Whisper to " + receiverName + ": " + txtMessage.Text + Environment.NewLine);
                SayAndClear(receiverName, txtMessage.Text, true);
                txtMessage.Focus();
            }
        }

        /// <summary>
        /// The Say button has been clicked, so conduct a
        /// non private message between the currentPerson and
        /// the all other chatters.
        /// Calls the SayAndClear() method with a blank "to" parameter
        /// </summary>
        /// <param name="sender">btnSay</param>
        /// <param name="e">The event args</param>
        private void btnSay_Click(object sender, RoutedEventArgs e)
        {
            SayAndClear("", txtMessage.Text, false);
            txtMessage.Focus();
        }

        /// <summary>
        /// Raises the CloseClickEvent and the
        /// CloseClickEvent is raised which is used by the
        /// parent <see cref="Window1">window</see>
        /// </summary>
        /// <param name="sender">lblExit</param>
        /// <param name="e">The event args</param>
        private void lblExit_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(CloseClickEvent));
        }

        /// <summary>
        /// Simply calls the <see cref="Proxy_Singleton">
        /// Proxy.SayAndClear()</see> method passing it these
        /// input parameters
        /// </summary>
        /// <param name="to">The chatter name to send messager to</param>
        /// <param name="msg">The message to send</param>
        /// <param name="pvt">True means its a private 1 to 1 message</param>
        private void SayAndClear(string to, string msg, bool pvt)
        {
            if (msg != "")
            {
                try
                {
                    ProxySingleton.SayAndClear(to, msg, pvt);
                    txtMessage.Text = "";
                }
                catch
                {
                    AbortProxyAndUpdateUI();
                    AppendText("Disconnected at " + DateTime.Now.ToString() + Environment.NewLine);
                    Error("Error: Connection to chat server lost!");
                }
            }
        }

        /// <summary>
        /// Shows an error message and calls the <see cref="Proxy_Singleton">
        /// Proxy.AbortProxy()</see> method
        /// </summary>
        private void AbortProxyAndUpdateUI()
        {
            ProxySingleton.AbortProxy();
            MessageBox.Show("An error occurred, Disconnecting");
        }

        /// <summary>
        /// Shows an error message and calls the <see cref="Proxy_Singleton">
        /// Proxy.ExitChatSession()</see> method
        /// </summary>
        /// <param name="errMessage">The error message to display</param>
        private void Error(string errMessage)
        {
            ProxySingleton.ExitChatSession();
            MessageBox.Show(errMessage, "Connection error", MessageBoxButton.OK, MessageBoxImage.Error);

        }
        #endregion
    }
    #endregion
}