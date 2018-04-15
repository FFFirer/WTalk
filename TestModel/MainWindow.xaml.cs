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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestModel
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObjectSerializeTest ost = new ObjectSerializeTest();
            ost.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClientSendTest cst = new ClientSendTest();
            cst.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataHandleTest dht = new DataHandleTest();
            dht.Show();
        }
    }
}
