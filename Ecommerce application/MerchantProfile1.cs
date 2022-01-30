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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //To make the form movable by holding the panel in the top
        private bool mouseDown;
        private Point lastLocation;
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose photo (*.jpg; *.png; *.bmp;) | " + "*.jpg; *.jpeg; *.bmp;";
            if (op.ShowDialog() == DialogResult.OK)
            {
                profileImage.Image = Image.FromFile(op.FileName);
            }
        }


        //save will update the database
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
                    profileImage.Image.Save(ms, profileImage.Image.RawFormat);
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
