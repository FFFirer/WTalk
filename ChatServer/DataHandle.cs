using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    public class DataHandle
    {
        public static List<User> userList { get; set; }
        public static IPAddress localIP { get; set; }
        public static int port { get; set; }
        static DataHandle()
        {
            userList = new List<User>();
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

    }
}
