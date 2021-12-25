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
    public partial class CustomerCart : Form
    {
        public CustomerCart()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerPage c = new CustomerPage();
            panelCustomerCart.Controls.Clear();
            c.Dock = DockStyle.Fill;
            panelCustomerCart.Controls.Add(c.panelAdd);
            panelCustomerCart.Show();
            panelCustomerCart.BringToFront();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelCustomerCart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            dataGridView2.AllowUserToAddRows = false;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                bool isCellCheked = (bool)dataGridView2.Rows[i].Cells[0].Value;
                if (isCellCheked == true)
                {
                    dataGridView2.Rows.RemoveAt(i);
                }

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            MessageBox.Show("Items Bought!");
        }
    }
}
