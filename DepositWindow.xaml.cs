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
{//Окно регистрации депозитов
    public partial class DepositWindow : Window
    {
        //Подключение к БД
        DataBase _dataBase = new DataBase();

        public DepositWindow()
        {
            InitializeComponent();
        }

        private void Reg_Deposit_Button_Click(object sender, RoutedEventArgs e)
        {
            //Записывание данных из полей в переменные
            var _id_client = Id_client.Text.Trim();
            var _sum = Sum_deposit.Text.Trim();
            var _term = Term_deposit.Text.Trim();
            var _procent = Procent_deposit.Text.Trim();
            var _id_user = Id_user.Text.Trim();

            //Проверка заполненности полей ввода
            if (_id_client == "")
                Id_client.ToolTip = "Поле не заполнено!";
            else if (_sum == "")
                Sum_deposit.ToolTip = "Поле не заполнено!";
            else if (_term == "")
                Term_deposit.ToolTip = "Поле не заполнено!";
            else if (_procent == "")
                Procent_deposit.ToolTip = "Поле не заполнено!";
            else if (_id_user == "")
                Id_user.ToolTip = "Поле не заполнено!";
            else
            {
                Id_client.ToolTip = "";
                Sum_deposit.ToolTip = "";
                Term_deposit.ToolTip = "";
                Procent_deposit.ToolTip = "";
                Id_user.ToolTip = "";
            }

            //SQL запрос, записывающий в БД данные, введённые пользователем
            string querystring = $"insert into Deposits (id_client, sum_deposit, duration_deposit," +
                $"procent_deposit, id_user) values ('{_id_client}', '{_sum}', '{_term}'," +
                $"'{_procent}', '{_id_user}')";

            //Экземпляр класса SqlCommand, принимающий в себя SQL запрос и строку подключения к БД
            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            //Использование метода, открывающего связь с БД
            _dataBase.OpenConnection();

            //Проверка результата SQL запроса
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Депозит успешно зарегистрирован!");
            }
            //Использование метода, закрывающего связь с БД
            _dataBase.ClosedConnection();
        }
        //Кнопка "Назад"
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}