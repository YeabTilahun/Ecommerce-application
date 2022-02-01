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
    public partial class CustomerProfile : Form
    {
        public CustomerProfile()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose photo (*.jpg; *.png; *.bmp;) | " + "*.jpg; *.jpeg; *.bmp;";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBoxProfile.BackgroundImage = Image.FromFile(op.FileName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewHomeClass nhc = new NewHomeClass();
            nhc.UpdateProfile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeCustomerPassword change = new ChangeCustomerPassword();
            change.Show();
        }
    }
}
