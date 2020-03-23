using System;
using System.Windows.Forms;

namespace Company
{
    public partial class Verification : Form
    {
        public Verification(string s_Message)
        {
            InitializeComponent();
            l_Message.Text = s_Message;
        }

        private void b_Yes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void b_No_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
