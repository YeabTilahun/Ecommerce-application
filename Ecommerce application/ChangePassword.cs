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
    class ChangePassword
    {
        private static string username;
        private string password;
        private string confirm;
        private string role;
        public ChangePassword(string ema)
        {
            username = ema;
        }
        public ChangePassword( string pass, string conf, string role)
        {
            password = pass;
            confirm = conf;
            this.role = role;
        }
        Connection c = new Connection();
        public string checkEmail()
        {
            // string constr = "Server = JONNY; database = ecommerce; integrated security = true;";
            string role="";
            int flag = 0;
            try
            {
                using (SqlConnection con = c.CreateConnection())
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter("spLogin", con);
                    da.Fill(ds, "tableall");
                    DataTable dt = ds.Tables[0];



                    foreach (DataRow dr in dt.Rows)
                    {
                        if (username.CompareTo(dr["userName"]) == 0)
                        {

                            role =Convert.ToString( dr["role"]);
                            flag =1;
                            break;
                        }
                    }
                    if (flag==0)
                    {
                        MessageBox.Show("Invalid UserName!TRY AGAIN");
                    }


                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return role;
        }
        public void checkPassword()
        {
            if (password.CompareTo(confirm) == 0)
            {
                //string constr = "Server = JONNY; database = ecommerce; integrated security = true;";
                try
                {
                    using (SqlConnection con = c.CreateConnection())
                    {
                        con.Open();
                        if (role == "Customer")
                        {
                            SqlCommand cmd = new SqlCommand("spchangePassC", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@pass", password);
                            cmd.Parameters.AddWithValue("@username", username);
                            int rowAffected = cmd.ExecuteNonQuery();
                            con.Close();
                            if (rowAffected > 0)
                            {
                                MessageBox.Show("New password added sucessfully");
                            }
                            else
                                MessageBox.Show("changing password failed! Try again.");
                        }
                       else if (role == "Merchant")
                        {
                            SqlCommand cmd = new SqlCommand("spchangePassM", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@pass", password);
                            cmd.Parameters.AddWithValue("@username", username);
                            int rowAffected = cmd.ExecuteNonQuery();
                            con.Close();
                            if (rowAffected > 0)
                            {
                                MessageBox.Show("New password added sucessfully");
                            }
                            else
                                MessageBox.Show("changing password failed! Try again.");
                        }
                       else 
                        {
                            SqlCommand cmd = new SqlCommand("spchangePassA", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@pass", password);
                            cmd.Parameters.AddWithValue("@username", username);
                            int rowAffected = cmd.ExecuteNonQuery();
                            con.Close();
                            if (rowAffected > 0)
                            {
                                MessageBox.Show("New password added sucessfully");
                            }
                            else
                                MessageBox.Show("changing password failed! Try again.");
                        }
                        if (role == "Customer" || role == "Merchant" || role == "Admin")
                        {
                            if (role == "Customer")
                            {
                                SqlCommand cmd = new SqlCommand("spcheckPass", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@pass", password);
                                cmd.Parameters.AddWithValue("@username", username);
                                int rowAffected = cmd.ExecuteNonQuery();
                                con.Close();
                                if (rowAffected > 0)
                                {
                                    MessageBox.Show("New password added sucessfully");
                                }
                                else
                                    MessageBox.Show("changing password failed! Try again.");
                            }
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
}