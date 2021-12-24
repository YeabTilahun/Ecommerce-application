using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class MerchantBuy:Form
    {
        public MerchantBuy()
        {
            InitializeComponent();
            //TO ADD THE CHECK BOX WHEN IT LOADS
            AddCheckBox();
            //TO LOAD THE DATA WHEN IT LOADS
            loading();
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
            dataGridView1.Columns["productID"].DisplayIndex = 1;
            dataGridView1.Columns["name"].DisplayIndex = 2;
            dataGridView1.Columns["price"].DisplayIndex = 3;
            dataGridView1.Columns["quantity"].DisplayIndex = 4;
            dataGridView1.Columns["category"].DisplayIndex = 5;
            dataGridView1.Columns["description"].DisplayIndex = 6;
            //EXTENDING DESCRIPTION COLUMN
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].Width = 40;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[1].Width = 58;
            dataGridView1.Columns[2].Width = 80;
        }
        //ADDING CHECKBOX TO DGV
        void AddCheckBox()
        {
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "X";
            checkColumn.HeaderText = "Select";
            checkColumn.Width = 50;
            checkColumn.FillWeight = 10;
            checkColumn.TrueValue = 1;
            checkColumn.FalseValue = 0;
            checkColumn.ReadOnly = false;
            dataGridView1.Columns.Add(checkColumn);
            dataGridView1.Columns["X"].DisplayIndex = 0;
        }



        //WHEN SEARCH BOX TEXT CHANGED CALL SEARCH METHOD 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        //FOR SEARCH CALLS THE PROCEDURE AND DOES THE JOB BUT THEIR IS ERORR AFTER WE SEARCH THE DGV CONTENT WILL DISAPEAR
        void search()
        {
            string constr = "Server=YEABS;   database=Ecommerce; integrated security=true; ";

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("Exec spSearch @search", con);
                sqlCmd.Parameters.AddWithValue("@search", textBox1.Text);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        //SEARCH BOX MOUSE LEAVE SHOW TEXT "search items here"
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search items here";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        //SEARCH BOX MOUSE ENTERS HIDE TEXT "search items here"
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search items here")
                textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        //ADDING SELECTED ITEMS TO CART DGV
        private void button8_Click(object sender, EventArgs e)
        {
            //NEEDS A LOT OF WORK  
            string[] id = new string[ConfigurationManager.ConnectionStrings.Count]; //This will initialize the array 
            MerchantCart a = new MerchantCart();
            a.dataGridView1.AllowUserToAddRows = false;
            int numRows = dataGridView1.Rows.Count;
            a.dataGridView1.RowCount = numRows;
            for (int i = 0; i < numRows; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["X"].Value) == true)
                {
                    //copy everything
                    //DataGridView2.DataSource = DataGridView1.DataSource;
                }
            }
        }
    }
}
