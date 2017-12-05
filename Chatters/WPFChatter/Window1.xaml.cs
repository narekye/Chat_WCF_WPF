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
using System.Windows.Threading; //for Dispatcher



using Common;

namespace WPFChatter
{
    #region Window1 class
    /// <summary>
    /// This class represents a window, which may be used to show a list of 
    /// chatters connected to a chat room. A new chat window may be spawned
    /// by clicking on the list items, which will show a <see cref="ChatControl">
    /// ChatControl</see>
    /// 
    /// It achieves this by using the following WPF techniques
    /// 
    /// Data binding
    /// Templates
    /// Animation
    /// Styles
    /// Routed events
    /// Custom controls
    /// Dependancy properties
    /// WCF, service model interaction
    /// Singleton design pattern
    /// Multithreading
    /// Asynchronous delegates
    /// 
    /// This provides the logic for Window1, whilst the Window1.xaml
    /// provides the WPF UI design.
    /// </summary>
    public partial class Window1 : System.Windows.Window
    {
        #region Instance Fields
        Person currPerson;
        bool chatControlShown = false;
        private Proxy_Singleton ProxySingleton = Proxy_Singleton.GetInstance();
        #endregion
        #region Ctor
        /// <summary>
        /// Wires up the UI Element events
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            this.Loaded += delegate { initialiseGUI(); };
            this.Closed += delegate { Window_Closed(); };
            this.SignInControl.AddButtonClick += new RoutedEventHandler(SignInControl_AddButtonClick);
            this.lstChatters.SelectionChanged += new SelectionChangedEventHandler(lstChatters_SelectionChanged);
            this.ChatControl.CloseClick += new RoutedEventHandler(ChatControl_CloseClick);
        }
        #endregion
        #region Callback methods

        /// <summary>
        /// Calls the showChatWindow() method, passing it the sender
        /// parameter
        /// </summary>
        /// <param name="sender">The <see cref="Common.Person">Originator</see> 
        /// chatter</param>
        /// <param name="message">The message</param>
        private void Receive(Person sender, string message)
        {

            showChatWindow(sender);
        }

        /// <summary>
        /// Calls the showChatWindow() method, passing it the sender
        /// parameter
        /// </summary>
        /// <param name="sender">The <see cref="Common.Person">Originator</see> 
        /// chatter</param>
        /// <param name="message">The message</param>
        private void ReceiveWhisper(Person sender, string message)
        {
            showChatWindow(sender);
        }

        /// <summary>
        /// Adds the person input parameter to the internal list of
        /// chatters
        /// </summary>
        /// <param name="sender">The <see cref="Common.Person">new chatter</see> 
        /// </param>
        private void UserEnter(Person person)
        {
            lstChatters.Items.Add(person);
        }

        /// <summary>
        /// Removes the person input parameter to the internal list of
        /// chatters
        /// </summary>
        /// <param name="sender">The <see cref="Common.Person">chatter leaving</see> 
        /// </param>
        private void UserLeave(Person person)
        {
            lstChatters.Items.Remove(person);
        }
        #endregion
        #region Private Methods
        /// <summary>
        /// Initialise the GUI components
        /// </summary>
        private void initialiseGUI()
        {
            this.SignInControl.Visibility = Visibility.Visible;
            this.MainBorder.Visibility = Visibility.Hidden;
            this.mnuBorder.Visibility = Visibility.Hidden;
            Point windowRelativePoint =
                    this.bottomDocker.TranslatePoint(new Point(0, 0), this.MainBorder);
            double bottomDockerTop = windowRelativePoint.Y;
            this.lstChatters.Height = (double)(this.MainBorder.RenderSize.Height - (bottomDockerTop + 20));
        }

        /// <summary>
        /// Close the chat session by calling the <see cref="Proxy_Singleton">
        /// ExitChatSession()</see> method, and closing the application
        /// </summary>
        private void Window_Closed()
        {
            ProxySingleton.ExitChatSession();
            Application.Current.Shutdown();
        }

        /// <summary>
        /// This event occurs when the <see cref="ChatControl">
        /// ChatControl</see> control window is closed.
        /// The hideChatWindow animation is found from the WPF 
        /// resources and is triggered, which hides the 
        /// <see cref="ChatControl">ChatControl</see> 
        /// and the CurrentPerson/OtherPerson properties are
        /// cleared on the <see cref="ChatControl">
        /// ChatControl</see>
        /// </summary>
        /// <param name="sender">ChatControl</param>
        /// <param name="e">The event args</param>
        private void ChatControl_CloseClick(object sender, RoutedEventArgs e)
        {
            if (chatControlShown)
            {
                ChatControl.CurrentPerson = null;
                ChatControl.OtherPerson = null;
                //get Storyboard animation from window resources
                ((Storyboard)this.Resources["hideChatWindow"]).Begin(this);
                chatControlShown = false;
                mnuDisConnect.IsEnabled = true;
            }
        }

        /// <summary>
        /// This event occurs when a item is clicked within the 
        /// list of connected <see cref="Common.Person">chatters</see>
        /// The showChatWindow animation is found from the WPF 
        /// resources and is triggered, which shows the 
        /// <see cref="ChatControl">ChatControl</see> 
        /// and the CurrentPerson/OtherPerson properties are
        /// set on the <see cref="ChatControl">
        /// ChatControl</see>
        /// </summary>
        /// <param name="otherPerson">The <see cref="Common.Person">other chatter to talk to</see></param>
        private void showChatWindow(Person otherPerson)
        {
            if (!chatControlShown)
            {
                ChatControl.CurrentPerson = currPerson;
                ChatControl.OtherPerson = otherPerson;
                ChatControl.Visibility = Visibility.Visible;
                //get Storyboard animation from window resources
                ((Storyboard)this.Resources["showChatWindow"]).Begin(this);
                chatControlShown = true;
                mnuDisConnect.IsEnabled = false;
            }
        }

