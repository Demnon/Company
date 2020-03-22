using System.Collections.Generic;
using System;

namespace Company
{
    // Запросы и прочие необходимые данные
    public partial class Database
    {
        // Значения по умолчанию для таблицы Department
        public static readonly Dictionary<string,string[]> d_DefaultValuesDepartments = new Dictionary<string, string[]>()
        {
            {"Companies", new string[]{"Отдел","O"} },
            {"Departments", new string[]{"Отдел","O"} },
            { "Employees", new string[]{"Имя","Фамилия","Отчество", "2000-01-01 00:00:00.000","0000","111111","Должность" } }
        };

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
