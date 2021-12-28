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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Application.Run(new Admin());
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Hide();
            //Customer form
          //  CustomerPage c = new CustomerPage();
           // c.Show();
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
            SignInUser s = new SignInUser(textUsername.Text, textPassword.Text, comboBox1.Text);
            label7.Visible = false;
            s.saveUser();
            //merchant
            Merchant m = new Merchant();
            m.Show();
            this.Hide();
            Admin admin = new Admin(textUsername.Text, textPassword.Text, comboBox1.Text);
            admin.Show();

        }


        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private bool firsttime = true;
        private void textUsername_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void textUsername_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void textUsername_MouseHover(object sender, EventArgs e)
        {

        }

        private void textUsername_Leave(object sender, EventArgs e)
        {
            if (textUsername.Text == "")
            {
                textUsername.Text = "User name";
                textUsername.ForeColor = Color.LightGray;
            }
        }

        private void textUsername_Enter(object sender, EventArgs e)
        {
            if (textUsername.Text == "User name")
            textUsername.Text = "";
            textUsername.ForeColor = Color.Black;
        }

        private void textPassword_Enter(object sender, EventArgs e)
        {
            if (textPassword.Text == "Password")
            textPassword.Text = "";
            textPassword.PasswordChar = '*';
            textPassword.ForeColor = Color.Black;
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            if (textPassword.Text == "")
            {
                textPassword.Text = "Password";
                textPassword.PasswordChar = '\0';
                textPassword.ForeColor = Color.LightGray;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            

        }
    }
}