        /// <summary>
        /// Gets the <see cref="Common.Person">selected chatter to talk to</see> 
        ///  and calls the showChatWindow() method
        /// </summary>
        /// <param name="sender">lstChatters</param>
        /// <param name="e">The event args</param>
        private void lstChatters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            showChatWindow(lstChatters.SelectedItem as Person);
        }

        /// <summary>
        /// Close the chat session by calling the <see cref="Proxy_Singleton">
        /// ExitChatSession()</see> method
        /// </summary>
        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            ProxySingleton.ExitChatSession();
        }

        /// <summary>
        /// Close the chat session by calling the <see cref="Proxy_Singleton">
        /// ExitChatSession()</see> method, and displaying the disconnected status
        /// within the <see cref="ChatControl">ChatControl</see> recieved messages
        /// text box
        /// </summary>
        private void mnuDisConnect_Click(object sender, RoutedEventArgs e)
        {
            ProxySingleton.ExitChatSession();
            this.ChatControl.AppendText("Disconnected at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        /// <summary>
        /// Uses the data entered on the <see cref="SignInControl">SignInControl</see>
        /// to initialise certain UI elements. And also creates a new 
        /// <see cref="Proxy_Singleton">ProxySingleton</see> and subscribes to its
        /// ProxyEvent/ProxyCallBackEvent events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignInControl_AddButtonClick(object sender, RoutedEventArgs e)
        {
            lstChatters.Items.Clear();
            currPerson = this.SignInControl.CurrentPerson;
            //connect to proxy, and subscribe to its events
            ProxySingleton.Connect(currPerson);
            ProxySingleton.ProxyEvent += new Proxy_Singleton.ProxyEventHandler(ProxySingleton_ProxyEvent);
            //one event subscription for the embedded ChatControl
            ProxySingleton.ProxyCallBackEvent += new Proxy_Singleton.ProxyCallBackEventHandler(this.ChatControl.ProxySingleton_ProxyCallBackEvent);
            //one event subscription for this window
            ProxySingleton.ProxyCallBackEvent += new Proxy_Singleton.ProxyCallBackEventHandler(this.ProxySingleton_ProxyCallBackEvent);
            //set the UI elements using signin data
            this.photoBig.Source = new BitmapImage(new Uri(currPerson.ImageURL));
            this.SignInControl.Visibility = Visibility.Hidden;
            this.MainBorder.Visibility = Visibility.Visible;
            this.mnuBorder.Visibility = Visibility.Visible;
            this.lblInstructions.Content = "You can click on the gridview below to launch a chat window. When the window is opened you may\r\n" +
                                        "either chat using either the Whisper button which will ONLY chat to the person you selected in\r\n" +
                                        "the gridview, or you can use the Say button, which will allow ALL connected people to see the message.\r\n";
            this.txtPerson.Content = "Hello " + currPerson.Name;
        }


        /// <summary>
        /// A delegate to allow a cross UI thread call to be marshalled to correct
        /// UI thread
        /// </summary>
        private delegate void ProxySingleton_ProxyEvent_Delegate(object sender, ProxyEventArgs e);

        /// <summary>
        /// This method checks to see if the current thread needs to be marshalled
        /// to the correct (UI owner) thread. If it does a new delegate is created
        /// which recalls this method on the correct thread
        /// </summary>
        /// <param name="sender"><see cref="Proxy_Singleton">ProxySingleton</see></param>
        /// <param name="e">The event args</param>
        private void ProxySingleton_ProxyEvent(object sender, ProxyEventArgs e)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                new ProxySingleton_ProxyEvent_Delegate(ProxySingleton_ProxyEvent),
                sender, new object[] { e });
                return;
            }
            //now marshalled to correct thread so proceed
            foreach (Person person in e.list)
            {
                lstChatters.Items.Add(person);
            }
            this.ChatControl.AppendText("Connected at " + DateTime.Now.ToString() + " with user name " + currPerson.Name + Environment.NewLine);
        }


        /// <summary>
        /// This method is called when ever the <see cref="Proxy_Singleton">
        /// Proxy</see> ProxyCallBackEvent is raised, in response to an incoming message
        /// When this method is called it will examine the events 
        /// ProxyCallBackEventArgs to see what type of message is being recieved, 
        /// and will then call the correspoding method. 
        /// <see cref="ChatProxy">Receive/ReceiveWhisper</see> are not dealt with 
        /// as they are not relevant to this control. They are dealt with by
        /// <see cref="ChatControl">the ChatControl</see>
        /// </summary>
        /// <param name="sender">the sender, which is not used</param>
        /// <param name="e">The ChatEventArgs</param>
        private void ProxySingleton_ProxyCallBackEvent(object sender, ProxyCallBackEventArgs e)
        {
            switch (e.callbackType)
            {
                case CallBackType.Receive:
                    Receive(e.person, e.message);
                    break;
                case CallBackType.ReceiveWhisper:
                    ReceiveWhisper(e.person, e.message);
                    break;
                case CallBackType.UserEnter:
                    UserEnter(e.person);
                    break;
                case CallBackType.UserLeave:
                    UserLeave(e.person);
                    break;

            }
        }
        #endregion
    }
    #endregion
}