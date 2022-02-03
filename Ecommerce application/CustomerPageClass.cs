using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_application
{
    class CustomerPageClass
    {
        public string fname;
        public string lname;
        public string bday;
        public string email;
        public string username;
        public string phone;
        public byte[] photo2;

        public CustomerPageClass(string fname, string lname, string bday, string email, string user, string phone, byte[] photo)
        {
            this.fname = fname;
            this.lname = lname;
            this.bday = bday;
            this.email = email;
            this.username = user;
            this.phone = phone;
            this.photo2 = photo;
        }

        public CustomerPageClass()
        {
        }

        CustomerPageDatabase cd = new CustomerPageDatabase();
        public void Transaction1()
        {
            CustomerPageDatabase cd = new CustomerPageDatabase();
            cd.Transaction1();
        }

        public DataTable PopulateItem()
        {
            CustomerPageDatabase cd = new CustomerPageDatabase();
            DataTable dt = null;
            dt = cd.PopulateItem();
            return dt;
        }

        public DataTable GetProfile()
        {
            CustomerPageDatabase md = new CustomerPageDatabase();
            DataTable dt = md.GetProfile();
            return dt;
        }

        public void UpdateProfile()
        {
            CustomerPageDatabase md = new CustomerPageDatabase();
            md.UpdateProfile(this);
        }

        public string GetOldPassword(string user)
        {
            string pass = null;
            CustomerPageDatabase md = new CustomerPageDatabase();
            pass = md.GetOldPassword(user);

            return pass;
        }

        public void UpdatePassword(string pass)
        {
            CustomerPageDatabase md = new CustomerPageDatabase();
            md.UpdatePassword(pass);
        }
    }
}
