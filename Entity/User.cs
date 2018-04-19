using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using TalkHelper;
using System.IO;

namespace Entity
{
    public class User
    {
        //属性
        public bool isExit = false;
        public TcpClient tcpClient;
        public UdpClient udpClient;
        public BinaryReader br;
        public BinaryWriter bw;
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LocalIP = "127.0.0.1";
        public int LocalPort = 65501;
        public List<User> Friends { get; set; }
        public delegate void handle(string data, User user);

        //方法
        public User(string userid, string password, TcpClient tcpclient)
        {
            this.UserId = userid;
            this.Password = password;
            this.tcpClient = tcpclient;
            NetworkStream ns = tcpClient.GetStream();
            br = new BinaryReader(ns);
            bw = new BinaryWriter(ns);
            Task.Run(() => ReceiveDataTcp());
        }
        #region 用户进行的操作
        //注册
        public void Signup(User user)
        {

        }
        //登陆
        public void Login()
        {

        }
        //登出
        public void Logout()
        {

        }
        //查询用户
        //public List<User> SearchUsesr(string userid)
        //{

        //}
        //添加用户为好友
        public void AddUser(string userid)
        {

        }
        //从好友列表移除用户
        public void RemoveUser(string userid)
        {

        }
        //聊天
        public void Talk(string userid, string content)
        {

        }
        //更新用户密码
        public void UpdatePWD(User user)
        {

        }
        #endregion

        #region 通讯操作
        //发送Tcp数据
        public void SendMessage(string msg)
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
        //接收Tcp数据
        public void ReceiveDataTcp(handle h, User user)
        {
            while(isExit == false)
            {
                string receiveString = null;
                try
                {
                    receiveString = br.ReadString();
                    h(receiveString,user);
                }
                catch
                {
                    //异常处理
                    break;
                }
                string[] spilt = receiveString.Split(':');
                switch (spilt[0])
                {
                    case "CALLBACK":
                        ClientDataHandle.Default("CALLBACK:" + spilt[1]+"\n");
                        break;
                    default:
                        ClientDataHandle.Default(spilt[1]+"\n");
                        break;

                }
            }
        }
        //接收Tcp数据
        public void ReceiveDataTcp()
        {
            while (isExit == false)
            {
                string receiveString = null;
                try
                {
                    receiveString = br.ReadString();
                }
                catch
                {
                    //异常处理
                    break;
                }
                string[] spilt = receiveString.Split(':');
                switch (spilt[0])
                {
                    case "CALLBACK":
                        ClientDataHandle.Default("CALLBACK:" + spilt[1] + "\n");
                        break;
                    default:
                        ClientDataHandle.Default(spilt[1] + "\n");
                        break;

                }
            }
        }
        //接收UDP数据
        public void ReceiveDataUDP()
        {
            
        }
        #endregion
    }
}
