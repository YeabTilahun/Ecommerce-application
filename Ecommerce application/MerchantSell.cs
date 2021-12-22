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
    public partial class MerchantSell : Form
    {
        public MerchantSell()
        {
            InitializeComponent();
            LoadIntoCatagoryComboBox();

        }

        private void LoadIntoCatagoryComboBox()
        {
            String[] itemsCatagory = {"Foods & Snacks", "Canned Goods", "Beverages and Drinks",
                                    "Cleaning Products ","Home Appliances","Dairy & Groceries","Hygiene Products",
                                    "Stationary Products","Others"};
            comboBox1.Items.AddRange(itemsCatagory);
        }
        private void CloseM_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinMer_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MerchantBuy m = new MerchantBuy();
            m.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Merchant m = new Merchant();
            m.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MerchantSell_Load(object sender, EventArgs e)
        {
            //To hide update and to show edit when this form loads
            //NOTICE THE NAME FOR UPDATE AND EDIT IS CHANGED btnEdit IS UPDATE AND btnUpd IS UPDATE
            btnEdit.Hide();
            btnUpd.Show();
            btnUpd.BringToFront();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        //When the user clicks add the products info will be copied to MerchantSellClass
        private void btnAdd_Click(object sender, EventArgs e)
        {
            MerchantClass sell = new MerchantClass(textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, textBox4.Text);
            sell.Add();
            //update the grid view after merchant added product 
            dataGridView1.Refresh();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            MerchantClass sell = new MerchantClass();
            sell.Delete(id);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           // MerchantClass sell = new MerchantClass();
            //When the user press cancel all text fields and combobox will be cleard
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text=" ";
            textBox4.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MerchantClass sell = new MerchantClass(textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, textBox4.Text);
            sell.Update();

            //Hide update button after click
            //NOTICE THE NAME FOR UPDATE AND EDIT IS CHANGED btnEdit IS UPDATE AND btnUpd IS UPDATE
            btnEdit.Hide();
            btnUpd.Show();
            btnUpd.BringToFront();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            //To hide edit and to show Update when this form loads
            //NOTICE THE NAME FOR UPDATE AND EDIT IS CHANGED btnEdit IS UPDATE AND btnUpd IS UPDATE
            btnEdit.Show();
            btnUpd.Hide();
            btnEdit.BringToFront();

            //We need to show the product thats going to be edited from the data grid view in to textbox
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //Means if the checkbox is selected
                if (Convert.ToBoolean(row.Cells[1].Value))
                {
                    //Assign from the table to the textbox and combobox to be edited
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
