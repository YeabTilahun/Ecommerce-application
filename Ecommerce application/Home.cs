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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Newcart nc = new Newcart();
            panel3.Controls.Clear();
            nc.Dock = DockStyle.Fill;
            panel3.Controls.Add(nc.panel1);
            panel3.Show();
            panel3.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            panel3.Controls.Clear();
            l.Dock = DockStyle.Fill;
            panel3.Controls.Add(l.panel1);
            panel3.Show();
            panel3.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewSignUp newsu = new NewSignUp();
            panel3.Controls.Clear();
            newsu.Dock = DockStyle.Fill;
            panel3.Controls.Add(newsu.panel1);
            panel3.Show();
            panel3.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            panel3.Controls.Clear();
            h.Dock = DockStyle.Fill;
            panel3.Controls.Add(h.panel3);
            panel3.Show();
            panel3.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
