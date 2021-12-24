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
            //LOADING THE ITEMS FOR THE COMBOBOX WHEN THE CLASS LOADS
            LoadIntoCatagoryComboBox();
            //LOADING THE DATA TO THE DGV WHEN THE CLASS LOADS
            loading();
            //disable ID textbox
            textBox5.Enabled = false;
        }

        private void LoadIntoCatagoryComboBox()
        {
            String[] itemsCatagory = {"Alcohol","Bikes","Books","Cars","Phone","Cleaning supplies","Clothing","Electronics","Exercise Equipment","Furniture"
                    ,"Jewelry","Medicine","Musical Instruments","Sporting goods","Tools and Home Care","Toys & Games","Watches","Other"};
            comboBox1.Items.AddRange(itemsCatagory);
        }

        private void MerchantSell_Load(object sender, EventArgs e)
        {
            //To hide update and to show edit when this form loads
            //NOTICE THE NAME FOR UPDATE AND EDIT IS CHANGED btnEdit IS UPDATE AND btnUpd IS UPDATE
            btnEdit.Hide();
            btnUpd.Show();
            btnUpd.BringToFront();
        }

        //LOADING THE DATA TO THE DGV
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

        //When the user clicks add the products info will be copied to MerchantSellClass
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "/0" && textBox2.Text == "/0" && textBox3.Text == "/0" && textBox4.Text == "/0" && comboBox1.Text == "/0")
            {
                MerchantClass sell = new MerchantClass(textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, textBox4.Text);
                sell.Add();
                //update the grid view after merchant added product 
                loading();
                //After product added texbox will be cleared
                textBox5.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.Text = " ";
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Please fill the required fields!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //SELECTED VALUE PASSING FROM DGV
            try
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["productID"].Value);
                string id = cellValue;
                MerchantClass sell = new MerchantClass();
                sell.Delete(id);
                loading();
            }
            catch (ArgumentOutOfRangeException a)
            {
                MessageBox.Show("Please select row.");
            }

            //After product deleted texbox will be cleared
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = " ";
            textBox4.Clear();

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
            textBox5.Enabled = false;
            MerchantClass sell = new MerchantClass(textBox5.Text, textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, textBox4.Text);
            sell.Update();
            loading();
            //Hide update button after click
            //NOTICE THE NAME FOR UPDATE AND EDIT IS CHANGED btnEdit IS UPDATE AND btnUpd IS UPDATE
            btnEdit.Hide();
            btnUpd.Show();
            btnUpd.BringToFront();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            textBox5.Enabled = false;
            //seleted ROW VALUE
            try {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["productID"].Value);
                textBox5.Text = cellValue;
                fill();
            }
            catch (ArgumentOutOfRangeException a)
            {
                MessageBox.Show("Please select row.");
            }
            //To hide edit and to show Update when this form loads
            //NOTICE THE NAME FOR UPDATE AND EDIT IS CHANGED btnEdit IS UPDATE AND btnUpd IS UPDATE
            btnEdit.Show();
            btnUpd.Hide();
            btnEdit.BringToFront();
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
        
        //TO CALL IT WHEN THE USER SELECT ROW DGV AND PRESS EDIT
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
    }
    }
