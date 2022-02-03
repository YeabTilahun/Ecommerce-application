using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class Home : Form
    {
        NewHomeDatabase newD = new NewHomeDatabase();
        public static DataGridView dataGridView1 = new DataGridView();
        public static string name;
        Connection connect = new Connection();
        int a = Screen.PrimaryScreen.WorkingArea.Width;
        int b = Screen.PrimaryScreen.WorkingArea.Height;
        public Home(string name)
        {
            Home.name = name;
            InitializeComponent();
        }
        public Home()
        {
            InitializeComponent();
        }

        // TestEntities db;
        private void Home_Load(object sender, EventArgs e)
        {
            //To get over the Hover on our Button Logo
            buttonLogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            buttonLogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            DataTable dt = newD.PopulateItem();
            SetupDataGridView();
            
            LoadItems[] a = new LoadItems[dt.Rows.Count];
                    resize();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        a[i] = new LoadItems();
                        a[i].Pic = (byte[])dt.Rows[i]["photo"];
                        a[i].Name = dt.Rows[i]["name"].ToString();
                        a[i].Description = dt.Rows[i]["description"].ToString();
                        a[i].Price = string.Format(dt.Rows[i]["price"].ToString());
                a[i].button1.Click += new EventHandler(btnClick); 
                        if (flowLayoutPanel1.Controls.Count < 0)
                            flowLayoutPanel1.Controls.Clear();
                        else
                            flowLayoutPanel1.Controls.Add(a[i]);
                    }
        }

        //ButtonCart
        private void button4_Click(object sender, EventArgs e)
        {
            buySize();
        }

        //Button SignIn
        private void button5_Click(object sender, EventArgs e)
        {
            resize();
            SignIn a = new SignIn();
            a.Show();
            this.Hide();
        }

        //Button SignUp
        private void button6_Click(object sender, EventArgs e)
        {
            resize();
            NewSignUp newsu = new NewSignUp();
            flowLayoutPanel1.Controls.Clear();
            newsu.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(newsu.panel1);
            flowLayoutPanel1.Show();
            flowLayoutPanel1.BringToFront();
        }

        //Button Logo
        private void button7_Click(object sender, EventArgs e)
        {
            DataTable dt = newD.PopulateItem();
            flowLayoutPanel1.Controls.Clear();
            //Dock = DockStyle.Fill;
            LoadItems[] a = new LoadItems[dt.Rows.Count];
            resize();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i] = new LoadItems();
                a[i].Pic = (byte[])dt.Rows[i]["photo"];
                a[i].Name = dt.Rows[i]["name"].ToString();
                a[i].Description = dt.Rows[i]["description"].ToString();
                a[i].Price = string.Format(dt.Rows[i]["price"].ToString());
                a[i].button1.Click += new EventHandler(btnClick);
                if (flowLayoutPanel1.Controls.Count < 0)
                    flowLayoutPanel1.Controls.Clear();
                else
                    flowLayoutPanel1.Controls.Add(a[i]);
            }
        }

        //Button Minimize
        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Button Close
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //For the Combobox in the Home Form
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewHomeClass nhc = new NewHomeClass();
            DataTable dt;
            if (comboBox1.Text.Equals("All"))
            {
                dt = nhc.CustomerProduct("");
            }
            else
                dt = nhc.CustomerProduct(comboBox1.Text);

            LoadItems[] a = new LoadItems[dt.Rows.Count];
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i] = new LoadItems();
                a[i].Pic = (byte[])dt.Rows[i]["photo"];
                a[i].Name = dt.Rows[i]["name"].ToString();
                a[i].Description = dt.Rows[i]["description"].ToString();
                a[i].Price = string.Format(dt.Rows[i]["price"].ToString());
                a[i].button1.Click += new EventHandler(btnClick);
                if (flowLayoutPanel1.Controls.Count < 0)
                    flowLayoutPanel1.Controls.Clear();
                else
                    flowLayoutPanel1.Controls.Add(a[i]);
            }
        }

       

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //It Initializes the Static DataGridView in cart
        private void SetupDataGridView()
        {
            this.Controls.Add(dataGridView1);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_49; 
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(1104, 94);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dataGridView1.Size = new System.Drawing.Size(213, 381);
            dataGridView1.TabIndex = 20;
            dataGridView1.Visible = true;
            dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(dataGridView1_RowsAdded);
        }


        //For the visiblity of the buttons label and datagridview it self at cart
        public void buySize()
        {
            labelTotal.Visible = true;
            buttonBuy.Visible = true;
            buttonCancel.Visible = true;
            dataGridView1.Visible = true;
            this.Size = new Size(a, b);
        }

        //Makes the dataGridview Invisible
        public void resize()
        {
            buttonBuy.Visible = false;
            labelTotal.Visible = false;
            buttonCancel.Visible = false;
            dataGridView1.Visible = false; 
            this.Size = new Size(a, b);
        }

        //An Event Subscriber that s used for the visibility of cart at HomeWhile Add to cart is pressed
        private void btnClick(object sender, EventArgs e)
        {
            button2.BringToFront();
            buttonBuy.Visible = true;
            labelTotal.Visible = true;
            buttonCancel.Visible = true;
            dataGridView1.Visible = true;
            this.Size = new Size(a, b);
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                SignIn a = new SignIn();
                a.Show();
            }
            else
            {
                MessageBox.Show("Your Cart is Empty!");
            }

            CustomerPage.dataGridView2.DataSource = dataGridView1;
        }

        //Removes the selected rows in cart datagridview
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int a = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
                int[] r = new int[a];
                for (int i = 0; i < a; i++)
                {
                    r[i] = dataGridView1.SelectedCells[i].RowIndex;
                }
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                for (int i = 0; i < a; i++)
                {
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            else
            {
                MessageBox.Show("Your cart is empty!");
            }
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
            }
            labelTotal.Text = string.Format("${0}", sum.ToString());
        }


        //Works the total of the products added from home to cart datagridview
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
            }
            labelTotal.Text = string.Format("${0}", sum.ToString());
        }


        public bool MouseDown;
        public Point LastLocation;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            LastLocation = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDown)
            {
                this.Location = new Point((this.Location.X - LastLocation.X) + e.X, (this.Location.Y - LastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1100, 677);
            button8.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            if (dataGridView1.Rows.Count > 0)
            {
                buySize();
            }
            else
            {
                resize();                
                this.Size = new Size(a, b);
            }
            //this.WindowState = FormWindowState.Maximized;
            button2.BringToFront(); 
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Brown;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }
    }
}
