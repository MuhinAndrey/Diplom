using System;
using System.Windows;
using System.Data.SqlClient;
using System.Data;

namespace The_bank_system
{//Окно регистрации сотрудника
    public partial class EmployeeRegWindow : Window
    {
        //Подключение к БД
        DataBase _dataBase = new DataBase();
        
        public EmployeeRegWindow()
        {
            InitializeComponent();
        }
        //Кнопка "Зарегистрировать"
        private void Reg_Employee_Button_Click(object sender, RoutedEventArgs e)
        {
            //Объявление метода, проверяющего существование клиента
            if (CheckUser())
            {
                return;
            }

            //Записывание данных из полей в переменные
            var _surname = Surname_employee.Text.Trim();
            var _name = Name_employee.Text.Trim();
            var _patronymic = Patronymic_employee.Text.Trim();
            var _passport = Passport_employee.Text.Trim();
            var _login = Login_employee.Text.Trim();
            var _password = Password_employee.Text.Trim();
            var _role = Role_employee.Text.ToLower().Trim();
            var _checkRole = 0;

            //Проверка заполненности полей ввода
            if (_surname == "")
                Surname_employee.ToolTip = "Поле не заполнено!";
            else if (_name == "")
                Name_employee.ToolTip = "Поле не заполнено!";
            else if (_patronymic == "")
                Patronymic_employee.ToolTip = "Поле не заполнено!";
            else if (_passport == "")
                Passport_employee.ToolTip = "Поле не заполнено!";
            else if (_login == "")
                Login_employee.ToolTip = "Поле не заполнено!";
            else if (_password == "")
                Password_employee.ToolTip = "Поле не заполнено!";
            else if (_role == "")
                Role_employee.ToolTip = "Поле не заполнено!";
            else
            {
                Surname_employee.ToolTip = "";
                Name_employee.ToolTip = "";
                Patronymic_employee.ToolTip = "";
                Passport_employee.ToolTip = "";
                Login_employee.ToolTip = "";
                Password_employee.ToolTip = "";
                Role_employee.ToolTip = "";
            }

            //Проверка ввода роли
            if (_role == "администратор")
            {
                _checkRole = 1;
            }
            else if(_role == "пользователь")
            {
                _checkRole = 0;
            }
            else
            {
                MessageBox.Show("Такой роли нет!");
            }

            //SQL запрос, записывающий в БД данные, введённые пользователем
            string querystring = $"insert into Users (login_user, password_user, surname_user, name_user," +
                $" patronymic_user, passport_user, is_admin) values ('{_login}', '{_password}','{_surname}'," +
                $"'{_name}', '{_patronymic}', '{_passport}', '{_checkRole}')";

            //Экземпляр класса SqlCommand, принимающий в себя SQL запрос и строку подключения к БД
            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            //Использование метода, открывающего связь с БД
            _dataBase.OpenConnection();

            //Проверка результата SQL запроса
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                //Если в результате только одно поле
                MessageBox.Show("Регистрация прошла успешно!");
            }
            else 
            {
                MessageBox.Show("Учётная запись не была создана!");
            }
            //Использование метода, закрывающего связь с БД
            _dataBase.ClosedConnection();

        }
        //Метод, проверяющий, существует ли пользователь
        private Boolean CheckUser()
        {
            var _surname = Surname_employee.Text.Trim();
            var _name = Name_employee.Text.Trim();
            var _patronymic = Patronymic_employee.Text.Trim();
            var _passport = Passport_employee.Text.Trim();
            var _login = Login_employee.Text.Trim();
            var _password = Password_employee.Text.Trim();

            //Два объека для работы с БД
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            //SQL запрос, проверяющий, существует ли пользователь
            string querystring = $"select login_user, password_user, surname_user," +
                $" name_user, patronymic_user, passport_user, is_admin from Users where login_user = '{_login}'" +
                $"and password_user = '{_password}' and surname_user = '{_surname}' and  name_user = '{_name}'" +
                $"and patronymic_user = '{_patronymic}' and passport_user = '{_passport}'";

            //Экземпляр класса SqlCommand, принимающий в себя SQL запрос и строку подключения к БД
            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            //Работа с адаптером
            adapter.SelectCommand = sqlCommand;
            //Занесение данных SQL запроса в таблицу
            adapter.Fill(dataTable);

            //Проверка результата SQL запроса
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
        //Кнопка "Назад"
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}