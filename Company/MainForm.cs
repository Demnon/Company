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
        // Несохраненные изменения 
        bool b_Changes;

        public MainForm()
        {
            InitializeComponent();
            b_Changes = false;
        }

        // Заполнение данных для подключения к бд и подключение
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Оповещение о несохраненных изменениях, если переподключение
                if (b_Changes == true)
                {
                    SaveToolStripMenuItem_Click(sender, e);
                }
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
                m_Save.Click -= SaveToolStripMenuItem_Click;
                m_Cancel.Click -= CancelToolStripMenuItem_Click;
            }
            catch (Exception e_Ex)
            {
                new Notification(e_Ex.ToString()).ShowDialog();
                m_Save.Click -= SaveToolStripMenuItem_Click;
                m_Cancel.Click -= CancelToolStripMenuItem_Click;
                //new Notification(e_Ex.Message).ShowDialog();
            }
        }

        // Завершение работы
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (b_Changes == true)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
            Close();
        }

        // Оповещение о несохраненных изменениях при завершении работы, очистка ресурсов
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (b_Changes == true)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
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
            string[] s_Tag = t_StructDepartments.SelectedNode.Tag.ToString().Split('|');
            Table.OutputInfoInTable(d_Table, s_Tag, d_Database);
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
            b_Changes = true;
        }

        // Сохранение изменений в БД
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Если изменений нет, выход
                if (!b_Changes)
                {
                    return;
                }
                // Если пользователь подтвердил сохранение изменений
                if (new Verification("Подтверждение сохранения изменений.Да/Нет?").ShowDialog() == DialogResult.Yes)
                {     
                    
                    // Сохранение изменений в бд
                    string[] s_Tag = t_StructDepartments.SelectedNode.Tag.ToString().Split('|');
                    d_Database.CallMethod("1|update", s_Tag[2]);

                    // Изменения сохранены
                    b_Changes = false;

                    //перестроение дерева и открытие нужного узла
                    List<List<string>> s_CopyNodes = new List<List<string>>();

                    //копирование всей ветки до данного элемента
                    TreeNode t_Node = t_StructDepartments.SelectedNode;
                    do
                    {
                        s_CopyNodes.Add(new List<string>() { t_Node.Name, t_Node.Tag.ToString() });
                        if (t_Node.Parent != null)
                        {
                            t_Node = t_Node.Parent;
                        }
                    } while (t_Node.Parent != null);

                    //обновление дерева
                    t_StructDepartments.Nodes.Clear();
                    t_StructDepartments.Nodes.Add(StructureTree.BuildTree(d_Database));

                    // Выбор того же узла, либо его родителя
                    bool b_Test = false;
                    for (int i = 0; i < s_CopyNodes.Count && !b_Test; i++)
                    {
                        TreeNode[] t_FindNodes = t_StructDepartments.Nodes.Find(s_CopyNodes[i][0], true);
                        for (int j = 0; j < t_FindNodes.Length; j++)
                        {
                            if (t_FindNodes[j].Tag.Equals(s_CopyNodes[i][1]))
                            {
                                t_StructDepartments.SelectedNode = t_FindNodes[j];
                                b_Test = true;
                                break;
                            }
                        }
                    }
                }
                // Если не подтвердил, отмена
                else
                {
                    b_Changes = false;
                    // Вывод информации в таблицу
                    string[] s_Tag = t_StructDepartments.SelectedNode.Tag.ToString().Split('|');
                    Table.OutputInfoInTable(d_Table, s_Tag, d_Database);
                }
            }
            catch (SqlException e_Ex)
            {
                new Notification("Сначала удалите дочерние элементы!").ShowDialog();
                b_Changes = false;
                // Вывод информации в таблицу
                string[] s_Tag = t_StructDepartments.SelectedNode.Tag.ToString().Split('|');
                Table.OutputInfoInTable(d_Table, s_Tag, d_Database);
            }
        }

        // Отмена изменений
        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Если пользователь подтвердил отмену изменений
            if (b_Changes && new Verification("Подтверждение отмены изменений.Да/Нет?").ShowDialog() == DialogResult.Yes)
            {
                // Вывод информации в таблицу
                string[] s_Tag = t_StructDepartments.SelectedNode.Tag.ToString().Split('|');
                Table.OutputInfoInTable(d_Table, s_Tag, d_Database);
                b_Changes = false;
            }
        }

        // Добавление
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Форма для ввода количества добавляемых элементов
            AddElements a_AddElements = new AddElements();
            if (a_AddElements.ShowDialog().Equals(DialogResult.OK))
            {
                string[] s_Tag = t_StructDepartments.SelectedNode.Tag.ToString().Split('|');

                // Изменим ключевое слово для нужного запроса из БД
                s_Tag[1] = ((ToolStripMenuItem)sender).Text.ToLower().Split(' ')[1];
                // Выполнение запроса и вывод в таблицу
                Table.OutputInfoInTable(d_Table, s_Tag, d_Database);
                // Настройка внешнего вида таблицы
                l_Element.Text = Char.ToUpper(s_Tag[1][0])+s_Tag[1].Substring(1);
                d_Table.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                d_Table.DefaultCellStyle.Font = new Font("Times New Roman", 12);
                // Добавление строк в Dataset
                for (int i = 0; i < a_AddElements.GetQuantityElements; i++)
                {
                    d_Database.GetSetDataset.Tables[0].Rows.Add(Database.DefaultValues(s_Tag[1], s_Tag[2]));
                    // Синий фон добавленной строки
                    d_Table.Rows[d_Table.Rows.Count-1].DefaultCellStyle.BackColor = Color.LightGreen;
                }
                b_Changes = true;
            }
        }

        // Удаление выбранных строк из таблицы
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Удаляем выбранные строки из таблицы
            foreach (DataGridViewRow d_Row in d_Table.SelectedRows)
            {
                d_Table.Rows.Remove(d_Row);
            }
            b_Changes = true;
        }

        // Оповещение о несохраненных изменениях
        private void t_StructDepartments_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (b_Changes == true)
            {
                SaveToolStripMenuItem_Click(sender, e);
            }
        }

        // Исключения в таблице при вводе неверного формата (например, datatime)
        private void d_Table_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            new Notification("В столбце с именем '" + d_Table.Columns[e.ColumnIndex].Name + "' указано значение неверного формата!").ShowDialog();
        }

        // Проверка значения ячейки
        private void d_Table_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                // Проверка корректности ввода
                Table.CheckData(d_Table, d_Database,e.FormattedValue);
            }
            catch (ApplicationException a_Ex)
            {
                new Notification(a_Ex.Message).ShowDialog();
                ((DataGridView)sender).CancelEdit();
            }
        }
    }
}
