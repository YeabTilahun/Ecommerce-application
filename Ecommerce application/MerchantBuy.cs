using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class MerchantBuy : Form
    {
        public MerchantBuy()
        {
            InitializeComponent();
        }

        private void CloseM_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinMer_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Merchant m = new Merchant();
            m.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MerchantSell m = new MerchantSell();
            m.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search items here";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search items here")
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Array is to hold different product ID that are selected in data grid view 
            string[] id= new string[ConfigurationManager.ConnectionStrings.Count]; //This will initialize the array 
            dataGridView1.AllowUserToAddRows = false;
            for (int i=0; i < dataGridView1.Rows.Count; i++)
            {
                bool isCellCheked = (bool)dataGridView1.Rows[i].Cells[0].Value;
                if (isCellCheked==true)
                {
                    //MessageBox.Show("Checked!");
                    id = new String[0+1];
                    //Retrive the selected id from data grid view to string array
                    DataGridViewRow row = dataGridView1.Rows[i];
                    id[i] = row.Cells[2].Value.ToString();
                }
                /* else
                     MessageBox.Show("Not checked!");*/
            }
               MerchantClass buy = new MerchantClass();
               buy.SelectedProduct(id);
        }

        private void panelBuy_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
