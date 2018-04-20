using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    public static class DataHandle
    {
        public static List<UserServer> userList { get; set; }
        public static IPAddress localIP { get; set; }
        public static int port { get; set; }
        public static event EventHandler<string> ShowHandler;
        static DataHandle()
        {
            userList = new List<UserServer>();
            port = 51888;
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach(var v in ips)
            {
                if(v.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = v;
                    break;
                }
            }
        }
        //业务操作
        public static void Default(string data)
        {
            if(ShowHandler != null)
            {
                ShowHandler(null, data);
            }
        }

        public static string Resend(string data)
        {
            return "CALLBACK:服务器返回消息";
        }

        //登陆
        public static string Login(string id, string pwd)
        {
            if (id == "admin" && pwd == "admin")
            {
                return "LOGIN SUCCESS";
            }
            else
            {
                return "LOGIN FAILURE";
            }
        }

        //注册
        public static string Signup(string name, string pwd)
        {
            return "SIGNUP SUCCESS";
        }

        //登出
        public static string Logouot(string name)
        {
            return name + "已登出";
        }
    }
}
