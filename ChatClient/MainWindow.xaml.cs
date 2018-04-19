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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using Entity;
using System.IO;
using TalkHelper;

namespace ChatClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private TcpClient tcpClient = null;
        private User user;
        private BinaryReader br;
        private BinaryWriter bw;
        public MainWindow()
        {
            InitializeComponent();
            
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            GetConnected();
            string ID = txtId.Text.Trim();
            string PWD = txtPwd.Password.Trim();
            LoginMsg login = new LoginMsg(ID, PWD);
            bw.Write(string.Format("LOGIN@{0}", HandleHelper.XMLSer<LoginMsg>(login)));
            bw.Flush();
            //ChatWindow cw = new ChatWindow();
            //cw.Show();
            //this.Close();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignupWindow sw = new SignupWindow(tcpClient);
            sw.Show();
            this.Close();
        }

        public void GetConnected()
        {
            tcpClient = new TcpClient("192.168.10.1", 51888);
            NetworkStream ns = tcpClient.GetStream();
            br = new BinaryReader(ns);
            bw = new BinaryWriter(ns);
            Task.Run(() =>
            {
                while (true)
                {
                    string receiveString = null;
                    try
                    {
                        receiveString = br.ReadString();
                    }
                    catch
                    {
                        //异常处理
                    }
                    switch (receiveString)
                    {
                        case "LOGIN SUCCESS":
                            ChatWindow cw = new ChatWindow();
                            cw.Show();
                            this.Close();
                            break;
                        case "LOGIN FAILURE":
                            MessageBox.Show("用户名密码错误！");
                            this.txtPwd.Password = "";
                            break;
                        default:
                            MessageBox.Show(receiveString);
                            break;
                    }
                }
            });
        }
    }
}
