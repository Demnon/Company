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
