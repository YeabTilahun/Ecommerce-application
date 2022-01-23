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
    public partial class Merchant : Form
    {
        public static string name;
        public Merchant(string userName)
        {
            Merchant.name = userName;
            InitializeComponent();
            label2.Text = Merchant.name;
        }

        //To make life easier
        public Merchant()
        {
          
        }

        MerchantSell n = new MerchantSell();
        MerchantCart l = new MerchantCart();
        MerchantHome k = new MerchantHome();
        //To display home page first every time merchat account looged in
        private void Merchant_Load(object sender, EventArgs e)
        {
            //Disable search box
            textBox1.Enabled = false;

            //load information about the user
            loadMyProfile();

            //Sth. wrong to display merchant home
            panelAdd.Controls.Clear();
            k.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(k.panelHome);
            panelAdd.BringToFront();
            panelAdd.Show();

            //TO REMOVE HOVER PROPERTY FOR SIDE BUTTONS
            button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        }

        //Fetch information about merchant from database and assign it to my profile page

        public void loadMyProfile()
        {
            MerchantProfile1 m = new MerchantProfile1();
            string constr = "Server=YEABS;   database=Ecommerce; integrated security=true;";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select fname,lname,birthday,email,userName,photo from merchant where merchantName=@user", con);
                    cmd.Parameters.AddWithValue("@user", Merchant.name);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        m.fnameBox.Text = da.GetValue(0).ToString();
                        m.lnameBox.Text = da.GetValue(1).ToString();
                        m.birthdayBox.Value = Convert.ToDateTime(da.GetValue(2).ToString());
                        m.emailBox.Text = da.GetValue(3).ToString();
                        m.usernameBox.Text = da.GetValue(4).ToString();

                        byte[] photo = (byte[])da.GetValue(5);
                        MemoryStream ms = new MemoryStream(photo);
                        m.profileImage.Image = Image.FromStream(ms);
                    }
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //To show Buy interface we created the object then we added the panel in buy form in to panel in merchant and YES the acess modifer for the panel is internal
        private void button6_Click(object sender, EventArgs e)
        {
            //Enable search box
            textBox1.Enabled = true;

            MerchantBuy m = new MerchantBuy(1);
            panelAdd.Controls.Clear();
            m.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(m.panelBuy);
            panelAdd.Show();
            panelAdd.BringToFront();
        }


        //To show Sell interface we created the object then we added the panel in sell form in to panel in merchant and YES the acess modifer for the panel is internal
        private void button5_Click(object sender, EventArgs e)
        {
            //Disable search box
            textBox1.Enabled = false;

            panelAdd.Controls.Clear();
            n.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(n.panelSell);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        //To show Home interface we created the object then we added the panel in home form in to panel in merchant and YES the acess modifer for the panel is internal
        private void button12_Click(object sender, EventArgs e)
        {
            //Disable search box
            textBox1.Enabled = false;

            panelAdd.Controls.Clear();
            k.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(k.panelHome);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        //close button to be red when mouse hovers 
        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.BackColor = Color.Brown;
        }


        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            SignIn c = new SignIn();
            c.Show();
        }

        //when the mouse leaves the close button will be transparent
        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.Transparent;
        }

        private void button4_Click_2(object sender, EventArgs e)
        {

            //Disable search box
            textBox1.Enabled = false;

            panelAdd.Controls.Clear();
            l.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(l.panelCart);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //To make the form movable by holding the panel in the top
        private bool mouseDown;
        private Point lastLocation;
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        // Maximize and Restore window
        private void button10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            // button10.Hide();
            button11.BringToFront();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int a = Screen.PrimaryScreen.WorkingArea.Width;
            int b = Screen.PrimaryScreen.WorkingArea.Height;
            this.Size = new Size(a, b);
            // this.WindowState = FormWindowState.Maximized;
            ///button11.Hide();
            button10.BringToFront();
        }
        private void button13_Click(object sender, EventArgs e)
        {
            Newcart nc = new Newcart();
            panelAdd.Controls.Clear();
            nc.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(nc.panel1);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        //WHEN LOGOUT CLICKED FROM THE MENU
        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Logout", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                this.Close();
                SignIn signIn = new SignIn();
                signIn.Show();
            }
            if (res == DialogResult.No)
            {

            }
        }

        //My profile
        private void profileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Disable search box
            textBox1.Enabled = false;

            MerchantProfile1 a = new MerchantProfile1();
            panelAdd.Controls.Clear();
            panelAdd.Controls.Add(a.panel1);
            panelAdd.Show();
            panelAdd.BringToFront();

        }

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Disable search box
            textBox1.Enabled = false;

            //change password

            MerchantChangePassword a = new MerchantChangePassword();
            panelAdd.Controls.Clear();
            panelAdd.Controls.Add(a.panel1);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

      

        //FOR SEARCH CALLS THE PROCEDURE AND DOES THE JOB BUT THEIR IS ERORR AFTER WE SEARCH THE DGV CONTENT WILL DISAPEAR
        void search(){

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

        //SEARCH BOX MOUSE ENTERS HIDE TEXT "search items here"
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search items here")
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
        }

        //WHEN SEARCH BOX TEXT CHANGED CALL SEARCH METHOD
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search items here";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        //my product
        private void button3_Click(object sender, EventArgs e)
        {
            //Disable search box
            textBox1.Enabled = false;
            MerchantBuy m = new MerchantBuy(2);
            panelAdd.Controls.Clear();
            m.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(m.panelBuy);
            panelAdd.Show();
            panelAdd.BringToFront();
        }
    }
}
