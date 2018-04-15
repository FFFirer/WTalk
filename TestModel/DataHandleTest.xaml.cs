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
using TalkHelper;

namespace TestModel
{
    /// <summary>
    /// DataHandleTest.xaml 的交互逻辑
    /// </summary>
    public partial class DataHandleTest : Window
    {
        public DataHandleTest()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            if(txtTest.Text!=null)
            {
                txtbShow.Text += ("\n" + DataHandle.Handle(txtTest.Text));
            }
            else
            {
                MessageBox.Show("输入测试字符串");
            }
        }
    }
}
