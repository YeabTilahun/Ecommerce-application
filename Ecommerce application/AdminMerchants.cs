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
    public partial class AdminMerchants : Form
    {
        private bool btnAllClicked = false;
        private bool btnValidClicked = false;
        private bool btnProgressClicked = false;
        public AdminMerchants()
        {
            InitializeComponent();
        }

        public void DisplayMerchants(DataTable dt)
        {
            LoadCustomerOrAdmin[] a = new LoadCustomerOrAdmin[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                a[i] = new LoadCustomerOrAdmin();
            if (this.Size == SystemInformation.WorkingArea.Size)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    a[i].Width = flowLayoutPanel1.Width - 3;
                }

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (!Convert.IsDBNull(dt.Rows[i]["photo"]))
                    a[i].PicCustomerOrAdmin = (byte[])dt.Rows[i]["photo"];
                a[i].FName = dt.Rows[i]["fname"].ToString();
                a[i].LName = dt.Rows[i]["lname"].ToString();
                a[i].Phone = dt.Rows[i]["phone"].ToString();
                a[i].Email = dt.Rows[i]["email"].ToString();
                a[i].BDay = dt.Rows[i]["birthday"].ToString();
                a[i].Sex = dt.Rows[i]["sex"].ToString();
                a[i].UName = dt.Rows[i]["userName"].ToString();

                if (flowLayoutPanel1.Controls.Count < 0)
                    flowLayoutPanel1.Controls.Clear();
                else
                    flowLayoutPanel1.Controls.Add(a[i]);
            }
            if (btnProgressClicked)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    a[i].picCustomerOrAdmin.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].fName.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].lName.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].phone.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].email.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].bDay.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].sex.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].uName.MouseHover += new EventHandler(a[i].HoverAll);

                    a[i].picCustomerOrAdmin.Click += new EventHandler(a[i].AllClicked);
                    a[i].fName.Click += new EventHandler(a[i].AllClicked);
                    a[i].lName.Click += new EventHandler(a[i].AllClicked);
                    a[i].phone.Click += new EventHandler(a[i].AllClicked);
                    a[i].email.Click += new EventHandler(a[i].AllClicked);
                    a[i].bDay.Click += new EventHandler(a[i].AllClicked);
                    a[i].sex.Click += new EventHandler(a[i].AllClicked);
                    a[i].uName.Click += new EventHandler(a[i].AllClicked);
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showPassBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            AdminCustomers adminCustomers = new AdminCustomers();
            adminCustomers.Show();
            this.Hide();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            AdminTransaction adminTransaction = new AdminTransaction();
            adminTransaction.Show();
            this.Hide();
        }

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            AdminAdmins adminAdmins = new AdminAdmins();
            adminAdmins.Show();
            this.Hide();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            AdminProducts adminProducts = new AdminProducts();
            adminProducts.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            AdminRegister adminRegister = new AdminRegister();
            adminRegister.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void AdminMerchants_Load(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void pnlMerchant_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Array is to hold different product ID that are selected in data grid view 
            int counter = 0;
            string[] id; //This will initialize the array 
            dgvMerchants.AllowUserToAddRows = false;
            for (int i = 0; i < dgvMerchants.Rows.Count; i++)
            {
                if ((bool)dgvMerchants.Rows[i].Cells[0].Value)
                    counter++;
            }
            id = new string[counter];
            counter = 0;
            for (int i = 0; i < dgvMerchants.Rows.Count; i++)
            {
                if ((bool)dgvMerchants.Rows[i].Cells[0].Value)
                {
                    //Retrive the selected id from data grid view to string array
                    DataGridViewRow row = dgvMerchants.Rows[i];
                    id[counter] = row.Cells[2].Value.ToString();
                    counter++;
                }
            }
            AdminClass Merchants = new AdminClass();
            Merchants.DeleteMerchants(id);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search Items Here";
                txtSearch.ForeColor = Color.LightGray;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search Items Here")
                txtSearch.Text = "";
            txtSearch.ForeColor = Color.Black;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            DataTable dt;
            if (btnValidClicked)
            {
                dt = ac.GetValidMerchant(txtSearch.Text);
            }
            else if (btnAllClicked)
            {
                dt = ac.GetMerchant(txtSearch.Text);
            }
            else
            {
                dt = ac.GetProgressMerchant(txtSearch.Text);
            }
            //dgvMerchants.DataSource = dt;
            DisplayMerchants(dt);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMerchants.RowCount; i++)
            {
                dgvMerchants.Rows[i].Cells[0].Value = true;
            }
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvMerchants.RowCount; i++)
            {
                dgvMerchants.Rows[i].Cells[0].Value = false;
            }
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            btnAllClicked = false;
            btnValidClicked = true;
            btnProgressClicked = false;
            btnValid.ForeColor = Color.FromArgb(0, 77, 153);
            pnlValid.Show();
            btnAll.ForeColor = Color.Black;
            pnlAll.Hide();
            btnProgress.ForeColor = Color.Black;
            pnlProgress.Hide();

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetValidMerchant("");
            //dgvMerchants.DataSource = dt;
            DisplayMerchants(dt);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnAllClicked = true;
            btnValidClicked = false;
            btnProgressClicked = false;
            btnValid.ForeColor = Color.Black;
            pnlValid.Hide();
            btnAll.ForeColor = Color.FromArgb(0, 77, 153);
            pnlAll.Show();
            btnProgress.ForeColor = Color.Black;
            pnlProgress.Hide();

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetMerchant("");
            //dgvMerchants.DataSource = dt;
            DisplayMerchants(dt);

        }

        private void btnProgress_Click(object sender, EventArgs e)
        {
            btnAllClicked = false;
            btnValidClicked = false;
            btnProgressClicked = true;
            btnValid.ForeColor = Color.Black;
            pnlValid.Hide();
            btnAll.ForeColor = Color.Black;
            pnlAll.Hide();
            btnProgress.ForeColor = Color.FromArgb(0, 77, 153);
            pnlProgress.Show();

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetProgressMerchant("");
            //dgvMerchants.DataSource = dt;
            DisplayMerchants(dt);
        }
    }
}

