using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Ecommerce_application
{
    class MerchantDatabase
    {
        public void connection()
        {
          

        }
        string constr = "Server=YEABS;   database=Ecommerce; integrated security=true; ";
        //giving productID by ourselves  BUT MID WILL BE UPDATED!!
        static  int mid = 1, pid = 1;
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
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("New product added sucessfully");
                        mid++;
                        pid++;
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

        public DataTable getUser()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("select photo,name,description from product", con);


            DataSet ds = new DataSet();
            da.Fill(ds, "product");
            DataTable dt = ds.Tables["product"];
            return dt;

        }
    }
}
