using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class MerchantBuy : Form
    {
        public MerchantBuy()
        {
            InitializeComponent();
            loadProducts();
        }

        //WHEN SEARCH BOX TEXT CHANGED CALL SEARCH METHOD 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //search();
        }

        //FOR SEARCH CALLS THE PROCEDURE AND DOES THE JOB BUT THEIR IS ERORR AFTER WE SEARCH THE DGV CONTENT WILL DISAPEAR
        /*void search()
        {
            string constr = "Server=YEABS;   database=Ecommerce; integrated security=true; ";

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("Exec spSearch @search", con);
                sqlCmd.Parameters.AddWithValue("@search", textBox1.Text);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                //dataGridView1.DataSource = dt;
                con.Close();
            }
        }

        //SEARCH BOX MOUSE LEAVE SHOW TEXT "search items here"
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search items here";
                textBox1.ForeColor = Color.LightGray;
            }
        }*/

        //SEARCH BOX MOUSE ENTERS HIDE TEXT "search items here"
        /*private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search items here")
                textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }*/

        //load the products image from database

        private Label price;
        private Label name;
        public void loadProducts()
        {
            SqlConnection msc = new SqlConnection("Server=YEABS;   database=Ecommerce; integrated security=true;");
            SqlCommand cmd = new SqlCommand("select photo,price,name from product");
            msc.Open();
            cmd.Connection = msc;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                long len = dr.GetBytes(0, 0, null, 0, 0);
                byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                dr.GetBytes(0, 0, array, 0, System.Convert.ToInt32(len));
                PictureBox pic = new PictureBox();
                pic.Width = 179;
                pic.Height = 157;


                pic.BackgroundImageLayout = ImageLayout.Stretch;
                MemoryStream ms = new MemoryStream(array);
                Bitmap bit = new Bitmap(ms);
                pic.BackgroundImage = bit;

                price = new Label();
                price.Text = dr["price"].ToString() + "$";
                price.BackColor = ColorTranslator.FromHtml("#064663");
                price.TextAlign = ContentAlignment.MiddleCenter;
                price.Width = 40;
                price.Height = 15;
                pic.Controls.Add(price);

                name = new Label();
                name.Text = dr["name"].ToString();
                name.BackColor = ColorTranslator.FromHtml("#DFD3C3");
                name.TextAlign = ContentAlignment.BottomLeft;
                name.Dock = DockStyle.Bottom;
                name.Height = 20;
                name.Font = new Font("Montserrat", 8);
                pic.Controls.Add(name);

                //flowLayoutPanel1.Controls.Add(pic);
            }
            dr.Close();
            msc.Close();

        }
    }
}
