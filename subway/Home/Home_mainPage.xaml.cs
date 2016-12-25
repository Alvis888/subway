using subway.Model;
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
using System.Windows.Threading;

namespace subway.Home
{
    /// <summary>
    /// Home_mainPage.xaml 的交互逻辑
    /// </summary>
    public partial class Home_mainPage : Window
    {
        private DispatcherTimer ShowTimer;
        Ticket info = new Ticket();

       


        public Home_mainPage()
        {
            InitializeComponent();
            double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            double x1 = SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
            double y1 = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度
            this.Width = x1;//设置窗体宽度
            this.Height = y1;//设置窗体高度


            ShowTimer = new System.Windows.Threading.DispatcherTimer();
            ShowTimer.Tick += new EventHandler(ShowCurTimer);//起个Timer一直获取当前时间
            ShowTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            ShowTimer.Start();
        }


        public void ShowCurTimer(object sender, EventArgs e)
        {
            //"星期"+DateTime.Now.DayOfWeek.ToString(("d"))

            //获得星期几
            this.Time.Content = DateTime.Now.ToString("dddd", new System.Globalization.CultureInfo("zh-cn"));
            this.Time.Content += " ";
            //获得年月日
            this.Time.Content += DateTime.Now.ToString("yyyy年MM月dd日");   //yyyy年MM月dd日
            this.Time.Content += " ";
            //获得时分秒
            this.Time.Content += DateTime.Now.ToString("HH:mm:ss:ms");
            //System.Diagnostics.Debug.Print("this.ShowCurrentTime {0}", this.ShowCurrentTime);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Home_ticketInfo ticketInfo = new Home_ticketInfo();
            //ticketInfo.Show();
        }
    }
}
