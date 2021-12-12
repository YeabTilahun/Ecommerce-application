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
    public partial class CustomerPage : Form
    {
        public CustomerPage()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void CustomerPage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            CustomerBuy c = new CustomerBuy();
            panelCustomerHome.Controls.Clear();
            c.Dock = DockStyle.Fill;
            panelCustomerHome.Controls.Add(c.panelCustomerBuy);
            panelCustomerHome.Show();
            panelCustomerHome.BringToFront();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            CustomerCart c = new CustomerCart();
            panelCustomerHome.Controls.Clear();
            c.Dock = DockStyle.Fill;
            panelCustomerHome.Controls.Add(c.panelCustomerCart);
            panelCustomerHome.Show();
            panelCustomerHome.BringToFront();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
