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
            ///button11.Hide();
            btnRestore.BringToFront();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            // button10.Hide();
            btnMaximized.BringToFront();
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
            //lblNav.Text = "Products";
            AdminProducts adminProducts = new AdminProducts();
            pnlCard.Controls.Clear();
            adminProducts.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminProducts.pnlProducts);
            pnlCard.Show();
            pnlCard.BringToFront();
            btnProducts.BackColor = SystemColors.ScrollBar;
            btnMerchants.BackColor = SystemColors.ControlLight;
            btnCustomers.BackColor = SystemColors.ControlLight;
            btnTransactions.BackColor = SystemColors.ControlLight;
            btnAdmins.BackColor = SystemColors.ControlLight;

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetProduct("");
            adminProducts.dgvProducts.DataSource = dt;
        }

        private void btnMerchants_Click(object sender, EventArgs e)
        {
            //lblNav.Text = "Merchants";
            AdminMerchants adminMerchants = new AdminMerchants();
            pnlCard.Controls.Clear();
            adminMerchants.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminMerchants.pnlMerchant);
            pnlCard.Show();
            pnlCard.BringToFront();
            btnProducts.BackColor = SystemColors.ControlLight;
            btnMerchants.BackColor = SystemColors.ScrollBar;
            btnCustomers.BackColor = SystemColors.ControlLight;
            btnTransactions.BackColor = SystemColors.ControlLight;
            btnAdmins.BackColor = SystemColors.ControlLight;

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetMerchant("");
            adminMerchants.dgvMerchants.DataSource = dt;
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            //lblNav.Text = "Customers";
            AdminCustomers adminCustomers = new AdminCustomers();
            pnlCard.Controls.Clear();
            adminCustomers.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminCustomers.pnlCustomer);
            pnlCard.Show();
            pnlCard.BringToFront();
            btnProducts.BackColor = SystemColors.ControlLight;
            btnMerchants.BackColor = SystemColors.ControlLight;
            btnCustomers.BackColor = SystemColors.ScrollBar;
            btnTransactions.BackColor = SystemColors.ControlLight;
            btnAdmins.BackColor = SystemColors.ControlLight;

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetCustomer("");
            adminCustomers.dgvCustomers.DataSource = dt;
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            //lblNav.Text = "Transactions";
            AdminTransaction adminTransaction = new AdminTransaction();
            pnlCard.Controls.Clear();
            adminTransaction.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminTransaction.pnlTransaction);
            pnlCard.Show();
            pnlCard.BringToFront();
            btnProducts.BackColor = SystemColors.ControlLight;
            btnMerchants.BackColor = SystemColors.ControlLight;
            btnCustomers.BackColor = SystemColors.ControlLight;
            btnTransactions.BackColor = SystemColors.ScrollBar;
            btnAdmins.BackColor = SystemColors.ControlLight;

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetTransaction();
            adminTransaction.dgvTransaction.DataSource = dt;
        }

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            //lblNav.Text = "Admins";
            AdminAdmins adminAdmins = new AdminAdmins();
            pnlCard.Controls.Clear();
            adminAdmins.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminAdmins.pnlAdmin);
            pnlCard.Show();
            pnlCard.BringToFront();
            btnProducts.BackColor = SystemColors.ControlLight;
            btnMerchants.BackColor = SystemColors.ControlLight;
            btnCustomers.BackColor = SystemColors.ControlLight;
            btnTransactions.BackColor = SystemColors.ControlLight;
            btnAdmins.BackColor = SystemColors.ScrollBar;

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetAdmin("");
            adminAdmins.dgvAdmins.DataSource = dt;
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
                this.Hide();
                new SignIn().ShowDialog();
                this.Close();
            }
        }

        //To move the panel anywhere
        private bool mouseDown;
        private Point lastLocation;

        private void pblTopNav_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pblTopNav_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pblTopNav_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlSideNav_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblNav_Click(object sender, EventArgs e)
        {

        }

        private void pblTopNav_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AccountMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CloseM_MouseHover(object sender, EventArgs e)
        {
            CloseM.BackColor = Color.Brown;
        }

        private void CloseM_MouseLeave(object sender, EventArgs e)
        {
            CloseM.BackColor = Color.Transparent;
        }
    }
}
