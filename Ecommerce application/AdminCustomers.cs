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
    public partial class AdminCustomers : Form
    {
        public AdminCustomers()
        {
            InitializeComponent();
        }

        private void showPassBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMerchants_Click(object sender, EventArgs e)
        {
            AdminMerchants adminMerchants = new AdminMerchants();
            adminMerchants.Show();
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Array is to hold different product ID that are selected in data grid view 
            int counter = 0;
            string[] id; //This will initialize the array 
            dgvCustomers.AllowUserToAddRows = false;
            for (int i = 0; i < dgvCustomers.Rows.Count; i++)
            {
                if ((bool)dgvCustomers.Rows[i].Cells[0].Value)
                    counter++;
            }
            id = new string[counter];
            counter = 0;
            for (int i = 0; i < dgvCustomers.Rows.Count; i++)
            {
                if ((bool)dgvCustomers.Rows[i].Cells[0].Value)
                {
                    //Retrive the selected id from data grid view to string array
                    DataGridViewRow row = dgvCustomers.Rows[i];
                    id[counter] = row.Cells[2].Value.ToString();
                    counter++;
                }
            }
            AdminClass customer = new AdminClass();
            customer.DeleteCustomers(id);
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            ac.GetCustomer(txtSearch.Text);
        }
    }
}
