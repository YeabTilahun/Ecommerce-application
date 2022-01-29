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
    public partial class AdminProfile : Form
    {
        public static string password;
        public AdminProfile()
        {
            InitializeComponent();
            
        }

        public AdminProfile(DataTable dt)
        {
            InitializeComponent();
            txtAdminID.Text = dt.Rows[0]["adminID"].ToString();
            txtFName.Text = dt.Rows[0]["fname"].ToString();
            txtLName.Text = dt.Rows[0]["lname"].ToString();
            cmbSex.Text = dt.Rows[0]["sex"].ToString();
            dtpBirthday.Text = dt.Rows[0]["birthday"].ToString();
            txtPhoneNum.Text = dt.Rows[0]["phone"].ToString();
            txtEmail.Text = dt.Rows[0]["email"].ToString();
            txtUserName.Text = dt.Rows[0]["userName"].ToString();
            //txtPass.Text = dt.Rows[0]["password"].ToString();
            password = dt.Rows[0]["password"].ToString();
            for (int i = 0; i < password.Length; i++)
                txtPass.AppendText("*");
            if (!Convert.IsDBNull(dt.Rows[0]["photo"]))
            {
                MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["photo"]);
                picAdmin.BackgroundImage = Image.FromStream(ms);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
