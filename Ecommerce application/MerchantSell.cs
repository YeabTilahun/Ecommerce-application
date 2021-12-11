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
    public partial class MerchantSell : Form
    {
        public MerchantSell()
        {
            InitializeComponent();
        }

        private void CloseM_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinMer_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
