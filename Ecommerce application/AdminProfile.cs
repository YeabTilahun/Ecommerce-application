using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class AdminProfile : Form
    {
        /*public static string adminID;
        public static string firstName;
        public static string lastName;
        public static string sex;
        public static string birthday;
        public static string phoneNumber;
        public static string email;
        public static string userName;
        public static string password;
        public static string role;*/

        public AdminProfile()
        {
            InitializeComponent();
        }

        public AdminProfile(string adminID, string firstName, string lastName, string sex, string birthday, string phoneNumber, string email, string userName, string password, string role)
        {
            /*AdminProfile.adminID = adminID;
            AdminProfile.firstName = firstName;
            AdminProfile.lastName = lastName;
            AdminProfile.sex = sex;
            AdminProfile.birthday = birthday;
            AdminProfile.phoneNumber = phoneNumber;
            AdminProfile.email = email;
            AdminProfile.userName = userName;
            AdminProfile.password = password;
            AdminProfile.role = role;*/
            InitializeComponent();
            txtAdminID.Text = adminID;
            txtFName.Text = firstName;
            txtLName.Text = lastName;
            cmbSex.Text = sex;
            dtpBirthday.Text = birthday;
            txtPhoneNum.Text = phoneNumber;
            txtEmail.Text = email;
            txtUserName.Text = userName;
            txtPass.Text = password;
            txtRole.Text = role;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPass.Text.Equals(txtConfermPass.Text))
            {
                AdminRegisterClass admin = new AdminRegisterClass(txtAdminID.Text, txtFName.Text, txtLName.Text, cmbSex.Text, dtpBirthday.Text, txtPhoneNum.Text, txtEmail.Text, txtUserName.Text, txtPass.Text, txtRole.Text);
                admin.UpdateAdmin();
            }
            else
                MessageBox.Show("Your Password Does Not Match!!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
