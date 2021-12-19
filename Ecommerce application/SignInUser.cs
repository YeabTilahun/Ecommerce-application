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
        public SignInUser(string uname, string pass, string role)
        {
            this.username = uname;
            this.Password = pass;
            this.role = role;
        }
        public void saveUser()
        {
            // object creation for the third layer

        }
    }
}
