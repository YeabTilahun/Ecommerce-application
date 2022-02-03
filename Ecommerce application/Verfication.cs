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
    public partial class Verfication : Form
    {
         private string role;
        public Verfication(string role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.CompareTo("1234") == 0)
            {
                PasswordReset pe = new PasswordReset(role);
                pe.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Incorrect code!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
