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
    public partial class The_Wait_Form : Form
    {
        public The_Wait_Form()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
