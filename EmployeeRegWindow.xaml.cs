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
using System.Data;

namespace The_bank_system
{
    public partial class EmployeeRegWindow : Window
    {

        DataBase _dataBase = new DataBase();
        

        public EmployeeRegWindow()
        {
            InitializeComponent();
        }

        private void Reg_Employee_Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (CheckUser())
            {
                return;
            }

            var _surname = Surname_employee.Text.Trim();
            var _name = Name_employee.Text.Trim();
            var _patronymic = Patronymic_employee.Text.Trim();
            var _passport = Passport_employee.Text.Trim();
            var _login = Login_employee.Text.Trim();
            var _password = Password_employee.Text.Trim();

            string querystring = $"insert into Users (login_user, password_user, surname_user, name_user," +
                $" patronymic_user, passport_user, is_admin) values ('{_login}', '{_password}','{_surname}'," +
                $"'{_name}', '{_patronymic}', '{_passport}', 0)";

            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            _dataBase.OpenConnection();

            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Регистрация прошла успешно!");
            }
            else 
            {
                MessageBox.Show("Учётная запись не была создана!");
            }
            _dataBase.ClosedConnection();
        }

        private Boolean CheckUser()
        {
            var _surname = Surname_employee.Text.Trim();
            var _name = Name_employee.Text.Trim();
            var _patronymic = Patronymic_employee.Text.Trim();
            var _passport = Passport_employee.Text.Trim();
            var _login = Login_employee.Text.Trim();
            var _password = Password_employee.Text.Trim();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"select login_user, password_user, surname_user," +
                $" name_user, patronymic_user, passport_user, is_admin from Users where login_user = '{_login}'" +
                $"and password_user = '{_password}' and surname_user = '{_surname}' and  name_user = '{_name}'" +
                $"and patronymic_user = '{_patronymic}' and passport_user = '{_passport}'";

            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}