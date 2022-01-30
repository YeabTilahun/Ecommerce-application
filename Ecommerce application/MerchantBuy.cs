using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class MerchantBuy : Form
    {
        public MerchantBuy(int i)
        {
            InitializeComponent();
            GetCategory();
            comboBox1.Items.Add ("All");
            choose(i);
        }

        //To call this class with out a parameter
        public MerchantBuy()
        {

        }

        //if it is 1 then its buy tab from merchant form and will display products to be bought
        //but if it is 2 then its my product tab and it will display the users product only
        public void choose(int i) {
            if (i == 1)
            {
                PopulateItem();
            }
            if (i == 2)
            {

                Getproduct(Merchant.name);
            }
        }

        //display all products in datatbase
        public void PopulateItem()
        {
            string constr = "Server=YEABS;   database=Ecommerce; integrated security=true;";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spLoad_data", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    DataTable dt = ds.Tables["tblProduct"];
                    MerchantLoadProducts[] a = new MerchantLoadProducts[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        a[i] = new MerchantLoadProducts(1);
                        a[i].Pic = (byte[])dt.Rows[i]["photo"];
                        a[i].Name = dt.Rows[i]["name"].ToString();
                        a[i].Description = dt.Rows[i]["description"].ToString();
                        a[i].Price = dt.Rows[i]["price"].ToString();
                        a[i].productid= dt.Rows[i]["productid"].ToString();

                        if (panelBuy.Controls.Count < 0)
                            panelBuy.Controls.Clear();
                        else
                            panelBuy.Controls.Add(a[i]);
                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //get products added by the user
        string constr = "Server=YEABS;   database=Ecommerce; integrated security=true;";
        public void Getproduct(String user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    panelBuy.Controls.Clear();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetMyProduct", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@name", user);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    DataTable dt = ds.Tables["tblProduct"];
                    if (dt != null)
                    {
                        MerchantLoadProducts[] a = new MerchantLoadProducts[dt.Rows.Count];
                      //  MessageBox.Show("yes");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            a[i] = new MerchantLoadProducts(0);
                            a[i].Pic = (byte[])dt.Rows[i]["photo"];
                            a[i].Name = dt.Rows[i]["name"].ToString();
                            a[i].Description = dt.Rows[i]["description"].ToString();
                            a[i].Price = dt.Rows[i]["price"].ToString();
                            a[i].productid = dt.Rows[i]["productid"].ToString();
                            a[i].cat = dt.Rows[i]["category"].ToString();
                            if (panelBuy.Controls.Count < 0)
                              panelBuy.Controls.Clear();
                           else
                                panelBuy.Controls.Add(a[i]);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry you don't have any product to sell!");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //when search text box entered it will also search the database (LIVE SEARCH)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        //when search box entered
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.TextAlign = (HorizontalAlignment)Left;
            textBox1.ForeColor = Color.Black;
        }

        //when search box leave
        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "Search items here";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.ForeColor = Color.LightGray;
        }

        //method that search the database 
        void search()
        {
            if(!textBox1.Text.Equals("Search items here")) { 
            string constr = "Server=YEABS;   database=Ecommerce; integrated security=true; ";
            MerchantBuy ab = new MerchantBuy();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("Exec spSearch @search", con);
                sqlCmd.Parameters.AddWithValue("@search", textBox1.Text);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                //dataGridView1.DataSource = dt;
                MerchantLoadProducts[] a = new MerchantLoadProducts[dt.Rows.Count];
                    panelBuy.Controls.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        a[i] = new MerchantLoadProducts();
                        a[i].Pic = (byte[])dt.Rows[i]["photo"];
                        a[i].Name = dt.Rows[i]["name"].ToString();
                        a[i].Description = dt.Rows[i]["description"].ToString();
                        a[i].Price = dt.Rows[i]["price"].ToString();
                        a[i].productid = dt.Rows[i]["productid"].ToString();
                        a[i].cat = dt.Rows[i]["category"].ToString();

                        if (panelBuy.Controls.Count < 0)
                            panelBuy.Controls.Clear();
                        else
                            panelBuy.Controls.Add(a[i]);
                    }
      
                }
            }
        }

        // Get the catagories that are available in the database
        public void GetCategory()
        {
            string[] category = null;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetCategory", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "tblCategory");
                DataTable dt = ds.Tables["tblCategory"];
                category = new string[dt.Rows.Count];
                DataRow row;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = dt.Rows[i];
                    category[i] = row["category"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (string cat in category)
            {
                comboBox1.Items.Add(cat);
            }
        }

        // When the combobox item changed products will be displayed that are in the specific category which is the selected  
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MerchantClass x = new MerchantClass();
            DataTable dt=null;
            if (comboBox1.Text.Equals("All"))
            {
                dt = x.Selected_Cat("");
            }
            else
                dt = x.Selected_Cat(comboBox1.Text);

            MerchantLoadProducts[] a = new MerchantLoadProducts[dt.Rows.Count];
            panelBuy.Controls.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i] = new MerchantLoadProducts();
                a[i].Pic = (byte[])dt.Rows[i]["photo"];
                a[i].Name = dt.Rows[i]["name"].ToString();
                a[i].Description = dt.Rows[i]["description"].ToString();
                a[i].Price = dt.Rows[i]["price"].ToString();

                if (panelBuy.Controls.Count < 0)
                    panelBuy.Controls.Clear();
                else
                    panelBuy.Controls.Add(a[i]);
            }
        }
    }
}
