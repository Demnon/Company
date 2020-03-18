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
                if(d_DataConnection.ShowDialog() == DialogResult.OK)
                {
                    //Вызов подключения
                    string s_ConnectString = "";
                    //если проверка подлинности Sql
                    if (d_DataConnection.GetAuthentication== "Authentication SQL Server")
                    {
                        s_ConnectString = @"Data Source=" + d_DataConnection.GetDataSource + ";Initial Catalog="+d_DataConnection.GetDatabase+";Persist Security Info=True;User ID="
                        + d_DataConnection.GetUsername + ";Password=" + d_DataConnection.GetPassword;
                    }
                    //если проверка подлинности Windows
                    else
                    {
                        s_ConnectString = @"Data Source=" + d_DataConnection.GetDataSource + ";Initial Catalog=" + d_DataConnection.GetDatabase + ";Persist Security Info=True;Integrated Security=true";
                    }

                    d_Database = new Database(s_ConnectString);

                    //*****************************
                   /* DataSet dd = d_Database.GetDepartments("45594551-05eb-49f5-92e9-df96f4111d22");
                    for (int i=0;i<dd.Tables.Count;i++)
                    {
                        for (int j=0;j<dd.Tables[i].Rows.Count;j++)
                        {
                            string dfgf = "";
                        }
                    }*/
                }
               
            }
            catch (SqlException e_Ex)
            {
                new Notification(e_Ex.ToString()).ShowDialog();
                //new Notification("Соединение с базой данных не установлено, проверьте правильность введенных данных. Возможно, сервер не активен либо базы данных не существует.").ShowDialog();
            }
            catch (Exception e_Ex)
            {
                new Notification(e_Ex.Message).ShowDialog();
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
    }
}
