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
        string old_pass = null;
        public MerchantProfile1(DataTable dt)
        {
            InitializeComponent();
            try
            {
                fnameBox.Text = dt.Rows[0]["fname"].ToString();
                lnameBox.Text = dt.Rows[0]["lname"].ToString();
                birthdayBox.Text = dt.Rows[0]["birthday"].ToString();
                emailBox.Text = dt.Rows[0]["email"].ToString();
                phoneBox.Text = dt.Rows[0]["phone"].ToString();
                usernameBox.Text = dt.Rows[0]["userName"].ToString();
                old_pass = dt.Rows[0]["password"].ToString();
            }
            catch(NullReferenceException e)
            {
                MessageBox.Show("No data please reload the app");
            }
            if (!Convert.IsDBNull(dt.Rows[0]["photo"]))
            {
                MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["photo"]);
                profileImage.BackgroundImage = Image.FromStream(ms);
            }
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
            /*            MemoryStream ms = new MemoryStream();
                        profileImage.BackgroundImage.Save(ms, profileImage.BackgroundImage.RawFormat);
                        byte[] photo = ms.ToArray();
                        MerchantClass mc = new MerchantClass();
                        mc.UpdateProfile(photo);*/
            MemoryStream ms = new MemoryStream();
            profileImage.BackgroundImage.Save(ms, profileImage.BackgroundImage.RawFormat);
            byte[] photo = ms.ToArray();
            if (!(fnameBox.Text.Equals("") || lnameBox.Text.Equals("") || birthdayBox.Text.Equals("") || emailBox.Text.Equals("") || usernameBox.Text.Equals("") || phoneBox.Text.Equals("")))
            {
                MerchantClass admin = new MerchantClass(fnameBox.Text, lnameBox.Text, birthdayBox.Text, emailBox.Text, usernameBox.Text, phoneBox.Text, photo);
                admin.UpdateProfile();
            }
            else
            {
                MessageBox.Show("You Did Not Fill All the Fields!!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;

            oldTextbox.Visible = true;
            NewTextbox.Visible = true;
            ConfirmPassword.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MerchantClass mc = new MerchantClass();
            //save clicked
            if (oldTextbox.Text == old_pass)
            {
                if (NewTextbox.Text == ConfirmPassword.Text)
                {
                    mc.UpdatePassword(NewTextbox.Text);
                }
                else
                    MessageBox.Show("New password doesn't match!");
            }
            else
                MessageBox.Show("Wrong password");
        }
    }
}
