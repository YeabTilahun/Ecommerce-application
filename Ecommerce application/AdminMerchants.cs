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
            if (this.Size.Width > 900)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    a[i].Width = flowLayoutPanel1.Width - 3;
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
                a[i].lblStatus.Text = "Status:";
                a[i].sex.Location = new Point(570,42);
                a[i].Sex = dt.Rows[i]["status"].ToString();
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
                    a[i].MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].picCustomerOrAdmin.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].fName.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].lName.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].phone.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].email.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].bDay.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].sex.MouseHover += new EventHandler(a[i].HoverAll);
                    a[i].uName.MouseHover += new EventHandler(a[i].HoverAll);

                    a[i].Click += new EventHandler(a[i].AllClicked);
                    a[i].picCustomerOrAdmin.Click += new EventHandler(a[i].AllClicked);
                    a[i].fName.Click += new EventHandler(a[i].AllClicked);
                    a[i].lName.Click += new EventHandler(a[i].AllClicked);
                    a[i].phone.Click += new EventHandler(a[i].AllClicked);
                    a[i].email.Click += new EventHandler(a[i].AllClicked);
                    a[i].bDay.Click += new EventHandler(a[i].AllClicked);
                    a[i].sex.Click += new EventHandler(a[i].AllClicked);
                    a[i].uName.Click += new EventHandler(a[i].AllClicked);

                    a[i].MouseLeave += new EventHandler(a[i].LeaveAll);
                    a[i].picCustomerOrAdmin.MouseLeave += new EventHandler(a[i].LeaveAll);
                    a[i].fName.MouseLeave += new EventHandler(a[i].LeaveAll);
                    a[i].lName.MouseLeave += new EventHandler(a[i].LeaveAll);
                    a[i].phone.MouseLeave += new EventHandler(a[i].LeaveAll);
                    a[i].email.MouseLeave += new EventHandler(a[i].LeaveAll);
                    a[i].bDay.MouseLeave += new EventHandler(a[i].LeaveAll);
                    a[i].sex.MouseLeave += new EventHandler(a[i].LeaveAll);
                    a[i].uName.MouseLeave += new EventHandler(a[i].LeaveAll);
                }
            }
        }

        private void AdminMerchants_Load(object sender, EventArgs e)
        {

        }

        private void pnlMerchant_Paint(object sender, PaintEventArgs e)
        {
            btnValid.ForeColor = Color.Black;
            pnlValid.Hide();
            btnAll.ForeColor = Color.FromArgb(0, 77, 153);
            pnlAll.Show();
            btnProgress.ForeColor = Color.Black;
            pnlProgress.Hide();
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
            DisplayMerchants(dt);
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
            DisplayMerchants(dt);
        }
    }
}

