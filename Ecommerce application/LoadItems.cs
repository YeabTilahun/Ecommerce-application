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
        //A User Control Properties That We Used To Populate the Product in HomeClass
        public LoadItems()
        {
            InitializeComponent();
        }

        private string name;
        private string price;
        private string description;
        private byte[] pic;
        Home home = new Home();

        //For the product's Name
        [Category("Custom Props")]
        public string Name
        {
            get { return name; }
            set {
                    name = value;
                    labelName.Text = value;
                }
        }

        //For the product's Price
        [Category("Custom Props")]
        public string Price
        {
            get { return price; }
            set { price = value; labelPrice.Text = value; }
        }

        //For the product's Description
        [Category("Custom Props")]
        public string Description
        {
            get { return description; }
            set { description = value; labelDescription.Text = value; }
        }

        //For the product's Picture
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
           
        }

        private void labelDescription_MouseLeave(object sender, EventArgs e)
        {
            
        }

        //To Load The Selected Product On The Cart dataGridView
        private void button1_Click(object sender, EventArgs e)
        {
            home.buySize();
            Home.dataGridView1.Columns.Add("name", "Product Name");
            Home.dataGridView1.Columns.Add("Price", "Price");
            Home.dataGridView1.Rows.Add(name, price);
        }

        
        public void Onclick(object sender,EventArgs e)
        {

        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            labelDescription.Visible = false;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            labelDescription.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
