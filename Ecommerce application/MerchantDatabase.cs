using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Ecommerce_application
{
    class MerchantDatabase
    {
        public void connection()
        {
          

        }
        string constr = "Server=YEABS;   database=Ecommerce; integrated security=true; ";
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

 /*       public void Getproduct(String user)
        {
            MyProduct c = new MyProduct();
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetProduct", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@name", user);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    DataTable dt = ds.Tables["tblProduct"];
                    if (dt != null)
                    {
                        LoadItems[] a = new LoadItems[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            a[i] = new LoadItems();
                            a[i].Pic = (byte[])dt.Rows[i]["photo"];
                            a[i].Name = dt.Rows[i]["name"].ToString();
                            a[i].Description = dt.Rows[i]["description"].ToString();
                            a[i].Price = string.Format("${0}.00", dt.Rows[i]["price"].ToString());

                            if (c.flowLayoutPanel1.Controls.Count < 0)
                                c.flowLayoutPanel1.Controls.Clear();
                            else
                                c.flowLayoutPanel1.Controls.Add(a[i]);

                        }
                    }
                    else
                    {
                        Label show = new Label();
                        show.Text = "You don't have any added products.";
                        show.ForeColor = Color.DarkGray;
                        show.Size = new Size(120, 25);
                        c.flowLayoutPanel1.Controls.Add(show);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }*/

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


        //
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
    }
}
