using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class MerchantChangePassword : Form
    {
        public MerchantChangePassword()
        {
            InitializeComponent();
        }

        //This will save the password if the coditions are true
        private void button4_Click(object sender, EventArgs e)
        {
            MerchantClass mc = new MerchantClass();
            string oldPassword = mc.GetOldPassword(Merchant.name);
            //save clicked
            if (oldTextbox.Text == oldPassword)
            {
                if (NewTextbox.Text == ConfirmPassword.Text)
                {
                    mc.UpdatePassword(NewTextbox.Text);
                }
                else
                    MessageBox.Show("New password doesn't match!");
            }
            else
                MessageBox.Show("Wrong password");
        }
    }
}
