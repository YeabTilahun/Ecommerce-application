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
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetAdmin", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@name", name);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblAdmin");
                dt = ds.Tables["tblAdmin"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;

        }

        public DataTable GetAdminProfile()
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetAdminProfile", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@userName", Admin.userName);
                da.SelectCommand.Parameters.AddWithValue("@password", Admin.password);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblProfile");
                dt = ds.Tables["tblProfile"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
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

        public DataTable GetProduct(string name, string category)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetProduct", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@name", name);
                da.SelectCommand.Parameters.AddWithValue("@category", category);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblProduct");
                dt = ds.Tables["tblProduct"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public DataTable GetLatestProduct(string name, string category)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetLatestProduct", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@name", name);
                da.SelectCommand.Parameters.AddWithValue("@category", category);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblProduct");
                dt = ds.Tables["tblProduct"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetCustomer", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@name", name);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblCustomer");
                dt = ds.Tables["tblCustomer"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetMerchant", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@name", name);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblMerchant");
                dt = ds.Tables["tblMerchant"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;

        }

        public DataTable GetTransaction()
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetTransaction", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "tblTransaction");
                dt = ds.Tables["tblTransaction"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;

        }
        public string[] GetCategory()
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
            return category;
        }
        
        public string[] GetLatestCategory()
        {
            string[] category = null;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetLatestCategory", con);
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
            return category;
        }

        /*public DataTable GetProductByCategory(string category)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetProductByCategory", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@category", category);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblProduct");
                dt = ds.Tables["tblProduct"];
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;

        }*/

        public string[] GetMonthlySold(int month)
        {
            string[] product = new string[3];
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetMontlySold", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@month", month);
                DataSet ds = new DataSet();
                da.Fill(ds, "tblList");
                DataTable dt = ds.Tables["tblList"];
                if (dt.Rows.Count > 0)
                {
                    double[] products = new double[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        products[i] = double.Parse(dt.Rows[i]["quantity"].ToString());
                    }
                    int x = Array.IndexOf(products, products.Max());
                    SqlDataAdapter da1 = new SqlDataAdapter("spGetProductImageAndName", con);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da1.SelectCommand.Parameters.AddWithValue("@id", dt.Rows[x]["productID"]);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "tblProduct");
                    DataTable dt1 = ds1.Tables["tblProduct"];
                    product[0] = dt1.Rows[0]["name"].ToString();
                    product[1] = dt.Rows[x]["quantity"].ToString();
                    product[2] = dt.Rows[x]["total"].ToString();
                }
                else
                {
                    product[0] = "No Product";
                    product[1] = "0";
                    product[2] = "0";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return product;
        }

        public double GetMonthlyIncome()
        {
            double income = 0;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetMonthlyIncome", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "tblList");
                DataTable dt = ds.Tables["tblList"];
                if(dt.Rows.Count > 0)
                    income = double.Parse(dt.Rows[0]["total"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return income;
        }

        public double GetYearlyIncome()
        {
            double income = 0;
            try
            {
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter("spGetYearlyIncome", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "tblList");
                DataTable dt = ds.Tables["tblList"];
                if (dt.Rows.Count > 0)
                    income = double.Parse(dt.Rows[0]["total"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return income;
        }
    }
}
