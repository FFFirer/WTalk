using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Entity;
using TalkHelper;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    /// <summary>
    /// MainServer.xaml 的交互逻辑
    /// </summary>
    public partial class MainServer : Window
    {
        private TcpListener listener;

        public MainServer()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int port = int.Parse(txtPort.Text);
            IPAddress ip = DataHandle.localIP;
            listener = new TcpListener(ip, port);
            listener.Start();
            txtbMsg.Text += "开始监听。。。\n";

        }
        
        public void ListenConnect()
        {
            TcpClient newClient;
            while(true)
            {
                try
                {
                    newClient = listener.AcceptTcpClient();
                    this.txtbMsg.Dispatcher.Invoke(() => txtbMsg.Text += string.Format("{0}-->新客户端连接-->{1}\n", DateTime.Now.ToLongTimeString(), newClient.Client.RemoteEndPoint));
                    User user = new User(newClient);
                    DataHandle.userList.Add(user);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
    }
}
