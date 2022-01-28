using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace Ecommerce_application
{
    class SignUpPro
    {
        public void signUpProccedure(SignUpUser u)
        {
            string constr = "Server = JONNY; database = ecommerce; integrated security = true;";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    if (u.role == "customer" || u.role == "Customer")
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("spSignup", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@firstname", u.firstName);
                        cmd.Parameters.AddWithValue("@lastname", u.fatherName);
                        cmd.Parameters.AddWithValue("@username", u.userName);
                        cmd.Parameters.AddWithValue("@password", u.password);
                        cmd.Parameters.AddWithValue("@role", u.role);
                        cmd.Parameters.AddWithValue("@phone", u.phone);
                        cmd.Parameters.AddWithValue("@email", u.email);
                        cmd.Parameters.AddWithValue("@customID", 1);
                        cmd.Parameters.AddWithValue("@sex", "male");
                      //  cmd.Parameters.AddWithValue("@birthday", u.birthday);
                        int rowAffected = cmd.ExecuteNonQuery();
                        con.Close();
                        if (rowAffected > 0)
                            MessageBox.Show("signed up succesfully! ");

                    }
                    else if (u.role == "merchant")
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("spSignUpmer", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@firstname", u.firstName);
                        cmd.Parameters.AddWithValue("@lastname", u.fatherName);
                        cmd.Parameters.AddWithValue("@username", u.userName);
                        cmd.Parameters.AddWithValue("@password", u.password);
                        cmd.Parameters.AddWithValue("@role", u.role);
                        cmd.Parameters.AddWithValue("@phone", u.phone);
                        cmd.Parameters.AddWithValue("@email", u.email);
                        //cmd.Parameters.AddWithValue("@birthday", u.birthday);
                        int rowAffected = cmd.ExecuteNonQuery();
                        con.Close();
                        if (rowAffected > 0)
                            MessageBox.Show("signed up succesfully! ");

                    }
                    else
                        MessageBox.Show("signing up failed! ");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}