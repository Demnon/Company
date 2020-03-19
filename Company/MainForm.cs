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
                }
               
            }
            catch (SqlException e_Ex)
            {
                new Notification("Соединение с базой данных не установлено, проверьте правильность введенных данных. Возможно, сервер не активен либо базы данных не существует.").ShowDialog();
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
                }
                else
                {
                    m_Delete.DropDownItems.Add(s_Text);
                }
            }
        }
    }
}
