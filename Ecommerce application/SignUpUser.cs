using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_application
{
    class SignUpUser
    {
        public string email;
        public string firstName;
        public string fatherName;
        public string userName;
        public string password;
        public string role;
        public string phone;
        public byte[] photo;
        public byte[] permit;
        public string birthday;
        public SignUpUser(string fname, string lname, string uname, string pass, string pnum, string email, string role, byte[] phot,string birthday )
        {
            this.email = email;
            this.firstName = fname;
            this.fatherName = lname;
            this.userName = uname;
            this.password = pass;
            this.role = role;
            this.phone = pnum;
            this.photo = phot;
            this.birthday = birthday;
        }
        public SignUpUser(string fname, string lname, string uname, string pass, string pnum, string email, string role, byte[] phot,byte [] pic, string birthday)
        {
            this.email = email;
            this.firstName = fname;
            this.fatherName = lname;
            this.userName = uname;
            this.password = pass;
            this.role = role;
            this.phone = pnum;
            this.photo = phot;
            this.permit = pic;
            this.birthday = birthday;
        }
        public void signUp()
        {
            SignUpPro sr = new SignUpPro();//object for the third layer
            sr.signUpProccedure(this);
            sr.AddtoTableAll(this);
        }
    }
}
