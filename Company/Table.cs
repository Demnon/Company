using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                DataGridViewColumn d_Column = new DataGridViewColumn(d_Table.Columns[0].HeaderCell);
                d_Table.Columns.Add("SDfd","Dfd");
                d_Table.Columns[d_Table.Columns.Count-1].DisplayIndex = 5;
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
                        throw new ApplicationException("Столбец с именем '" + d_Column.ColumnName + "' не должен иметь пустые значения!");
                    }
                    break;
                }
            }
        }
    }
}
