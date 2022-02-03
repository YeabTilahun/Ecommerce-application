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
    public partial class PasswordReset : Form
    {
        private string role;
        public PasswordReset(string role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePassword o = new ChangePassword(textBox1.Text, textBox2.Text,role);
            o.checkPassword();
            SignIn s = new SignIn();
            s.Show();
            this.Hide();
        }
    }
}
