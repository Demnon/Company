using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Company
{
    // Подключение к базе данных, обмен информацией
    public partial class Database: IDisposable
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

        // Получение данных из таблицы Department
        public DataSet GetDepartments(string s_ParentDepartmentID)
        {
            string s_Request = RequestGetDepartments(s_ParentDepartmentID);
            SqlDataAdapter s_Data = new SqlDataAdapter(s_Request, s_Connection);
            DataSet d_Data = new DataSet();
            s_Data.Fill(d_Data);

            return d_Data;
        }

        // Освобождение ресурсов
        public void Dispose()
        {
            if (s_Connection != null)
            {
                s_Connection.Close();
                s_Connection.Dispose();
                s_ConnectString = "";
            }
        }
    }
}
