using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace The_bank_system
{// Класс для подключения к БД
    public class DataBase
    {
        //Строка подключения к БД
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=GrEI3uI3JI9I;Initial Catalog=Bank;Integrated Security=True");
        //Метод, открывающий связь с БД
        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed) 
            {
                sqlConnection.Open();
            }
        }
        //Метод, закрывающий связь с БД
        public void ClosedConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        //Метод, возвращающий строку подключения
        public SqlConnection GetSqlConnection() 
        {
            return sqlConnection;
        }

    }
}
