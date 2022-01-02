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
            PopulateProducts();
        }

        //load the products image from database

        private Label price;
        private Label name;
       /* public void loadProducts()
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

                flowLayoutPanel1.Controls.Add(pic);
            }
            dr.Close();
            msc.Close();

        }*/


        public void PopulateProducts()
        {
            string constr = "Server=YEABS;   database=Ecommerce; integrated security=true;";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spLoad_data", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "product");
                    DataTable dt = ds.Tables["product"];
                    int a;
                    MessageBox.Show(dt.Rows.Count.ToString());
                    LoadItems[] b = new LoadItems[dt.Rows.Count];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        b[i] = new LoadItems();
                        b[i].Pic = (byte[])dt.Rows[i]["photo"];
                        b[i].Name = dt.Rows[i]["name"].ToString();
                        b[i].Description = dt.Rows[i]["description"].ToString();
                        b[i].Price = string.Format("${0}.00", dt.Rows[i]["price"].ToString());

                        if (panelBuy.Controls.Count < 0)
                            panelBuy.Controls.Clear();
                        else
                            panelBuy.Controls.Add(b[i]);
                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panelBuy_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picBoxSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
