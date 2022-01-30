using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class MerchantProfile1 : Form
    {
        public MerchantProfile1()
        {
            InitializeComponent();
        }

        //WHEN BROWSE CLICKED THEY WILL CHOOSE IMAGE
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose photo (*.jpg; *.png; *.bmp;) | " + "*.jpg; *.jpeg; *.bmp;";
            if (op.ShowDialog() == DialogResult.OK)
            {
                profileImage.BackgroundImage = Image.FromFile(op.FileName);
            }
        }


        //save will update the profile in database
        private void button6_Click(object sender, EventArgs e)
        {
            UpdateProfile();
        }

        //This will update merchant database information when called
        public void UpdateProfile()
        {
            try
            {
                string constr = "Server=YEABS;   database=Ecommerce; integrated security=true;";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("spUpdateMerchantProfile", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    MemoryStream ms = new MemoryStream();
                    profileImage.BackgroundImage.Save(ms, profileImage.BackgroundImage.RawFormat);
                    byte[] Photo = ms.ToArray();
                    cmd.Parameters.AddWithValue("@user", Merchant.name);
                    cmd.Parameters.AddWithValue("@fname",fnameBox.Text);
                    cmd.Parameters.AddWithValue("@lname", lnameBox.Text);
                    cmd.Parameters.AddWithValue("@birthday",birthdayBox.Value);
                    cmd.Parameters.AddWithValue("@email", emailBox.Text);
                    cmd.Parameters.AddWithValue("@username", usernameBox.Text);
                    cmd.Parameters.AddWithValue("@phone", phoneBox.Text);
                    cmd.Parameters.AddWithValue("@photo", Photo);
                    int rowAffected = cmd.ExecuteNonQuery();

                    con.Close();
                    if (rowAffected > 0)
                    {
                        MessageBox.Show("Saved!");

                    }
                    else
                        MessageBox.Show("Nothing changed!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
