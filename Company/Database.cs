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
        // Обмен данными с бд
        SqlDataAdapter s_Data;
        // Данные
        DataSet d_Data;

        public Database(string s_ConnectString)
        {
            this.s_ConnectString = s_ConnectString;
            s_Connection = new SqlConnection(this.s_ConnectString);
            s_Connection.Open();
            d_Data = new DataSet();
        }

        public DataSet GetSetDataset
        {
            get
            {
                return d_Data;
            }
            set
            {
                d_Data = value;
            }
        }

        // Получение данных из таблицы Department
        public void GetDepartments(string s_ParentDepartmentID)
        {
            string s_Request = RequestGetDepartments(s_ParentDepartmentID);
            s_Data = new SqlDataAdapter(s_Request, s_Connection);
            s_Data.Fill(d_Data);
            d_Data.Tables[0].TableName = "Department";
        }

        // Обновление данных в таблице Department (вставка, удаление, обновление)
        public void UpdateDepartments()
        {
            SqlCommandBuilder s_Command = new SqlCommandBuilder(s_Data);
            s_Data.Update(d_Data);
            d_Data.Clear();
            s_Data.Fill(d_Data);
        }

        // Освобождение ресурсов
        public void Dispose()
        {
            if (s_Connection != null)
            {
                s_Data.Dispose();
                d_Data.Clear();
                d_Data.Dispose();
                s_Connection.Close();
                s_Connection.Dispose();
                s_ConnectString = "";
            }
        }
    }
}
