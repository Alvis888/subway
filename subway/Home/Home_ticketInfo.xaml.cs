using subway.DAO;
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
        public Home_ticketInfo(string destnation,int ticketNumber,int stationNumber,int fastPreMoney)
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
                textBox_departure.Text = "郑州东站";
            //comboBox_ticketNumber.MouseLeave += ComboBox_ticketNumber_MouseLeave;
            this.MouseMove+= ComboBox_ticketNumber_MouseLeave;

        }

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
            textBox_Sum.Text= (money*Int32.Parse( ticketNumber)).ToString();
        }

        private void Button_giveMoney_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = new Ticket();
            ticket.endAddress = textBox_destination.Text;
            ticket.startAddress = textBox_departure.Text;
            ticket.money = Int32.Parse(textBox_Sum.Text);
            ticket.buyTime = DateTime.Now.ToString();
            ticket.username = MainWindow.username;
            string info= baseF.SaveTicketInfo(ticket);
            ticket.ticketNum =Int32.Parse( comboBox_ticketNumber.Text);
            //Success
            MessageBox.Show(info);
        }

        private void Button_cancelGiveMoney_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
