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

                }
               
            }
            catch (SqlException)
            {
                new Notification("Соединение с базой данных не установлено, проверьте правильность введенных данных. Возможно, сервер не активен либо базы данных не существует.").ShowDialog();
            }
            catch (Exception e_Ex)
            {
                new Notification(e_Ex.Message).ShowDialog();
            }
        }

        // Завершение работы, закрытие подключения к бд
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (d_Database != null)
            {
                d_Database.Dispose();
            }
            Close();
        }

       
    }
}
