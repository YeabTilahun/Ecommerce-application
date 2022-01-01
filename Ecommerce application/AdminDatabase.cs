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
    class AdminDatabase
    {
        string constr = "Server = DESKTOP-4370VSE;   Database = Ecommerce; integrated security=true";

        public void SaveAdmin(AdminRegisterClass ar)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spInsertAdmin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fname", ar.firstName);
                    cmd.Parameters.AddWithValue("@lname", ar.lastName);
                    cmd.Parameters.AddWithValue("@phone", ar.phoneNumber);
                    cmd.Parameters.AddWithValue("@birthday", ar.birthday);
                    cmd.Parameters.AddWithValue("@sex", ar.sex);
                    cmd.Parameters.AddWithValue("@email", ar.email);
                    cmd.Parameters.AddWithValue("@userName", ar.userName);
                    cmd.Parameters.AddWithValue("@password", ar.password);
                    cmd.Parameters.AddWithValue("@role", ar.role);
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Admin Inserted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed! Please Try Again");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateAdmin(AdminRegisterClass ar)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateAdmin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@adminID", ar.adminID);
                    cmd.Parameters.AddWithValue("@fname", ar.firstName);
                    cmd.Parameters.AddWithValue("@lname", ar.lastName);
                    cmd.Parameters.AddWithValue("@phone", ar.phoneNumber);
                    cmd.Parameters.AddWithValue("@birthday", ar.birthday);
                    cmd.Parameters.AddWithValue("@sex", ar.sex);
                    cmd.Parameters.AddWithValue("@email", ar.email);
                    cmd.Parameters.AddWithValue("@userName", ar.userName);
                    cmd.Parameters.AddWithValue("@password", ar.password);
                    cmd.Parameters.AddWithValue("@role", ar.role);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Admin Inserted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed! Please Try Again");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteAdmin(string[] id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    int rowAffected = 0;
                    con.Open();
                    for (int i = 0; i < id.Length; i++)
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteAdmin", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@adminID", id[i]);

                        rowAffected = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    if (rowAffected > 0 && id.Length > 1)
                    {
                        MessageBox.Show("Admins Deleted Successfully");
                    }
                    else if(rowAffected > 0)
                    {
                        MessageBox.Show("Admin Deleted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed! Please Try Again");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable GetAdmin(string name)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("spGetAdmin", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@name", name);
            DataSet ds = new DataSet();
            da.Fill(ds, "tblAdmin");
            DataTable dt = ds.Tables["tblAdmin"];
            return dt;

        }

        public string[] GetAdminProfile()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("spGetAdminProfile", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@userName", Admin.userName);
            da.SelectCommand.Parameters.AddWithValue("@password", Admin.password);
            da.SelectCommand.Parameters.AddWithValue("@role", Admin.role);
            DataSet ds = new DataSet();
            da.Fill(ds, "tblProfile");
            DataTable dt = ds.Tables["tblProfile"];
            string[] profile = new string[dt.Columns.Count];
            profile[0] = dt.Rows[0]["adminID"].ToString();
            profile[1] = dt.Rows[0]["fname"].ToString();
            profile[2] = dt.Rows[0]["lname"].ToString();
            profile[3] = dt.Rows[0]["phone"].ToString();
            profile[4] = dt.Rows[0]["birthday"].ToString();
            profile[5] = dt.Rows[0]["sex"].ToString();
            profile[6] = dt.Rows[0]["email"].ToString();
            profile[7] = dt.Rows[0]["userName"].ToString();
            profile[8] = dt.Rows[0]["password"].ToString();
            profile[9] = dt.Rows[0]["role"].ToString();
            return profile;
        }

        public void DeleteProduct(string[] id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    int rowAffected = 0;
                    con.Open();
                    for (int i = 0; i < id.Length; i++)
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteProduct", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pid", id[i]);

                        rowAffected = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    if (rowAffected > 0 && id.Length > 1)
                    {
                        MessageBox.Show("Products Deleted Successfully");
                    }
                    else if (rowAffected > 0)
                    {
                        MessageBox.Show("Product Deleted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed! Please Try Again");
                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable GetProduct(string name)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("spGetProduct", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@name", name);
            DataSet ds = new DataSet();
            da.Fill(ds, "tblProduct");
            DataTable dt = ds.Tables["tblProduct"];
            return dt;

        }

        public void DeleteCustomer(string[] id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    int rowAffected = 0;
                    con.Open();
                    for (int i = 0; i < id.Length; i++)
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id[i]);

                        rowAffected = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    if (rowAffected > 0 && id.Length > 1)
                    {
                        MessageBox.Show("Customers Deleted Successfully");
                    }
                    else if (rowAffected > 0)
                    {
                        MessageBox.Show("customer Deleted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed! Please Try Again");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable GetCustomer(string name)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("spGetCustomer", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@name", name);
            DataSet ds = new DataSet();
            da.Fill(ds, "tblCustomer");
            DataTable dt = ds.Tables["tblCustomer"];
            return dt;
        }

        public void DeleteMerchant(string[] id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    int rowAffected = 0;
                    con.Open();
                    for (int i = 0; i < id.Length; i++)
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteMerchant", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id[i]);

                        rowAffected = cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    if (rowAffected > 0 && id.Length > 1)
                    {
                        MessageBox.Show("Merchants Deleted Successfully");
                    }
                    else if (rowAffected > 0)
                    {
                        MessageBox.Show("Merchant Deleted Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Failed! Please Try Again");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable GetMerchant(string name)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("spGetMerchant", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@name", name);
            DataSet ds = new DataSet();
            da.Fill(ds, "tblMerchant");
            DataTable dt = ds.Tables["tblMerchant"];
            return dt;

        }

        public DataTable GetTransaction()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("spGetTransaction", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds, "tblTransaction");
            DataTable dt = ds.Tables["tblTransaction"];
            return dt;

        }
        public string[] GetCategory()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("spGetCategory", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.Fill(ds, "tblCategory");
            DataTable dt = ds.Tables["tblCategory"];
            string[] category = new string[dt.Rows.Count];
            DataRow row;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = dt.Rows[i];
                category[i] = row["category"].ToString();
            }
            return category;
        }

        public DataTable GetProductByCategory(string category)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("spGetProductByCategory", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@category", category);
            DataSet ds = new DataSet();
            da.Fill(ds, "tblProduct");
            DataTable dt = ds.Tables["tblProduct"];
            return dt;

        }
    }
}
