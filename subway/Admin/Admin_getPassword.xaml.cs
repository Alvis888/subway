using subway.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Admin_getPassword.xaml 的交互逻辑
    /// </summary>
    public partial class Admin_getPassword : Window
    {
        public Admin_getPassword()
        {
            InitializeComponent();
            textBox_email_Password.MouseDoubleClick += TextBox_email_Password_MouseDoubleClick;
            textBox_username_Password.MouseDoubleClick += TextBox_username_Password_MouseDoubleClick;
        }
        /// <summary>
        /// 双击用户名窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_username_Password_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox_email_Password.Text = "";
            textBox_username_Password.Text = "";
        }

        /// <summary>
        /// 双击密码窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_email_Password_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox_email_Password.Text = "";
            textBox_username_Password.Text = "";
        }

        /// <summary>
        /// 点击OK按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Password_Click(object sender, RoutedEventArgs e)
        {
            BaseFunc baseFc = new BaseFunc();
            string username = textBox_username_Password.Text.Trim().ToLower();
            string email = textBox_email_Password.Text.Trim().ToLower();
            if (username == "" || email == "")
            {
                MessageBox.Show("请输入正确信息");
                return;
            }
            else
            {
                ForgetPassword getPassword = new ForgetPassword();
                string str = getPassword.GetSendpasswrord(username, email);
                MessageBox.Show(str);
            }
        }

        /// <summary>
        /// 点击cancel按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Password_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 登陆连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Hyperlink_toLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow toLogin = new MainWindow();
            toLogin.Show();
        }
    }
}
