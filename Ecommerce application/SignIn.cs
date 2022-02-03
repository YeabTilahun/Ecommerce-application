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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }
        private void SignIn_Load(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;

            button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;

            btnLogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnLogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Application.Run(new Admin());
            NewSignUp signUp = new NewSignUp();
            signUp.Show();
            this.Hide();        
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showPassword_Click(object sender, EventArgs e)
        {

            if (textPassword.PasswordChar == '*')
            {
                hidePassword.BringToFront();
                textPassword.PasswordChar = '\0';
            }
        }

        private void hidePassword_Click(object sender, EventArgs e)
        {

            if (textPassword.PasswordChar == '\0')
            {
                showPassword.BringToFront();
                textPassword.PasswordChar = '*';
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SignInUser s = new SignInUser(textUsername.Text, textPassword.Text);
            s.saveUser();
            if (s.role == "Merchant")
            {
                label7.Visible = false;
                Merchant m = new Merchant(textUsername.Text);
                Merchant.dataGridView2 = Home.dataGridView1;
                m.Show();
                this.Hide();
            }
            else if (s.role == "Admin")
            {
                label7.Visible = false;
                Admin admin = new Admin(textUsername.Text);
                admin.Show();
                this.Hide();
            }
            else if (s.role == "Customer")
            {
                label7.Visible = false;
                CustomerPage cust = new CustomerPage(textUsername.Text);
                CustomerPage.dataGridView2 = Home.dataGridView1;
                cust.Show();
                this.Hide();
            }
            else
                label7.Visible = true;
        }
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword f = new ForgotPassword();
            f.Show();
        }

        private void textUsername_Click(object sender, EventArgs e)
        {
            textUsername.Text = "";
        }

        private void textPassword_Click(object sender, EventArgs e)
        {
            textPassword.Text = "";
        }
    }
}
