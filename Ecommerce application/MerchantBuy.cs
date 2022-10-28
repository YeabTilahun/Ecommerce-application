using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class MerchantBuy : Form
    {
        public MerchantBuy(int i)
        {
            InitializeComponent();
            GetCategory();
            comboBox1.Items.Add ("All");
            choose(i);
        }

        //To call this class with out a parameter
        public MerchantBuy()
        {

        }

        //if it is 1 then its buy tab from merchant form and will display products to be bought
        //but if it is 2 then its my product tab and it will display the users product only
        public void choose(int i) {
            if (i == 1)
            {
                PopulateItem();
            }
            if (i == 2)
            {

                Getproduct(Merchant.name);
            }
        }

        //display all products in datatbase
        public void PopulateItem()
        {
            MerchantClass mc = new MerchantClass();
            DataTable dt = mc.PopulateItem();
            MerchantLoadProducts[] a = new MerchantLoadProducts[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i] = new MerchantLoadProducts(1);
                a[i].Pic = (byte[])dt.Rows[i]["photo"];
                a[i].Name = dt.Rows[i]["name"].ToString();
                a[i].Description = dt.Rows[i]["description"].ToString();
                a[i].Price = dt.Rows[i]["price"].ToString();
                a[i].productid = dt.Rows[i]["productid"].ToString();

                if (panelBuy.Controls.Count < 0)
                    panelBuy.Controls.Clear();
                else
                    panelBuy.Controls.Add(a[i]);
            }
        }

        //get products added by the user
        public void Getproduct(String user)
        {
            MerchantClass mc = new MerchantClass();
            DataTable dt = mc.Getproduct(user);
            if (dt != null)
            {
                MerchantLoadProducts[] a = new MerchantLoadProducts[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    a[i] = new MerchantLoadProducts(0);
                    a[i].Pic = (byte[])dt.Rows[i]["photo"];
                    a[i].Name = dt.Rows[i]["name"].ToString();
                    a[i].Description = dt.Rows[i]["description"].ToString();
                    a[i].Price = dt.Rows[i]["price"].ToString();
                    a[i].productid = dt.Rows[i]["productid"].ToString();
                    a[i].cat = dt.Rows[i]["category"].ToString();
                    if (panelBuy.Controls.Count < 0)
                        panelBuy.Controls.Clear();
                    else
                        panelBuy.Controls.Add(a[i]);
                }

            }
        }

        //when search text box entered it will also search the database (LIVE SEARCH)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        //when search box entered
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.TextAlign = (HorizontalAlignment)Left;
            textBox1.ForeColor = Color.Black;
        }

        //when search box leave
        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = "Search items here";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.ForeColor = Color.LightGray;
        }

        //method that search the database 
        void search()
        {
            if(!textBox1.Text.Equals("Search items here")&&!textBox1.Text.Equals("")&&!textBox1.Text.Equals(" ")) {
                MerchantClass mc = new MerchantClass();
                DataTable dt = mc.search(textBox1.Text);
                MerchantLoadProducts[] a = new MerchantLoadProducts[dt.Rows.Count];
               panelBuy.Controls.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                    a[i] = new MerchantLoadProducts(1);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!Convert.IsDBNull(dt.Rows[i]["photo"]))
                        a[i].Pic = (byte[])dt.Rows[i]["photo"];
                    a[i].Name = dt.Rows[i]["name"].ToString();
                    a[i].Description = dt.Rows[i]["description"].ToString();
                    a[i].Price = dt.Rows[i]["price"].ToString();
                    a[i].productid = dt.Rows[i]["productid"].ToString();
                    a[i].cat = dt.Rows[i]["category"].ToString();

                    if (panelBuy.Controls.Count < 0)
                        panelBuy.Controls.Clear();
                    else
                        panelBuy.Controls.Add(a[i]);
                }
            }
        }

        // Get the catagories that are available in the database
        public void GetCategory()
        {
            string[] category = null;
            MerchantClass md = new MerchantClass();
            category = md.GetCategory();

            foreach (string cat in category)
            {
                comboBox1.Items.Add(cat);
            }
        }

        // When the combobox item changed products will be displayed that are in the specific category which is the selected  
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MerchantClass x = new MerchantClass();
            DataTable dt=null;
            if (comboBox1.Text.Equals("All"))
            {
                dt = x.Selected_Cat("");
            }
            else
                dt = x.Selected_Cat(comboBox1.Text);

            MerchantLoadProducts[] a = new MerchantLoadProducts[dt.Rows.Count];
            panelBuy.Controls.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                a[i] = new MerchantLoadProducts(1);
                a[i].Pic = (byte[])dt.Rows[i]["photo"];
                a[i].Name = dt.Rows[i]["name"].ToString();
                a[i].Description = dt.Rows[i]["description"].ToString();
                a[i].Price = dt.Rows[i]["price"].ToString();

                if (panelBuy.Controls.Count < 0)
                    panelBuy.Controls.Clear();
                else
                    panelBuy.Controls.Add(a[i]);
            }
        }

        private void panelBuy_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
