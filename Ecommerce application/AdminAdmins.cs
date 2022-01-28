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
    public partial class AdminAdmins : Form
    {
        public AdminAdmins()
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

        private void dgvAdmins_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
