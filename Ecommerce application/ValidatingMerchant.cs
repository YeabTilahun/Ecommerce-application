using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class ValidatingMerchant : Form
    {
        private string userName;
        private DataTable dt;
        public ValidatingMerchant()
        {
            InitializeComponent();
        }

        public ValidatingMerchant(string userName)
        {
            InitializeComponent();
            this.userName = userName;
            AdminClass ac = new AdminClass();
            dt = ac.GetPermit(userName);
            byte[] photo = (byte[])dt.Rows[0]["permit"];
            MemoryStream ms = new MemoryStream(photo);
            picPermit.BackgroundImage = Image.FromStream(ms);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            /*ac.AddToAll(dt.Rows[0]["userName"].ToString(), dt.Rows[0]["password"].ToString(), dt.Rows[0]["role"].ToString());*/
            ac.UpdateStatusActive(dt.Rows[0]["userName"].ToString());
            this.Close();
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            AdminClass ac = new AdminClass();
            ac.UpdateStatusReject(userName);
            this.Close();
        }
    }
}
