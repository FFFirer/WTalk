using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    //消息格式"操作名称:操作参数"
    //使用XML对象转换成字符串进行传输
    public class Contract
    {
        public string OperationName { get; set; }
        public string Content { get; set; }
        public Contract(string opname, string content)
        {
            this.OperationName = opname;
            this.Content = content;
        }
    }
    
}
