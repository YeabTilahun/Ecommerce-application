using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class ChangeCustomerPassword : Form
    {
        public ChangeCustomerPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            NewHomeClass nhc = new NewHomeClass();
            string oldPassword = nhc.GetOldPassword(h.name);
            //save clicked
            if (textBoxOldPass.Text == oldPassword)
            {
                if (textBoxNewPass.Text == textBoxConfirmPass.Text)
                {
                    nhc.UpdatePassword(textBoxNewPass.Text);
                }
                else
                    MessageBox.Show("New password doesn't match!");
            }
            else
                MessageBox.Show("Wrong password");
            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
