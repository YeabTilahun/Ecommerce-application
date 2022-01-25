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
        private bool btnLatestClicked = false;
        public AdminProducts()
        {
            InitializeComponent();
        }

        private void DisplayOnFlowChart(DataTable dt)
        {
            LoadProduct[] a = new LoadProduct[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                a[i] = new LoadProduct();
            if (this.Size == SystemInformation.WorkingArea.Size)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    a[i].Width = flowLayoutPanel1.Width - 3;
                    a[i].description.MaximumSize = new Size(a[i].panel6.Location.X - a[i].panel5.Location.X - 22, 0);
                }

            }
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i].PicProduct = (byte[])dt.Rows[i]["photo"];
                a[i].ID = dt.Rows[i]["productid"].ToString();
                a[i].Name = dt.Rows[i]["name"].ToString();
                a[i].Price = dt.Rows[i]["price"].ToString();
                a[i].Quantity = dt.Rows[i]["quantity"].ToString();
                a[i].Category = dt.Rows[i]["category"].ToString();
                a[i].Description = dt.Rows[i]["description"].ToString();
                a[i].ExpireDate = dt.Rows[i]["expireDate"].ToString();
                a[i].DateStamp = dt.Rows[i]["dateStamp"].ToString();

                if (flowLayoutPanel1.Controls.Count < 0)
                    flowLayoutPanel1.Controls.Clear();
                else
                    flowLayoutPanel1.Controls.Add(a[i]);
            }
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

        /*private void btnDelete_Click(object sender, EventArgs e)
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
        }*/

        /*private void btnCheck_Click(object sender, EventArgs e)
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
        }*/

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
            if (btnLatestClicked)
            {
                if (cmbCatagories.Text.Equals("All"))
                    dt = ac.GetLatestProduct(txtSearch.Text, "");
                else
                    dt = ac.GetLatestProduct(txtSearch.Text, cmbCatagories.Text);
            }
            else
            {
                if (cmbCatagories.Text.Equals("All"))
                    dt = ac.GetProduct(txtSearch.Text, "");
                else
                    dt = ac.GetProduct(txtSearch.Text, cmbCatagories.Text);
            }
            //dgvProducts.DataSource = dt;
            DisplayOnFlowChart(dt);
        }

        private void pnlProducts_Paint(object sender, PaintEventArgs e)
        {
            btnAll.ForeColor = Color.FromArgb(0, 77, 153);
            pnlAll.Show();
            btnLatest.ForeColor = Color.Black;
            pnlLatest.Hide();
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
            if(btnLatestClicked)
            {
                if (cmbCatagories.Text.Equals("All"))
                {
                    dt = ac.GetLatestProduct("", ""); ;
                }
                else
                    dt = ac.GetLatestProduct("", cmbCatagories.Text);
            }
            else
            {
                if (cmbCatagories.Text.Equals("All"))
                {
                    dt = ac.GetProduct("", ""); ;               
                }
                else
                    dt = ac.GetProduct("", cmbCatagories.Text);
            }

            //dgvProducts.DataSource = dt;
            DisplayOnFlowChart(dt);


        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnLatestClicked = false;
            btnAll.ForeColor = Color.FromArgb(0, 77, 153);
            pnlAll.Show();
            btnLatest.ForeColor = Color.Black;
            pnlLatest.Hide();

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetProduct("", "");
            //dgvProducts.DataSource = dt;
            DisplayOnFlowChart(dt);

            string[] category = ac.GetCategory();
            cmbCatagories.Items.Clear();
            cmbCatagories.Items.Add("All");
            cmbCatagories.Text = "All";
            foreach (string cat in category)
            {
                cmbCatagories.Items.Add(cat);
            }

        }

        private void btnLatest_Click(object sender, EventArgs e)
        {
            btnLatestClicked = true;
            btnAll.ForeColor = Color.Black;
            pnlAll.Hide();
            btnLatest.ForeColor = Color.FromArgb(0, 77, 153);
            pnlLatest.Show();

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetLatestProduct("", "");
            //dgvProducts.DataSource = dt;
            DisplayOnFlowChart(dt);

            string[] category = ac.GetLatestCategory();
            cmbCatagories.Items.Clear();
            cmbCatagories.Items.Add("All");
            cmbCatagories.Text = "All";
            foreach (string cat in category)
            {
                cmbCatagories.Items.Add(cat);
            }
        }

        private void cmbCatagories_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
