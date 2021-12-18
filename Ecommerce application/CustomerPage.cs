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
            CustomerPage c = new CustomerPage();
            panelAdd.Controls.Clear();
            c.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(c.panelAdd);
            panelAdd.Show();
            panelAdd.BringToFront();
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
          
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click_3(object sender, EventArgs e)
        {
            CustomerBuy c = new CustomerBuy();
            panelAdd.Controls.Clear();
            c.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(c.panelCustomerBuy);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            CustomerCart c = new CustomerCart();
            panelAdd.Controls.Clear();
            c.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(c.panelCustomerCart);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        private void button4_Click_2(object sender, EventArgs e)
        {

            CustomerPage c = new CustomerPage();
            panelAdd.Controls.Clear();
            c.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(c.panelAdd);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        private void CloseM_Click(object sender, EventArgs e)
        {
                this.Close();
                SignIn signIn = new SignIn();
                signIn.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelAdd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestore.BringToFront();
        }

        private void btnRestore_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximized.BringToFront();

        }

        private void CloseM_MouseEnter(object sender, EventArgs e)
        {
            CloseM.BackColor = Color.Brown;
        }

        private void CloseM_MouseLeave(object sender, EventArgs e)
        {
            CloseM.BackColor = Color.Transparent;
        }

        private void btnMaximized_MouseEnter(object sender, EventArgs e)
        {
            btnMaximized.BackColor = Color.Gray;
        }

        private void btnRestore_MouseEnter(object sender, EventArgs e)
        {
            btnRestore.BackColor = Color.Gray;
        }

        private void btnRestore_MouseLeave(object sender, EventArgs e)
        {
            btnRestore.BackColor = Color.Transparent;
        }

        private void btnMaximized_MouseLeave(object sender, EventArgs e)
        {
            btnMaximized.BackColor = Color.Transparent;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure You Want to Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                this.Close();
                SignIn signIn = new SignIn();
                signIn.Show();
            }
            if (res == DialogResult.No)
            {

            }
        }
    }
}
