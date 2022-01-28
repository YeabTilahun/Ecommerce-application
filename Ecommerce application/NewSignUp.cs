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
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pwd = textpassword.Text;
            string cpwd = textconfirmpassword.Text;
            MemoryStream ms = new MemoryStream();
           picBoxAddphoto.BackgroundImage.Save(ms, picBoxAddphoto.BackgroundImage.RawFormat);
            byte[] photo = ms.ToArray();

            if (pwd == cpwd)
            {
                NewHomeClass hc = new NewHomeClass(textUserId.Text, textFirstName.Text, textLastName.Text, textUserName.Text, textpassword.Text, photo);
                MemoryStream stream = new MemoryStream(hc.photo);
                Image RetImage = Image.FromStream(stream);
                picBoxAddphoto.Image = RetImage;
                hc.SaveUser();
                SignIn s = new SignIn();
                s.Show();
                this.Hide();
            }
            else
                MessageBox.Show("The password dont match!");

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
    }
}
