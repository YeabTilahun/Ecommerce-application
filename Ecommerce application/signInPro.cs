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
    class signInPro : SignIn
    {
        public string SigninProccedure(SignInUser u)
        {
            string role = "No Role";
            string constr = "Server = JONNY; database = Ecommerce; integrated security = true;";

            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter("spLogin", con);
                    da.Fill(ds, "tableall");
                    DataTable dt = ds.Tables[0];
                    int flag = 0;

                    
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (u.username.CompareTo(dr["userName"]) == 0 && u.Password.CompareTo(dr["password"]) == 0)
                        {
                            
                            flag = 1;
                            
                            role = dr["role"].ToString();

                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        MessageBox.Show("Invalid UserName and Password ");

                        role = "No Role";
                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return role;
        }
    }
}