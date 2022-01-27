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
        public AdminMerchants()
        {
            InitializeComponent();
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
            AdminSettingOrRegister adminRegister = new AdminSettingOrRegister();
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
            DataTable dt = ac.GetMerchant(txtSearch.Text);
            dgvMerchants.DataSource = dt;
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
    }
}

