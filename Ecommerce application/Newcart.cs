using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class Newcart : Form
    {
        public Newcart()
        {
            //SetupDataGridView();
            InitializeComponent();
        }

        private void dataGridViewCart_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

           /* string constr = "Server = LAPTOP-RS59N8IM;   Database = Ecommerce; integrated security=true";
            try
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("spLoadToCart", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    da.Fill(ds, "tblProduct");
                    DataTable dt = ds.Tables["tblProduct"];
                    LoadItems[] a = new LoadItems[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                       // a[i].Pic = dataGridViewCart.CurrentRow.Cells[i].Value.ToString();

                    }
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("ex.Message");
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
        }

        private void dataGridViewCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
