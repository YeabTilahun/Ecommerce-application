using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class CustomerPage : Form
    {
        //OUR OWN PERSONAL STATIC DATAGRIDVIEW
        public static DataGridView dataGridView2 = new DataGridView();
        public static string name;
        public CustomerPage(string userName)
        {
            InitializeComponent();

            //TO DISPLAY USERNAME IT TAKES THE VALUE FROM SIGN IN FORM THEN ASSIGN IN TO LABEL
            name = userName;
            label2.Text = name;
        }
        public CustomerPage()
        {

        }

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
        private void CustomerPage_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            //load information about the user
            loadMyProfile();

            //load and display when app run
            button6_Click(sender, e);

            //TO REMOVE HOVER PROPERTY FOR SIDE AND CART BUTTONS
            button6.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button6.FlatAppearance.MouseDownBackColor = Color.Transparent;

            button12.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button12.FlatAppearance.MouseDownBackColor = Color.Transparent;

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
            dataGridView2.Visible = false;
            dataGridView2.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView2_RowsAdded);
        }

        //close button to be red when mouse hovers 
        private void button9_MouseHover(object sender, EventArgs e)
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

        // Restore window
        public Point oldLoc;
        public Size oldSize;
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

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resize();
            CustomerProfile a = new CustomerProfile();
            panelAdd.Controls.Clear();
            panelAdd.Controls.Add(a.panel1);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resize();
            ChangeCustomerPassword a = new ChangeCustomerPassword();
            panelAdd.Controls.Clear();
            panelAdd.Controls.Add(a.panel1);
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        //Removes the selected rows in cart datagridview
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count != 0)
            {
                int a = dataGridView2.GetCellCount(DataGridViewElementStates.Selected);
                int[] r = new int[a];
                for (int i = 0; i < a; i++)
                {
                    r[i] = dataGridView2.SelectedCells[i].RowIndex;
                }
                int rowIndex = dataGridView2.CurrentCell.RowIndex;
                for (int i = 0; i < a; i++)
                {
                    dataGridView2.Rows.RemoveAt(r[i]);

                }
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

        private void button8_Click(object sender, EventArgs e)
        {
            NewHomeClass a = new NewHomeClass();
            a.Transaction("customer");
            dataGridView2.Rows.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            buySize();
            NewHomeDatabase newD = new NewHomeDatabase();
            DataTable dt = newD.PopulateItem();
            panelAdd.Controls.Clear();
            CustomerLoadProduct[] a = new CustomerLoadProduct[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i] = new CustomerLoadProduct();
                a[i].Pic = (byte[])dt.Rows[i]["photo"];
                a[i].Name = dt.Rows[i]["name"].ToString();
                a[i].Description = dt.Rows[i]["description"].ToString();
                a[i].Price = string.Format(dt.Rows[i]["price"].ToString());
                a[i].productid = string.Format(dt.Rows[i]["productid"].ToString());
                a[i].cat = string.Format(dt.Rows[i]["category"].ToString());
                if (panelAdd.Controls.Count < 0)
                    panelAdd.Controls.Clear();
                else
                    panelAdd.Controls.Add(a[i]);
            }

        }

        public void loadMyProfile()
        {
            NewHomeClass a = new NewHomeClass();
            a.loadMyProfile();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count != 0)
            {
                int a = dataGridView2.GetCellCount(DataGridViewElementStates.Selected);
                int[] r = new int[a];
                for (int i = 0; i < a; i++)
                {
                    r[i] = dataGridView2.SelectedCells[i].RowIndex;
                }
                int rowIndex = dataGridView2.CurrentCell.RowIndex;
                for (int i = 0; i < a; i++)
                {
                    dataGridView2.Rows.RemoveAt(r[i]);

                }
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
    }
}
