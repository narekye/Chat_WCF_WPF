using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Configuration;

namespace Chatters
{
    #region ChatService
    /// <summary>
    /// This class creates the initial <see cref="ChatService">ChatService </see>which
    /// is used by all the connected chat clients. The app.config is used to creat the
    /// service bindings
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main access point, creates the initial <see cref="ChatService">ChatService </see>which
        /// is used by all the connected chat clients. The app.config is used to creat the
        /// service bindings
        /// </summary>
        /// <param name="args">The command line args</param>
        static void Main(string[] args)
        {
            Uri uri = new Uri(ConfigurationManager.AppSettings["addr"]);
            ServiceHost host = new ServiceHost(typeof(Chatters.ChatService), uri);
            host.Open();
            Console.WriteLine("Chat service listen on endpoint {0}", uri.ToString());
            Console.WriteLine("Press ENTER to stop chat service...");
            Console.ReadLine();
            host.Abort();
            host.Close(); 
        }
    }
    #endregion
}
