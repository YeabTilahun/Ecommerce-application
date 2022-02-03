using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class CustomerProfile : Form
    {
        public CustomerProfile()
        {
            InitializeComponent();
        }

        string oldPass = null;
        public CustomerProfile(DataTable dt)
        {
            InitializeComponent();
            try
            {
                txtCustFirstName.Text = dt.Rows[0]["fname"].ToString();
                txtCustLastName.Text = dt.Rows[0]["lname"].ToString();
                txtCustUserName.Text = dt.Rows[0]["userName"].ToString();
                //birthdayBox.Text = dt.Rows[0]["birthday"].ToString();
                txtCustEmail.Text = dt.Rows[0]["email"].ToString();
                txtCustPhoneNumber.Text = dt.Rows[0]["phone"].ToString();
                //old_pass = dt.Rows[0]["password"].ToString();
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show("No data please reload the app");
            }
            if (!Convert.IsDBNull(dt.Rows[0]["photo"]))
            {
                MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["photo"]);
                pictureBoxProfile.BackgroundImage = Image.FromStream(ms);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose photo (*.jpg; *.png; *.bmp;) | " + "*.jpg; *.jpeg; *.bmp;";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProfile.BackgroundImage = Image.FromFile(op.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerPageClass nhc = new CustomerPageClass();
            nhc.UpdateProfile();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeCustomerPassword change = new ChangeCustomerPassword();
            change.Show();
        }
    }
}
