using MainChoose;
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
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (btn.IsChecked == true)
            {
                btn.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                btn.Background = new SolidColorBrush(Colors.White);
            }
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
            this.Time.Content += DateTime.Now.ToString("HH:mm:ss");
            //System.Diagnostics.Debug.Print("this.ShowCurrentTime {0}", this.ShowCurrentTime);
        }
        

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (btn.IsChecked==true)
            {
                btn.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                btn.Background = new SolidColorBrush(Colors.Blue);
            }
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
        }


    }
}
