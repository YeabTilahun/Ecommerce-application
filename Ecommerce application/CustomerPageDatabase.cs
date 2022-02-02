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
            CustomerLoadProduct a = new CustomerLoadProduct();
            Dictionary<string, int> column_Counts = cp.GetCountOfValues("id");
            string now = DateTime.Now.ToShortDateString();
            int rowAffected = 0;
            foreach (KeyValuePair<string, int> kvp in column_Counts)
            { }
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand();

                    for (int i = 0; i < CustomerPage.dataGridView2.Rows.Count; i++)
                    {
                        array(CustomerPage.dataGridView2.Rows[i].Cells["id"].Value.ToString());
                        cmd = new SqlCommand("spTransaction", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@user_name", CustomerPage.name);
                        cmd.Parameters.AddWithValue("@productID", CustomerPage.dataGridView2.Rows[i].Cells["id"].Value);

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
                        MessageBox.Show("You don't have any product to buy");
                }
            }
            catch (SqlException ex)
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
