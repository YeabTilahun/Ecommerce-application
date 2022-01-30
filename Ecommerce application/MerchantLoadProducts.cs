using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ecommerce_application
{
    public partial class MerchantLoadProducts: UserControl
    {
        public MerchantLoadProducts()
        {
            InitializeComponent();
        }

    //PROPERT FOR THE USER CONTROL
        private string name;
        private string price;
        private string description;
        private byte[] pic;
        Merchant a = new Merchant();


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


        //WHEN ADDTOCART CLICKED IT WILL CALL THE STATIC DGV AND ADD COLUMNS AND THEN WILL ADD THED DATA
        private void button1_Click(object sender, EventArgs e)
        {
            Merchant.dataGridView2.Columns.Add("name", "Product Name");
            Merchant.dataGridView2.Columns.Add("Price", "Price");
            Merchant.dataGridView2.Rows.Add(name, price);
        }

        //DESCRIPTION WILL APPEAR WHEN MOSE HOVER ON THE PICTURE BOX AND DISAPEAR WHEN MOUSE LEAVE
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
