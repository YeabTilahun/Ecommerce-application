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
    public partial class Merchant : Form
    {
        public Merchant()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        //Useless but dont remove it it will disrupt the design page i dont know why probably its a bug
        private void CloseM_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MinMer_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Merchant_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //To add date and time in the home page
        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToShortTimeString();
            label13.Text = time;
            string date = DateTime.Now.ToShortDateString();
            label12.Text = date;
        }

        //Calling Buy form 
        private void button4_Click_1(object sender, EventArgs e)
        {
            MerchantBuy m = new MerchantBuy();
            m.Show();
            this.Hide();
        }

        //Useless but dont remove it
        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        //To show Buy interface we created the object then we added the panel in buy form in to panel in merchant and YES the acess modifer for the panel is internal
        private void button6_Click_1(object sender, EventArgs e)
        {
            MerchantBuy m = new MerchantBuy();
           // MerchantSell n = new MerchantSell();
           // panelAdd.Controls.Remove(n.panelSell);
            m.Dock = DockStyle.Fill;
            panelAdd2.Controls.Add(m.panelBuy);
            panelHome.Hide();
            //n.panelSell.Hide();
            panelAdd2.Show();
            panelAdd2.BringToFront();
        }

        //To show Sell interface we created the object then we added the panel in sell form in to panel in merchant and YES the acess modifer for the panel is internal
        private void button5_Click(object sender, EventArgs e)
        {
            //MerchantBuy n = new MerchantBuy();
            MerchantSell m = new MerchantSell();
            //panelAdd.Controls.Remove(n.panelBuy);
            m.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(m.panelSell);
            panelHome.Hide();
           //n.panelBuy.Hide();
            panelAdd.Show();
            panelAdd.BringToFront();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelHome.Show();
            panelHome.BringToFront();
        }

        //Minimize button
        private void button7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Close button
        private void CloseM_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
