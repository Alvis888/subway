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
    /// chooseOpen.xaml 的交互逻辑
    /// </summary>
    public partial class chooseOpen : Window
    {
        //余额
        string remainingMoney = "";
        ConnectBD connectdb = new ConnectBD();
        public chooseOpen()
        {
            InitializeComponent();
            double x = SystemParameters.WorkArea.Width;//得到屏幕工作区域宽度
            double y = SystemParameters.WorkArea.Height;//得到屏幕工作区域高度
            double x1 = SystemParameters.PrimaryScreenWidth;//得到屏幕整体宽度
            double y1 = SystemParameters.PrimaryScreenHeight;//得到屏幕整体高度
            this.Width = x1;//设置窗体宽度
            this.Height = y1;//设置窗体高度

            button_charge.Click += Button_Click;
            button_delete.Click += Button_Click;
            button_open.Click += Button_Click;


            ////设置渐变字体
            //LinearGradientBrush brush = new LinearGradientBrush();

            //GradientStop gradientStop1 = new GradientStop();
            //gradientStop1.Offset = 0;
            //gradientStop1.Color = Color.FromArgb(255, 251, 100, 17);
            //brush.GradientStops.Add(gradientStop1);

            //GradientStop gradientStop2 = new GradientStop();
            //gradientStop2.Offset = 1;
            //gradientStop2.Color = Color.FromArgb(255, 247, 238, 52);
            //brush.GradientStops.Add(gradientStop2);

            //brush.StartPoint = new Point(0.5, 0);
            //brush.EndPoint = new Point(0.5, 1);
            //Welcome.Foreground = brush;

            //System.Windows.Media.Effects.DropShadowEffect ds = new System.Windows.Media.Effects.DropShadowEffect();
            //Welcome.Effect = ds;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            switch (btn.Name)
            {
                case "button_charge":
                    button_charge.Background = new SolidColorBrush(Colors.LightBlue);
                    button_delete.Background = new SolidColorBrush(Colors.SkyBlue);
                    button_open.Background = new SolidColorBrush(Colors.SkyBlue);
                    border_charge.Visibility = Visibility.Visible;
                    border_delete.Visibility = Visibility.Hidden;
                    border_open.Visibility = Visibility.Hidden;
                    break;
                case "button_delete":
                    button_charge.Background = new SolidColorBrush(Colors.SkyBlue);
                    button_delete.Background = new SolidColorBrush(Colors.LightBlue);
                    button_open.Background = new SolidColorBrush(Colors.SkyBlue);
                    border_charge.Visibility = Visibility.Hidden;
                    border_delete.Visibility = Visibility.Visible;
                    border_open.Visibility = Visibility.Hidden;
                    break;
                case "button_open":
                    button_charge.Background = new SolidColorBrush(Colors.SkyBlue);
                    button_delete.Background = new SolidColorBrush(Colors.SkyBlue);
                    button_open.Background = new SolidColorBrush(Colors.LightBlue);
                    border_charge.Visibility = Visibility.Hidden;
                    border_delete.Visibility = Visibility.Hidden;
                    border_open.Visibility = Visibility.Visible;
                    break;
            }
        }

        #region 充值
        /// <summary>
        /// 点击确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChargeOK_Click(object sender, RoutedEventArgs e)
        {
            string phone = textbox_chargePhone.Text;
            string password = textbox_chargePassword.Text.Trim().ToLower(); ;
            string money = textbox_chargeRemainingMoney.Text;

            if (phone == "" || password == "")
            {
                MessageBox.Show("信息不完整，请重新输入");
                return;
            }
            SqlConnection conn = connectdb.ConnectDataBase();
            try
            {
                //打开数据库
                conn.Open();
                //创建查询语句
                SqlCommand querySingleInfo = conn.CreateCommand();
                querySingleInfo.CommandText = "update coustom set money=" + "'" + money + "' where phonenumber=" + "'" + phone + "' and password=" + "'" + password + "'";
                int lineNumber = querySingleInfo.ExecuteNonQuery();
                //关闭数据库连接
                conn.Close();
                MessageBox.Show("充值成功");
                textbox_chargePhone.Clear();
                textbox_chargePassword.Clear();
                textbox_chargeRemainingMoney.Clear();
                textbox_chargeNumber.Clear();
                

            }
            catch (SqlException)
            {
                MessageBox.Show("充值失败");
            }
        }
        /// <summary>
        /// 点击取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChargeCanel_Click(object sender, RoutedEventArgs e)
        {
            textbox_chargePhone.Clear();
            textbox_chargePassword.Clear();
            textbox_chargeRemainingMoney.Clear();
            textbox_chargeNumber.Clear();
        }
        /// <summary>
        /// 输入密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textbox_chargePassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textbox_chargePhone.Text.Trim() != "" || textbox_chargePassword.Text.Trim() != "")
            {
                string phone = textbox_chargePhone.Text;
                string password = textbox_chargePassword.Text.Trim().ToLower();
                //连接本地数据库
                SqlConnection conn = connectdb.ConnectDataBase();
                try
                {
                    //打开数据库
                    conn.Open();
                    //创建查询语句
                    SqlCommand querySingleInfo = conn.CreateCommand();
                    querySingleInfo.CommandText = "select money from coustom where phonenumber=" + "'" + phone + "'";
                    SqlDataReader singleInfoReader = querySingleInfo.ExecuteReader();
                    //有多行数据，用while循环
                    while (singleInfoReader.Read())
                    {
                        remainingMoney = singleInfoReader["money"].ToString().Trim();
                    }
                    textbox_chargeRemainingMoney.Text = remainingMoney.Trim();
                    //关闭查询
                    singleInfoReader.Close();
                    //关闭数据库连接
                    conn.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("查询失败");
                }
            }
            else
                MessageBox.Show("请输入手机号");
        }
        /// <summary>
        /// 输入充值金额,余额变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textbox_chargeNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            int num = 0;

            if (Int32.TryParse(textbox_chargeNumber.Text, out num))
            {
                textbox_chargeRemainingMoney.Text = (Int32.Parse(remainingMoney) + num).ToString().Trim().ToLower(); ;
            }
        }
        #endregion

        #region 开户
        /// <summary>
        /// 密码框变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_newPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            string username = textBox_newName.Text.Trim().ToLower(); ;
            string phone = textBox_newPhone.Text.Trim().ToLower(); ;
            string userID = null;
            SqlConnection conn = connectdb.ConnectDataBase();
            try
            {
                //打开数据库
                conn.Open();
                //创建查询语句
                SqlCommand querySingleInfo = conn.CreateCommand();
                querySingleInfo.CommandText = "select id from coustom where username=" + "'" + username + "' and phonenumber=" + "'" + phone + "' ";
                SqlDataReader singleInfoReader = querySingleInfo.ExecuteReader();
                //有多行数据，用while循环
                while (singleInfoReader.Read())
                {
                    userID = singleInfoReader["id"].ToString().Trim();
                }
                //关闭查询
                singleInfoReader.Close();
                //关闭数据库连接
                conn.Close();
                if (userID != null)
                {
                    MessageBox.Show("用户已注册");
                    textBox_newName.Clear();
                    textBox_newPhone.Clear();
                    textBox_newPassword.Clear();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("查找失败");
            }

        }
        /// <summary>
        /// 点击开户取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_newCancel_Click(object sender, RoutedEventArgs e)
        {
            textBox_newName.Clear();
            textBox_newPhone.Clear();
            textBox_newPassword.Clear();
            comboBox_newSex.Items.Clear();
            textBox_newEmail.Clear();
            textBox_newMoney.Clear();
            button_newOK.IsEnabled = true;
        }
        /// <summary>
        /// 点击开户确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_newOK_Click(object sender, RoutedEventArgs e)
        {
            string username = textBox_newName.Text.Trim().ToLower(); ;
            string phone = textBox_newPhone.Text;
            string password = textBox_newPassword.Text.Trim().ToLower(); ;
            string sex = comboBox_newSex.Text;
            string email = textBox_newEmail.Text.Trim().ToLower(); ;
            int money = 0;
            int _money;
            if (username == "" || phone == "" || password == "" || sex == "" || email == "")
            {
                MessageBox.Show("信息不完整，请重新输入");
                return;
            }
            if(!email.Contains('@')|| !email.Contains('.'))
            {
                textBox_newEmail.Text = "输入格式错误";
                MessageBox.Show("邮箱输入格式错误");
                //  button_newOK.IsEnabled = false;
                return;
            }
            if (Int32.TryParse(textBox_newMoney.Text, out _money))
            {
                money = _money;
            }
            else
            {
                textBox_newMoney.Text = "输入格式错误";
                MessageBox.Show("金额输入格式错误");
              //  button_newOK.IsEnabled = false;
                return;
            }
            button_newOK.IsEnabled = true;
            SqlConnection conn = connectdb.ConnectDataBase();
            try
            {
                //打开数据库
                conn.Open();
                //创建查询语句
                SqlCommand querySingleInfo = conn.CreateCommand();
                querySingleInfo.CommandText = "insert into coustom(username,sex,phonenumber,money,password,email) values('" + username + "','" + sex + "','" + phone + "','" + money + "','" + password + "','" + email + "')";
                int lineNumber = querySingleInfo.ExecuteNonQuery();
                //关闭数据库连接
                conn.Close();
                MessageBox.Show("开户成功");
                textBox_newEmail.Clear();
                textBox_newMoney.Clear();
                textBox_newName.Clear();
                textBox_newPassword.Clear();
                textBox_newPhone.Clear();
                comboBox_newSex.Text = "";
            }
            catch (SqlException)
            {
                MessageBox.Show("开户失败");
            }
        }
        #endregion

        private void textBox_deletePassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            string remainingMoney = "";
            string phone = textBox_deletePhone.Text;
            string password = textBox_deletePassword.Text.Trim().ToLower(); ;
            //连接本地数据库
            SqlConnection conn = connectdb.ConnectDataBase();
            try
            {
                //打开数据库
                conn.Open();
                //创建查询语句
                SqlCommand querySingleInfo = conn.CreateCommand();
                querySingleInfo.CommandText = "select money from coustom where phonenumber=" + "'" + phone + "'";
                SqlDataReader singleInfoReader = querySingleInfo.ExecuteReader();
                //有多行数据，用while循环
                while (singleInfoReader.Read())
                {
                    remainingMoney = singleInfoReader["money"].ToString().Trim();
                }
                textBox_deleteMoney.Text = remainingMoney;
                //关闭查询
                singleInfoReader.Close();
                //关闭数据库连接
                conn.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("查询失败");
            }
        }

        private void imageSearch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (textBox_deletePhone.Text != "")
            {
                string phone = textBox_deletePhone.Text;
                string password = textBox_deletePassword.Text.Trim().ToLower(); ;
                //连接本地数据库
                SqlConnection conn = connectdb.ConnectDataBase();
                try
                {
                    //打开数据库
                    conn.Open();
                    //创建查询语句
                    SqlCommand querySingleInfo = conn.CreateCommand();
                    querySingleInfo.CommandText = "select money from coustom where phonenumber=" + "'" + phone + "'";
                    SqlDataReader singleInfoReader = querySingleInfo.ExecuteReader();
                    //有多行数据，用while循环
                    while (singleInfoReader.Read())
                    {
                        remainingMoney = singleInfoReader["money"].ToString().Trim();
                    }
                    if (remainingMoney == "" || remainingMoney == null)
                    {
                        MessageBox.Show("用户不存在");
                    }
                    textBox_deleteMoney.Text = remainingMoney;
                    //关闭查询
                    singleInfoReader.Close();
                    //关闭数据库连接
                    conn.Close();
                }
                catch (SqlException)
                {
                    MessageBox.Show("查询失败");
                }
            }
            else { }
        }

        private void button_delete_OK_Click(object sender, RoutedEventArgs e)
        {
            string password = textBox_deletePassword.Text.Trim().ToLower(); ;
            string phone = textBox_deletePhone.Text;
            string DB_pwd = "";
            if (password == "" || phone == null)
            {
                MessageBox.Show("信息不完整，请重新输入");
                return;
            }
            //连接本地数据库
            SqlConnection conn = connectdb.ConnectDataBase();
            try
            {
                //打开数据库
                conn.Open();
                //创建查询语句
                SqlCommand querySingleInfo = conn.CreateCommand();
                querySingleInfo.CommandText = "select password from coustom where phonenumber=" + "'" + phone + "'";
                SqlDataReader singleInfoReader = querySingleInfo.ExecuteReader();
                //有多行数据，用while循环
                while (singleInfoReader.Read())
                {
                    DB_pwd = singleInfoReader["password"].ToString().Trim();
                }
                //关闭查询
                singleInfoReader.Close();

                if (DB_pwd.Equals(password))
                {
                    querySingleInfo = conn.CreateCommand();
                    querySingleInfo.CommandText = "delete from coustom where phonenumber=" + "'" + phone + "'";
                    int lineNumber = querySingleInfo.ExecuteNonQuery();
                    MessageBox.Show("销户成功");
                    textBox_deleteMoney.Clear();
                    textBox_deletePassword.Clear();
                    textBox_deletePhone.Clear();
                    conn.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("密码错误");
                    conn.Close();
                    return;
                }
                //关闭数据库连接
                //conn.Close();

            }
            catch (SqlException)
            {
                MessageBox.Show("销户失败");
            }
            conn.Close();
        }

        private void textBox_deletePhone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_delete_canel_Click(object sender, RoutedEventArgs e)
        {
            textBox_deletePassword.Clear();
            textBox_deletePhone.Clear();
            textBox_deleteMoney.Clear();
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            chooseSystem chose = new chooseSystem();
            chose.Show();
        }

        private void textBox_newMoney_TextChanged(object sender, TextChangedEventArgs e)
        {
            //int _money;
            //string money = textBox_newMoney.Text;
            //if(!Int32.TryParse(money, out _money))
            //{
            //    button_newOK.IsEnabled = false;
            //    //textBox_newMoney.Text = "格式不正确";
            //}
            //else
            //    button_newOK.IsEnabled = true;
        }
    }
}