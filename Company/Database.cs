using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Company
{
    // Подключение к базе данных, обмен информацией
    class Database: IDisposable
    {
        // Строка подключения 
        string s_ConnectString;
        // Подключение
        SqlConnection s_Connection;

        public Database(string s_ConnectString)
        {
            this.s_ConnectString = s_ConnectString;
            s_Connection = new SqlConnection(this.s_ConnectString);
            s_Connection.Open();   
        }

        // Освобождение ресурсов
        public void Dispose()
        {
            if (s_Connection != null)
            {
                s_Connection.Dispose();
            }
        }
    }
}
