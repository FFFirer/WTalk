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
using System.Net;
using System.Net.Sockets;
using TalkHelper;

namespace TestModel
{
    /// <summary>
    /// ClientSendTest.xaml 的交互逻辑
    /// </summary>
    public partial class ClientSendTest : Window
    {
        public TcpClient tcpClient;
        public User user;

        public ClientSendTest()
        {
            InitializeComponent();
            ClientDataHandle.ShowMsg += UpdateTxtb;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tcpClient = new TcpClient("192.168.10.1", 51888);
            user = new User("", "", tcpClient);
            txtShow.Text += "用户创建成功";
        }
        

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (user != null && txtSend.Text != "")
            {
                user.SendMessage(txtSend.Text);
            }
            txtSend.Clear();
        }

        public void UpdateTxtb(object sender, string msg)
        {
            this.txtShow.Dispatcher.Invoke(() => this.txtShow.Text += msg);
        }
    }
}
