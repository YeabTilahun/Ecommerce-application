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
    public partial class MerchantHome : Form
    {
        public MerchantHome()
        {
            InitializeComponent();
        }

        //To display date and time using timer it will count after it fetch from the system
        private void timer1_Tick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToShortTimeString();
            label13.Text = time;
            string date = DateTime.Now.ToShortDateString();
            label12.Text = date;
        }


    }
}
