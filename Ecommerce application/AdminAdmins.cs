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

        private void DisplayOnFlowChart(DataTable dt)
        {
            LoadCustomerOrAdmin[] a = new LoadCustomerOrAdmin[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                a[i] = new LoadCustomerOrAdmin();
            if (this.Size.Width > 900)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    a[i].Width = flowLayoutPanel1.Width - 20;
                }

            }

            flowLayoutPanel1.Controls.Clear();
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
            AdminSettingOrRegister adminRegister = new AdminSettingOrRegister();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetAdmin(txtSearch.Text);
            DisplayOnFlowChart(dt);
        }
    }
}
