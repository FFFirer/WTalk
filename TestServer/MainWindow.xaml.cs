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
using System.IO;

namespace TestServer
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public TcpListener listener;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int port = int.Parse(txtPort.Text);
            IPAddress IP = null;
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach(var v in ips)
            {
                if(v.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP = v;break;
                }
            }
            listener = new TcpListener(IP, port);
            listener.Start();
            txtbShow.Text += "开始监听\n";
            Task.Run(() => ListenClient());
        }
        public void ShowMsg(string msg)
        {
            txtbShow.Text += "\n receive:";
            txtbShow.Text += msg;
        }
        public void ListenClient()
        {
            TcpClient tcpClient = null;
            while (true)
            {
                try
                {
                    tcpClient = listener.AcceptTcpClient();
                    //ShowMsg("获取到一个客户端");
                    this.txtbShow.Dispatcher.Invoke(() => txtbShow.Text += "获取到一个客户端");
                    Task.Run(() =>
                    {
                        NetworkStream ns = tcpClient.GetStream();
                        BinaryReader br = new BinaryReader(ns);
                        BinaryWriter bw = new BinaryWriter(ns);
                        while (true)
                        {
                            string rec = null;
                            try
                            {
                                rec = br.ReadString();

                                this.txtbShow.Dispatcher.Invoke(() => txtbShow.Text += rec);
                            }
                            catch
                            {
                                return;
                            }
                        }
                    });
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
              
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            listener.Stop();
            ShowMsg("停止监听");
        }
    }
}
