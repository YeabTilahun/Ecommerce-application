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
    public partial class AdminSettingOrRegister : Form
    {
        public static string password;
        public AdminSettingOrRegister()
        {
            InitializeComponent();
        }

        public AdminSettingOrRegister(DataTable dt)
        {
            InitializeComponent();
            lblId.Text = dt.Rows[0]["adminID"].ToString();
            txtFName.Text = dt.Rows[0]["fname"].ToString();
            txtLName.Text = dt.Rows[0]["lname"].ToString();
            cmbSex.Text = dt.Rows[0]["sex"].ToString();
            dtpBirthday.Text = dt.Rows[0]["birthday"].ToString();
            txtPhoneNum.Text = dt.Rows[0]["phone"].ToString();
            txtEmail.Text = dt.Rows[0]["email"].ToString();
            txtUserName.Text = dt.Rows[0]["userName"].ToString();
            password = dt.Rows[0]["password"].ToString();
            for (int i = 0; i < password.Length; i++)
                txtPass.AppendText("*");
            if (!Convert.IsDBNull(dt.Rows[0]["photo"]))
            {
                MemoryStream ms = new MemoryStream((byte[])dt.Rows[0]["photo"]);
                picAdmin.BackgroundImage = Image.FromStream(ms);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtFName_Leave(object sender, EventArgs e)
        {
            if(!txtFName.Text.Equals(""))
                txtFName.Text = txtFName.Text.Substring(0, 1).ToUpper() + txtFName.Text.Substring(1).ToLower();
        }

        private void txtLName_Leave(object sender, EventArgs e)
        {
            if (!txtLName.Text.Equals(""))
                txtLName.Text = txtLName.Text.Substring(0, 1).ToUpper() + txtLName.Text.Substring(1).ToLower();
        }

        private void AdminRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            picAdmin.BackgroundImage.Save(ms, picAdmin.BackgroundImage.RawFormat);
            byte[] photo = ms.ToArray();
            if (txtPass.Text.Equals(txtConfirmPass.Text))
            {
                AdminClass admin = new AdminClass(txtFName.Text, txtLName.Text, cmbSex.Text, dtpBirthday.Text, txtPhoneNum.Text, txtEmail.Text, txtUserName.Text, txtPass.Text, txtRole.Text,photo);
                admin.Save();
            }
            else
                MessageBox.Show("Your Password Does Not Match!!");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose Photo (*.Jpg; *.png; *.jpeg; *.bmp;) | " + "*.Jpg; *.png; *.jpeg; *.bmp;";
            if (op.ShowDialog() == DialogResult.OK)
            {
                picAdmin.BackgroundImage = Image.FromFile(op.FileName);
            }
        }

        private void linkLblChangePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            btnUpdate.Enabled = false;
            this.Width = 800;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            picAdmin.BackgroundImage.Save(ms, picAdmin.BackgroundImage.RawFormat);
            byte[] photo = ms.ToArray();
            
            AdminClass admin = new AdminClass(lblId.Text,txtFName.Text, txtLName.Text, cmbSex.Text, dtpBirthday.Text, txtPhoneNum.Text, txtEmail.Text, txtUserName.Text, txtPass.Text, txtRole.Text, photo);
            admin.UpdateAdmin();
        }

        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            if (txtOldPass.Equals(password))
            {
                if (txtNewPass.Equals(txtConfirmNewPass))
                {
                    AdminClass admin = new AdminClass(lblId.Text, txtPass.Text);
                    admin.UpdateAdmin();
                }
                else
                    MessageBox.Show("Your New Password does Not Match!!");
            }
            else
            {
                MessageBox.Show("Your Old Password does Not Match!!");
            }
        }
    }
}
