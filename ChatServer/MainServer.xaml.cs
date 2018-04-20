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
        public List<UserServer> users;
        private Task listenTask = null;
        public MainServer()
        {
            InitializeComponent();
            DataHandle.ShowHandler += UpdateTxtb;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int port = int.Parse(txtPort.Text);
            IPAddress ip = DataHandle.localIP;
            listener = new TcpListener(ip, port);
            listener.Start();
            txtbMsg.Text += string.Format("在{0}:{1}开始监听。。。\n",ip.ToString(), port.ToString());
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
            listenTask = new Task(() => ListenConnect());
            listenTask.Start();
        }
        
        public void ListenConnect()
        {
            TcpClient newClient = null;
            while(true)
            {
                try
                {
                    newClient = listener.AcceptTcpClient();
                    this.txtbMsg.Dispatcher.Invoke(() => txtbMsg.Text += string.Format("{0}-->新客户端连接-->{1}\n", DateTime.Now.ToLongTimeString(), newClient.Client.RemoteEndPoint));
                    UserServer user = new UserServer(newClient);
                    DataHandle.userList.Add(user);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Accept:"+ex.Message);
                    return;
                }
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listener.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stop:"+ex.Message);
            }
            this.txtbMsg.Dispatcher.Invoke(() => this.txtbMsg.Text += "已停止监听");
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
            if(users!=null)
            {
                users.Clear();
            }
        }

        public void UpdateTxtb(object sender, string data)
        {
            this.txtbMsg.Dispatcher.Invoke(() => this.txtbMsg.Text += data);
        }
    }
}
