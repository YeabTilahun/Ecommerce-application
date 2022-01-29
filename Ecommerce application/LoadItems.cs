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
            //SetupDataGridView();
            InitializeComponent();
        }

        private string name;
        private string price;
        private string description;
        private byte[] pic;
        Merchant a = new Merchant();


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
           
        }

        private void labelDescription_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Newcart cart = new Newcart();
            Home home = new Home();
            home.buySize();
            Home.dataGridViewCart.Columns.Add("name", "Product Name");
            Home.dataGridViewCart.Columns.Add("Price", "Price");
            Home.dataGridViewCart.Rows.Add(name, price);

            //calculate total
            double sum = 0;
            for (int i = 0; i < Home.dataGridViewCart.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(Home.dataGridViewCart.Rows[i].Cells[1].Value);
            }
            //home.labelTotal.Text = string.Format("${0}", sum.ToString());

           
            /* Newcart cart = new Newcart();
              Newcart.dataGridViewCart.Columns.Add("name", "productname");
              Newcart.dataGridViewCart.Columns.Add("price", "price");
              Newcart.dataGridViewCart.Rows.Add(name, price);*/


            /*int[] theData = new int[50];

            for (int i = 0; i < theData.Length; i++)
            {
                Newcart.dataGridViewCart.Rows.Add(new object[] { i + 1, theData[i] });
            }*/
            /*DataTable LoadToCart(string name, float price)
                        {
                            string constr = "Server = LAPTOP-RS59N8IM;   Database = Ecommerce; integrated security=true";
                            SqlConnection con = new SqlConnection(constr);
                            SqlDataAdapter da = new SqlDataAdapter("spLoadToCart", con);
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@name", name);
                            da.SelectCommand.Parameters.AddWithValue("@price", price);
                            DataSet ds = new DataSet();
                            da.Fill(ds, "tblProduct");
                            DataTable dt = ds.Tables["tblProduct"];
                            return dt;
                        }*/
        }

        //Even
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
