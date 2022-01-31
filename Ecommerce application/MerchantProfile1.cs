using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class MerchantProfile1 : Form
    {
        public MerchantProfile1()
        {
            InitializeComponent();
        }

        //WHEN BROWSE CLICKED THEY WILL CHOOSE IMAGE
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Choose photo (*.jpg; *.png; *.bmp;) | " + "*.jpg; *.jpeg; *.bmp;";
            if (op.ShowDialog() == DialogResult.OK)
            {
                profileImage.BackgroundImage = Image.FromFile(op.FileName);
            }
        }


        //save will update the profile in database
        private void button6_Click(object sender, EventArgs e)
        {
            MerchantClass mc = new MerchantClass();
            mc.UpdateProfile();
        }
    }
}
