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

namespace subway.Admin
{
    /// <summary>
    /// chooseOpen.xaml 的交互逻辑
    /// </summary>
    public partial class chooseOpen : Window
    {
        public chooseOpen()
        {
            InitializeComponent();
            double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            double x1 = SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
            double y1 = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度
            this.Width = x1;//设置窗体宽度
            this.Height = y1;//设置窗体高度


            //设置渐变字体
            LinearGradientBrush brush = new LinearGradientBrush();

            GradientStop gradientStop1 = new GradientStop();
            gradientStop1.Offset = 0;
            gradientStop1.Color = Color.FromArgb(255, 251, 100, 17);
            brush.GradientStops.Add(gradientStop1);

            GradientStop gradientStop2 = new GradientStop();
            gradientStop2.Offset = 1;
            gradientStop2.Color = Color.FromArgb(255, 247, 238, 52);
            brush.GradientStops.Add(gradientStop2);

            brush.StartPoint = new Point(0.5, 0);
            brush.EndPoint = new Point(0.5, 1);
            Welcome.Foreground = brush;

            System.Windows.Media.Effects.DropShadowEffect ds = new System.Windows.Media.Effects.DropShadowEffect();
            Welcome.Effect = ds;  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XinYongKa choose = new XinYongKa();
            choose.ShowDialog();
        }
    }
}
