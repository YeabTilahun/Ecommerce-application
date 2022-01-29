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
        public static  DataGridView dataGridView2 = new DataGridView();
        public static string name;
        public Merchant(string userName)
        {
            InitializeComponent();
            Merchant.name = userName;
            label2.Text = Merchant.name;
        }
        //To make life easier
        public Merchant()
        {
            //InitializeComponent();
        }

        MerchantSell n = new MerchantSell();
        MerchantCart l = new MerchantCart();
        MerchantHome k = new MerchantHome();
        

        public void buySize()
        {
            label3.Visible = true;
            button13.Visible = true;
            button8.Visible = true;
            btnAdd.Visible = true;
            dataGridView2.Visible = true;
            total.Visible = true;
            this.Size = new Size(1317, 677);
            label2.Location = new Point(934, 5);
        }

        public void resize()
        {
            button8.Visible = false;
            btnAdd.Visible = false;
            label3.Visible = false;
            button13.Visible = false;
            dataGridView2.Visible = false;
            total.Visible = false;
            this.Size = new Size(1100, 677);
            label2.Location = new Point(712, 5);
        }

        //To display home page first every time merchat account looged in
        private void Merchant_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            //Disable search box
            textBox1.Enabled = false;

            //load information about the user
            loadMyProfile();

            //check if the user is allowed to sell products
            check();

            //Sth. wrong to display merchant home
            panelAdd.Controls.Clear();
            k.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(k.panelHome);
            panelAdd.BringToFront();
            panelAdd.Show();

            //TO REMOVE HOVER PROPERTY FOR SIDE AND CART BUTTONS
            button6.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button6.FlatAppearance.MouseDownBackColor = Color.Transparent;

            button12.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button12.FlatAppearance.MouseDownBackColor = Color.Transparent;

            button5.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button5.FlatAppearance.MouseDownBackColor = Color.Transparent;

            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;

            button13.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button13.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }


        //check if the user is allowed to sell products
        public void check()
        {
            string constr = "Server=YEABS;   database=Ecommerce; integrated security=true;";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select status from merchant where merchantName=@user", con);
                    cmd.Parameters.AddWithValue("@user", Merchant.name);
                    SqlDataReader da = cmd.ExecuteReader();
                    while (da.Read())
                    {
                        string check = da.GetValue(0).ToString();
                        if (check == "Active" || check == "active")
                        {
                            button5.Enabled = true;
                            button3.Enabled = true;
                        }
                        else if (check == "Inactive" || check == "inactive")
                        {
                            MessageBox.Show("Your Seller's Permit is under review so you can't add products to sell but you can buy products. Thank you for your patience!");
                        }

                        else
                        {
                            MessageBox.Show("Your Seller's Permit is rejected");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            buySize();
            //Enable search box
            textBox1.Enabled = true;

            MerchantBuy m = new MerchantBuy(1);
            panelAdd.Controls.Clear();
            m.panel1.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(m.panel2);
            panelAdd.Show();
            panelAdd.BringToFront();
        }


        //To show Sell interface we created the object then we added the panel in sell form in to panel in merchant and YES the acess modifer for the panel is internal
        private void button5_Click(object sender, EventArgs e)
        {
            resize();
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
            resize();
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
            resize();
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
            this.Size = new Size(1100, 677);
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
            /*            Newcart nc = new Newcart();
                        panelAdd.Controls.Clear();
                        nc.Dock = DockStyle.Fill;
                        panelAdd.Controls.Add(nc.panel1);
                        panelAdd.Show();
                        panelAdd.BringToFront();*/
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
            resize();
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
            resize();
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
         void search()
        {

            string constr = "Server=YEABS;   database=Ecommerce; integrated security=true; ";
            MerchantBuy ab = new MerchantBuy();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("Exec spSearch @search", con);
                sqlCmd.Parameters.AddWithValue("@search", textBox1.Text);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                //dataGridView1.DataSource = dt;
                MerchantLoadProducts[] a = new MerchantLoadProducts[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    a[i] = new MerchantLoadProducts();
                    /*SqlDataAdapter da1 = new SqlDataAdapter("spLoad_data", con);
                    da1.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da1.SelectCommand.Parameters.AddWithValue("@productid", dt.Rows[i]["productid"]);
                    DataSet ds1 = new DataSet();
                    da1.Fill(ds1, "tblproduct");
                    DataTable dt1 = ds1.Tables["tblproduct"];*/
                    a[i].Pic = (byte[])dt.Rows[i]["photo"];
                    a[i].Name = dt.Rows[i]["name"].ToString();
                    a[i].Description = dt.Rows[i]["description"].ToString();
                    a[i].Price = dt.Rows[i]["price"].ToString();

                    if (ab.panelBuy.Controls.Count < 0)
                        ab.panelBuy.Controls.Clear();
                    else
                        ab.panelBuy.Controls.Add(a[i]);
                }
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
            resize();
            //Disable search box
            textBox1.Enabled = false;
            MerchantBuy m = new MerchantBuy(2);
            panelAdd.Controls.Clear();
            m.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(m.panelBuy);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count != 0)
            {
                int rowIndex = dataGridView2.CurrentCell.RowIndex;
                dataGridView2.Rows.RemoveAt(rowIndex);
            }
            else
            {
                MessageBox.Show("Your cart is empty!");
            }
            double sum = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);
            }
            total.Text = string.Format("${0}", sum.ToString());
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(dataGridView2);
            dataGridView2.AllowUserToAddRows = false;
           dataGridView2.AllowUserToDeleteRows = false;
           dataGridView2.BackgroundColor = System.Drawing.Color.White;
           dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
           dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
           dataGridView2.Location = new System.Drawing.Point(1104, 94);
           dataGridView2.Name = "dataGridView2";
           dataGridView2.ReadOnly = true;
           dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
           dataGridView2.Size = new System.Drawing.Size(213, 381);
           dataGridView2.TabIndex = 20;
           dataGridView2.Visible = true;
        }


    }
}
