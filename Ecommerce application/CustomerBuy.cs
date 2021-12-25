using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class CustomerBuy : Form
    {
        public CustomerBuy(string id, string name, string price, string qty, string description, string category)
        {
            InitializeComponent();

           // dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value =  id;
        }

        public CustomerBuy()
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panelCustomerBuy_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            CustomerPage c = new CustomerPage();
            panelCustomerBuy.Controls.Clear();
            c.Dock = DockStyle.Fill;
            panelCustomerBuy.Controls.Add(c.panelAdd);
            panelCustomerBuy.Show();
            panelCustomerBuy.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CustomerCart c = new CustomerCart();
            panelCustomerBuy.Controls.Clear();
            c.Dock = DockStyle.Fill;
            panelCustomerBuy.Controls.Add(c.panelCustomerCart);
            panelCustomerBuy.Show();
            panelCustomerBuy.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            CustomerCart c = new CustomerCart();
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
           if(textBox1.Text != "\0")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            if (textBox1.Text != "\0")
                textBox1.Text = "";
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            textBox1.Text = "Search the items here!";
        }

        private void picBoxSearch_Click(object sender, EventArgs e)
        {

        }

        private void picBoxSearch_MouseEnter(object sender, EventArgs e)
        {
            picBoxSearch.BackColor = Color.DarkSeaGreen;
        }

        private void picBoxSearch_MouseLeave(object sender, EventArgs e)
        {
            picBoxSearch.BackColor = Color.Transparent;
        }

        

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button8_Click_2(object sender, EventArgs e)
        {

            /* dataGridView1.AllowUserToAddRows = false;
             for (int i = 0; i < dataGridView1.Rows.Count; i++)
             {
                 bool isCellCheked = (bool)dataGridView1.Rows[i].Cells[0].Value;
                 if (isCellCheked == true)
                 {
                     dataGridView1.Rows.RemoveAt(i);
                 }

             }*/
            //Addtocart();
            MessageBox.Show("Items Added to Cart");

        }

        //Adds the items selected in CustomerBuy data grid view to the CustomerCart data grid view When Add To Cart is clicked. 
        private void Addtocart(string id, string qty, string price)
        {
            CustomerCart cart = new CustomerCart();
            string[] add = { id, qty, price };
            cart.dataGridView2.Rows.Add(add);
        }

        private void textBox1_MouseEnter_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "\0")
                textBox1.Text = "";
        }

        private void textBox1_MouseLeave_1(object sender, EventArgs e)
        {
            textBox1.Text = "Search The Items Here!";
        }

        private void CustomerBuy_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ecommerceDataSet.product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.ecommerceDataSet.product);

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection("Server =  LAPTOP-RS59N8IM; Database = E-Commerce; integrated security = true;");
            SqlDataAdapter ada = new SqlDataAdapter("SELECT productID, name, price, quantity, category, description FROM product", con);
            DataTable dt = new DataTable();
            ada.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
