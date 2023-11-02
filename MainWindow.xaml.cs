using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=" +
                "(PROTOCOL=TCP)(HOST=fei-sql3.upceucebny.cz)(PORT=1521)))(CONNECT_DATA = " +
                "(SERVER = DEDICATED)(SERVICE_NAME = BDAS)));" +
                " User Id = ST67052 ;Password = sLTE620SOEx; ";

            // string oradb = "Data Source=ORCL;User Id=st67034;Password=abcde;";
            OracleConnection conn = new OracleConnection(connectionString);  // C#
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select name from counttest where id = 100";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            lbl_info.Content = dr.GetString(0);
            conn.Dispose();
        }

    }
}
