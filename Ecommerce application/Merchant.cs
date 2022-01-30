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
        //OUR OWN PERSONAL STATIC DATAGRIDVIEW
        public static  DataGridView dataGridView2 = new DataGridView();
        public static string name;
        public Merchant(string userName)
        {
            InitializeComponent();

            //TO DISPLAY USERNAME IT TAKES THE VALUE FROM SIGN IN FORM THEN ASSIGN IN TO LABEL
            Merchant.name = userName;
            label2.Text = Merchant.name;
        }

        //DECLARED TO USE MERCHANT CLASS WITH OUT ANY ARAMETER
        public Merchant()
        {
            //InitializeComponent();
        }

        //INSTANTIATING OBJECTS TO USE THEM WHEN SPECIFIC TABS PRESSED
        MerchantSell n = new MerchantSell();
        MerchantHome k = new MerchantHome();
        

        //WHEN BUY PRODUCT PRESSED...THIS MAKES IT STREACHED SO THAT CART IS VISIBLE
        public void buySize()
        {
            label3.Visible = true;
            button13.Visible = true;
            button8.Visible = true;
            btnAdd.Visible = true;
            dataGridView2.Visible = true;
            total.Visible = true;
            this.Size = new Size(1325, 677);
            label2.Location = new Point(934, 5);
        }

        //IF NOT BUY PRODUCT PRESSED THE FORM WILL GO BACK TO ITS NORMAL SIZE CART HIDDEN
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


        private void Merchant_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            //load information about the user
            loadMyProfile();

            //check if the user is allowed to sell products...IF HIS /HERS PERMIT IS VALID WHEN THE PROGRAM LOADS
            check();

            //To display home page first every time merchat account looged in
            button12_Click( sender, e);

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

        //INITIALIZING OUR OWN STATIC DATAGRIDVIEW 
        private void SetupDataGridView()
        {
            this.Controls.Add(dataGridView2);
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.BorderStyle = BorderStyle.Fixed3D;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(1104, 94);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.ScrollBars = ScrollBars.Vertical;
            dataGridView2.Size = new Size(213, 381);
            dataGridView2.TabIndex = 20;
            dataGridView2.Visible = true;
            dataGridView2.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView2_RowsAdded);
        }

        //METHOD TO check if the user is allowed to sell products
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
                        else if (check == "Inprogress" || check == "inprogress")
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

        //To show Buy interface..we created the object then we added the panel in buy form in to panel in merchant and YES the acess modifer for the panel is internal
        private void button6_Click(object sender, EventArgs e)
        {
            buySize();
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
            panelAdd.Controls.Clear();
            k.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(k.panel1);
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
        }

        //when the mouse leaves the close window btn will be transparent
        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.Transparent;
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

        //

        public Point oldLoc;
        public Size oldSize;
        // Restore window
        private void button10_Click(object sender, EventArgs e)
        {
            this.Location = oldLoc;
            this.Size = oldSize;
            button11.BringToFront();
        }

        // Maximize window
        private void button11_Click(object sender, EventArgs e)
        {
            oldLoc = this.Location;
            oldSize = this.Size;
            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(x, y);
         
            button10.BringToFront();
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

        //WHEN MYPROFILE CLICKED FROM THE MENU
        private void profileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            resize();
            MerchantProfile1 a = new MerchantProfile1();
            panelAdd.Controls.Clear();
            panelAdd.Controls.Add(a.panel1);
            panelAdd.Show();
            panelAdd.BringToFront();
        }


        //WHEN CHANGEPASSWORD CLICKED FROM THE MENU
        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            resize();
            MerchantChangePassword a = new MerchantChangePassword();
            panelAdd.Controls.Clear();
            panelAdd.Controls.Add(a.panel1);
            panelAdd.Show();
            panelAdd.BringToFront();
        }


        //WHEN MYPRODUCT TAB CLICKED
        private void button3_Click(object sender, EventArgs e)
        {
            resize();
            MerchantBuy m = new MerchantBuy(2);
            panelAdd.Controls.Clear();
            m.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(m.panelBuy);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        //WHEN REMOVE CLICKED FROM SELECTED PRODUCTS IN DATAGIDVIEW WILL BE REMOVED FROM CART
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

       
        //EVERYTIME NEW ROW IS ADDED TOTAL WILL BE UPDATED 
        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);
            }
            total.Text = string.Format("${0}", sum.ToString());
        }
    }
}
