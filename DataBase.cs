using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace The_bank_system
{
    public class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=GrEI3uI3JI9I;Initial Catalog=Bank;Integrated Security=True");

        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed) 
            {
                sqlConnection.Open();
            }
        }

        public void ClosedConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetSqlConnection() 
        {
            return sqlConnection;
        }

    }
}
