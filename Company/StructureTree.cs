using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Company
{
    // Работа с деревом
    public static class StructureTree
    {
        // Построение дерева. Состав Tag для узлов: Имя таблицы|Ключевое слово|Передаваемый параметр
        public static TreeNode BuildTree(Database d_Database)
        {
            // Создание корневого узла
            TreeNode t_RootNode = new TreeNode("Companies");
            t_RootNode.NodeFont = new Font("Times New Roman", 12, FontStyle.Bold);
            t_RootNode.Name = "companies";
            t_RootNode.Tag = "department|companies|";

            // Контекстное меню узла (для реализации кнопок добавить, удалить)
            t_RootNode.ContextMenuStrip = new ContextMenuStrip();
            t_RootNode.ContextMenuStrip.Items.Add("Add companies");
            t_RootNode.ContextMenuStrip.Items[t_RootNode.ContextMenuStrip.Items.Count - 1].Visible = false;
            t_RootNode.ContextMenuStrip.Items.Add("Delete selected companies");
            t_RootNode.ContextMenuStrip.Items[t_RootNode.ContextMenuStrip.Items.Count - 1].Visible = false;
            // Построение дерева, начиная с departments, внутри которого достраивается employees
            BuildTreeDepartments(t_RootNode, d_Database);

            return t_RootNode;
        }

        // Часть дерева Departments
        private static void BuildTreeDepartments(TreeNode t_RootNode, Database d_Database)
        {
            // Получение всех узлов Departments, начиная с корневых узлов - компаний
            d_Database.CallMethod("0|recursivedepartments", "");
            DataSet d_Data = d_Database.GetSetDataset.Copy();
            string s_NameTable = d_Database.GetSetNameTable;

            foreach (DataRow d_Row in d_Data.Tables[0].Rows)
            {
                // Если фирма
                if (d_Row["ParentDepartmentID"].ToString().Equals(""))
                {
                    // Добавление нового узла
                    t_RootNode.Nodes.Add(d_Row["Name"].ToString());
                    t_RootNode.LastNode.Name = d_Row["ID"].ToString();
                    t_RootNode.LastNode.Tag = s_NameTable + "|" + s_NameTable + "|" + t_RootNode.LastNode.Name;
                    t_RootNode.LastNode.NodeFont = new Font("Times New Roman", 12);
                    // Добавление контекстного меню для узла
                    t_RootNode.LastNode.ContextMenuStrip = new ContextMenuStrip();
                    t_RootNode.LastNode.ContextMenuStrip.Items.Add("Add departments");
                    t_RootNode.LastNode.ContextMenuStrip.Items[t_RootNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                    t_RootNode.LastNode.ContextMenuStrip.Items.Add("Add employees");
                    t_RootNode.LastNode.ContextMenuStrip.Items[t_RootNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;        
                    t_RootNode.LastNode.ContextMenuStrip.Items.Add("Delete selected department");
                    t_RootNode.LastNode.ContextMenuStrip.Items[t_RootNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                    // Получение сотрудников для отдела
                    BuildTreeEmployees(t_RootNode.LastNode, d_Database);
                }
                // Если отдел, ищем родительский узел и добавляем к нему
                else
                {
                    TreeNode[] t_ParentNodes = t_RootNode.Nodes.Find(d_Row["ParentDepartmentID"].ToString(), true);
                    for (int i = 0; i < t_ParentNodes.Length; i++)
                    {
                        if (t_ParentNodes[i].Tag.ToString().Split('|')[0].Equals(s_NameTable))
                        {
                            // Если у узла нет промежуточного узла Departments, то сначала добавляем его потом сам узел
                            TreeNode[] t_NodeDepartments = t_ParentNodes[i].Nodes.Find("Departments", false);
                            if (t_NodeDepartments.Length.Equals(0))
                            {
                                t_ParentNodes[i].Nodes.Add("Departments");
                                t_ParentNodes[i].LastNode.Name = "departments";
                                t_ParentNodes[i].LastNode.Tag = "department|departments|" + t_ParentNodes[i].Name;
                                t_ParentNodes[i].LastNode.NodeFont = new Font("Times New Roman", 12, FontStyle.Bold);
                                // Добавление контекстного меню для узла
                                t_ParentNodes[i].LastNode.ContextMenuStrip = new ContextMenuStrip();
                                t_ParentNodes[i].LastNode.ContextMenuStrip.Items.Add("Add departments");
                                t_ParentNodes[i].LastNode.ContextMenuStrip.Items[t_ParentNodes[i].LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                t_ParentNodes[i].LastNode.ContextMenuStrip.Items.Add("Delete selected departments");
                                t_ParentNodes[i].LastNode.ContextMenuStrip.Items[t_ParentNodes[i].LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;

                                // Добавление самого узла
                                t_ParentNodes[i].LastNode.Nodes.Add(d_Row["Name"].ToString());
                                t_ParentNodes[i].LastNode.LastNode.Name = d_Row["ID"].ToString();
                                t_ParentNodes[i].LastNode.LastNode.Tag = s_NameTable + "|"+ s_NameTable + "|"+
                                    t_ParentNodes[i].LastNode.LastNode.Name;
                                t_ParentNodes[i].LastNode.LastNode.NodeFont = new Font("Times New Roman", 12);
                                // Добавление контекстного меню для узла
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip = new ContextMenuStrip();
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Add("Add departments");
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items[t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Add("Add employees");
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items[t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Add("Delete selected department");
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items[t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                // Получение сотрудников для отдела
                                BuildTreeEmployees(t_ParentNodes[i].LastNode.LastNode, d_Database);
                            }
                            // Добавление самого узла
                            else
                            {
                                // Добавление нового узла
                                t_NodeDepartments[0].Nodes.Add(d_Row["Name"].ToString());
                                t_NodeDepartments[0].LastNode.Name = d_Row["ID"].ToString();
                                t_NodeDepartments[0].LastNode.Tag = s_NameTable + "|"+ s_NameTable + "|"+
                                    t_NodeDepartments[0].LastNode.Name;
                                t_NodeDepartments[0].LastNode.NodeFont = new Font("Times New Roman", 12);
                                // Добавление контекстного меню для узла
                                t_NodeDepartments[0].LastNode.ContextMenuStrip = new ContextMenuStrip();
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Add("Add departments");
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items[t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Add("Add employees");
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items[t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Add("Delete selected department");
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items[t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                // Получение сотрудников для отдела
                                BuildTreeEmployees(t_NodeDepartments[0].LastNode, d_Database);
                            }
                            // Выход из цикла поиска
                            break;
                        }
                    }
                }
            }
        }

        // Часть дерева Employees
        private static void BuildTreeEmployees(TreeNode t_Node, Database d_Database)
        {
            // Получение Employees, принадлежащих отделу
            //d_Database.GetEmployees(t_Node.Name);
            d_Database.CallMethod("0|employees", t_Node.Name);
            string s_NameTable = d_Database.GetSetNameTable;

            foreach (DataRow d_Row in d_Database.GetSetDataset.Tables[0].Rows)
            {
                // Если у узла нет промежуточного узла Employees, то сначала добавляем его, потом сам узел
                TreeNode[] t_NodeEmployees = t_Node.Nodes.Find("employees", false);
                if (t_NodeEmployees.Length.Equals(0))
                {
                    t_Node.Nodes.Add("Employees");
                    t_Node.LastNode.Name = "employees";
                    t_Node.LastNode.Tag = "employee|employees|" + t_Node.Name;
                    t_Node.LastNode.NodeFont = new Font("Times New Roman", 12, FontStyle.Bold);
                    // Добавление контекстного меню для узла
                    t_Node.LastNode.ContextMenuStrip = new ContextMenuStrip();
                    t_Node.LastNode.ContextMenuStrip.Items.Add("Add employees");
                    t_Node.LastNode.ContextMenuStrip.Items[t_Node.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                    t_Node.LastNode.ContextMenuStrip.Items.Add("Delete selected employees");
                    t_Node.LastNode.ContextMenuStrip.Items[t_Node.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;

                    // Добавление самого узла
                    t_Node.LastNode.Nodes.Add(String.Format("{0} {1} {2}",d_Row["FirstName"].ToString(), 
                        d_Row["Patronymic"].ToString(), d_Row["SurName"].ToString()));
                    t_Node.LastNode.LastNode.Name = d_Row["ID"].ToString();
                    t_Node.LastNode.LastNode.Tag = s_NameTable + "|"+ s_NameTable + "|"+ t_Node.LastNode.LastNode.Name;
                    t_Node.LastNode.LastNode.NodeFont = new Font("Times New Roman", 12);
                    // Добавление контекстного меню для узла
                    t_Node.LastNode.LastNode.ContextMenuStrip = new ContextMenuStrip();
                    t_Node.LastNode.LastNode.ContextMenuStrip.Items.Add("Delete selected employee");
                    t_Node.LastNode.LastNode.ContextMenuStrip.Items[t_Node.LastNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                }
                // Добавление самого узла
                else
                {
                    // Добавление нового узла
                    t_NodeEmployees[0].Nodes.Add(String.Format("{0} {1} {2}", d_Row["FirstName"].ToString(),
                        d_Row["Patronymic"].ToString(), d_Row["SurName"].ToString()));
                    t_NodeEmployees[0].LastNode.Name = d_Row["ID"].ToString();
                    t_NodeEmployees[0].LastNode.Tag = s_NameTable + "|"+ s_NameTable + "|"+ t_NodeEmployees[0].LastNode.Name;
                    t_NodeEmployees[0].LastNode.NodeFont = new Font("Times New Roman", 12);
                    // Добавление контекстного меню для узла
                    t_NodeEmployees[0].LastNode.ContextMenuStrip = new ContextMenuStrip();
                    t_NodeEmployees[0].LastNode.ContextMenuStrip.Items.Add("Delete selected employee");
                    t_NodeEmployees[0].LastNode.ContextMenuStrip.Items[t_NodeEmployees[0].LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                }
            }
        }
    }
}
