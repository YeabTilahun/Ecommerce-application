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
    public partial class LoadCustomerOrAdmin : UserControl
    {
        public LoadCustomerOrAdmin()
        {
            InitializeComponent();
        }

        #region Properties
        private byte[] _image;
        private string _fName;
        private string _LName;
        private string _phone;
        private string _email;
        private string _bDay;
        private string _sex;
        private string _uName;

        [Category("Custom")]
        public byte[] PicCustomerOrAdmin
        {
            get { return _image; }
            set
            {
                _image = value;
                MemoryStream ms = new MemoryStream(value);
                picCustomerOrAdmin.BackgroundImage = Image.FromStream(ms);
            }
        }

        [Category("Custom")]
        public string FName
        {
            get { return _fName
                    ; }
            set
            {
                _fName= value;
                fName.Text = value;
            }
        }

        [Category("Custom")]
        public string LName
        {
            get { return _LName; }
            set
            {
                _LName = value;
                lName.Text = value;
            }
        }

        [Category("Custom")]
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                phone.Text = value;
            }
        }

        [Category("Custom")]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                email.Text = value;
            }
        }

        [Category("Custom")]
        public string BDay
        {
            get { return _bDay; }
            set
            {
                _bDay = value;
                bDay.Text = value;
            }
        }

        [Category("Custom")]
        public string Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
                sex.Text = value;
            }
        }

        [Category("Custom")]
        public string UName
        {
            get { return _uName; }
            set
            {
                _uName = value;
                uName.Text = value;
            }
        }
        #endregion

        private void LoadCustomerOrAdmin_Load(object sender, EventArgs e)
        {

        }

        public void AllClicked(object sender, EventArgs e)
        {
            ValidatingMerchant vm = new ValidatingMerchant(_uName);
            vm.Show();
        }

        public void HoverAll(object sender, EventArgs e)
        {

        }
    }
}
