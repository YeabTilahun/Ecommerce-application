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
    public partial class Sign_UP_new : Form
    {
        public Sign_UP_new()
        {
            InitializeComponent();
        }

        private void CloseM_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            /*Home h = new Home();
            panel3.Controls.Clear();
            h.Dock = DockStyle.Fill;
            panel3.Controls.Add(h.panel3);
            panel3.Show();
            panel3.BringToFront();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Log_in l = new Log_in();
            panel1.Controls.Clear();
            l.Dock = DockStyle.Fill;
            panel1.Controls.Add(l.panel1);
            panel1.Show();
            panel1.BringToFront();
        }
    }
}

