
namespace Company
{
    // Запросы
    public partial class Database
    {
        // Рекурсивный запрос на получение данных из таблицы Department
        private string RequestGetDepartments(string s_ParentDepartmentID)
        {
            if (s_ParentDepartmentID.Equals(""))
            {
                return "WITH Recursive (ID, Name, Code, ParentDepartmentID) " +
                    "AS " +
                    "(" +
                    "select ID, Name, Code, ParentDepartmentID from dbo.Department e " +
                    "where e.ParentDepartmentID is NULL " +
                    "UNION ALL " +
                    "select e.ID, e.Name, e.Code, e.ParentDepartmentID from dbo.Department e " +
                    "JOIN Recursive r ON e.ParentDepartmentID = r.ID" +
                    ") " +
                    "select ID, Name, Code, ParentDepartmentID from Recursive r";
            }
            else
            {
                return "WITH Recursive (ID, Name, Code, ParentDepartmentID) " +
                    "AS " +
                    "(" +
                    "select ID, Name, Code, ParentDepartmentID from dbo.Department e " +
                    "where e.ParentDepartmentID = '"+ s_ParentDepartmentID +
                    "' UNION ALL " +
                    "select e.ID, e.Name, e.Code, e.ParentDepartmentID from dbo.Department e " +
                    "JOIN Recursive r ON e.ParentDepartmentID = r.ID" +
                    ") " +
                    "select ID, Name, Code, ParentDepartmentID from Recursive r";
            }
        }
    }
}
