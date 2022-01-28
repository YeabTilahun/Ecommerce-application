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
            if (this.Size.Width > 900)
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
                if (!Convert.IsDBNull(dt.Rows[i]["photo"]))
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
