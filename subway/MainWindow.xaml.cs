using subway.Admin;
using subway.DAO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace subway
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 静态变量，获取用户名，用于跨页面传值
        /// </summary>
        public static string username;

        public MainWindow()
        {
            InitializeComponent();
            textBox_username.MouseDoubleClick += TextBox_username_MouseDoubleClick;
            passwordBox_password.MouseDoubleClick += PasswordBox_password_MouseDoubleClick;
            double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            double x1 = SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
            double y1 = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度
            this.Width = x1;//设置窗体宽度
            this.Height = y1;//设置窗体高度
            this.Title = "登陆";
        }

        /// <summary>
        /// 双击密码框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_password_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            passwordBox_password.Password = "";
            textBox_username.Text = "";
        }

        /// <summary>
        /// 双击用户名窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_username_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            passwordBox_password.Password = "";
            textBox_username.Text = "";
        }

        /// <summary>
        /// 点击OK 实现登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            BaseFunc baseFc = new BaseFunc();
            username = textBox_username.Text.Trim();


            string password = passwordBox_password.Password.Trim();
            if(username==""||password=="")
            {
                MessageBox.Show("请输入正确信息");
                return;
            }
            else
            {
                string loginInfo = baseFc.GetLoginCheck(username, password);
                if(loginInfo=="admin")
                {
                    //this.Close();
                    // MessageBox.Show("登陆成功");
                    chooseSystem chose = new chooseSystem();
                    chose.ShowDialog();
                }
                else
                if (loginInfo == "coustom")
                {
                    //this.Close();
                    // MessageBox.Show("登陆成功");
                    admin_main main = new admin_main();
                   // chooseSystem chose = new chooseSystem();
                    main.ShowDialog();
                }
                else
                if(loginInfo=="failed")
                {
                    MessageBox.Show("登陆失败");
                }
                else
                    if(loginInfo=="not"|| loginInfo == "")
                {
                    MessageBox.Show("用户不存在");

                }
                else
                {
                    MessageBox.Show("密码错误");
                }
            }
           // MessageBox.Show(username);
           
        }
       
        /// <summary>
        /// 点击Cancel关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
       
        /// <summary>
        /// 跳转到找回密码页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_getPWD_Click(object sender, RoutedEventArgs e)
        {
            Admin_getPassword getpwd = new Admin_getPassword();
            getpwd.Show();
        }
       
        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <returns></returns>
        private string getUsername()
        {
            return textBox_username.Text;
        }
    }
}
