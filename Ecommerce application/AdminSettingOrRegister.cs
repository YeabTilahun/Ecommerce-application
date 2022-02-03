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
            txtFName.Text = txtFName.Text.Trim();
            if (!txtFName.Text.Equals(""))
                txtFName.Text = txtFName.Text.Substring(0, 1).ToUpper() + txtFName.Text.Substring(1).ToLower();
        }

        private void txtLName_Leave(object sender, EventArgs e)
        {
            txtLName.Text = txtLName.Text.Trim();
            if (!txtLName.Text.Equals(""))
                txtLName.Text = txtLName.Text.Substring(0, 1).ToUpper() + txtLName.Text.Substring(1).ToLower();
        }

        private void AdminRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            string[] userNames = ac.GetAllUserName();

            MemoryStream ms = new MemoryStream();
            picAdmin.BackgroundImage.Save(ms, picAdmin.BackgroundImage.RawFormat);
            byte[] photo = ms.ToArray();
            if (!(txtFName.Text.Equals("") || txtLName.Text.Equals("") || cmbSex.Text.Equals("") || txtUserName.Text.Equals("") || txtEmail.Text.Equals("") || txtPhoneNum.Text.Equals("")))
            {
                if (txtPass.Text.Equals(""))
                {
                    MessageBox.Show("Enter Your Password");
                }
                else
                {
                    if (txtPass.Text.Equals(txtConfirmPass.Text))
                    {
                        if (userNames.Contains(txtUserName.Text))
                        {
                            MessageBox.Show("Your User Name Has Already Been Taken!!");
                        }
                        else
                        {
                            AdminClass admin = new AdminClass(txtFName.Text, txtLName.Text, cmbSex.Text, dtpBirthday.Text, txtPhoneNum.Text, txtEmail.Text, txtUserName.Text, txtPass.Text, txtRole.Text, photo);
                            admin.Save();
                            admin.AddToAll(txtUserName.Text, txtPass.Text, txtRole.Text);
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("Your Password Does Not Match!!");
                }
            }
            else
                MessageBox.Show("You Did Not Fill All the Fields!!");
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
            if(!(txtFName.Text.Equals("") || txtLName.Text.Equals("") || cmbSex.Text.Equals("") || txtUserName.Text.Equals("") || txtEmail.Text.Equals("") || txtPhoneNum.Text.Equals("")))
            {
                AdminClass admin = new AdminClass(lblId.Text, txtFName.Text, txtLName.Text, cmbSex.Text, dtpBirthday.Text, txtPhoneNum.Text, txtEmail.Text, txtUserName.Text, txtPass.Text, txtRole.Text, photo);
                admin.UpdateAdmin();
            }
            else
            {
                MessageBox.Show("You Did Not Fill All the Fields!!");
            }
        }

        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            if (txtOldPass.Equals(password))
            {
                if (txtNewPass.Equals(txtConfirmNewPass) && !txtNewPass.Text.Equals(""))
                {
                    AdminClass admin = new AdminClass(lblId.Text, txtPass.Text);
                    admin.ChangePassword();
                    admin.ChangePasswordTblAll();
                }
                else
                    MessageBox.Show("Your New Password does Not Match!!");
            }
            else
            {
                MessageBox.Show("Your Old Password does Not Match!!");
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            txtUserName.Text = txtUserName.Text.Trim();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.Text = txtEmail.Text.Trim();
        }

        private void txtPhoneNum_Leave(object sender, EventArgs e)
        {
            txtPhoneNum.Text = txtPhoneNum.Text.Trim();
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtOldPass_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtNewPass_Leave(object sender, EventArgs e)
        {

        }
    }
}
