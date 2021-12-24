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
    public partial class MerchantBuy : Form
    {
        public MerchantBuy()
        {
            InitializeComponent();
            loading();
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

                    //This is throwing exeption called ...'Object reference not set to an instance of an object
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
        void loading()
        {
            string constr = "Server=YEABS;   database=Ecommerce; integrated security=true; ";

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Close();
                con.Open();
                string query = "SELECT productID,name,price,quantity,description,category FROM product ";
                SqlDataAdapter da = new SqlDataAdapter(query, constr);
                SqlCommandBuilder q = new SqlCommandBuilder(da);
                var ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            //ARRANGING DGV COLUMNS
            dataGridView1.Columns["productID"].DisplayIndex = 0;
            dataGridView1.Columns["name"].DisplayIndex = 1;
            dataGridView1.Columns["price"].DisplayIndex = 2;
            dataGridView1.Columns["quantity"].DisplayIndex = 3;
            dataGridView1.Columns["category"].DisplayIndex = 4;
            dataGridView1.Columns["description"].DisplayIndex = 5;
            //EXTENDING DESCRIPTION COLUMN
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
