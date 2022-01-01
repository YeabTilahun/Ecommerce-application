using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    class CustomerDatabase
    {
        string constr = "Server = 7.85.43.111;   Database = Ecommerce; Uid=sa; Pwd=12345; ";
        //giving productID by ourselves  BUT MID WILL BE UPDATED!!
        static int mid = 1, pid = 1;

        public void Delete(String id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CustDelete", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productid", id);
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

        public void UpdateProduct(CustomerClass buy)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CustUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@productid", buy.Id);
                    cmd.Parameters.AddWithValue("@name", buy.ProductName);
                    cmd.Parameters.AddWithValue("@price", buy.Price);
                    cmd.Parameters.AddWithValue("@quantity", buy.Quantity);
                    cmd.Parameters.AddWithValue("@description", buy.Description);
                    cmd.Parameters.AddWithValue("@category", buy.Category);
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
    }
}
