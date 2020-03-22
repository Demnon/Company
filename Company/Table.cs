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
        public static void OutputInfoInTable(DataGridView d_Table, TreeNode t_Node, Database d_Database)
        {
            // Получение информации из БД
            string[] s_Tag = t_Node.Tag.ToString().Split('|');
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
        }
    }
}
