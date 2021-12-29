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
    public partial class Home : Form
    {
        private SqlCommand cmd;
        private SqlDataReader dr;
        PictureBox pic = new PictureBox();
        Label price = new Label();
        Label descripton = new Label();

        public Home()
        {
            InitializeComponent();
        }
        private void Home_Load(object sender, EventArgs e)
        {
            ShowPic();
            ShowPrice();
        }

        //Displays the pictures to the floLayout from product table
        void ShowPic()
        {
            string con = "Server = LAPTOP-RS59N8IM; database = Ecommerce; integrated security = true;";
            SqlConnection cn = new SqlConnection(con);
            try
            {
                cn.Open();
                cmd = new SqlCommand("Select photo,description,price From product", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    long len = dr.GetBytes(0, 0, null, 0, 0);
                    byte[] array = new byte[System.Convert.ToInt32(len) + 1];
                    pic.Width = 100;
                    pic.Height = 100;
                    pic.BackgroundImageLayout = ImageLayout.Stretch;

                    MemoryStream ms = new MemoryStream();
                    Bitmap bit = new Bitmap(ms);
                    pic.BackgroundImage = bit;
                    flowLayoutPanel1.Controls.Add(pic);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void ShowPrice()
        {
            string con = "Server = LAPTOP-RS59N8IM; database = Ecommerce; integrated security = true;";
            SqlConnection cn = new SqlConnection(con);

            try
            {
                cn.Open();
                cmd = new SqlCommand("Select price From product", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    price.Text = dr["price"].ToString();
                    price.BackColor = Color.FromArgb(0, 26, 102);
                    price.Dock = DockStyle.Top;

                    MemoryStream ms = new MemoryStream();
                    Bitmap bit = new Bitmap(ms);
                    price.BackgroundImage = bit;
                    pic.Controls.Add(price);
                }
                dr.Close();
                cn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("ex.Message");
            }
        }

        void ShowDescription()
        {
            string con = "Server = LAPTOP-RS59N8IM; database = Ecommerce; integrated security = true;";
            SqlConnection cn = new SqlConnection(con);

            try
            {
                cn.Open();
                cmd = new SqlCommand("Select description From product", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    descripton.Text = dr["description"].ToString();
                    descripton.BackColor = Color.FromArgb(0, 26, 102);
                    descripton.Dock = DockStyle.Bottom;

                    MemoryStream ms = new MemoryStream();
                    Bitmap bit = new Bitmap(ms);
                    descripton.BackgroundImage = bit;
                    pic.Controls.Add(descripton);
                }
            dr.Close();
            cn.Close();
            }
            catch(SqlException ex)
            {
                MessageBox.Show("ex.Message");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Newcart nc = new Newcart();
            flowLayoutPanel1.Controls.Clear();
            nc.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(nc.panel1);
            flowLayoutPanel1.Show();
            flowLayoutPanel1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            flowLayoutPanel1.Controls.Clear();
            l.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(l.panel1);
            flowLayoutPanel1.Show();
            flowLayoutPanel1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewSignUp newsu = new NewSignUp();
            flowLayoutPanel1.Controls.Clear();
            newsu.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(newsu.panel1);
            flowLayoutPanel1.Show();
            flowLayoutPanel1.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            flowLayoutPanel1.Controls.Clear();
            h.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(h.flowLayoutPanel1);
            flowLayoutPanel1.Show();
            flowLayoutPanel1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(comboBox1.Text == "All")
            {

            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
