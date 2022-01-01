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
    public partial class LoadProductDetail : UserControl
    {
        public LoadProductDetail()
        {
            InitializeComponent();
        }

        private string price;
        [Category ("Custom props")]
        public string Price
        {
            get 
            { 
                return price; 
            }
            set 
            { 
                price = value;
                labelPrice.Text = value;
            }
        }


        private string description;
        [Category("Custom props")]
        public string Description
        {
            get 
            { 
                return description; 
            }
            set 
            { 
                description = value;
                labelDescription.Text = value;
            }
        }


        private Image picture;
        [Category("Custom props")]
        public Image Picture
        {
            get 
            { 
               return picture; 
            }

            set 
            { 
               picture = value; 
               pictureBox1.Image = value; 
            }
        }

        /*private Button addToCart;

        public Button AddToCart
        {
            get
            {
                return addToCart;
            }

            set
            {
                addToCart = value;
                buttonAddToCart.Button = value;
            }
        }*/
    }
}
