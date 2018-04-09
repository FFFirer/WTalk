using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace TalkHelper
{
    public class ChatClient
    {
        private TcpClient tcpClient;
        private string remoteHost;  //服务器IP和端口，应该是固定的
        private int remotePort;
        private BinaryReader br;
        private BinaryWriter bw;
        private NetworkStream networkStream;
        public ChatClient(string host, int port)
        {
            this.remoteHost = host;
            this.remotePort = port;
            try
            {
                tcpClient = new TcpClient(remoteHost, remotePort);
                networkStream = tcpClient.GetStream();
                br = new BinaryReader(networkStream);
                bw = new BinaryWriter(networkStream);
            }
            catch
            {
                //异常处理
            }
        }
        
        //发送消息
        public void SendMessage(string msg)
        {
            if (tcpClient != null)
            {
                try
                {
                    bw.Write(msg);
                    bw.Flush();
                }
                catch
                {
                    //异常处理
                }
            }
        }

        //处理接收的服务器数据
        public void ReceiveData()
        {
            string receiveString = null;
            while(tcpClient!=null)
            {
                try { receiveString = br.ReadString(); }
                catch
                {
                    if(tcpClient != null)
                    {
                        //异常处理
                    }
                    break;
                }
                //将数据送入处理中心,是用委托还是接口
                //TransToHandler(receiveString);
                
            }
        }
    }
}
