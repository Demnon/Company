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
    public static class StructureTree
    {
        // Построение дерева
        public static TreeNode BuildTree(Database d_Database)
        {
            // Создание корневого узла
            TreeNode t_RootNode = new TreeNode("Companies");
            t_RootNode.NodeFont = new Font("Times New Roman", 12, FontStyle.Bold);
            t_RootNode.Name = "Companies";
            // Контекстное меню узла (для реализации кнопок добавить, удалить)
            t_RootNode.ContextMenuStrip = new ContextMenuStrip();
            t_RootNode.ContextMenuStrip.Items.Add("Add company(es)");
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
            d_Database.GetDepartments("");

            foreach (DataRow d_Row in d_Database.GetSetDataset.Tables[0].Rows)
            {
                // Если фирма
                if (d_Row["ParentDepartmentID"].ToString().Equals(""))
                {
                    // Добавление нового узла
                    t_RootNode.Nodes.Add(d_Row["Name"].ToString());
                    t_RootNode.LastNode.Name = d_Row["ID"].ToString();
                    t_RootNode.LastNode.Tag = d_Row.Table.TableName;
                    t_RootNode.LastNode.NodeFont = new Font("Times New Roman", 12);
                    // Добавление контекстного меню для узла
                    t_RootNode.LastNode.ContextMenuStrip = new ContextMenuStrip();
                    t_RootNode.LastNode.ContextMenuStrip.Items.Add("Add department");
                    t_RootNode.LastNode.ContextMenuStrip.Items[t_RootNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                    t_RootNode.LastNode.ContextMenuStrip.Items.Add("Delete departments");
                    t_RootNode.LastNode.ContextMenuStrip.Items[t_RootNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                    t_RootNode.LastNode.ContextMenuStrip.Items.Add("Delete selected department");
                    t_RootNode.LastNode.ContextMenuStrip.Items[t_RootNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                }
                // Если отдел, ищем родительский узел и добавляем к нему
                else
                {
                    TreeNode[] t_ParentNodes = t_RootNode.Nodes.Find(d_Row["ParentDepartmentID"].ToString(), true);
                    for (int i = 0; i < t_ParentNodes.Length; i++)
                    {
                        if (t_ParentNodes[i].Tag.Equals(d_Row.Table.TableName))
                        {
                            // Если у узла нет промежуточного узла Departments, то сначала добавляем его потом сам узел
                            TreeNode[] t_NodeDepartments = t_ParentNodes[i].Nodes.Find("Departments", false);
                            if (t_NodeDepartments.Length.Equals(0))
                            {
                                t_ParentNodes[i].Nodes.Add("Departments");
                                t_ParentNodes[i].LastNode.Name = "Departments";
                                t_ParentNodes[i].LastNode.Tag = d_Row.Table.TableName;
                                t_ParentNodes[i].LastNode.NodeFont = new Font("Times New Roman", 12, FontStyle.Bold);
                                // Добавление контекстного меню для узла
                                t_ParentNodes[i].LastNode.ContextMenuStrip = new ContextMenuStrip();
                                t_ParentNodes[i].LastNode.ContextMenuStrip.Items.Add("Add department");
                                t_ParentNodes[i].LastNode.ContextMenuStrip.Items[t_ParentNodes[i].LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                t_ParentNodes[i].LastNode.ContextMenuStrip.Items.Add("Delete selected departments");
                                t_ParentNodes[i].LastNode.ContextMenuStrip.Items[t_ParentNodes[i].LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;

                                // Добавление самого узла
                                t_ParentNodes[i].LastNode.Nodes.Add(d_Row["Name"].ToString());
                                t_ParentNodes[i].LastNode.LastNode.Name = d_Row["ID"].ToString();
                                t_ParentNodes[i].LastNode.LastNode.Tag = d_Row.Table.TableName;
                                t_ParentNodes[i].LastNode.LastNode.NodeFont = new Font("Times New Roman", 12);
                                // Добавление контекстного меню для узла
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip = new ContextMenuStrip();
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Add("Add department");
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items[t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Add("Delete departments");
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items[t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Add("Delete selected department");
                                t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items[t_ParentNodes[i].LastNode.LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                            }
                            // Добавление самого узла
                            else
                            {
                                // Добавление нового узла
                                t_NodeDepartments[0].Nodes.Add(d_Row["Name"].ToString());
                                t_NodeDepartments[0].LastNode.Name = d_Row["ID"].ToString();
                                t_NodeDepartments[0].LastNode.Tag = d_Row.Table.TableName;
                                t_NodeDepartments[0].LastNode.NodeFont = new Font("Times New Roman", 12);
                                // Добавление контекстного меню для узла
                                t_NodeDepartments[0].LastNode.ContextMenuStrip = new ContextMenuStrip();
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Add("Add department");
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items[t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Add("Delete departments");
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items[t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Add("Delete selected department");
                                t_NodeDepartments[0].LastNode.ContextMenuStrip.Items[t_NodeDepartments[0].LastNode.ContextMenuStrip.Items.Count - 1].Visible = false;
                            }
                            // Выход из цикла поиска
                            break;
                        }
                    }
                }
            }
        }
    }
}
