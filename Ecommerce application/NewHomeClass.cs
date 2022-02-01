using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_application
{
    class NewHomeClass
    {
        public string Pname = "";
        public string category = "Bikes";
        public string id;
        public string FirstName;
        public string LastName;
        public string Username;
        public string Password;
        public string Phone;
        public string Email;
        public byte[] photo;
        public string price;
        public string quantity;
        public string description;
        public string user;
       /* private string text1;
        private string text2;
        private string text3;
        private object text4;*/

        public NewHomeClass()
        {
            /* string id
             this.id = id;*/
            Pname = "";
        }

        public NewHomeClass(string id, string firstname, string lastname, string username, string password, string phone, string email, byte[] photo, string price, string productname, string quantity, string category, string user)
        {
            this.id = id;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Username = username;
            this.Password = password;
            this.Phone = phone;
            this.Email = email;
            this.photo = photo;
            this.Pname = productname;
            this.price = price;
            this.quantity = quantity;
            this.category = category;
            this.user = user;
        }

        /*public NewHomeClass(string id, string text1, string text2, string text3, object text4, byte[] photo) //: this(id)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.text3 = text3;
            this.text4 = text4;
            this.photo = photo;
        }*/

        public void SaveUser()
        {
            NewHomeDatabase nhb = new NewHomeDatabase();
            nhb.SaveUserByStoredProc(this);
        }

        public void UpdateUser()
        {
            NewHomeDatabase nhb = new NewHomeDatabase();
            nhb.UpdateUserByStoredProc(this);
        }

        public void DeleteUser()
        {
            NewHomeDatabase nhb = new NewHomeDatabase();
            nhb.DeleteUserByStoredProc(this.id);
        }

        public DataTable getNewHomeClass()
        {
            NewHomeDatabase nhb = new NewHomeDatabase();
            DataTable dt = new DataTable();
            return dt;
        }

        public DataTable CustomerProduct(string category)
        {
            NewHomeDatabase homeD = new NewHomeDatabase();
            DataTable dt = homeD.CustomerProductCategory(category, Pname);
            return dt;
        }

        public void Transaction()
        {
            NewHomeDatabase buy = new NewHomeDatabase();
            buy.Transaction();
        }

        public void UpdateProfile()
        {
            NewHomeDatabase nhd = new NewHomeDatabase();
            nhd.UpdateProfile();
        }

        public string GetOldPassword(string user)
        {
            string pass = null;
            NewHomeDatabase nhd = new NewHomeDatabase();
            pass = nhd.GetOldPassword(user);

            return pass;
        }

        public void UpdatePassword(string pass)
        {
            NewHomeDatabase nhd = new NewHomeDatabase();
            nhd.UpdatePassword(pass);
        }
    }
}
