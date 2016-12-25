﻿using subway.Admin;
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
            

        }

        private void PasswordBox_password_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            passwordBox_password.Password = "";
            textBox_username.Text = "";
        }

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
            string username = textBox_username.Text.Trim();
            string password = passwordBox_password.Password.Trim();
            if(username==""||password=="")
            {
                MessageBox.Show("请输入正确信息");
                return;
            }
            else
            {
                bool isLogin = baseFc.GetLoginCheck(username, password);
                if(isLogin)
                {
                    //this.Close();
                    // MessageBox.Show("登陆成功");
                    chooseSystem chose = new chooseSystem();
                    chose.ShowDialog();
                }
                else
                {
                    MessageBox.Show("无此用户或信息错误");
                }
            }
           
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

        private void Hyperlink_getPWD_Click(object sender, RoutedEventArgs e)
        {
            Admin_getPassword getpwd = new Admin_getPassword();
            getpwd.Show();
        }
    }
}
