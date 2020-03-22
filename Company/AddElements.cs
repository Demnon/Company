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
    public partial class AddElements : Form
    {
        public AddElements()
        {
            InitializeComponent();

            t_QuantityElements.Text = "1";
        }

        public int GetQuantityElements
        {
            get { return Convert.ToInt32(t_QuantityElements.Text); }
        }

        // Нажатие ОК
        private void b_OK_Click(object sender, EventArgs e)
        {
			// Проверка и принятие изменений 
			try
			{
				// Проверка на наличие данных
				if (t_QuantityElements.Text.Equals(""))
				{
					throw new ApplicationException("Введите количество элементов!");
				}
				// Проверка на положительность
				if (Convert.ToInt32(t_QuantityElements.Text) < 0)
				{
					throw new ApplicationException("Введите положительное количество элементов!");
				}

				// Установка результата выполнения 
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			//исключения
			catch (ApplicationException e_Ex)
			{
				new Notification(e_Ex.Message).ShowDialog();
			}
			catch (FormatException)
			{
				new Notification("Введите корректное количество элементов!").ShowDialog();
			}
		}

		// Нажатие отмена
		private void b_Cancel_Click(object sender, EventArgs e)
		{
			// Установка результата выполнения 
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
