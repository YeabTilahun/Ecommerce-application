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
            button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;

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

      /*  private void button1_Click(object sender, EventArgs e)
        {
            //if it is merchant user
            Merchant m = new Merchant(textUsername.Text);
            m.Show();
            this.Hide();
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            SignInUser s = new SignInUser(textUsername.Text, textPassword.Text);
            s.saveUser();
            if (s.role == "Merchant")
            {
                Merchant m = new Merchant(textUsername.Text);
                m.Show();
                this.Hide();
            }
            else
            {
                Admin admin = new Admin(textUsername.Text, textPassword.Text);
                admin.Show();
                this.Hide();
            }
        }
        private void textUsername_MouseClick(object sender, MouseEventArgs e)
            {

            }
        private void textUsername_MouseHover(object sender, EventArgs e)
            {                 textUsername.ForeColor = Color.LightGray;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Application.Run(new Admin());
            NewSignUp signUp = new NewSignUp();
            signUp.Show();
            this.Hide();
        }

        private void textPassword_Leave(object sender, EventArgs e)
        {
            
        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword f = new ForgotPassword();
            f.Show();
            this.Hide();
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            //btnLogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            //btnLogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
         
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword f = new ForgotPassword();
            f.Show();
        }
    }
}
