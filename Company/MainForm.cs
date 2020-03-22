using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Company
{
    public partial class MainForm : Form
    {
        // Работа с БД
        Database d_Database;

        public MainForm()
        {
            InitializeComponent();
        }

        // Заполнение данных для подключения к бд и подключение
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Если данные введены, пробуем подключаться
                DataConnection d_DataConnection = new DataConnection();
                if(d_DataConnection.ShowDialog().Equals(DialogResult.OK))
                {
                    //Вызов подключения
                    string s_ConnectString = "";
                    //если проверка подлинности Sql
                    if (d_DataConnection.GetAuthentication.Equals("Authentication SQL Server"))
                    {
                        s_ConnectString = @"Data Source=" + d_DataConnection.GetDataSource + ";Initial Catalog="+d_DataConnection.GetDatabase+";Persist Security Info=True;User ID="
                        + d_DataConnection.GetUsername + ";Password=" + d_DataConnection.GetPassword;
                    }
                    //если проверка подлинности Windows
                    else
                    {
                        s_ConnectString = @"Data Source=" + d_DataConnection.GetDataSource + ";Initial Catalog=" + d_DataConnection.GetDatabase + ";Persist Security Info=True;Integrated Security=true";
                    }

                    // Очистка ресурсов (если переподключение к другой бд, например)
                    if (d_Database != null)
                    {
                        d_Database.Dispose();
                    }
                       
                    // Новое подключение
                    d_Database = new Database(s_ConnectString);

                    // Построение дерева
                    t_StructDepartments.Nodes.Clear();
                    t_StructDepartments.Nodes.Add(StructureTree.BuildTree(d_Database));
                    t_StructDepartments.SelectedNode = t_StructDepartments.TopNode;

                    // Привязка событий к меню Сохранить и Удалить
                    m_Save.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
                    m_Cancel.Click += new System.EventHandler(this.CancelToolStripMenuItem_Click);
                }
               
            }
            catch (SqlException e_Ex)
            {
                new Notification(e_Ex.ToString()).ShowDialog();
                //new Notification("Соединение с базой данных не установлено, проверьте правильность введенных данных. Возможно, сервер не активен либо базы данных не существует.").ShowDialog();
            }
            catch (Exception e_Ex)
            {
                new Notification(e_Ex.ToString()).ShowDialog();
                //new Notification(e_Ex.Message).ShowDialog();
            }
        }

        // Завершение работы
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Close();
        }

        // Очистка ресурсов без завершением работы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (d_Database != null)
            {
                d_Database.Dispose();
            }
        }

        // После выбора узла дерева открытие соответствующей таблицы и добавление контекстного меню к кнопкам добавить и удалить
        private void t_StructDepartments_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Контекстное меню для кнопок добавить и удалить
            m_Add.DropDownItems.Clear();
            m_Delete.DropDownItems.Clear();
            for (int i=0;i<t_StructDepartments.SelectedNode.ContextMenuStrip.Items.Count;i++)
            {
                string s_Text = t_StructDepartments.SelectedNode.ContextMenuStrip.Items[i].Text;
                if (s_Text.Contains("Add"))
                {
                    m_Add.DropDownItems.Add(s_Text);
                    // Привязываем событие клика мышью по элементу меню
                    m_Add.DropDownItems[m_Add.DropDownItems.Count-1].Click += new System.EventHandler(this.AddToolStripMenuItem_Click);
                }
                else
                {
                    m_Delete.DropDownItems.Add(s_Text);
                    // Привязываем событие клика мышью по элементу меню
                    m_Delete.DropDownItems[m_Delete.DropDownItems.Count - 1].Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
                }
            }

            // Вывод информации в таблицу
            Table.OutputInfoInTable(d_Table, t_StructDepartments.SelectedNode, d_Database);
            // Настройка внешнего вида таблицы
            // Заголовок таблицы
            l_Element.Text = t_StructDepartments.SelectedNode.Text;
            d_Table.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            d_Table.DefaultCellStyle.Font = new Font("Times New Roman",12);
        }

        // Изменение цвета ячейки при редактировании
        private void d_Table_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            d_Table.CurrentCell.Style.BackColor = Color.LightGreen;
        }

        // Сохранение изменений в БД
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] s_Tag = t_StructDepartments.SelectedNode.Tag.ToString().Split('|');
            d_Database.CallMethod("1|Update", s_Tag[2]);
        }

        // Отмена изменений
        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        // Добавление
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Форма для ввода количества добавляемых элементов
            AddElements a_AddElements = new AddElements();
            if (a_AddElements.ShowDialog().Equals(DialogResult.OK))
            {
                // Случай 1 - выбраны заголовки (Companies, employees или departments)
                if (t_StructDepartments.SelectedNode.Name.Equals(t_StructDepartments.SelectedNode.Text))
                {
                    // Просто добавляем строки в Dataset
                    string s_Name = t_StructDepartments.SelectedNode.Name;
                    for (int i = 0; i < a_AddElements.GetQuantityElements; i++)
                    {
                        d_Database.GetSetDataset.Tables[0].Rows.Add(Database.d_DefaultValuesDepartments[s_Name]);
                    }
                }
            }
        }

        // Удаление выбранных строк из таблицы
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
