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
            ChangePassword r = new ChangePassword(textBox2.Text);
            int x=r.checkEmail();
            if (x == 1)
            {
                Verfication v = new Verfication();
                v.Show();
                this.Hide();
            }
        }
    }
}
