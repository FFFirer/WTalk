using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Entity
{
    //消息格式"操作名称:操作参数"
    //使用XML对象转换成字符串进行传输
    public class Contract
    {
        public string OperationName { get; set; }
        public string Content { get; set; }
        public Contract()
        {

        }
        public Contract(string opname, string content)
        {
            this.OperationName = opname;
            this.Content = content;
        }

        public override string ToString()
        {
            return String.Format("{0}:{1}", OperationName, Content);
        }
        ////对象序列化XML字符串
        //static string XMLSer<T>(T entity)
        //{
        //    StringBuilder builder = new StringBuilder();
        //    XmlSerializer xs = new XmlSerializer(typeof(T));
        //    using (TextWriter writer = new StringWriter(builder))
        //    {
        //        xs.Serialize(writer, entity);
        //    }

        //    return builder.ToString();
        //}
        ////XML字符串反序列化为对象
        //static T DeXMLSer<T>(string xmlString)
        //{
        //    T cloneObject = default(T);
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append(xmlString);

        //    XmlSerializer serializer = new XmlSerializer(typeof(T));

        //    using(TextReader reader = new StringReader(builder.ToString()))
        //    {
        //        Object obj = serializer.Deserialize(reader);
        //        cloneObject = (T)obj;
        //    }

        //    return cloneObject;
        //}
        
    }
    //客户端发送的消息
    //登陆发送的消息协议
    public class LoginMsg
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public LoginMsg()
        {

        }
        public LoginMsg(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }
    }
    //注册发送的消息协议
    public class SignupMsg
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public SignupMsg()
        {

        }
        public SignupMsg(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }
    }
    //查询用户的消息协议
    public class SearchUserMsg
    {
        public string keyword { get; set; }
        public SearchUserMsg(string keyword)
        {
            this.keyword = keyword;
        }
    }
    //添加用户的消息协议
    public class AddUserMsg
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public AddUserMsg(string userid, string username)
        {
            this.UserID = userid;
            this.UserName = username;
        }
    }
    //删除用户的消息协议
    public class RemoveUserMsg
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public RemoveUserMsg(string userid, string username)
        {
            this.UserID = userid;
            this.UserName = UserName;
        }
    }
    //聊天发送的消息协议
    public class TalkMsg
    {
        public string DesUserID { get; set; }  //目标用户ID
        public string SendUserID { get; set; }  //发送用户ID
        public string Msg { get; set; }
        public TalkMsg(string desuserid, string senduserid, string msg)
        {
            this.DesUserID = desuserid;
            this.SendUserID = senduserid;
            this.Msg = msg;
        }
    }
    ////聊天发送的消息协议-发送给客户端
    //public class TalkMsg2Client
    //{
    //    public string 
    //}
    //更新用户密码的消息协议
    public class UpdateMsg
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public UpdateMsg(string userid, string password)
        {
            this.UserID = userid;
            this.Password = password;
        }
    }

}
