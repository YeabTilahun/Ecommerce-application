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
        public ChangePassword(string ema)
        {
            username = ema;
        }
        public ChangePassword( string pass, string conf)
        {
            password = pass;
            confirm = conf;
        }
        Connection c = new Connection();
        public int checkEmail()
        {
            // string constr = "Server = JONNY; database = ecommerce; integrated security = true;";
           
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

                            flag = 1;

                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        MessageBox.Show("Invalid UserName!TRY AGAIN");
                    }


                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return flag;
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
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}