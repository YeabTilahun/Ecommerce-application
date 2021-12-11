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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void CloseM_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            AdminProducts adminProducts = new AdminProducts();
            pnlCard.Controls.Clear();
            adminProducts.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminProducts.pnlProducts);
            pnlCard.Show();
            pnlCard.BringToFront();
            btnProducts.BackColor = SystemColors.Control;
            btnMerchants.BackColor = Color.FromArgb(66, 121, 99);
            btnCustomers.BackColor = Color.FromArgb(66, 121, 99);
            btnTransactions.BackColor = Color.FromArgb(66, 121, 99);
            btnAdmins.BackColor = Color.FromArgb(66, 121, 99);
        }

        private void btnMerchants_Click(object sender, EventArgs e)
        {
            AdminMerchants adminMerchants = new AdminMerchants();
            pnlCard.Controls.Clear();
            adminMerchants.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminMerchants.pnlMerchant);
            pnlCard.Show();
            pnlCard.BringToFront();
            btnProducts.BackColor = Color.FromArgb(66, 121, 99);
            btnMerchants.BackColor = SystemColors.Control;
            btnCustomers.BackColor = Color.FromArgb(66, 121, 99);
            btnTransactions.BackColor = Color.FromArgb(66, 121, 99);
            btnAdmins.BackColor = Color.FromArgb(66, 121, 99);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            AdminCustomers admincustomers = new AdminCustomers();
            pnlCard.Controls.Clear();
            admincustomers.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(admincustomers.pnlCustomer);
            pnlCard.Show();
            pnlCard.BringToFront();
            btnProducts.BackColor = Color.FromArgb(66, 121, 99);
            btnMerchants.BackColor = Color.FromArgb(66, 121, 99);
            btnCustomers.BackColor = SystemColors.Control;
            btnTransactions.BackColor = Color.FromArgb(66, 121, 99);
            btnAdmins.BackColor = Color.FromArgb(66, 121, 99);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            AdminTransaction adminTransaction = new AdminTransaction();
            pnlCard.Controls.Clear();
            adminTransaction.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminTransaction.pnlTransaction);
            pnlCard.Show();
            pnlCard.BringToFront();
            btnProducts.BackColor = Color.FromArgb(66, 121, 99);
            btnMerchants.BackColor = Color.FromArgb(66, 121, 99);
            btnCustomers.BackColor = Color.FromArgb(66, 121, 99);
            btnTransactions.BackColor = SystemColors.Control;
            btnAdmins.BackColor = Color.FromArgb(66, 121, 99);
        }

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            AdminAdmins adminAdmins = new AdminAdmins();
            pnlCard.Controls.Clear();
            adminAdmins.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminAdmins.pnlAdmin);
            pnlCard.Show();
            pnlCard.BringToFront();
            btnProducts.BackColor = Color.FromArgb(66, 121, 99);
            btnMerchants.BackColor = Color.FromArgb(66, 121, 99);
            btnCustomers.BackColor = Color.FromArgb(66, 121, 99);
            btnTransactions.BackColor = Color.FromArgb(66, 121, 99);
            btnAdmins.BackColor = SystemColors.Control;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            AdminRegister adminRegister = new AdminRegister();
            adminRegister.Show();
        }
    }
}
