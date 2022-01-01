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
    public partial class LoadItems : UserControl
    {

        public LoadItems()
        {
            InitializeComponent();
        }

        private string name;
        private string price;
        private string description;
        private byte[] pic;


       
        [Category("Custom Props")]
        public string Name
        {
            get { return name; }
            set {
                    name = value;
                    labelName.Text = value;
                }
        }

        [Category("Custom Props")]
        public string Price
        {
            get { return price; }
            set { price = value; labelPrice.Text = value; }
        }

        [Category("Custom Props")]
        public string Description
        {
            get { return description; }
            set { description = value; labelDescription.Text = value; }
        }

        [Category("Custom Props")]
        public byte[] Pic
        {
            get { return pic; }
            set
            {
                pic = value;
                MemoryStream ms = new MemoryStream(value);
                pictureBox1.BackgroundImage = Image.FromStream(ms);
            }
        }

        private void labelDescription_MouseEnter(object sender, EventArgs e)
        {
            labelDescription.Enabled = true;
        }

        private void labelDescription_MouseLeave(object sender, EventArgs e)
        {
            labelDescription.Enabled = false;
        }
    }
}
