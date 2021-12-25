using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    class CustomerClass
    {
        //CustomerBuy layer2
        
        public string Id;
        public string fname;
        public string lname;
        public string phone;
        public string email;
        public string userName;
        public string pasword;
        public string role;
        public string ProductName;
        public string Price;
        public string Quantity;
        public string Description;
        //public byte Photo;

        public CustomerClass(string id, string productname, string price, string quantity, string description)
        {
            this.Id = id;
            this.ProductName = productname;
            this.Price = price;
            this.Quantity = quantity;
            this.Description = description;
            //this.Photo = photo;
        }

        public void Update(string[] id)
        {
            MessageBox.Show("Updated Succesfully!");
        }

        public void Delete(string[] id)
        {
            MessageBox.Show("Deleted Succesfully!");
        }

        public void AddToCart(string[] id)
        {
            MessageBox.Show("The items you selected went to \"Cart\" go to cart to buy the items you selected!!");
        }
    }
}
