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
    /// Home_fasttickets.xaml 的交互逻辑
    /// </summary>
    public partial class Home_fasttickets : Window
    {
        string destnation="anyone";
        int ticketNumber = 1;
        int stationNumber = 555;

        public Home_fasttickets()
        {
            InitializeComponent();
            button_1RMB.Click += Button_RMB_Click;
            button_2RMB.Click += Button_RMB_Click;
            button_3RMB.Click += Button_RMB_Click;
            button_4RMB.Click += Button_RMB_Click;
            button_5RMB.Click += Button_RMB_Click;
            button_6RMB.Click += Button_RMB_Click;
        }

        private void Button_RMB_Click(object sender, RoutedEventArgs e)
        {
            Home_ticketInfo ticketInfo;
           
            Button btn = sender as Button;
            switch(btn.Content.ToString())
            {
                case "1元":
                    ticketInfo = new Home_ticketInfo( destnation, ticketNumber,  stationNumber ,1);
                    ticketInfo.Show();
                    break;
                case "2元":
                    ticketInfo = new Home_ticketInfo(destnation, ticketNumber, stationNumber, 2);
                    ticketInfo.Show();
                    break;
                case "3元":
                    ticketInfo = new Home_ticketInfo(destnation, ticketNumber, stationNumber, 3);
                    ticketInfo.Show();
                    break;
                case "4元":
                    ticketInfo = new Home_ticketInfo(destnation, ticketNumber, stationNumber, 4);
                    ticketInfo.Show();
                    break;
                case "5元":
                    ticketInfo = new Home_ticketInfo(destnation, ticketNumber, stationNumber, 5);
                    ticketInfo.Show();
                    break;
                case "6元":
                    ticketInfo = new Home_ticketInfo(destnation, ticketNumber, stationNumber, 6);
                    ticketInfo.Show();
                    break;
            }

        }
    }
}
