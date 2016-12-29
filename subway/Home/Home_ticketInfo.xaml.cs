using subway.DAO;
using subway.Model;
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

namespace subway.Home
{
    /// <summary>
    /// Home_ticketInfo.xaml 的交互逻辑
    /// </summary>
    public partial class Home_ticketInfo : Window
    {
        BaseFunc baseF = new BaseFunc();
        //购票单价
        int money;
        public Home_ticketInfo(string destnation, int ticketNumber, int stationNumber, int fastPreMoney)
        {
            InitializeComponent();
            //快捷购票单价
            if (stationNumber == 555)
                money = fastPreMoney;
            else
                money = preMoney(stationNumber);
            textBox_destination.Text = destnation;
            comboBox_ticketNumber.Text = ticketNumber.ToString();
            textBox_Sum.Text = (ticketNumber * money).ToString();
            textBox_departure.Text = "二七广场";
            //comboBox_ticketNumber.MouseLeave += ComboBox_ticketNumber_MouseLeave;
            this.MouseMove += ComboBox_ticketNumber_MouseLeave;

        }
        /// <summary>
        /// 选择购买数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_ticketNumber_MouseLeave(object sender, MouseEventArgs e)
        {
            string ticketNumber = comboBox_ticketNumber.Text;
            // MessageBox.Show(money.ToString());
            //  int number = Int32.Parse(ticketNumber);
            textBox_Sum.Text = (money * Int32.Parse(ticketNumber)).ToString();
        }

        /// <summary>
        /// 每张票价格
        /// </summary>
        /// <param name="stationnumber"></param>
        /// <returns></returns>
        private int preMoney(int stationnumber)
        {
            if (stationnumber <= 3)
                return 1;
            else
               if (stationnumber > 3 && stationnumber <= 5)
                return 2;
            else
               if (stationnumber > 5 && stationnumber <= 10)
                return 3;
            else
               if (stationnumber > 10 && stationnumber <= 15)
                return 4;
            else
                // if (stationnumber > 15 && stationnumber <= 20)
                return 5;

        }
        /// <summary>
        /// 选择购买车票数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_newSex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ticketNumber = comboBox_ticketNumber.Text;
            // MessageBox.Show(money.ToString());
            //  int number = Int32.Parse(ticketNumber);
            textBox_Sum.Text = (money * Int32.Parse(ticketNumber)).ToString();
        }
        /// <summary>
        /// 确定付款
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_giveMoney_Click(object sender, RoutedEventArgs e)
        {
            string info;
            string username = MainWindow.username;
            Ticket ticket = new Ticket();
            ticket.endAddress = textBox_destination.Text;
            ticket.startAddress = textBox_departure.Text;
            ticket.money = Int32.Parse(textBox_Sum.Text);
            ticket.buyTime = DateTime.Now.ToString();
            ticket.username = MainWindow.username;
            ticket.ticketNum = Int32.Parse(comboBox_ticketNumber.Text);

            if(ticket.endAddress==""||comboBox_ticketNumber.Text=="")
            {
                MessageBox.Show("信息不完整，无法购票");
                return;
            }


            if (checkMoney(username, ticket.money))
            {
                 info = baseF.SaveTicketInfo(ticket);

            }
            else
            {
                info = "余额不足，请联系管理员充值";
            }
          
            //Success
            MessageBox.Show(info);
            this.Close();
        }
        //取消购票
        private void Button_cancelGiveMoney_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool checkMoney(string username, int cost)
        {
            int money = 0;
            ConnectBD connectdb = new ConnectBD();
            //连接本地数据库
            SqlConnection conn = connectdb.ConnectDataBase();
            try
            {
                //打开数据库
                conn.Open();
                //创建查询语句
                SqlCommand querySingleInfo = conn.CreateCommand();
                querySingleInfo.CommandText = "SELECT money FROM coustom where UserName=" + "'" + username + "'";
                SqlDataReader singleInfoReader = querySingleInfo.ExecuteReader();
                //有多行数据，用while循环
                while (singleInfoReader.Read())
                {
                     money =Int32.Parse( singleInfoReader["money"].ToString().Trim());
                }
                //关闭查询
                singleInfoReader.Close();
                //关闭数据库连接
                if (cost <= money)
                    return true;
                else
                    return false;

            }
            catch (SqlException e)
            {
                MessageBox.Show("购买失败");
                return false;
            }
        }
    }
}