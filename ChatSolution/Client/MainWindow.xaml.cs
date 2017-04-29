using System;
using System.Threading;
using System.Windows;
using Client.Chat;

namespace Client
{
    public partial class MainWindow
    {
        Chat.ChatableClient proxy = new ChatableClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Send_Message(object sender, RoutedEventArgs e)
        {
            var ms = new Message()
            {
                MessageSender = name.Text,
                MessageContent = message.Text
            };
            proxy.Send(ms);
            MainWindow_OnActivated(null, null);
        }
        private async void MainWindow_OnActivated(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            res.Text = "";
            var list = await proxy.GetMessagesAsync();

            Dispatcher.Invoke(() =>
            {
                foreach (Message message in list)
                {
                    res.Text += message.MessageSender + "\t" + message.MessageContent + "\n";
                }
            });
        }

        private void Form_of_Show(object sender, RoutedEventArgs e)
        {

        }

        private void Label_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {

        }
    }
}
