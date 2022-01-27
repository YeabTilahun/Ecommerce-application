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
    public partial class LoadItem : UserControl
    {
        public LoadItem()
        {
            InitializeComponent();
        }

        #region Properties
        private string _name;
        private string _quantity;
        private string _total;

        [Category("Custom")]
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                lblName.Text = value;
            }
        }

        [Category("Custom")]
        public string Quantity
        {
            get { return _quantity; }
            set 
            { 
                _quantity = value;
                lblQuantity.Text = value;
            }
        }

        [Category("Custom")]
        public string Total
        {
            get { return _total; }
            set 
            { 
                _total = value;
                lblTotal.Text = value;
            }
        }
        #endregion

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblQuantity_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
    }
}
