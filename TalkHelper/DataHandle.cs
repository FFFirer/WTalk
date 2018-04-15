using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkHelper
{
    public class DataHandle
    {
        public static string Handle(string data)
        {
            string[] vars = data.Split(':');
            switch (vars[0])
            {
                case "LOGIN":
                    return vars[0];
                case "SIGNUP":
                    return vars[0];
                case "LOGOUT":
                    return vars[0];
                case "SEARCH":
                    return vars[0];
                case "ADD":
                    return vars[0];
                case "REMOVE":
                    return vars[0];
                case "TRANS":
                    return vars[0];
                case "UPDATE":
                    return vars[0];
                default:
                    return vars[0];
            }
        }
    }
}
