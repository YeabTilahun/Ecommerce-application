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
    public partial class LoadProduct : UserControl
    {
        public LoadProduct()
        {
            InitializeComponent();
        }

        #region Properties
        private byte[] _image;
        private string _name;
        private string _id;
        private string _price;
        private string _quantity;
        private string _category;
        private string _description;
        private string _expireDate;
        private string _dateStamp;

        [Category("Custom")]
        public byte[] PicProduct
        {
            get { return _image; }
            set 
            { 
                _image = value;
                MemoryStream ms = new MemoryStream(value);
                picProduct.BackgroundImage = Image.FromStream(ms);
            }
        }

        [Category("Custom")]
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                name.Text = value;
            }
        }

        [Category("Custom")]
        public string ID
        {
            get { return _id; }
            set 
            { 
                _id = value;
                iD.Text = value;
            }
        }

        [Category("Custom")]
        public string Price
        {
            get { return _price; }
            set 
            { 
                _price = value;
                price.Text = value;
            }
        }

        [Category("Custom")]
        public string Quantity
        {
            get { return _quantity; }
            set 
            { 
                _quantity = value;
                quantity.Text = value;
            }
        }

        [Category("Custom")]
        public string Category
        {
            get { return _category; }
            set 
            { 
                _category = value;
                category.Text = value;
            }
        }

        [Category("Custom")]
        public string Description
        {
            get { return _description; }
            set 
            { 
                _description = value;
                description.Text = value;
            }
        }

        [Category("Custom")]
        public string ExpireDate
        {
            get { return _expireDate; }
            set 
            { 
                _expireDate = value;
                expireDate.Text = value;
            }
        }

        [Category("Custom")]
        public string DateStamp
        {
            get { return _dateStamp; }
            set 
            { 
                _dateStamp = value;
                dateStamp.Text = value;
            }
        }
        #endregion

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
