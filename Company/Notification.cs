using System;
using System.Windows.Forms;

namespace Company
{
    public partial class Notification : Form
    {
        public Notification(string s_Massage)
        {
            InitializeComponent();

            t_Message.Text = s_Massage;
        }

        private void b_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
