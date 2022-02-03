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
        public static string userName;
        public static string password;
        public Point oldLoc;
        public Size oldSize;

        public Admin()
        {
            InitializeComponent();
        }

        public Admin(string userName)
        {
            Admin.userName = userName;
            InitializeComponent();
            btnProfile.Text = Admin.userName;
        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            oldLoc = this.Location;
            oldSize = this.Size;
            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(x, y);
            btnRestore.BringToFront();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.Location = oldLoc;
            this.Size = oldSize;
            btnMaximized.BringToFront();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CloseM_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            lblNav.Text = "Products";
            btnProducts.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_481;
            btnMerchants.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnCustomers.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnTransactions.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnAdmins.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnProducts.Width = 155;
            btnMerchants.Width = 150;
            btnCustomers.Width = 150;
            btnTransactions.Width = 150;
            btnAdmins.Width = 150;
            AdminProducts adminProducts = new AdminProducts();
            pnlCard.Controls.Clear();
            adminProducts.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminProducts.pnlProducts);
            pnlCard.Show();
            pnlCard.BringToFront();

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetProduct("","");
            //adminProducts.dgvProducts.DataSource = dt;
            
            LoadProduct[] a = new LoadProduct[dt.Rows.Count];
            for(int i = 0; i < dt.Rows.Count; i++)
                a[i] = new LoadProduct();
            if (this.Size == SystemInformation.WorkingArea.Size)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    a[i].Width = adminProducts.flowLayoutPanel1.Width-3;
                    a[i].description.MaximumSize = new Size(a[i].panel6.Location.X - a[i].panel5.Location.X - 22, 0);
                }

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i].Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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

                if (adminProducts.flowLayoutPanel1.Controls.Count < 0)
                    adminProducts.flowLayoutPanel1.Controls.Clear();
                else
                    adminProducts.flowLayoutPanel1.Controls.Add(a[i]);
            }

            string[] category = ac.GetCategory();
            adminProducts.cmbCatagories.Items.Add("All");
            adminProducts.cmbCatagories.Text = "All";
            foreach(string cat in category)
            {
                adminProducts.cmbCatagories.Items.Add(cat);
            }

            
        }

        private void btnMerchants_Click(object sender, EventArgs e)
        {
            lblNav.Text = "Merchants";
            btnProducts.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnMerchants.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_481;
            btnCustomers.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnTransactions.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnAdmins.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnProducts.Width = 150;
            btnMerchants.Width = 155;
            btnCustomers.Width = 150;
            btnTransactions.Width = 150;
            btnAdmins.Width = 150;
            AdminMerchants adminMerchants = new AdminMerchants();
            pnlCard.Controls.Clear();
            adminMerchants.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminMerchants.pnlMerchant);
            pnlCard.Show();
            pnlCard.BringToFront();

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetMerchant("");
            adminMerchants.dgvMerchants.DataSource = dt;

            LoadCustomerOrAdmin[] a = new LoadCustomerOrAdmin[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                a[i] = new LoadCustomerOrAdmin();
            if (this.Size == SystemInformation.WorkingArea.Size)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    a[i].Width = adminMerchants.flowLayoutPanel1.Width - 20;
                }

            }
            adminMerchants.flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i].Anchor = AnchorStyles.Top | AnchorStyles.Left| AnchorStyles.Right;
                if (!Convert.IsDBNull(dt.Rows[i]["photo"]))
                    a[i].PicCustomerOrAdmin = (byte[])dt.Rows[i]["photo"];
                a[i].FName = dt.Rows[i]["fname"].ToString();
                a[i].LName = dt.Rows[i]["lname"].ToString();
                a[i].Phone = dt.Rows[i]["phone"].ToString();
                a[i].Email = dt.Rows[i]["email"].ToString();
                a[i].BDay = dt.Rows[i]["birthday"].ToString();
                a[i].lblStatus.Text = "Status:";
                a[i].sex.Location = new Point(570, 42);
                a[i].Sex = dt.Rows[i]["status"].ToString();
                a[i].UName = dt.Rows[i]["userName"].ToString();

                if (adminMerchants.flowLayoutPanel1.Controls.Count < 0)
                    adminMerchants.flowLayoutPanel1.Controls.Clear();
                else
                    adminMerchants.flowLayoutPanel1.Controls.Add(a[i]);
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            lblNav.Text = "Customers";
            btnProducts.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnMerchants.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnCustomers.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_481;
            btnTransactions.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnAdmins.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnProducts.Width = 150;
            btnMerchants.Width = 150;
            btnCustomers.Width = 155;
            btnTransactions.Width = 150;
            btnAdmins.Width = 150;
            AdminCustomers adminCustomers = new AdminCustomers();
            pnlCard.Controls.Clear();
            adminCustomers.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminCustomers.pnlCustomer);
            pnlCard.Show();
            pnlCard.BringToFront();

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetCustomer("");
            adminCustomers.dgvCustomers.DataSource = dt;

            LoadCustomerOrAdmin[] a = new LoadCustomerOrAdmin[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                a[i] = new LoadCustomerOrAdmin();
            if (this.Size == SystemInformation.WorkingArea.Size)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    a[i].Width = adminCustomers.flowLayoutPanel1.Width - 20;
                }

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i].Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                if (!Convert.IsDBNull(dt.Rows[i]["photo"]))
                    a[i].PicCustomerOrAdmin = (byte[])dt.Rows[i]["photo"];
                a[i].FName = dt.Rows[i]["fname"].ToString();
                a[i].LName = dt.Rows[i]["lname"].ToString();
                a[i].Phone = dt.Rows[i]["phone"].ToString();
                a[i].Email = dt.Rows[i]["email"].ToString();
                a[i].BDay = dt.Rows[i]["birthday"].ToString();
                a[i].Sex = dt.Rows[i]["sex"].ToString();
                a[i].UName = dt.Rows[i]["userName"].ToString();

                if (adminCustomers.flowLayoutPanel1.Controls.Count < 0)
                    adminCustomers.flowLayoutPanel1.Controls.Clear();
                else
                    adminCustomers.flowLayoutPanel1.Controls.Add(a[i]);
            }
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            lblNav.Text = "Transactions";
            btnProducts.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnMerchants.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnCustomers.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnTransactions.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_481;
            btnAdmins.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnProducts.Width = 150;
            btnMerchants.Width = 150;
            btnCustomers.Width = 150;
            btnTransactions.Width = 155;
            btnAdmins.Width = 150;
            AdminTransaction adminTransaction = new AdminTransaction();
            pnlCard.Controls.Clear();
            adminTransaction.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminTransaction.pnlTransaction);
            pnlCard.Show();
            pnlCard.BringToFront();

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetTransaction();


            adminTransaction.chart1.DataSource = ac.GetDailyReport("");
            adminTransaction.DisplayProducts(ac.GetProductDailyReport(""));
            adminTransaction.chart1.Series["Series1"].XValueMember = "category";
            adminTransaction.chart1.Series["Series1"].YValueMembers = "total";
            adminTransaction.chart1.ChartAreas["ChartArea1"].AxisX.Title = "Category";
            adminTransaction.chart1.ChartAreas["ChartArea1"].AxisY.Title = "Total";
            adminTransaction.chart1.DataBind();
            adminTransaction.cmbCategory.Text = "All";
        }

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            lblNav.Text = "Admins";
            btnProducts.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnMerchants.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnCustomers.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnTransactions.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnAdmins.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_481;
            btnProducts.Width = 150;
            btnMerchants.Width = 150;
            btnCustomers.Width = 150;
            btnTransactions.Width = 150;
            btnAdmins.Width = 155;
            AdminAdmins adminAdmins = new AdminAdmins();
            pnlCard.Controls.Clear();
            adminAdmins.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminAdmins.pnlAdmin);
            pnlCard.Show();
            pnlCard.BringToFront();

            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetAdmin("");
            adminAdmins.dgvAdmins.DataSource = dt;

            LoadCustomerOrAdmin[] a = new LoadCustomerOrAdmin[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                a[i] = new LoadCustomerOrAdmin();
            if (this.Size == SystemInformation.WorkingArea.Size)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    a[i].Width = adminAdmins.flowLayoutPanel1.Width - 20;
                }

            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i].Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                if (!Convert.IsDBNull(dt.Rows[i]["photo"]))
                    a[i].PicCustomerOrAdmin = (byte[])dt.Rows[i]["photo"];
                a[i].FName = dt.Rows[i]["fname"].ToString();
                a[i].LName = dt.Rows[i]["lname"].ToString();
                a[i].Phone = dt.Rows[i]["phone"].ToString();
                a[i].Email = dt.Rows[i]["email"].ToString();
                a[i].BDay = dt.Rows[i]["birthday"].ToString();
                a[i].Sex = dt.Rows[i]["sex"].ToString();
                a[i].UName = dt.Rows[i]["userName"].ToString();

                if (adminAdmins.flowLayoutPanel1.Controls.Count < 0)
                    adminAdmins.flowLayoutPanel1.Controls.Clear();
                else
                    adminAdmins.flowLayoutPanel1.Controls.Add(a[i]);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            AdminSettingOrRegister adminSettingOrRegister = new AdminSettingOrRegister();
            adminSettingOrRegister.lblNav.Text = "Registeration";
            adminSettingOrRegister.txtPass.ReadOnly = false;
            adminSettingOrRegister.btnUpdate.Hide();
            adminSettingOrRegister.pnlConfirmPass.Show();
            adminSettingOrRegister.Width = 400;
            adminSettingOrRegister.Show();
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

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetAdminProfile();
            AdminProfile a = new AdminProfile(dt);
            a.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            btnLogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnLogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnProducts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnProducts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnMerchants.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnMerchants.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnCustomers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnCustomers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnTransactions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnTransactions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnAdmins.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnAdmins.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnSetting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;

            AdminHome adminHome = new AdminHome();
            pnlCard.Controls.Clear();
            adminHome.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminHome.pnlHome);
            pnlCard.Show();
            pnlCard.BringToFront();

            AdminClass adminClass = new AdminClass();
            double income = adminClass.GetMonthlyIncome();
            adminHome.lblIncomeMonth.Text = "$"+income.ToString();
            income = adminClass.GetYearlyIncome();
            adminHome.lblIncomeYear.Text = "$" + income.ToString();
            string[] product = adminClass.GetMonthlySold(0);
            adminHome.lblName.Text = product[0];
            adminHome.lblQuantity.Text = product[1];
            adminHome.lblPrice.Text = "$" + product[2];
            product = adminClass.GetMonthlySold(-1);
            adminHome.lblName2.Text = product[0];
            adminHome.lblQuantity2.Text = product[1];
            adminHome.lblPrice2.Text = "$" + product[2];

        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            lblNav.Text = "Home";
            btnProducts.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnMerchants.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnCustomers.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnTransactions.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnAdmins.BackgroundImage = global::Ecommerce_application.Properties.Resources.Asset_48;
            btnProducts.Width = 150;
            btnMerchants.Width = 150;
            btnCustomers.Width = 150;
            btnTransactions.Width = 150;
            btnAdmins.Width = 150;

            AdminHome adminHome = new AdminHome();
            pnlCard.Controls.Clear();
            adminHome.Dock = DockStyle.Fill;
            pnlCard.Controls.Add(adminHome.pnlHome);
            pnlCard.Show();
            pnlCard.BringToFront();

            AdminClass adminClass = new AdminClass();
            double income = adminClass.GetMonthlyIncome();
            adminHome.lblIncomeMonth.Text = "$" + income.ToString();
            income = adminClass.GetYearlyIncome();
            adminHome.lblIncomeYear.Text = "$" + income.ToString();
            string[] product = adminClass.GetMonthlySold(0);
            adminHome.lblName.Text = product[0];
            adminHome.lblQuantity.Text = product[1];
            adminHome.lblPrice.Text = "$" + product[2];
            product = adminClass.GetMonthlySold(-1);
            adminHome.lblName2.Text = product[0];
            adminHome.lblQuantity2.Text = product[1];
            adminHome.lblPrice2.Text = "$" + product[2];
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            DataTable dt = ac.GetAdminProfile();

            AdminSettingOrRegister adminSettingOrRegister = new AdminSettingOrRegister(dt);
            adminSettingOrRegister.btnRegister.Hide();
            adminSettingOrRegister.Width = 400;
            adminSettingOrRegister.Show();
        }
    }
}
