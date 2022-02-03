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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePassword r = new ChangePassword(txtuser.Text);
            string role=r.checkEmail();
            if (role!="")
            {
                Verfication v = new Verfication(role);
                v.Show();
                this.Hide();
            }
           
        }

        private void txtuser_Click(object sender, EventArgs e)
        {

            txtuser.Text = "";
        }
    }
}
