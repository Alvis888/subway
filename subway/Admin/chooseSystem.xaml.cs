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
using subway.Admin;
using MainChoose;


namespace subway.Admin
{
    /// <summary>
    /// chooseSystem.xaml 的交互逻辑
    /// </summary>
    public partial class chooseSystem : Window
    {
        public chooseSystem()
        {
            InitializeComponent();
        }

        private void button_Ticket_Click(object sender, RoutedEventArgs e)
        {
            admin_main chose = new admin_main();
            chose.ShowDialog();
            this.Close();
        }

        private void button_Charge_Click(object sender, RoutedEventArgs e)
        {
            Admin_deleteUser choose = new Admin_deleteUser();
            choose.ShowDialog();
            this.Close();
        }
    }
}
