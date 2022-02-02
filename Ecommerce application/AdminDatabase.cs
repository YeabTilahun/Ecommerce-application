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
        //string constr = "Server = DESKTOP-4370VSE;   Database = Ecommerce; integrated security=true";
        Connection connect = new Connection();
        
        public void SaveAdmin(AdminClass ar)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
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
                    cmd.Parameters.AddWithValue("@photo", ar.photo);
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

        public void UpdateAdmin(AdminClass ar)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateAdmin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@adminID", int.Parse(ar.adminID));
                    cmd.Parameters.AddWithValue("@fname", ar.firstName);
                    cmd.Parameters.AddWithValue("@lname", ar.lastName);
                    cmd.Parameters.AddWithValue("@phone", ar.phoneNumber);
                    cmd.Parameters.AddWithValue("@birthday", ar.birthday);
                    cmd.Parameters.AddWithValue("@sex", ar.sex);
                    cmd.Parameters.AddWithValue("@email", ar.email);
                    cmd.Parameters.AddWithValue("@userName", ar.userName);
                    cmd.Parameters.AddWithValue("@password", ar.password);
                    cmd.Parameters.AddWithValue("@role", ar.role);
                    cmd.Parameters.AddWithValue("@photo", ar.photo);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Admin Updated Successfully");
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

        public void ChangePassword(AdminClass ar)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spChangePassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@adminID", int.Parse(ar.adminID));
                    cmd.Parameters.AddWithValue("@password", ar.password);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Password Changed Successfully");
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

        public void ChangePasswordTblAll(AdminClass ar)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spChangePasswordTblAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@adminID", int.Parse(ar.adminID));
                    cmd.Parameters.AddWithValue("@password", ar.password);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Password Changed Successfully to All");
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
                SqlConnection con = connect.CreateConnection();
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
                SqlConnection con = connect.CreateConnection();
                SqlDataAdapter da = new SqlDataAdapter("spGetAdminProfile", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@userName", Admin.userName);
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

        public DataTable GetProduct(string name, string category)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = connect.CreateConnection();
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
                SqlConnection con = connect.CreateConnection();
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

        public DataTable GetCustomer(string name)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = connect.CreateConnection();
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

        public DataTable GetMerchant(string name)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = connect.CreateConnection();
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
                SqlConnection con = connect.CreateConnection();
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
                SqlConnection con = connect.CreateConnection();
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
                SqlConnection con = connect.CreateConnection();
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

        public string[] GetMonthlySold(int month)
        {
            string[] product = new string[3];
            try
            {
                SqlConnection con = connect.CreateConnection();
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
            catch (Exception ex)
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
                SqlConnection con = connect.CreateConnection();
                SqlDataAdapter da = new SqlDataAdapter("spGetMonthlyIncome", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "tblList");
                DataTable dt = ds.Tables["tblList"];
                if (dt.Rows.Count > 0 && !Convert.IsDBNull(dt.Rows[0]["total"]))
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
                SqlConnection con = connect.CreateConnection();
                SqlDataAdapter da = new SqlDataAdapter("spGetYearlyIncome", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "tblList");
                DataTable dt = ds.Tables["tblList"];
                if (dt.Rows.Count > 0 && !Convert.IsDBNull(dt.Rows[0]["total"]))
                    income = double.Parse(dt.Rows[0]["total"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return income;
        }

        public string[] GetMonth()
        {
            SqlConnection con = connect.CreateConnection();
            DataSet ds = new DataSet();
            DataTable dt = null;
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("spGetMonth", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds, "tblNum");
                dt = ds.Tables["tblNum"];
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            string[] month = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                month[i] = dt.Rows[i]["month"].ToString();
            }
            return month;
        }

        public string[] GetCategoryTransaction()
        {
            SqlConnection con = connect.CreateConnection();
            DataSet ds = new DataSet();
            DataTable dt = null;
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("spGetCategroyTransaction", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds, "tbltrans");
                dt = ds.Tables["tbltrans"];
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            string[] category = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                category[i] = dt.Rows[i]["category"].ToString();
            }
            return category;
        }

        public DataSet GetYearlyReport(string category)
        {
            SqlConnection con = connect.CreateConnection();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("spGetYearlyReport", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@category", category);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet GetMonthlyReport(string category, int month)
        {
            SqlConnection con = connect.CreateConnection();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("spGetMonthlyReport", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@category", category);
                da.SelectCommand.Parameters.AddWithValue("@month", month);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet GetWeeklyReport(string category)
        {
            SqlConnection con = connect.CreateConnection();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("spGetWeeklyReport", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@category", category);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataSet GetDailyReport(string category)
        {
            SqlConnection con = connect.CreateConnection();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("spGetDailyReport", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@category", category);
                da.Fill(ds);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ds;
        }

        public DataTable GetProductImageAndName(string ID)
        {
            DataTable dt = null;
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetProductImageAndName", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@id", ID);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProfile");
                    dt = ds.Tables["tblProfile"];
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public DataTable GetProductYearlyReport(string category)
        {
            DataTable dt = null;
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetProductYearlyReport", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@category", category);
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

        public DataTable GetProductMonthlyReport(string category, int month)
        {
            DataTable dt = null;
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetProductMonthlyReport", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@category", category);
                    da.SelectCommand.Parameters.AddWithValue("@month", month);
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

        public DataTable GetProductWeeklyReport(string category)
        {
            DataTable dt = null;
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetProductWeeklyReport", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@category", category);
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

        public DataTable GetProductDailyReport(string category)
        {
            DataTable dt = null;
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetProductDailyReport", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@category", category);
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

        public DataTable GetPermit(string userName)
        {
            DataTable dt = null;
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetPermit", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@userName", userName);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblMerchant");
                    dt = ds.Tables["tblMerchant"];
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public DataTable GetValidMerchant(string name)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = connect.CreateConnection();
                SqlDataAdapter da = new SqlDataAdapter("spGetValidMerchant", con);
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

        public DataTable GetProgressMerchant(string name)
        {
            DataTable dt = null;
            try
            {
                SqlConnection con = connect.CreateConnection();
                SqlDataAdapter da = new SqlDataAdapter("spGetProgressMerchant", con);
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

        public void AddToAll(string userName, string password, string role)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spAddToAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        //MessageBox.Show("Merchant Accepted");
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

        public void UpdateStatus(string userName, string status)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateStatus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@status", status);
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        if(status.Equals("Active"))
                            MessageBox.Show("Merchant status has been Active");
                        else
                            MessageBox.Show("Merchant status has been Rejected");
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
    }
}
