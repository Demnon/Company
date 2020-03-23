using System;
using System.Windows.Forms;
using System.Data;

namespace Company
{
    // Работа с таблицей
    public static class Table
    {
        // Вывод данных в таблицу
        public static void OutputInfoInTable(DataGridView d_Table, string[] s_Tag, Database d_Database)
        {
            // Получение информации из БД
            d_Database.CallMethod("0|" + s_Tag[1], s_Tag[2]);
            d_Table.DataSource = d_Database.GetSetDataset.Tables[0];

            // Заблокировать столбцы, содержащие id, а также отключение сортировки для столбцов
            for (int i=0;i<d_Table.Columns.Count;i++)
            {
                if (d_Table.Columns[i].HeaderText.ToUpper().Contains("ID"))
                {
                    d_Table.Columns[i].ReadOnly = true;
                }
                d_Table.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Добавить столбец с возрастом для таблицы Employees
            if (s_Tag[0].Equals("employee"))
            {
                // Если столбца нет, создаем его
                if (!d_Table.Columns.Contains("c_Age"))
                {
                    DataGridViewColumn d_Column = new DataGridViewColumn(d_Table.Columns[0].HeaderCell);           
                    d_Table.Columns.Add("c_Age", "Age");

                    d_Table.Columns[d_Table.Columns.Count - 1].ReadOnly = true;
                    d_Table.Columns[d_Table.Columns.Count - 1].DisplayIndex = d_Table.Columns["DateOfBirth"].DisplayIndex + 1;
                }
                // Получение возраста для каждой записи
                for (int i = 0; i < d_Table.Rows.Count; i++)
                {
                    DateTime d_Date = (DateTime)d_Table["DateOfBirth", i].Value;
                    d_Table["c_Age", i].Value = (new DateTime() + DateTime.Today.Subtract(d_Date)).Year;
                }
            }
            // Если другая и таблица, и столбец есть, то удаляем его
            else
            {
                if (d_Table.Columns.Contains("c_Age"))
                {
                    d_Table.Columns.Remove("c_Age");
                }
            }
        }

        // Проверка корректности ввода
        public static void CheckData(DataGridView d_Table, Database d_Database, object o_CellValue)
        {
            // Находим в Dataset соответствующий ячейке столбец, и проверяем значение ячейки на соответствие свойствам столбца
            foreach (DataColumn d_Column in d_Database.GetSetDataset.Tables[0].Columns)
            {
                if (d_Table.Columns[d_Table.CurrentCell.ColumnIndex].Name.Equals(d_Column.ColumnName))
                {
                    // Если столбец not null, а введено пустое значение
                    if (!Database.d_AllowDBNull[d_Database.GetSetNameTable][d_Table.CurrentCell.ColumnIndex] &&
                        o_CellValue.ToString().Equals(""))
                    {
                        throw new ApplicationException("The column with the name '" + d_Column.ColumnName + "' must not have empty values!");
                    }
                    break;
                }
            }
        }
    }
}
