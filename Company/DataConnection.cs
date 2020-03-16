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
            t_DataSource.Text = "localhost";
        }

		//свойства
		public string GetDataSource
		{
			get
			{
				return t_DataSource.Text;
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
			//проверка и принятие изменений 
			try
			{
				//проверка на наличие DataSources
				if (t_DataSource.Text == "")
				{
					throw new ApplicationException("Enter server!");
				}

				//если проверка подлинности SQL
				if (c_Authentication.SelectedItem.ToString() == "Authentication SQL Server")
				{
					//проверка на наличие Username
					if (t_Username.Text == "")
					{
						throw new ApplicationException("Enter username!");
					}

					//проверка на наличие Password
					if (mt_Password.Text == "")
					{
						throw new ApplicationException("Enter password!");
					}
				}

				//Установка результата выполнения 
				DialogResult = DialogResult.OK;
				//закрытие формы
				Close();
			}
			//исключение 
			catch (ApplicationException ex)
			{
				new Notification(ex.Message).ShowDialog();
			}
		}
	}
}
