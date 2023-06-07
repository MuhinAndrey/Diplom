using System.Windows;
using System.Data.SqlClient;

namespace The_bank_system
{//Окно регистрации кредитов
    public partial class CreditWindow : Window
    {
        //Подключение к БД
        DataBase _dataBase = new DataBase();

        public CreditWindow()
        {
            InitializeComponent();
        }

        private void Reg_Credit_Button_Click(object sender, RoutedEventArgs e)
        {
            //Записывание данных из полей в переменные
            var _id_client = Id_client.Text.Trim();
            var _sum = Sum_credit.Text.Trim();
            var _term = Term_credit.Text.Trim();
            var _procent = Procent_credit.Text.Trim();
            var _id_user = Id_user.Text.Trim();

            //Проверка заполненности полей ввода
            if (_id_client == "")
                Id_client.ToolTip = "Поле не заполнено!";
            else if(_sum == "")
                Sum_credit.ToolTip = "Поле не заполнено!";
            else if (_term == "")
                Term_credit.ToolTip = "Поле не заполнено!";
            else if (_procent == "")
                Procent_credit.ToolTip = "Поле не заполнено!";
            else if (_id_user == "")
                Id_user.ToolTip = "Поле не заполнено!";
            else
            {
                Id_client.ToolTip = "";
                Sum_credit.ToolTip = "";
                Term_credit.ToolTip = "";
                Procent_credit.ToolTip = "";
                Id_user.ToolTip = "";
            }

            //SQL запрос, записывающий в БД данные, введённые пользователем
            string querystring = $"insert into Credits (id_client, sum_credit, duration_credit," +
                $"procent_credit, id_user) values ('{_id_client}', '{_sum}', '{_term}'," +
                $"'{_procent}', '{_id_user}')";

            //Экземпляр класса SqlCommand, принимающий в себя SQL запрос и строку подключения к БД
            SqlCommand sqlCommand = new SqlCommand(querystring, _dataBase.GetSqlConnection());

            //Использование метода, открывающего связь с БД
            _dataBase.OpenConnection();

            //Проверка результата SQL запроса
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Кредит успешно зарегистрирован!");
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
