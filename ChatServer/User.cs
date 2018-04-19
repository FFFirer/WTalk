using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Entity;

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
            Task.Run(() => ReceiveFromClient());
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
                string[] spilt = receiveString.Split('@');
                switch (spilt[0])
                {
                    case "RESEND":
                        string res = DataHandle.Resend(spilt[1]);
                        this.bw.Write(res);
                        bw.Flush();
                        break;
                    case "LOGIN":   //登陆
                        LoginMsg msg = TalkHelper.HandleHelper.DeXMLSer<LoginMsg>(spilt[1]);
                        string loginres = DataHandle.Login(msg.UserName, msg.Password);
                        bw.Write(loginres);
                        bw.Flush();
                        DataHandle.Default(string.Format("\n{0}-->{1}-->LOGIN", DateTime.Now.ToLongDateString(), msg.UserName));
                        break;
                    case "SIGNUP":  //注册
                        SignupMsg signupMsg = TalkHelper.HandleHelper.DeXMLSer<SignupMsg>(spilt[1]);
                        string signupres = DataHandle.Signup(signupMsg.UserName, signupMsg.Password);
                        this.bw.Write(signupres);
                        bw.Flush(); //向客户端发送
                        DataHandle.Default(string.Format("\n{0}-->{1}-->SIGNUP", DateTime.Now.ToLongDateString(), signupMsg.UserName)); //将操作结果输出在服务器界面上
                        break;
                    case "LOGOUT":  //登出,暂时没有操作
                        break;
                    default:
                        try
                        {
                            DataHandle.Default(spilt[1]);
                        }
                        catch(Exception ex)
                        {
                            DataHandle.Default(ex.Message);
                        }
                        break;
                }
            }
        }
    }
}
