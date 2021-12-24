using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            loading();
        }

        private void LoadIntoCatagoryComboBox()
        {
            String[] itemsCatagory = {"Alcohol","Bikes","Books","Cars","Phone","Cleaning supplies","Clothing","Electronics","Exercise Equipment","Furniture"
                    ,"Jewelry","Medicine","Musical Instruments","Sporting goods","Tools and Home Care","Toys & Games","Watches","Other"};
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
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            //SELECTED VALUE PASSING FROM DGV
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string cellValue = Convert.ToString(selectedRow.Cells["productID"].Value);

            string id = cellValue;
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
            //arranging the button orders
            btnEdit.Hide();
            btnUpd.Show();
            btnUpd.BringToFront();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MerchantClass sell = new MerchantClass(textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, textBox4.Text);
            sell.Update();
            dataGridView1.Refresh();
            dataGridView1.Update();
            //Hide update button after click
            //NOTICE THE NAME FOR UPDATE AND EDIT IS CHANGED btnEdit IS UPDATE AND btnUpd IS UPDATE
            btnEdit.Hide();
            btnUpd.Show();
            btnUpd.BringToFront();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            //seleted ROW VALUE
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string cellValue = Convert.ToString(selectedRow.Cells["productID"].Value);
                    textBox5.Text = cellValue;
                    fill();

            //To hide edit and to show Update when this form loads
            //NOTICE THE NAME FOR UPDATE AND EDIT IS CHANGED btnEdit IS UPDATE AND btnUpd IS UPDATE
            btnEdit.Show();
            btnUpd.Hide();
            btnEdit.BringToFront();

            //We need to show the product thats going to be edited from the data grid view in to textbox
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                //Means if the checkbox is selected
               /* if (Convert.ToBoolean(row.Cells[1].Value))
                {
                    //Assign from the table to the textbox and combobox to be edited
                }*/
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //when the user enters ID it will fill the textboxes with the apropriate value(product)
        string constr = "Server=YEABS;   database=Ecommerce; integrated security=true; ";
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                //WHEN THE TEXT CHANGED IT WILL CALL FILL TO FILL THE TEXT BOXES
                fill();
            }
            }
        
        //TO CALL IT WHEN THE USER SELECT ROM DGV AND PRESS EDIT
        public void fill()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spFillProductSell", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", textBox5.Text);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        textBox5.Text = da.GetValue(0).ToString();
                        textBox5.Text = da.GetValue(1).ToString();
                        textBox1.Text = da.GetValue(2).ToString();
                        textBox2.Text = da.GetValue(3).ToString();
                        textBox3.Text = da.GetValue(4).ToString();
                        textBox4.Text = da.GetValue(5).ToString();
                        //PROBLEM ON THE COMBOBOX THE VALUE WONT CHANGE!
                        comboBox1.Text = da.GetValue(6).ToString();

                    }
                    con.Close();
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void productBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
    }
