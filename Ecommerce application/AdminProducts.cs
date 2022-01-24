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
    public partial class AdminProducts : Form
    {
        public AdminProducts()
        {
            InitializeComponent();
        }

        private void AdminProduct_Load(object sender, EventArgs e)
        {

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            AdminRegister adminRegister = new AdminRegister();
            adminRegister.Show();
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Array is to hold different product ID that are selected in data grid view 
            int counter = 0;
            string[] id; //This will initialize the array 
            dgvProducts.AllowUserToAddRows = false;
            for(int i = 0; i < dgvProducts.Rows.Count; i++)
            {
                if ((bool)dgvProducts.Rows[i].Cells[0].Value)
                    counter++;
            }
            id = new string[counter];
            counter = 0;
            for (int i = 0; i < dgvProducts.Rows.Count; i++)
            {
                if ((bool)dgvProducts.Rows[i].Cells[0].Value)
                {
                    //Retrive the selected id from data grid view to string array
                    DataGridViewRow row = dgvProducts.Rows[i];
                    id[counter] = row.Cells[2].Value.ToString();
                    counter++;
                }
            }
            AdminClass product = new AdminClass();
            product.DeleteProduct(id);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvProducts.RowCount; i++)
            {
                dgvProducts.Rows[i].Cells[0].Value = true;
            }
        }

        private void btnUncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvProducts.RowCount; i++)
            {
                dgvProducts.Rows[i].Cells[0].Value = false;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            /*if (txtSearch.Text == "Search Items Here")
                txtSearch.Text = "";
            txtSearch.ForeColor = Color.Black;*/
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            /*if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search Items Here";
                txtSearch.ForeColor = Color.LightGray;
            }*/
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            DataTable dt;
            if (cmbCatagories.Text.Equals("All"))
                dt = ac.GetProduct(txtSearch.Text, "");
            else
                dt = ac.GetProduct(txtSearch.Text, cmbCatagories.Text);
            dgvProducts.DataSource = dt;
        }

        private void pnlProducts_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void picBoxSearch_Click(object sender, EventArgs e)
        {

        }

        private void cmbCatagories_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            DataTable dt;
            if (cmbCatagories.Text.Equals("All"))
            {
                dt = ac.GetProductByCategory("");               
            }
            else
                dt = ac.GetProductByCategory(cmbCatagories.Text);
            dgvProducts.DataSource = dt;
        }
    }
}
