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
using System.Net;
using System.Net.Sockets;
using System.IO;
using Entity;
using TalkHelper;

namespace ChatClient
{
    /// <summary>
    /// SignupWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SignupWindow : Window
    {
        public TcpClient tcpClient = null;
        private BinaryReader br;
        private BinaryWriter bw;
        public SignupWindow(TcpClient tcpClient)
        {
            InitializeComponent();
            this.tcpClient = tcpClient;
            NetworkStream ns = tcpClient.GetStream();
            br = new BinaryReader(ns);
            bw = new BinaryWriter(ns);
            Task.Run(() =>
            {
                while (true)
                {
                    string receivestring = null;
                    try
                    {
                        receivestring = br.ReadString();
                    }
                    catch
                    {
                        //异常处理
                    }
                    if (receivestring == "SIGNUP SUCCESS")
                    {
                        MessageBox.Show("注册成功！");
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(receivestring);
                    }
                }
            });
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            if(txtName.Text!=""&&Pwd.Password !=""&&Pwd2.Password!="")
            {
                if (Pwd.Password.Equals(Pwd2.Password))
                {
                    SignupMsg msg = new SignupMsg(txtName.Text.Trim(), Pwd.Password.Trim());
                    bw.Write(string.Format("SIGNUP@{0}", TalkHelper.HandleHelper.XMLSer<SignupMsg>(msg)));
                    bw.Flush();
                }
                else
                {
                    MessageBox.Show("两次密码不一致");
                }
            }
            else
            {
                MessageBox.Show("所有空都需填写");
            }
        }
    }
}
