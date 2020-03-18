using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Company
{
    // Работа с деревом
    class StructureTree
    {
        // Корневой узел - Предприятия
        TreeNode t_RootNode;
        // Работа с БД
        Database d_Database;

        public StructureTree(Database d_Database)
        {
            this.d_Database = d_Database;
            // Создание корневого узла
            t_RootNode = new TreeNode("Companies");
            t_RootNode.NodeFont = new Font("Times New Roman", 12, FontStyle.Bold);
            t_RootNode.Name = "Companies";
            // Контекстное меню узла (для реализации кнопок добавить, удалить)
            t_RootNode.ContextMenuStrip = new ContextMenuStrip();
            t_RootNode.ContextMenuStrip.Items.Add("Add company(es)");
            t_RootNode.ContextMenuStrip.Items[t_RootNode.ContextMenuStrip.Items.Count - 1].Visible = false;
            t_RootNode.ContextMenuStrip.Items.Add("Delete selected companies");
            t_RootNode.ContextMenuStrip.Items[t_RootNode.ContextMenuStrip.Items.Count - 1].Visible = false;
        }

        public TreeNode GetStructureTree
        {
            get
            {
                return t_RootNode;
            }
        }

        // Построение дерева
        public void BuildTree()
        {
            // Получение корневых узлов - компаний
            d_Database.GetDepartments("");
            foreach (DataRow d_Row in d_Database.GetSetDataset.Tables[0].Rows)
            {
                foreach (object o_Cell in d_Row.ItemArray)
                {

                }
            }
        }

    }
}
