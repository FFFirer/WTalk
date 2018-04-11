using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace TalkHelper
{
    public class HandleHelper
    {
        //对象序列化XML字符串
        public static string XMLSer<T>(T entity)
        {
            StringBuilder builder = new StringBuilder();
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StringWriter(builder))
            {
                xs.Serialize(writer, entity);
            }

            return builder.ToString();
        }
        //XML字符串反序列化为对象
        public static T DeXMLSer<T>(string xmlString)
        {
            T cloneObject = default(T);
            StringBuilder builder = new StringBuilder();
            builder.Append(xmlString);

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (TextReader reader = new StringReader(builder.ToString()))
            {
                Object obj = serializer.Deserialize(reader);
                cloneObject = (T)obj;
            }

            return cloneObject;
        }
    }
}
