using System.Collections.Generic;
using System;

namespace Company
{
    // Запросы и прочие необходимые данные
    public partial class Database
    {
        // Значения null или not null для столбов таблиц
        public static readonly Dictionary<string, bool[]> d_AllowDBNull = new Dictionary<string, bool[]>()
        {
            {"department", new bool[]{false,false,true,true} },
            { "employee", new bool[]{false,false,false,true,false,true,true,false,false} }
        };

        // Значения по умолчанию для таблиц (s_Parameter - id родительского узла)
        public static string[] DefaultValues(string s_Name,string s_Parameter)
        {
            if (s_Parameter.Equals(""))
            {
                return new Dictionary<string, string[]>()
                {
                {"companies", new string[]{Guid.NewGuid().ToString(),"Отдел","O",null} },
                {"departments", new string[]{ Guid.NewGuid().ToString(),"Отдел","O",null} },
                { "employees", new string[]{"0","Имя","Фамилия","Отчество", "2000-01-01","0000","111111","Должность",s_Parameter} }
                }[s_Name];
            }
            else
            {
                return new Dictionary<string, string[]>()
                {
                {"companies", new string[]{Guid.NewGuid().ToString(),"Отдел","O",s_Parameter} },
                {"departments", new string[]{ Guid.NewGuid().ToString(),"Отдел","O",s_Parameter} },
                { "employees", new string[]{"0","Имя","Фамилия","Отчество", "2000-01-01","0000","111111","Должность",s_Parameter} }
                }[s_Name];
            }
        }

        // Рекурсивный запрос на получение всех данных из таблицы Department
        private string RecursiveRequestGetDepartments()
        {
            return "WITH Recursive (ID, Name, Code, ParentDepartmentID) " +
                "AS " +
                "(" +
                "select ID, Name, Code, ParentDepartmentID from Department e " +
                "where e.ParentDepartmentID is NULL " +
                "UNION ALL " +
                "select e.ID, e.Name, e.Code, e.ParentDepartmentID from Department e " +
                "JOIN Recursive r ON e.ParentDepartmentID = r.ID" +
                ") " +
                "select * from Recursive r";
        }

        //Запрос на получение данных из таблицы Department
        private string RequestGetDepartments(string s_ParentDepartmentID)
        {
            if (s_ParentDepartmentID.Equals(""))
            {
                return "Select * from Department where ParentDepartmentID is NULL";
            }
            else
            {
                return "Select * from Department where ParentDepartmentID ='"+s_ParentDepartmentID+"'";
            }
        }

        // Запрос на получение данных конкретного отдела из таблицы Department
        private string RequestGetDepartment(string s_ID)
        {
            return "Select * from Department where ID = '" + s_ID + "'";
        }

        // Запрос на получение данных из таблицы Employee
        private string RequestGetEmployees(string s_DepartmentID)
        {
            return "Select * from Empoyee where DepartmentID = '" + s_DepartmentID + "'";
        }

        // Запрос на получение данных конкретного сотрудника из таблицы Employee
        private string RequestGetEmployee(string s_ID)
        {
            return "Select * from Empoyee where ID = '" + s_ID + "'";
        }
    }
}
