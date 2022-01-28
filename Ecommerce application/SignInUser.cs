using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_application
{
    class SignInUser
    {
        public string username;
        public string Password;
        public string role;
        public SignInUser(string uname, string pass)
        {
            this.username = uname;
            this.Password = pass;
        }
        public void saveUser()
        {
            // object creation for the third layer
            signInPro s = new signInPro();
            role = s.SigninProccedure(this);// returns the role of the username from database
           
        }
    }
}
