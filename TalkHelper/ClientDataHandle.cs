using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkHelper
{
    public static class ClientDataHandle
    {
        public static  event EventHandler<string> ShowMsg;  //新建事件委托
        public static  void Default(string msg)
        {
            if(ShowMsg!=null)
            {
                ShowMsg(null, msg); 
            }
        }
    }
}
