using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace Ecommerce_application
{
    class MerchantDatabase
    {
        public void connection()
        {
          

        }
        string constr = "Server=YEABS;   database=Ecommerce; integrated security=true; ";

        //Add Product
        public void AddProduct(MerchantClass sell)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spInsertProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", sell.productName);
                    cmd.Parameters.AddWithValue("@price", sell.price);
                    cmd.Parameters.AddWithValue("@quantity", sell.quantity);
                    cmd.Parameters.AddWithValue("@category", sell.category);
                    cmd.Parameters.AddWithValue("@description", sell.description);
                    cmd.Parameters.AddWithValue("@expireDate", sell.exDate);
                    cmd.Parameters.AddWithValue("@DateStamp", sell.stamp);
                    cmd.Parameters.AddWithValue("@Photo", sell.photo);
                    cmd.Parameters.AddWithValue("@merchantName", sell.user);
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("New product added sucessfully");
                    }
                    else
                        MessageBox.Show("Adding product failed! Try again.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Delete Product
        public void Delete(String id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spDeleteProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", id);
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Product deleted Sucessfully");
                    }
                    else
                        MessageBox.Show("Failed! Please try again.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Update Product
        public void UpdateProduct(MerchantClass sell)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", sell.productName);
                    cmd.Parameters.AddWithValue("@price", sell.price);
                    cmd.Parameters.AddWithValue("@quantity",sell.quantity);
                    cmd.Parameters.AddWithValue("@category", sell.category);
                    cmd.Parameters.AddWithValue("@description", sell.description);
                    cmd.Parameters.AddWithValue("@expireDate", sell.exDate);
                    cmd.Parameters.AddWithValue("@DateStamp", sell.stamp);
                    cmd.Parameters.AddWithValue("@Photo", sell.photo);
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Product Updated Sucessfully!");
       
                    }
                    else
                        MessageBox.Show("Failed! Please try again");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //GET ITEMS ACCORDING TO THE SELECTED CATEGORY
        public DataTable Selected_Cat(string category)
        {
            DataTable dt = null;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spSelected-cat-product", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@category", category);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    dt = ds.Tables["tblProduct"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        //Count the frequency of each products in a DataGridView
        private Dictionary<string, int> GetCountOfValues(string columnName)
        {
            string curKey = "";
            Dictionary<string, int> valuesAndCounts = new Dictionary<string, int>();
            foreach (DataGridViewRow row in Merchant.dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[columnName].Value != null)
                    {
                        curKey = row.Cells[columnName].Value.ToString();
                        if (valuesAndCounts.ContainsKey(curKey))
                        {
                            valuesAndCounts[curKey]++;
                        }
                        else
                        {
                            valuesAndCounts.Add(curKey, 1);
                        }
                    }
                }
            }
            return valuesAndCounts;
        }

        static string cat;
        static string price1;
        static string id1;
        static string qty;
        public void array(string id2)
        {
            string constr = "Server=YEABS;   database=Ecommerce; integrated security=true;";

            Dictionary<string, int> column_Counts = GetCountOfValues("id");

            Queue cate = new Queue();
            Queue price = new Queue();
            Queue id = new Queue();
            Queue Qty = new Queue();
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    foreach (KeyValuePair<string, int> kvp in column_Counts)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select category,price from product where productid=@id", con);
                        cmd.Parameters.AddWithValue("@id", id2);
                        SqlDataReader da = cmd.ExecuteReader();
                        while (da.Read())
                        {
                            cate.Enqueue(da.GetValue(0).ToString());
                            price.Enqueue(da.GetValue(1).ToString());
                            id.Enqueue(Convert.ToString(id2));
                            Qty.Enqueue(Convert.ToString(kvp.Value));
                        }
                        con.Close();
                    }
                   ;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
           // cat = new string[cate.Count];

            cat = (string)cate.Dequeue();

            price1 = (string)price.Dequeue();

            id1 = (string)id.Dequeue();

            qty = (string)Qty.Dequeue();
        }

        //Add traansaction information when buy clicked
       
        public void Transaction1(Label tot)
        {

            MerchantLoadProducts a = new MerchantLoadProducts();
            MerchantClass b = new MerchantClass();
            Dictionary<string, int> column_Counts = GetCountOfValues("id");
            string now = DateTime.Now.ToShortDateString();
            int rowAffected = 0;
            // float total = float.Parse(tot.Text, CultureInfo.InvariantCulture.NumberFormat);
            foreach (KeyValuePair<string, int> kvp in column_Counts)
            { }
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand();

                    for (int i = 0; i < Merchant.dataGridView2.Rows.Count; i++)
                    {
                        array(Merchant.dataGridView2.Rows[i].Cells["id"].Value.ToString());
                        cmd = new SqlCommand("spTransaction", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@user_name", Merchant.name);
                        cmd.Parameters.AddWithValue("@productID", Merchant.dataGridView2.Rows[i].Cells["id"].Value);
                        
                        cmd.Parameters.AddWithValue("@totalPrice", price1);
                        cmd.Parameters.AddWithValue("@category", cat);
                        cmd.Parameters.AddWithValue("@date", now);
                        cmd.Parameters.AddWithValue("@quantity", qty);
                        rowAffected = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Our partner Addis Delivery will contact you in a moment through your mobile number.");
                        MessageBox.Show("Thank you for using our application!");
                    }
                    else
                        MessageBox.Show("Something is wrong with our server please restart the application.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
/*        public void Transaction(Label tot)
        {

            MerchantLoadProducts a = new MerchantLoadProducts();
            MerchantClass b = new MerchantClass();
            Dictionary<string, int> column_Counts = GetCountOfValues("id");
            string now = DateTime.Now.ToShortDateString();
            // float total = float.Parse(tot.Text, CultureInfo.InvariantCulture.NumberFormat);
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spTransaction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    

                    foreach (KeyValuePair<string, int> kvp in column_Counts)
                    {
                    cmd.Parameters.AddWithValue("@user_name", Merchant.name);
                    cmd.Parameters.AddWithValue("@productID", kvp.Key);
                    cmd.Parameters.AddWithValue("@quantity", kvp.Value);
                       // for (int i = 0; i < price1.Length; i++)
                       // {
                            cmd.Parameters.AddWithValue("@totalPrice", price1[1]);
                       // }

                       // for (int i = 0; i < cat.Length; i++)
                        //{
                        cmd.Parameters.AddWithValue("@category", cat[1]);
                     //   }

                    cmd.Parameters.AddWithValue("@date",now);
                    }

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Our partner Addis Delivery will contact you in a moment through your mobile number.");
                        MessageBox.Show("Thank you for using our application!");
                    }
                    else
                        MessageBox.Show("Something is wrong with our server please restart the application.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            *//*Merchant.dataGridView2.Columns.Add("name", "Product Name");
            Merchant.dataGridView2.Columns.Add("Price", "Price");
            for (int i = 0; i < Merchant.dataGridView2.Rows.Count; i++)
            {
                Merchant.dataGridView2.Rows.Add(GetCountOfValues("Product Name"), GetCountOfValues("Price"));
            }

            Dictionary<string, int> column_Counts = GetCountOfValues("id");
            foreach (KeyValuePair<string, int> kvp in column_Counts) { Merchant.textBox1.Text += string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value); }*//*

        }*/