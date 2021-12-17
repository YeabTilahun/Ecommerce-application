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

        //close button to be red when mouse hovers 
        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.BackColor = Color.Brown;
        }

       
        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //when the mouse leaves the close button will be transparent
        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.Transparent;
        }

        //Logout
        private void button8_Click(object sender, EventArgs e)
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

        private void button4_Click_2(object sender, EventArgs e)
        {
            MerchantCart m = new MerchantCart();
            panelAdd.Controls.Clear();
            m.Dock = DockStyle.Fill;
            panelAdd.Controls.Add(m.panelCart);
            panelAdd.Show();
            panelAdd.BringToFront();
            //hide other panels next to the buttons and show panel next to buy
            panel6.Show();
            panel8.Hide();
            panel5.Hide();
            panel7.Hide();

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //To make the form movable by holding the panel in the top
        private bool mouseDown;
        private Point lastLocation;
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        // Maximize and Restore window
        private void button10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
           // button10.Hide();
            button11.BringToFront();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ///button11.Hide();
            button10.BringToFront();
        }
    }
}
