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
    public partial class AdminTransaction : Form
    {
        public AdminTransaction()
        {
            InitializeComponent();

            AdminClass ac = new AdminClass();
            string[] month = ac.GetMonth();

            for (int i = 0; i < month.Length; i++)
            {
                cmbMonth.Items.Add(month[i]);
            }
            cmbTime.Items.Add("Yearly");
            cmbTime.Items.Add("Monthly");
            cmbTime.Items.Add("Weekly");
            cmbTime.Items.Add("Daily");

            string[] category = ac.GetCategoryTransaction();
            cmbCategory.Items.Add("All");
            for (int i = 0; i < category.Length; i++)
            {
                cmbCategory.Items.Add(category[i]);
            }
            chart1.ChartAreas.FirstOrDefault().AxisX.Interval = 1;
        }

        public void DisplayProducts(DataTable dt)
        {
            AdminClass ac = new AdminClass();
            LoadItem[] a = new LoadItem[dt.Rows.Count];
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i] = new LoadItem();
                DataTable dt1 = ac.GetProductImageAndName(dt.Rows[i]["productID"].ToString());
                a[i].Name = dt1.Rows[0]["name"].ToString();
                a[i].Quantity = dt.Rows[i]["quantity"].ToString();
                a[i].Total = "$" + dt.Rows[i]["total"].ToString();

                if (flowLayoutPanel1.Controls.Count < 0)
                    flowLayoutPanel1.Controls.Clear();
                else
                    flowLayoutPanel1.Controls.Add(a[i]);
            }
        }

        private void cmbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            string category;
            if (cmbCategory.Text.Equals("All"))
                category = "";
            else
                category = cmbCategory.Text;
            switch (cmbTime.Text)
            {
                case "Yearly":
                    cmbMonth.Visible = false;
                    chart1.DataSource = ac.GetYearlyReport(category);
                    DisplayProducts(ac.GetProductYearlyReport(category));
                    chart1.Series["Series1"].XValueMember = "month";
                    chart1.Series["Series1"].YValueMembers = "total";
                    chart1.ChartAreas["ChartArea1"].AxisX.Title = "Month";
                    chart1.ChartAreas["ChartArea1"].AxisY.Title = "Total";
                    chart1.DataBind();
                    break;
                case "Monthly":
                    cmbMonth.Visible = true;
                    cmbMonth_SelectedIndexChanged(sender, e);
                    break;
                case "Weekly":
                    cmbMonth.Visible = false;
                    chart1.DataSource = ac.GetWeeklyReport(category);
                    DisplayProducts(ac.GetProductWeeklyReport(category));
                    chart1.Series["Series1"].XValueMember = "day";
                    chart1.Series["Series1"].YValueMembers = "total";
                    chart1.ChartAreas["ChartArea1"].AxisX.Title = "Day";
                    chart1.ChartAreas["ChartArea1"].AxisY.Title = "Total";
                    chart1.DataBind();
                    break;
                case "Daily":
                    cmbMonth.Visible = false;
                    chart1.DataSource = ac.GetDailyReport(category);
                    DisplayProducts(ac.GetProductDailyReport(category));
                    chart1.Series["Series1"].XValueMember = "category";
                    chart1.Series["Series1"].YValueMembers = "total";
                    chart1.ChartAreas["ChartArea1"].AxisX.Title = "Category";
                    chart1.ChartAreas["ChartArea1"].AxisY.Title = "Total";
                    chart1.DataBind();
                    break;
                default:
                    break;
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            string category;
            if (cmbCategory.Text.Equals("All"))
                category = "";
            else
                category = cmbCategory.Text;
            switch (cmbMonth.Text)
            {
                case "":
                    chart1.DataSource = ac.GetMonthlyReport(category, 1);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 1));
                    break;
                case "January":
                    chart1.DataSource = ac.GetMonthlyReport(category, 1);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 1));
                    break;
                case "Feburary":
                    chart1.DataSource = ac.GetMonthlyReport(category, 2);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 2));
                    break;
                case "March":
                    chart1.DataSource = ac.GetMonthlyReport(category, 3);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 3));
                    break;
                case "April":
                    chart1.DataSource = ac.GetMonthlyReport(category, 4);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 4));
                    break;
                case "May":
                    chart1.DataSource = ac.GetMonthlyReport(category, 5);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 5));
                    break;
                case "June":
                    chart1.DataSource = ac.GetMonthlyReport(category, 6);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 6));
                    break;
                case "July":
                    chart1.DataSource = ac.GetMonthlyReport(category, 7);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 7));
                    break;
                case "August":
                    chart1.DataSource = ac.GetMonthlyReport(category, 8);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 8));
                    break;
                case "September":
                    chart1.DataSource = ac.GetMonthlyReport(category, 9);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 9));
                    break;
                case "October":
                    chart1.DataSource = ac.GetMonthlyReport(category, 10);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 10));
                    break;
                case "November":
                    chart1.DataSource = ac.GetMonthlyReport(category, 11);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 11));
                    break;
                case "December":
                    chart1.DataSource = ac.GetMonthlyReport(category, 12);
                    DisplayProducts(ac.GetProductMonthlyReport(category, 12));
                    break;
            }
            chart1.Series["Series1"].XValueMember = "day";
            chart1.Series["Series1"].YValueMembers = "total";
            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Day";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Total";
            chart1.DataBind();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbTime_SelectedIndexChanged(sender, e);
        }
    }
}
