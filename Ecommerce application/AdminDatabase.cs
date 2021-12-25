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
        string constr = "Server = DESKTOP-4370VSE; database = Ecommerce; integrated security = true;";

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
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spDeleteAdmin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@adminID", id);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
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

        public void DeleteProduct(string[] id)
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
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spDeleteCustomer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Customer Deleted Successfully");
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
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spDeleteMerchant", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
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
    }
}
