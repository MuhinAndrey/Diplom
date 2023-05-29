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
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.Data;

namespace The_bank_system
{
    public partial class RegistrationWindow : Window
    {
        DataBase _dataBase = new DataBase();

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckClient())
            {
                return;
            }

            var _surname = Surname_client.Text.Trim();
            var _name = Name_client.Text.Trim();
            var _patronymic = Patronymic_client.Text.Trim();
            var _passport = Passport_client.Text.Trim();
            var _phone = Phone_client.Text.Trim();
            var _adres = Adres_client.Text.Trim();

            string querystring = $"insert into Clients (surname_client, name_client, patronymic_client," +
                $"passport_client, phone_client, address_client) values ('{_surname}', '{_name}', '{_patronymic}'," +
                $"'{_passport}', '{_phone}', '{_adres}')";

            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            _dataBase.OpenConnection();

            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Клиент успешно зарегистрирован!");
            }
            else
            {
                MessageBox.Show("Клиент не зарегистрирован!");
            }
            _dataBase.ClosedConnection();
        }

        private Boolean CheckClient()
        {
            var _surname = Surname_client.Text.Trim();
            var _name = Name_client.Text.Trim();
            var _patronymic = Patronymic_client.Text.Trim();
            var _passport = Passport_client.Text.Trim();
            var _phone = Phone_client.Text.Trim();
            var _adres = Adres_client.Text.Trim();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"select surname_client, name_client, patronymic_client, passport_client," +
                $"phone_client, address_client from Clients where surname_client = '{_surname}' " +
                $"and name_client = '{_name}' and  patronymic_client = '{_patronymic}'" +
                $"and passport_client = '{_passport}' and phone_client = '{_phone}' and address_client = '{_adres}' ";

            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("Клиент уже существует!");
                return true;
            }
            else
            {
                return false;
            }

        }


        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
