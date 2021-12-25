using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    class AdminRegisterClass
    {
        public string adminID;
        public string firstName;
        public string lastName;
        public string sex;
        public string birthday;
        public string phoneNumber;
        public string email;
        public string userName;
        public string password;
        public string role;

        public AdminRegisterClass()
        {

        }

        public AdminRegisterClass(string firstName, string lastName, string sex, string birthday, string phoneNumber, string email, string userName, string password, string role)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.sex = sex;
            this.birthday = birthday;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.userName = userName;
            this.password = password;
            this.role = role;
        }

        public void Save()
        {
            MessageBox.Show("New Admin Added Successfully!!");
        }

        public void Update()
        {
            MessageBox.Show("Admin Updated Successfully!!");
        }
    }
}
