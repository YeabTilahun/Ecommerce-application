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
            choose(i);
        }
        public MerchantBuy()
        {

        }

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
                        a[i] = new MerchantLoadProducts();
                        /*SqlDataAdapter da1 = new SqlDataAdapter("spLoad_data", con);
                        da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da1.SelectCommand.Parameters.AddWithValue("@productid", dt.Rows[i]["productid"]);
                        DataSet ds1 = new DataSet();
                        da1.Fill(ds1, "tblproduct");
                        DataTable dt1 = ds1.Tables["tblproduct"];*/
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
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
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

        //when search text box entered 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.TextAlign = (HorizontalAlignment)Left;
            textBox1.ForeColor = Color.Black;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "Search items here";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.ForeColor = Color.LightGray;
        }
        //

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

                        if (panelBuy.Controls.Count < 0)
                            panelBuy.Controls.Clear();
                        else
                            panelBuy.Controls.Add(a[i]);
                    }
      
                }
            }
        }

    }
}
