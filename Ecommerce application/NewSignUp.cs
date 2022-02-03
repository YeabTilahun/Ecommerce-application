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
    public partial class NewSignUp : Form
    {
        public NewSignUp()
        {
            InitializeComponent();
            this.Size = new Size(800, 450);
            //pnlPermit.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SignUpUser h = new SignUpUser();
                byte[] permit = null;
                string pwd = textpassword.Text;
                string cpwd = textconfirmpassword.Text;
                MemoryStream ms = new MemoryStream();
                picBoxAddphoto.BackgroundImage.Save(ms, picBoxAddphoto.BackgroundImage.RawFormat);
                byte[] photo = ms.ToArray();
                if (cmbRole.Text == "Merchant")
                {
                    MemoryStream m = new MemoryStream();
                    picPermit.BackgroundImage.Save(m, picPermit.BackgroundImage.RawFormat);
                    permit = m.ToArray();
                }
                string[] user = h.GetUser();
                if (user.Contains(textUserName.Text))
                {
                    MessageBox.Show("USER-NAME ALREADY EXISTS!");
                }
                else
                {
                    if (pwd == cpwd)
                    {
                        if (cmbRole.Text == "Customer")
                        {
                            //NewHomeClass hc = new NewHomeClass( textFirstName.Text, textLastName.Text, textUserName.Text, textpassword.Text, photo);
                            SignUpUser hc = new SignUpUser(textFirstName.Text, textLastName.Text, textUserName.Text, textpassword.Text, textPhone.Text, textEmail.Text, cmbRole.Text, photo, dateTimePicker1.Text);
                            MemoryStream stream = new MemoryStream(hc.photo);
                            Image RetImage = Image.FromStream(stream);
                            picBoxAddphoto.Image = RetImage;
                            hc.signUp();
                            this.Close();
                            SignIn a = new SignIn();
                            a.Show();
                        }
                        else if (cmbRole.Text == "Merchant")
                        {
                            SignUpUser hc = new SignUpUser(textFirstName.Text, textLastName.Text, textUserName.Text, textpassword.Text, textPhone.Text, textEmail.Text, cmbRole.Text, photo, permit, dateTimePicker1.Text);
                            MemoryStream stream = new MemoryStream(hc.photo);
                            Image RetImage = Image.FromStream(stream);
                            picBoxAddphoto.Image = RetImage;
                            MemoryStream str = new MemoryStream(hc.permit);
                            Image RetIma = Image.FromStream(str);
                            picPermit.Image = RetIma;
                            hc.signUp();
                            this.Close();
                            SignIn a = new SignIn();
                            a.Show();
                        }
                    }
                    else
                        MessageBox.Show("Your Password is Different");
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
                OpenFileDialog op = new OpenFileDialog();
                op.Filter = "Choose Photo (*.Jpg; *.png; *.jpeg; *.bmp;) | " + "*.Jpg; *.png; *.jpeg; *.bmp;";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    picBoxAddphoto.BackgroundImage = Image.FromFile(op.FileName);
                }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbRole_TextChanged(object sender, EventArgs e)
        {
            if (cmbRole.Text.Equals("Customer"))
            {
                this.Size = new Size(800, 450);
                panel1.Size = new Size(800, 450);
                //  pnlPermit.Visible = false;
                btnPermit.Visible = false;
                picPermit.Visible = false;
            }
            else if (cmbRole.Text.Equals("Merchant"))
            {
                this.Size = new Size(1000, 450);
                panel1.Size = new Size(1000, 450);
                //pnlPermit.Visible = true;
                btnPermit.Visible = true;
                picPermit.Visible = true;
            }

        }

        private void btnPermit_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose Photo (*.Jpg; *.png; *.jpeg; *.bmp;) | " + "*.Jpg; *.png; *.jpeg; *.bmp;";
            if (op.ShowDialog() == DialogResult.OK)
            {
               picPermit.BackgroundImage = Image.FromFile(op.FileName);
            }
        }
    }
}
