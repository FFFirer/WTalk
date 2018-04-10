using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Entity
{
    public class User
    {
        //属性
        private TcpClient tcpClient;
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string remoteIP = "127.0.0.1";
        public int remotePort = 65501;
        public List<User> Friends { get; set; }


        //方法
        public User()
        {
            GetTcpClient();
        }

        public void GetTcpClient()
        {
            try
            {
                tcpClient = new TcpClient(remoteIP, remotePort);
            }
            catch
            {
                //异常处理
            }
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
        public List<User> SearchUsesr(string userid)
        {

        }
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
        //更新用户信息
        public void UpdatePWD(User user)
        {

        }
        #endregion

        #region 通讯操作
        //接收Tcp数据
        public void ReceiveDataTcp()
        {

        }
        //接收UDP数据
        public void ReceiveDataUDP()
        {

        }
        #endregion
    }
}
