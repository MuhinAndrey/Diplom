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
using System.Data.SqlClient;

namespace The_bank_system
{
    public partial class DepositWindow : Window
    {
        DataBase _dataBase = new DataBase();

        public DepositWindow()
        {
            InitializeComponent();
        }

        private void Reg_Deposit_Button_Click(object sender, RoutedEventArgs e)
        {
            var _id_client = Id_client.Text.Trim();
            var _sum = Sum_deposit.Text.Trim();
            var _term = Term_deposit.Text.Trim();
            var _procent = Procent_deposit.Text.Trim();
            var _id_user = Id_user.Text.Trim();

            string querystring = $"insert into Deposits (id_client, sum_deposit, duration_deposit," +
                $"procent_deposit, id_user) values ('{_id_client}', '{_sum}', '{_term}'," +
                $"'{_procent}', '{_id_user}')";

            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            _dataBase.OpenConnection();

            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Депозит успешно зарегистрирован!");
            }
            _dataBase.ClosedConnection();
        }
    }
}