using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetWeb();
            //更改一下试试
        }
        public void GetWeb()
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;

            string strBuff = "";
            char[] cbuffer = new char[256];
            int byteRead = 0;

            Uri URL = new Uri("http://dotamax.com/player/detail/203592444/");

            try
            {
                req = (HttpWebRequest)WebRequest.Create(URL);
                res = (HttpWebResponse)req.GetResponse();
                Stream respStream = res.GetResponseStream();
                StreamReader sr = new StreamReader(respStream, Encoding.UTF8);
                byteRead = sr.Read(cbuffer, 0, 256);
                while (byteRead != 0)
                {
                    string strResp = new string(cbuffer, 0, byteRead);
                    strBuff = strBuff + strResp;
                    byteRead = sr.Read(cbuffer, 0, 256);
                }
                StreamWriter sw = new StreamWriter(@"d:1.txt");
                sw.Write(strBuff);
                respStream.Close();
                sw.Close();
                Close();
            }
            catch (ProtocolViolationException e)
            {
                Console.WriteLine("获取网页内容失败", e);
            }
            catch
            {
                Console.WriteLine("发生错误");
            }
        }


    }
}
