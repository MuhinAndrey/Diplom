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
{//Окно регистрации клиента
    public partial class RegistrationWindow : Window
    {
        //Подключение к БД
        DataBase _dataBase = new DataBase();

        public RegistrationWindow()
        {
            InitializeComponent();
        }
        //Кнопка "Зарегистрировать"
        private void Registration_Button_Click(object sender, RoutedEventArgs e)
        {
            //Объявление метода, проверяющего существование клиента
            if (CheckClient())
            {
                return;
            }
            //Записывание данных из полей в переменные
            var _surname = Surname_client.Text.Trim();
            var _name = Name_client.Text.Trim();
            var _patronymic = Patronymic_client.Text.Trim();
            var _passport = Passport_client.Text.Trim();
            var _phone = Phone_client.Text.Trim();
            var _adres = Adres_client.Text.Trim();

            //Проверка заполненности полей ввода
            if (_surname == "")
                Surname_client.ToolTip = "Поле не заполнено!";
            else if (_name == "")
                Name_client.ToolTip = "Поле не заполнено!";
            else if (_patronymic == "")
                Patronymic_client.ToolTip = "Поле не заполнено!";
            else if (_passport == "")
                Passport_client.ToolTip = "Поле не заполнено!";
            else if (_phone == "")
                Phone_client.ToolTip = "Поле не заполнено!";
            else if (_adres == "")
                Adres_client.ToolTip = "Поле не заполнено!";
            else
            {
                Surname_client.ToolTip = "";
                Name_client.ToolTip = "";
                Patronymic_client.ToolTip = "";
                Passport_client.ToolTip = "";
                Phone_client.ToolTip = "";
                Adres_client.ToolTip = "";
            }

            //SQL запрос, записывающий в БД данные, введённые пользователем
            string querystring = $"insert into Clients (surname_client, name_client, patronymic_client," +
                $"passport_client, phone_client, address_client) values ('{_surname}', '{_name}', '{_patronymic}'," +
                $"'{_passport}', '{_phone}', '{_adres}')";

            //Экземпляр класса SqlCommand, принимающий в себя SQL запрос и строку подключения к БД
            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            //Использование метода, открывающего связь с БД
            _dataBase.OpenConnection();

            //Проверка результата SQL запроса
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                //Если в результате только одно поле
                MessageBox.Show("Клиент успешно зарегистрирован!");
            }
            else
            {
                MessageBox.Show("Клиент не зарегистрирован!");
            }
            //Использование метода, закрывающего связь с БД
            _dataBase.ClosedConnection();
        }
        //Метод, проверяющий, существует ли клиент
        private Boolean CheckClient()
        {
            var _surname = Surname_client.Text.Trim();
            var _name = Name_client.Text.Trim();
            var _patronymic = Patronymic_client.Text.Trim();
            var _passport = Passport_client.Text.Trim();
            var _phone = Phone_client.Text.Trim();
            var _adres = Adres_client.Text.Trim();

            //Два объека для работы с БД
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            //SQL запрос, проверяющий, существует ли клиент
            string querystring = $"select surname_client, name_client, patronymic_client, passport_client," +
                $"phone_client, address_client from Clients where surname_client = '{_surname}' " +
                $"and name_client = '{_name}' and  patronymic_client = '{_patronymic}'" +
                $"and passport_client = '{_passport}' and phone_client = '{_phone}' and address_client = '{_adres}' ";

            //Экземпляр класса SqlCommand, принимающий в себя SQL запрос и строку подключения к БД
            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            //Работа с адаптером
            adapter.SelectCommand = sqlCommand;
            //Занесение данных SQL запроса в таблицу
            adapter.Fill(dataTable);

            //Проверка результата SQL запроса
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
        //Кнопка "Назад"
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
