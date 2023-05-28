using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace The_bank_system
{
    internal class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=GrEI3uI3JI9I;Initial Catalog=Bank;Integrated Security=True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open) 
            {
                sqlConnection.Open();
            }
        }

        public void closedConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getSqlConnection() 
        {
            return sqlConnection;
        }

    }
}
