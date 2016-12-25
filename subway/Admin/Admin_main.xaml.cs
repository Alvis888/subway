using MainChoose;
using subway.Home;
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


namespace subway.Admin
{
    /// <summary>
    /// admin_main.xaml 的交互逻辑
    /// </summary>
    public partial class admin_main : Window
    {
        private DispatcherTimer ShowTimer;
        int ticketNumber = 0;
        int stationNumber = 0;
        string destination = "";
        string[] lineOne = { "西流湖", "西三环", "秦岭路", "桐柏路", "碧沙路", "绿城广场", "医学院", "郑州火车站", "二七广场","人民路", "紫荆路", "燕庄", "民航路", "会展中心" };
        string[] lineTwo = { "刘庄", "柳林", "沙门", "北三环", "东风路", "关虎路", "黄河路", "紫荆山", "东大街", "陇海东路", "二里岗", "南五里堡", "花寨", "南三环" };
        public admin_main()
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

            //点击1号线站点
            radioButton_1_1.Checked += RadioButton_Checked;
            radioButton_1_2.Checked += RadioButton_Checked;
            radioButton_1_3.Checked += RadioButton_Checked;
            radioButton_1_4.Checked += RadioButton_Checked;
            radioButton_1_5.Checked += RadioButton_Checked;
            radioButton_1_6.Checked += RadioButton_Checked;
            radioButton_1_7.Checked += RadioButton_Checked;
            radioButton_1_8.Checked += RadioButton_Checked;
            radioButton_1_9.Checked += RadioButton_Checked;
            radioButton_1_10.Checked += RadioButton_Checked;
            radioButton_1_11.Checked += RadioButton_Checked;
            radioButton_1_12.Checked += RadioButton_Checked;
            radioButton_1_13.Checked += RadioButton_Checked;
            radioButton_1_14.Checked += RadioButton_Checked;

            //点击2号线站点
            radioButton_2_1.Checked += RadioButton_Checked;
            radioButton_2_2.Checked += RadioButton_Checked;
            radioButton_2_2.Checked += RadioButton_Checked;
            radioButton_2_3.Checked += RadioButton_Checked;
            radioButton_2_4.Checked += RadioButton_Checked;
            radioButton_2_5.Checked += RadioButton_Checked;
            radioButton_2_6.Checked += RadioButton_Checked;
            radioButton_2_7.Checked += RadioButton_Checked;
            radioButton_2_8.Checked += RadioButton_Checked;
            radioButton_2_9.Checked += RadioButton_Checked;
            radioButton_2_10.Checked += RadioButton_Checked;
            radioButton_2_11.Checked += RadioButton_Checked;
            radioButton_2_12.Checked += RadioButton_Checked;
            radioButton_2_13.Checked += RadioButton_Checked;
            radioButton_2_14.Checked += RadioButton_Checked;

