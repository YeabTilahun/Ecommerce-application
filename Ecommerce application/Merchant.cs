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


        //To display home page first every time merchat account looged in
        private void Merchant_Load(object sender, EventArgs e)
        {
            MerchantHome m = new MerchantHome();
            panelAdd.Controls.Clear();
            m.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(m.panelHome);
            panelAdd.Show();
            panelAdd.BringToFront();
            //hiding panels 
            panel5.Show();
            panel6.Hide();
            panel7.Hide();
            panel8.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //Useless but dont remove it
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        //Useless but dont remove it
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
            panelAdd.Controls.Clear();
            m.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(m.panelBuy);
            panelAdd.Show();
            panelAdd.BringToFront();
            //hide other panels next to the buttons and show panel next to buy
            panel8.Show();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
        }

        //To show Sell interface we created the object then we added the panel in sell form in to panel in merchant and YES the acess modifer for the panel is internal
        private void button5_Click(object sender, EventArgs e)
        {
           
            MerchantSell m = new MerchantSell();
            panelAdd.Controls.Clear();
            m.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(m.panelSell);
            panelAdd.Show();
            panelAdd.BringToFront();
            //hide other panels next to the buttons and show panel next to buy
            panel7.Show();
            panel8.Hide();
            panel5.Hide();
            panel6.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        //To show Home interface we created the object then we added the panel in home form in to panel in merchant and YES the acess modifer for the panel is internal
        private void button3_Click(object sender, EventArgs e)
        {
            MerchantHome m = new MerchantHome();
            panelAdd.Controls.Clear();
            m.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(m.panelHome);
            panelAdd.Show();
            panelAdd.BringToFront();
            //show panel5
            panel5.Show();
            //hide others
            panel6.Hide();
            panel7.Hide();
            panel8.Hide();
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

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.BackColor = Color.Brown;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.Transparent;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to Logout", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                this.Close();
                SignIn signIn = new SignIn();
                signIn.Show();
            }
            if (res == DialogResult.Cancel)
            {
               
            }
           
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            //hide other panels next to the buttons and show panel next to buy
            panel6.Show();
            panel8.Hide();
            panel5.Hide();
            panel7.Hide();

        }
    }
}
