using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Entity;
using TalkHelper;

namespace TestModel
{
    /// <summary>
    /// ObjectSerializeTest.xaml 的交互逻辑
    /// </summary>
    public partial class ObjectSerializeTest : Window
    {
        public ObjectSerializeTest()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtShow.Text = "";
            txtShow.Text += "测试开始";
            LoginMsg loginMsg = new LoginMsg();
            loginMsg.UserName = "testuser";
            loginMsg.Password = "testpassword";
            string res = TalkHelper.HandleHelper.XMLSer(loginMsg);
            txtShow.Text += res;
            var loginMsg2 = TalkHelper.HandleHelper.DeXMLSer<LoginMsg>(res);
            txtShow.Text += loginMsg2.UserName;
            txtShow.Text += loginMsg2.Password;
        }
    }
}