            //点击购买票数
            button_Number_1.Click += Button_Number_Click;
            button_Number_2.Click += Button_Number_Click;
            button_Number_3.Click += Button_Number_Click;
            button_Number_4.Click += Button_Number_Click;
            button_Number_5.Click += Button_Number_Click;
            button_Number_6.Click += Button_Number_Click;
            button_Number_7.Click += Button_Number_Click;
            button_Number_8.Click += Button_Number_Click;
        }
        /// <summary>
        /// 点击站点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            
            switch (btn.Name.ToString())
            {
                case "radioButton_1_1":
                    destination = lineOne[0];
                    stationNumber = 8;
                   // stationNumber=
                    break;
                case "radioButton_1_2":
                    destination = lineOne[1];
                    stationNumber = 7;
                    break;
                case "radioButton_1_3":
                    destination = lineOne[2];
                    stationNumber = 6;
                    break;
                case "radioButton_1_4":
                    destination = lineOne[3];
                    stationNumber = 8;
                    break;
                case "radioButton_1_5":
                    destination = lineOne[4];
                    stationNumber = 4;
                    break;
                case "radioButton_1_6":
                    destination = lineOne[5];
                    stationNumber = 3;
                    break;
                case "radioButton_1_7":
                    destination = lineOne[6];
                    stationNumber = 2;
                    break;
                case "radioButton_1_8":
                    destination = lineOne[7];
                    stationNumber = 1;
                    break;
                case "radioButton_1_9":
                    destination = lineOne[8];
                    stationNumber = 0;
                    break;
                case "radioButton_1_10":
                    destination = lineOne[9];
                    stationNumber = 1;
                    break;
                case "radioButton_1_11":
                    destination = lineOne[10];
                    stationNumber = 2;
                    break;
                case "radioButton_1_12":
                    destination = lineOne[11];
                    stationNumber = 3;
                    break;
                case "radioButton_1_13":
                    destination = lineOne[12];
                    stationNumber = 4;
                    break;
                case "radioButton_1_14":
                    destination = lineOne[13];
                    stationNumber = 5;
                    break;






                case "radioButton_2_1":
                    destination = lineTwo[0];
                    stationNumber = 9;
                    break;
                case "radioButton_2_2":
                    destination = lineTwo[1];
                    stationNumber = 8;
                    break;
                case "radioButton_2_3":
                    destination = lineTwo[2];
                    stationNumber = 7;
                    break;
                case "radioButton_2_4":
                    destination = lineTwo[3];
                    stationNumber = 6;
                    break;
                case "radioButton_2_5":
                    destination = lineTwo[4];
                    stationNumber = 5;
                    break;
                case "radioButton_2_6":
                    destination = lineTwo[5];
                    stationNumber = 4;
                    break;
                case "radioButton_2_7":
                    destination = lineTwo[6];
                    stationNumber = 3;
                    break;
                case "radioButton_2_8":
                    destination = lineTwo[7];
                    stationNumber = 2;
                    break;
                case "radioButton_2_9":
                    destination = lineTwo[8];
                    stationNumber = 3;
                    break;
                case "radioButton_2_10":
                    destination = lineTwo[9];
                    stationNumber = 4;
                    break;
                case "radioButton_2_11":
                    destination = lineTwo[10];
                    stationNumber = 5;
                    break;
                case "radioButton_2_12":
                    destination = lineTwo[11];
                    stationNumber = 6;
                    break;
                case "radioButton_2_13":
                    destination = lineTwo[12];
                    stationNumber = 7;
                    break;
                case "radioButton_2_14":
                    destination = lineTwo[13];
                    stationNumber = 8;
                    break;

            }
        }

        /// <summary>
        /// 点击购买票数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Number_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name.ToString())
            {
                case "button_Number_1":
                    btn.Content = "选中 1";
                    btn.Foreground = new SolidColorBrush(Colors.Blue); 
                    button_Number_2.Content = "2张";
                    button_Number_2.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_3.Content = "3张";
                    button_Number_3.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_4.Content = "4张";
                    button_Number_4.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_5.Content = "5张";
                    button_Number_5.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_6.Content = "6张";
                    button_Number_6.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_7.Content = "7张";
                    button_Number_7.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_8.Content = "8张";
                    button_Number_8.Foreground = new SolidColorBrush(Colors.Black);

                    ticketNumber = 1;
                    break;
                case "button_Number_2":
                    btn.Content = "选中 2";
                    btn.Foreground = new SolidColorBrush(Colors.Blue);
                    button_Number_1.Content = "1张";
                    button_Number_1.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_3.Content = "3张";
                    button_Number_3.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_4.Content = "4张";
                    button_Number_4.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_5.Content = "5张";
                    button_Number_5.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_6.Content = "6张";
                    button_Number_6.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_7.Content = "7张";
                    button_Number_7.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_8.Content = "8张";
                    button_Number_8.Foreground = new SolidColorBrush(Colors.Black);
                    ticketNumber = 2;
                    break;
                case "button_Number_3":
                    btn.Content = "选中 3";
                    btn.Foreground = new SolidColorBrush(Colors.Blue);
                    button_Number_2.Content = "2张";
                    button_Number_2.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_1.Content = "1张";
                    button_Number_1.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_4.Content = "4张";
                    button_Number_4.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_5.Content = "5张";
                    button_Number_5.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_6.Content = "6张";
                    button_Number_6.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_7.Content = "7张";
                    button_Number_7.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_8.Content = "8张";
                    button_Number_8.Foreground = new SolidColorBrush(Colors.Black);
                    ticketNumber = 3;
                    break;
                case "button_Number_4":

                    btn.Content = "选中 4";
                    btn.Foreground = new SolidColorBrush(Colors.Blue);
                    button_Number_2.Content = "2张";
                    button_Number_2.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_3.Content = "3张";
                    button_Number_3.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_1.Content = "1张";
                    button_Number_1.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_5.Content = "5张";
                    button_Number_5.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_6.Content = "6张";
                    button_Number_6.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_7.Content = "7张";
                    button_Number_7.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_8.Content = "8张";
                    button_Number_8.Foreground = new SolidColorBrush(Colors.Black);
                    ticketNumber = 4;
                    break;
                case "button_Number_5":

                    btn.Content = "选中 5";
                    btn.Foreground = new SolidColorBrush(Colors.Blue);
                    button_Number_2.Content = "2张";
                    button_Number_2.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_3.Content = "3张";
                    button_Number_3.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_4.Content = "4张";
                    button_Number_4.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_1.Content = "1张";
                    button_Number_1.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_6.Content = "6张";
                    button_Number_6.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_7.Content = "7张";
                    button_Number_7.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_8.Content = "8张";
                    button_Number_8.Foreground = new SolidColorBrush(Colors.Black);
                    ticketNumber = 5;
                    break;
                case "button_Number_6":

                    btn.Content = "选中 6";
                    btn.Foreground = new SolidColorBrush(Colors.Blue);
                    button_Number_2.Content = "2张";
                    button_Number_2.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_3.Content = "3张";
                    button_Number_3.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_4.Content = "4张";
                    button_Number_4.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_5.Content = "5张";
                    button_Number_5.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_1.Content = "1张";
                    button_Number_1.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_7.Content = "7张";
                    button_Number_7.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_8.Content = "8张";
                    button_Number_8.Foreground = new SolidColorBrush(Colors.Black);
                    ticketNumber = 6;
                    break;
                case "button_Number_7":

                    btn.Content = "选中 7";
                    btn.Foreground = new SolidColorBrush(Colors.Blue);
                    button_Number_2.Content = "2张";
                    button_Number_2.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_3.Content = "3张";
                    button_Number_3.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_4.Content = "4张";
                    button_Number_4.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_5.Content = "5张";
                    button_Number_5.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_6.Content = "6张";
                    button_Number_6.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_1.Content = "1张";
                    button_Number_1.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_8.Content = "8张";
                    button_Number_8.Foreground = new SolidColorBrush(Colors.Black);
                    ticketNumber = 7;
                    break;
                case "button_Number_8":

                    btn.Content = "选中 8";
                    btn.Foreground = new SolidColorBrush(Colors.Blue);
                    button_Number_2.Content = "2张";
                    button_Number_2.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_3.Content = "3张";
                    button_Number_3.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_4.Content = "4张";
                    button_Number_4.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_5.Content = "5张";
                    button_Number_5.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_6.Content = "6张";
                    button_Number_6.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_7.Content = "7张";
                    button_Number_7.Foreground = new SolidColorBrush(Colors.Black);
                    button_Number_1.Content = "1张";
                    button_Number_1.Foreground = new SolidColorBrush(Colors.Black);
                    ticketNumber = 8;
                    break;
                

            }
            //if (btn.IsChecked == true)
            //{
            //    //btn.Background = new SolidColorBrush(Colors.Red);
            //}
            //else
            //{
            //    //btn.Background = new SolidColorBrush(Colors.White);
            //}
        }

        /// <summary>
        /// 显示当前日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            this.Time.Content += DateTime.Now.ToString("HH:mm:ss");
            //System.Diagnostics.Debug.Print("this.ShowCurrentTime {0}", this.ShowCurrentTime);
        }


        /// <summary>
        /// 点击总图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            image1.Visibility = Visibility.Visible;
            image2.Visibility = Visibility.Hidden;
            image3.Visibility = Visibility.Hidden;


            radioButton_2_1.Visibility = Visibility.Hidden;
            radioButton_2_2.Visibility = Visibility.Hidden;
            radioButton_2_2.Visibility = Visibility.Hidden;
            radioButton_2_3.Visibility = Visibility.Hidden;
            radioButton_2_4.Visibility = Visibility.Hidden;
            radioButton_2_5.Visibility = Visibility.Hidden;
            radioButton_2_6.Visibility = Visibility.Hidden;
            radioButton_2_7.Visibility = Visibility.Hidden;
            radioButton_2_8.Visibility = Visibility.Hidden;
            radioButton_2_9.Visibility = Visibility.Hidden;
            radioButton_2_10.Visibility = Visibility.Hidden;
            radioButton_2_11.Visibility = Visibility.Hidden;
            radioButton_2_12.Visibility = Visibility.Hidden;
            radioButton_2_13.Visibility = Visibility.Hidden;
            radioButton_2_14.Visibility = Visibility.Hidden;

            radioButton_1_1.Visibility = Visibility.Hidden;
            radioButton_1_2.Visibility = Visibility.Hidden;
            radioButton_1_2.Visibility = Visibility.Hidden;
            radioButton_1_3.Visibility = Visibility.Hidden;
            radioButton_1_4.Visibility = Visibility.Hidden;
            radioButton_1_5.Visibility = Visibility.Hidden;
            radioButton_1_6.Visibility = Visibility.Hidden;
            radioButton_1_7.Visibility = Visibility.Hidden;
            radioButton_1_8.Visibility = Visibility.Hidden;
            radioButton_1_9.Visibility = Visibility.Hidden;
            radioButton_1_10.Visibility = Visibility.Hidden;
            radioButton_1_11.Visibility = Visibility.Hidden;
            radioButton_1_12.Visibility = Visibility.Hidden;
            radioButton_1_13.Visibility = Visibility.Hidden;
            radioButton_1_14.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// 点击1号线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            image1.Visibility = Visibility.Hidden;
            image2.Visibility = Visibility.Visible;
            image3.Visibility = Visibility.Hidden;
            radioButton_1_1.Visibility = Visibility.Visible;
            radioButton_1_2.Visibility = Visibility.Visible;
            radioButton_1_2.Visibility = Visibility.Visible;
            radioButton_1_3.Visibility = Visibility.Visible;
            radioButton_1_4.Visibility = Visibility.Visible;
            radioButton_1_5.Visibility = Visibility.Visible;
            radioButton_1_6.Visibility = Visibility.Visible;
            radioButton_1_7.Visibility = Visibility.Visible;
            radioButton_1_8.Visibility = Visibility.Visible;
            radioButton_1_9.Visibility = Visibility.Visible;
            radioButton_1_10.Visibility = Visibility.Visible;
            radioButton_1_11.Visibility = Visibility.Visible;
            radioButton_1_12.Visibility = Visibility.Visible;
            radioButton_1_13.Visibility = Visibility.Visible;
            radioButton_1_14.Visibility = Visibility.Visible;

            radioButton_2_1.Visibility = Visibility.Hidden;
            radioButton_2_2.Visibility = Visibility.Hidden;
            radioButton_2_2.Visibility = Visibility.Hidden;
            radioButton_2_3.Visibility = Visibility.Hidden;
            radioButton_2_4.Visibility = Visibility.Hidden;
            radioButton_2_5.Visibility = Visibility.Hidden;
            radioButton_2_6.Visibility = Visibility.Hidden;
            radioButton_2_7.Visibility = Visibility.Hidden;
            radioButton_2_8.Visibility = Visibility.Hidden;
            radioButton_2_9.Visibility = Visibility.Hidden;
            radioButton_2_10.Visibility = Visibility.Hidden;
            radioButton_2_11.Visibility = Visibility.Hidden;
            radioButton_2_12.Visibility = Visibility.Hidden;
            radioButton_2_13.Visibility = Visibility.Hidden;
            radioButton_2_14.Visibility = Visibility.Hidden;


            radioButton_2_1.IsChecked=false;
            radioButton_2_2.IsChecked = false;
            radioButton_2_2.IsChecked = false;
            radioButton_2_3.IsChecked = false;
            radioButton_2_4.IsChecked = false;
            radioButton_2_5.IsChecked = false;
            radioButton_2_6.IsChecked = false;
            radioButton_2_7.IsChecked = false;
            radioButton_2_8.IsChecked = false;
            radioButton_2_9.IsChecked = false;
            radioButton_2_10.IsChecked = false;
            radioButton_2_11.IsChecked = false;
            radioButton_2_12.IsChecked = false;
            radioButton_2_13.IsChecked = false;
            radioButton_2_14.IsChecked = false;
        }
        /// <summary>
        /// 点击2号线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            image1.Visibility = Visibility.Hidden;
            image2.Visibility = Visibility.Hidden;
            image3.Visibility = Visibility.Visible;
            radioButton_2_1.Visibility = Visibility.Visible;
            radioButton_2_2.Visibility = Visibility.Visible;
            radioButton_2_2.Visibility = Visibility.Visible;
            radioButton_2_3.Visibility = Visibility.Visible;
            radioButton_2_4.Visibility = Visibility.Visible;
            radioButton_2_5.Visibility = Visibility.Visible;
            radioButton_2_6.Visibility = Visibility.Visible;
            radioButton_2_7.Visibility = Visibility.Visible;
            radioButton_2_8.Visibility = Visibility.Visible;
            radioButton_2_9.Visibility = Visibility.Visible;
            radioButton_2_10.Visibility = Visibility.Visible;
            radioButton_2_11.Visibility = Visibility.Visible;
            radioButton_2_12.Visibility = Visibility.Visible;
            radioButton_2_13.Visibility = Visibility.Visible;
            radioButton_2_14.Visibility = Visibility.Visible;

            radioButton_1_1.Visibility = Visibility.Hidden;
            radioButton_1_2.Visibility = Visibility.Hidden;
            radioButton_1_2.Visibility = Visibility.Hidden;
            radioButton_1_3.Visibility = Visibility.Hidden;
            radioButton_1_4.Visibility = Visibility.Hidden;
            radioButton_1_5.Visibility = Visibility.Hidden;
            radioButton_1_6.Visibility = Visibility.Hidden;
            radioButton_1_7.Visibility = Visibility.Hidden;
            radioButton_1_8.Visibility = Visibility.Hidden;
            radioButton_1_9.Visibility = Visibility.Hidden;
            radioButton_1_10.Visibility = Visibility.Hidden;
            radioButton_1_11.Visibility = Visibility.Hidden;
            radioButton_1_12.Visibility = Visibility.Hidden;
            radioButton_1_13.Visibility = Visibility.Hidden;
            radioButton_1_14.Visibility = Visibility.Hidden;

            radioButton_1_1.IsChecked = false;
            radioButton_1_2.IsChecked = false;
            radioButton_1_2.IsChecked = false;
            radioButton_1_3.IsChecked = false;
            radioButton_1_4.IsChecked = false;
            radioButton_1_5.IsChecked = false;
            radioButton_1_6.IsChecked = false;
            radioButton_1_7.IsChecked = false;
            radioButton_1_8.IsChecked = false;
            radioButton_1_9.IsChecked = false;
            radioButton_1_10.IsChecked = false;
            radioButton_1_11.IsChecked = false;
            radioButton_1_12.IsChecked = false;
            radioButton_1_13.IsChecked = false;
            radioButton_1_14.IsChecked = false;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Home_fasttickets fastTicket = new Home_fasttickets();
            fastTicket.Show();
        }
        /// <summary>
        /// 点击购买按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OkToPay_Click(object sender, RoutedEventArgs e)
        {
            Home_ticketInfo ticketInfo = new Home_ticketInfo(destination,ticketNumber, stationNumber,0);
            //MessageBox.Show(destination);
            //MessageBox.Show(ticketNumber.ToString());
            //MessageBox.Show(stationNumber.ToString());
            ticketInfo.Show();
        }
    }
}
