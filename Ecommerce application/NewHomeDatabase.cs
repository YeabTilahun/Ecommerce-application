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
    class NewHomeDatabase
    {
        string constr = "Server = LAPTOP-RS59N8IM; database = Ecommerce; integrated security = true;";
        Connection connect = new Connection();
        public void SaveUser(NewHomeClass hc)
        {
            using (SqlConnection con = connect.CreateConnection())
            {
                con.Open();
                string query = "INSERT INTO tblUser VALUES ('" + hc.id + "','" + hc.FirstName + "','" + hc.LastName + "','" + hc.Username + "','" + hc.Password + "','" + hc.photo + "', '"  + hc.Phone + "' , '" + hc.Email + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                    MessageBox.Show("Save Successful");
                con.Close();

            }
        }

        public void SaveUserByStoredProc(NewHomeClass hc)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spInsertCustomer", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", hc.id);
                    cmd.Parameters.AddWithValue("@fname", hc.FirstName);
                    cmd.Parameters.AddWithValue("@lname", hc.LastName);
                    cmd.Parameters.AddWithValue("@userName", hc.Username);
                    cmd.Parameters.AddWithValue("@password", hc.Password);
                    cmd.Parameters.AddWithValue("@phone", hc.Phone);
                    cmd.Parameters.AddWithValue("@email ", hc.Email);
                    //cmd.Parameters.AddWithValue("@role", u.role);
                    cmd.Parameters.AddWithValue("@photo", hc.photo);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                        MessageBox.Show("Save Successfully!!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void DeleteUserByStoredProc(string id)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spDeleteUser", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                        MessageBox.Show("Deleted Successfully!!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateUserByStoredProc(NewHomeClass u)
        {
            try
            {
                using (SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateUser", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", u.id);
                    cmd.Parameters.AddWithValue("@firstname", u.FirstName);
                    cmd.Parameters.AddWithValue("@fathername", u.LastName);
                    cmd.Parameters.AddWithValue("@username", u.Username);
                    cmd.Parameters.AddWithValue("@password", u.Password);
                    cmd.Parameters.AddWithValue("@photo", u.photo);

                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                        MessageBox.Show("Updated Successfully!!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable getUser(string fn, string ln)
        {
            SqlConnection con = connect.CreateConnection();
            SqlDataAdapter da = new SqlDataAdapter("spGetUser", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@fn", fn);
            da.SelectCommand.Parameters.AddWithValue("@ln", ln);
            DataSet ds = new DataSet();
            da.Fill(ds, "tblUser");
            DataTable dt = ds.Tables["tblUser"];
            return dt;
        }

        public DataTable CustomerProductCategory(string category, string name)
        {
            DataTable dt = null;
            try
            {
                using(SqlConnection con = connect.CreateConnection())
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetProduct", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@name", name);
                    da.SelectCommand.Parameters.AddWithValue("@category", category);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    dt = ds.Tables["tblProduct"];
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
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
                   /* LoadItems[] a = new LoadItems[dt.Rows.Count];
                    //home.resize();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        a[i] = new LoadItems();
                        a[i].Pic = (byte[])dt.Rows[i]["photo"];
                        a[i].Name = dt.Rows[i]["name"].ToString();
                        a[i].Description = dt.Rows[i]["description"].ToString();
                        a[i].Price = string.Format(dt.Rows[i]["price"].ToString());

                        if (home.flowLayoutPanel1.Controls.Count < 0)
                            home.flowLayoutPanel1.Controls.Clear();
                        else
                            home.flowLayoutPanel1.Controls.Add(a[i]);
                    }*/

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
