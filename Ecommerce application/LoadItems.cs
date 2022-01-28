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
            /*            DataTable LoadToCart(string name, float price)
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

            Merchant.dataGridView1.Columns.Add("name", "Product Name");
            Merchant.dataGridView1.Columns.Add("Price", "Price");
            Merchant.dataGridView1.Rows.Add(name, price);

            //calculate total
            double sum = 0;
            for (int i = 0; i < Merchant.dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(Merchant.dataGridView1.Rows[i].Cells[1].Value);
            }
            Merchant.total.Text = string.Format("${0}", sum.ToString());

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
