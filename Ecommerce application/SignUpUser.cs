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
        public SignUpUser(string fname, string lname, string uname, string pass, string pnum, string email, string role, byte[] phot)
        {
            this.email = email;
            this.firstName = fname;
            this.fatherName = lname;
            this.userName = uname;
            this.password = pass;
            this.role = role;
            this.phone = pnum;
            this.photo = phot;
       
        }
        public SignUpUser(string fname, string lname, string uname, string pass, string pnum, string email, string role, byte[] phot,byte [] pic)
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
            
        }
        public void signUp()
        {
            SignUpPro sr = new SignUpPro();//object for the third layer
            sr.signUpProccedure(this);
            sr.AddtoTableAll(this);
        }
    }
}
