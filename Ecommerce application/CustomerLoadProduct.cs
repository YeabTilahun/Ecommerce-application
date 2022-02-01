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
    public partial class CustomerLoadProduct : UserControl
    {
        public CustomerLoadProduct()
        {
            InitializeComponent();
        }

        private string name;
        private string price;
        private string description;
        private byte[] pic;
        private string category;
        //Home home = new Home();
        private string productID;

        //For the product's Name
        [Category("Custom Props")]
        public string Name
        {
            get { return name; }
            set
            {
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

        public string cat
        {
            get { return category; }
            set
            {
                category = value;
            }
        }

        public string productid
        {
            get { return productID; }
            set
            {
                productID = value;

            }
        }

        //To Load The Selected Product On The Cart dataGridView
        private void button1_Click(object sender, EventArgs e)
        {
            //home.buySize();
            CustomerPage.dataGridView2.Columns.Add("name", "Product Name");
            CustomerPage.dataGridView2.Columns.Add("Price", "Price");
            

            CustomerPage.dataGridView2.Columns.Add("id", "Product ID");
            CustomerPage.dataGridView2.Columns.Add("cat", "category");

            CustomerPage.dataGridView2.Columns["id"].Visible = false;
            CustomerPage.dataGridView2.Rows.Add(name, price, productID);
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            labelDescription.Visible = false;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            labelDescription.Visible = true;
        }


    }
}
