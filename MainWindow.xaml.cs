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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBase _dataBase = new DataBase();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string _login = inputLogin.Text.Trim();
            string _password = inputPassword.Password.Trim();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string querystring = $"select id_user, login_user, password_user from Users where login_user = '{_login}' and password_user = '{_password}'";

            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.getSqlConnection());
            adapter.SelectCommand = sqlCommand;
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!");
                OfficeWindow officeWindow = new OfficeWindow();
                officeWindow.Show();
                Close();
            }

        }
    }
}