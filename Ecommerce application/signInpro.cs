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
    class signInpro : SignIn
    {
        public void SigninProccedure(SignInUser u)
        {

            string constr = "Server = JONNY; database = Ecommerce; integrated security = true;";
            SqlCommand cmd;
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    if (u.role == "Customer") { 
                        con.Open();
                     cmd = new SqlCommand("spLogIn", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                   
                    
                        cmd.Parameters.AddWithValue("@unamec", u.username);
                        cmd.Parameters.AddWithValue("@passwordc", u.Password);
                        // cmd.Parameters.AddWithValue("@role", u.role);

                        int rowAffected = cmd.ExecuteNonQuery();
                        con.Close();
                        if (rowAffected <= 0)
                        {
                            label7.Visible = true;
                        }
                        CustomerPage c = new CustomerPage();
                        c.Show();
                       
                    }
                    else if (u.role == "Merchant")
                    {
                        con.Open();
                        cmd = new SqlCommand("spLoginM", con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@unamem", u.username);
                        cmd.Parameters.AddWithValue("@passwordm", u.Password);
                        int rowAffected = cmd.ExecuteNonQuery();
                        con.Close();
                        if (rowAffected <= 0)
                        {
                            label7.Visible = true;
                        }
                        Merchant m = new Merchant();
                        m.Show();
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
