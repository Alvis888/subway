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

        private void TextBox_username_Password_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox_email_Password.Text = "";
            textBox_username_Password.Text = "";
        }

        private void TextBox_email_Password_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textBox_email_Password.Text = "";
            textBox_username_Password.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            BaseFunc baseFc = new BaseFunc();
            string username = textBox_username_Password.Text;
            string email = textBox_email_Password.Text;
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


        private void button_Password_Click(object sender, RoutedEventArgs e)
        {
            BaseFunc baseFc = new BaseFunc();
            string username = textBox_username_Password.Text.Trim();
            string email = textBox_email_Password.Text.Trim();
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

        private void button1_Password_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Hyperlink_toLogin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow toLogin = new MainWindow();
            toLogin.Show();
        }
    }
}
