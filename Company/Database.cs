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
        // Имя таблицы SQL, из которой получены данные
        string s_NameTable;
        // Словарь для вызова соответствующих методов данного класса (замена if else при выводе в таблицу, заполняется в дереве, 
        // так как зависит от надписей в дереве)
        readonly Dictionary<string, Action<string>> d_NameMethods;

        public Database(string s_ConnectString)
        {
            this.s_ConnectString = s_ConnectString;
            s_Connection = new SqlConnection(this.s_ConnectString);
            s_Connection.Open();
            d_Data = new DataSet();
            s_NameTable = "";

            // Инициализация словаря
            d_NameMethods = new Dictionary<string, Action<string>>();
            d_NameMethods.Add("0|companies", GetDepartments);
            d_NameMethods.Add("0|departments", GetDepartments);
            d_NameMethods.Add("0|recursivedepartments", GetRecursiveDepartments);
            d_NameMethods.Add("0|employees", GetEmployees);
            d_NameMethods.Add("0|department", GetDepartment);
            d_NameMethods.Add("0|employee", GetEmployee);
            d_NameMethods.Add("1|update", UpdateInfo);
        }

        public DataSet GetSetDataset
        {
            get{ return d_Data; }
            set{ d_Data = value; }
        }

        public string GetSetNameTable
        {
            get { return s_NameTable; }
            set { s_NameTable = value; }
        }

        // Вызов необходимого метода обмена информацией с БД в соответствии с входной строкой
        // Строка: 0 - получение либо 1 - обновление|Ключевое слово
        // Передаваемый параметр в метод
        public void CallMethod(string s_InputString, string s_Parameter)
        {
            // Вызов нужного метода работы с БД
            d_NameMethods[s_InputString](s_Parameter);
        }

        // Получение данных из таблицы Department
        private void GetDepartments(string s_ParentDepartmentID)
        {
            string s_Request = RequestGetDepartments(s_ParentDepartmentID);
            s_Data = new SqlDataAdapter(s_Request, s_Connection);
            d_Data.Tables.Clear();
            s_Data.Fill(d_Data);
            s_NameTable = "department";
        }

        // Получение всех данных из таблицы Department с помощью рекурсивного запроса
        private void GetRecursiveDepartments(string s_Sender)
        {
            string s_Request = RecursiveRequestGetDepartments();
            s_Data = new SqlDataAdapter(s_Request, s_Connection);
            d_Data.Tables.Clear();
            s_Data.Fill(d_Data);
            s_NameTable = "department";
        }

        // Получение данных для конкретного отдела
        private void GetDepartment(string s_ID)
        {
            string s_Request = RequestGetDepartment(s_ID);
            s_Data = new SqlDataAdapter(s_Request, s_Connection);
            d_Data.Tables.Clear();
            s_Data.Fill(d_Data);
            s_NameTable = "department";
        }

        // Получение данных из таблицы Employee
        private void GetEmployees(string s_DepartmentID)
        {
            string s_Request = RequestGetEmployees(s_DepartmentID);
            s_Data = new SqlDataAdapter(s_Request, s_Connection);
            d_Data.Tables.Clear();
            s_Data.Fill(d_Data);
            s_NameTable = "employee";
        }

        // Получение данных для конкретного сотрудника
        private void GetEmployee(string s_ID)
        {
            string s_Request = RequestGetEmployee(s_ID);
            s_Data = new SqlDataAdapter(s_Request, s_Connection);
            d_Data.Tables.Clear();
            s_Data.Fill(d_Data);
            s_NameTable = "employee";
        }

        // Обновление данных в любой таблице (вставка, удаление, обновление)
        private void UpdateInfo(string s_Sender)
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
                s_NameTable = "";
            }
        }
    }
}
