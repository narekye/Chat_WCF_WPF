using System;
using System.Windows;
using Client.Chat;

namespace Client
{
    public partial class MainWindow
    {
        ChatableClient proxy = new ChatableClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Send_Message(object sender, RoutedEventArgs e)
        {
            Message msg = new Message()
            {
                // MessageSender = name.Text,
                MessageContent = message.Text
            };
            proxy.Send(msg);
            Refresh_Block(null, null);
        }
        private async void Refresh_Block(object sender, EventArgs e)
        {
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
