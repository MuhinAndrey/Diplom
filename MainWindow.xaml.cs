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
using System.Data.SqlClient;
using System.Data;

namespace The_bank_system
{
    public partial class MainWindow : Window
    {
        DataBase _dataBase = new DataBase();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            var _login = inputLogin.Text.Trim();
            var _password = inputPassword.Password.Trim();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"select id_user, login_user, password_user, is_admin from Users" +
                $" where login_user = '{_login}' and password_user = '{_password}'";

            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                var _userStatus = Convert.ToBoolean(dataTable.Rows[0].ItemArray[3]);

                if (_userStatus)
                {
                    MessageBox.Show("Вы успешно вошли, как администратор!");
                    AdminOfficeWindow adminOfficeWindow = new AdminOfficeWindow();
                    adminOfficeWindow.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Вы успешно вошли!");
                    OfficeWindow officeWindow = new OfficeWindow();
                    officeWindow.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Такой учётной записи не существует!");
            }
        }
    }
}