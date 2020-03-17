using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Company
{
    public partial class DataConnection : Form
    {
        public DataConnection()
        {
            InitializeComponent();

            // Значения по умолчанию
            c_Authentication.SelectedIndex = 0;
            t_DataSource.Text = @"localhost\SQLEXPRESS";
			t_Database.Text = "TestDB";
        }

		public string GetDataSource
		{
			get
			{
				return t_DataSource.Text;
			}
		}
		public string GetDatabase
		{
			get
			{
				return t_Database.Text;
			}
		}

		public string GetUsername
		{
			get
			{
				return t_Username.Text;
			}
		}

		public string GetPassword
		{
			get
			{
				return mt_Password.Text;
			}
		}

		public string GetAuthentication
		{
			get
			{
				return c_Authentication.SelectedItem.ToString();
			}
		}

		// Принятие информации
		private void b_OK_Click(object sender, EventArgs e)
		{
			// Проверка и принятие изменений 
			try
			{
				// Проверка на наличие DataSources
				if (t_DataSource.Text == null || t_DataSource.Text == "")
				{
					throw new ApplicationException("Enter server!");
				}

				// Проверка на наличие бд
				if (t_Database.Text == null || t_Database.Text == "")
				{
					throw new ApplicationException("Enter database!");
				}

				// Если проверка подлинности SQL
				if (c_Authentication.SelectedItem.ToString() == "Authentication SQL Server")
				{	
					if (t_Username.Text == null || t_Username.Text == "")
					{
						throw new ApplicationException("Enter username!");
					}

					if (mt_Password.Text ==null || mt_Password.Text == "")
					{
						throw new ApplicationException("Enter password!");
					}
				}

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (ApplicationException ex)
			{
				new Notification(ex.Message).ShowDialog();
			}
		}

		// Кнопка отмена
		private void b_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		// Событие изменения аутентификации
		private void c_Authentication_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Выбор аутентификации
			if (c_Authentication.SelectedItem.ToString() == "Authentication Windows")
			{
				l_Username.Enabled = false;
				l_Password.Enabled = false;
				t_Username.Enabled = false;
				mt_Password.Enabled = false;
			}
			else
			{
				l_Username.Enabled = true;
				l_Password.Enabled = true;
				t_Username.Enabled = true;
				mt_Password.Enabled = true;
			}
		}
	}
}
