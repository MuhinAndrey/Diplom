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
{//Окно авторизации
    public partial class MainWindow : Window
    {   //Подключение к БД
        DataBase _dataBase = new DataBase();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {   //Принимаем логин и пароль из полей
            var _login = inputLogin.Text.Trim();
            var _password = inputPassword.Password.Trim();

            //Проверка заполненности полей ввода
            if(_login == "")
                inputLogin.ToolTip = "Поле не заполнено!";
            else if(_password == "")
                inputPassword.ToolTip = "Поле не заполнено!";
            else
            {
                inputLogin.ToolTip = "";
                inputPassword.ToolTip = "";
            }

            //Два объека для работы с БД
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            //SQL запрос, проверяющий, существует ли пользователь
            string querystring = $"select id_user, login_user, password_user, is_admin from Users" +
                $" where login_user = '{_login}' and password_user = '{_password}'";

            //Экземпляр класса SqlCommand, принимающий в себя SQL запрос и строку подключения к БД
            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            //Работа с адаптером
            adapter.SelectCommand = sqlCommand;
            //Занесение данных SQL запроса в таблицу
            adapter.Fill(dataTable);

            //Проверка результата SQL запроса
            if (dataTable.Rows.Count == 1)
            {
                //Проверка роли пользователя
                var _userStatus = Convert.ToBoolean(dataTable.Rows[0].ItemArray[3]);

                if (_userStatus)
                {
                    //Открытие окна для администратора
                    MessageBox.Show("Вы успешно вошли, как администратор!");
                    AdminOfficeWindow adminOfficeWindow = new AdminOfficeWindow();
                    adminOfficeWindow.Show();
                    Close();
                }
                else
                {
                    //Открытие окна для пользователя
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