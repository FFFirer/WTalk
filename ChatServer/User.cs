using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ChatServer
{
    public class User
    {
        public BinaryReader br { get; set; }
        public BinaryWriter bw { get; set; }
        private string UserId { get; set; }
        private string UserName { get; set; }
        private TcpClient client { get; set; }
        public User(TcpClient client)
        {
            this.client = client;
            NetworkStream ns = client.GetStream();
            br = new BinaryReader(ns);
            bw = new BinaryWriter(ns);

        }

        public void ReceiveFromClient()
        {
            while(true)
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
                string[] spilt = receiveString.Split(':');
                switch (spilt[0])
                {
                    default:
                        break;
                }
            }
        }
    }
}
