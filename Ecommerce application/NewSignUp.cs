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
            label5.Visible = false;
            textMerName.Visible = false;
            //pnlPermit.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string pwd = textpassword.Text;
                string cpwd = textconfirmpassword.Text;
                MemoryStream ms = new MemoryStream();
                picBoxAddphoto.BackgroundImage.Save(ms, picBoxAddphoto.BackgroundImage.RawFormat);
                byte[] photo = ms.ToArray();
                picPermit.BackgroundImage.Save(ms, picPermit.BackgroundImage.RawFormat);
                byte[] permit = ms.ToArray();

                if (pwd == cpwd)
                {
                    if (cmbRole.Text == "Customer")
                    {
                        //NewHomeClass hc = new NewHomeClass( textFirstName.Text, textLastName.Text, textUserName.Text, textpassword.Text, photo);
                        SignUpUser hc = new SignUpUser(textFirstName.Text, textLastName.Text, textUserName.Text, textpassword.Text, textPhone.Text, textEmail.Text, cmbRole.Text, photo);
                        MemoryStream stream = new MemoryStream(hc.photo);
                        Image RetImage = Image.FromStream(stream);
                        picBoxAddphoto.Image = RetImage;
                        hc.signUp();
                    }
                    else if(cmbRole.Text == "Merchant")
                    {
                        SignUpUser hc = new SignUpUser(textFirstName.Text, textLastName.Text, textUserName.Text, textpassword.Text, textPhone.Text, textEmail.Text, cmbRole.Text, photo);
                        MemoryStream stream = new MemoryStream(hc.photo);
                        Image RetImage = Image.FromStream(stream);
                        picBoxAddphoto.Image = RetImage;

                        hc.signUp();

                    }
                }
                else
                    MessageBox.Show("They are Different");

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textconfirmpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
                label5.Visible = false;
                textMerName.Visible = false;
                //  pnlPermit.Visible = false;
                btnPermit.Visible = false;
                picPermit.Visible = false;
            }
            else if (cmbRole.Text.Equals("Merchant"))
            {
                this.Size = new Size(1000, 450);
                panel1.Size = new Size(1000, 450);
                label5.Visible = true;
                textMerName.Visible = true;
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
