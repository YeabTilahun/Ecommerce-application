using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class MerchantChangePassword : Form
    {
        public MerchantChangePassword()
        {
            InitializeComponent();
        }


        //Fetch old password to check
        string oldPassword;
        string constr = "Server=YEABS;   database=Ecommerce; integrated security=true;";
        public void Getproduct(String user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spGetPassword", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@name", user);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    DataTable dt = ds.Tables["tblProduct"];
                    oldPassword = dt.Rows[0]["name"].ToString();
                   
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //This will uppdate the password if called
        public void UpdatePassword(string pass)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdatePassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@user", Merchant.name);
                    int rowAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Password reset!");

                    }
                    else
                        MessageBox.Show("Failed! Please try again");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //save clicked
            if (oldTextbox.Text == oldPassword)
            {
                if (NewTextbox.Text == ConfirmPassword.Text)
                {
                    UpdatePassword(NewTextbox.Text);
                }
                else
                    MessageBox.Show("New password doesn't match!");
            }
            else
                MessageBox.Show("Wrong password");
        }
    }
}
