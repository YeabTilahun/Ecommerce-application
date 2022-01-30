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
    public partial class MerchantCart : Form
    {
        public MerchantCart()
        {
            InitializeComponent();
        }

        private void btnAdd_MouseClick(object sender, MouseEventArgs e)
        {
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //When the user clik remove checked rows will be removed
            dataGridView1.AllowUserToAddRows = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                bool isCellCheked = (bool)dataGridView1.Rows[i].Cells[0].Value;
                if (isCellCheked == true)
                {
                    dataGridView1.Rows.RemoveAt(i);
                }
               
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
