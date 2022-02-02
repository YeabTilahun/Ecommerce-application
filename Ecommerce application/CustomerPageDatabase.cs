using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ecommerce_application
{
    class CustomerPageDatabase
    {

        string cat;
        string price1;
        string id1;
        string qty;
        Connection connect = new Connection();
        CustomerPage cp = new CustomerPage();
        public void array(string id2)
        {
            Dictionary<string, int> column_Counts = cp.GetCountOfValues("id");
            try
            {

                using (SqlConnection con = connect.CreateConnection())
                {
                    foreach (KeyValuePair<string, int> kvp in column_Counts)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("Select category,price from product where productid=@id", con);
                        cmd.Parameters.AddWithValue("@id", id2);
                        SqlDataReader da = cmd.ExecuteReader();
                        while (da.Read())
                        {
                            cat = da.GetValue(0).ToString();
                            price1 = da.GetValue(1).ToString();
                            id1 = Convert.ToString(id2);
                            qty = Convert.ToString(kvp.Value);
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
        }

        public void Transaction1()
        {
            int counter = 0;
            CustomerLoadProduct a = new CustomerLoadProduct();
            Dictionary<string, int> column_Counts = cp.GetCountOfValues("id");
            DataTable dt;
            string now = DateTime.Now.ToShortDateString();
            int rowAffected = 0;
            try
            {
                foreach (KeyValuePair<string, int> kvp in column_Counts)
                {
                    using (SqlConnection con = connect.CreateConnection())
                    {

                        SqlDataAdapter da = new SqlDataAdapter("spGetProductImageAndName", con);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.AddWithValue("@id", int.Parse(kvp.Key));
                        DataSet ds = new DataSet();
                        da.Fill(ds, "tblProfile");
                        dt = ds.Tables["tblProfile"];
                        if (int.Parse(dt.Rows[0]["quantity"].ToString()) < kvp.Value && !Convert.IsDBNull(dt.Rows[0]["quantity"]))
                        {
                            MessageBox.Show("There is no Efficent Quantity by {0} Product in our store", dt.Rows[0]["name"].ToString());
                            counter++;
                            continue;
                        }
                    }
                    using (SqlConnection con = connect.CreateConnection())
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("spTransaction", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@user_name", Merchant.name);
                        cmd.Parameters.AddWithValue("@productID", kvp.Key);

                        cmd.Parameters.AddWithValue("@totalPrice", (kvp.Value * double.Parse(dt.Rows[0]["price"].ToString())));
                        cmd.Parameters.AddWithValue("@category", dt.Rows[0]["category"].ToString());
                        cmd.Parameters.AddWithValue("@date", now);
                        cmd.Parameters.AddWithValue("@quantity", kvp.Value.ToString());
                        rowAffected = cmd.ExecuteNonQuery();
                    }
                    using (SqlConnection con = connect.CreateConnection())
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("spUpdateQuanity", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@productId", int.Parse(kvp.Key));
                        cmd.Parameters.AddWithValue("@qty", (double.Parse(dt.Rows[0]["quantity"].ToString()) - kvp.Value).ToString());
                        rowAffected = cmd.ExecuteNonQuery();
                    }
                }
                if (rowAffected > 0)
                {
                    MessageBox.Show("Our partner Addis Delivery will contact you in a moment through your mobile number.");
                    MessageBox.Show("Thank you for using our application!");
                }
                else
                    MessageBox.Show("You don't have any product to buy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public DataTable PopulateItem()
        {
            DataTable dt = null;
            //Home home = new Home();
            //string constr = "Server = LAPTOP-RS59N8IM;   Database = Ecommerce; integrated security=true";
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spLoad_data", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    dt = ds.Tables["tblProduct"];
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dt;
        }
    }
}
