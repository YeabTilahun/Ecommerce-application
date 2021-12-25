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
        public string ProductName;
        public string Price;
        public string Quantity;
        public string Description;
        public string Category;

        public CustomerClass(string id, string productname, string price, string quantity, string description, string category)
        {
            this.Id = id;
            this.ProductName = productname;
            this.Price = price;
            this.Quantity = quantity;
            this.Description = description;
            this.Category = category;
            //this.Photo = photo;
        }

        public void Update(string id)
        {
            CustomerDatabase buy = new CustomerDatabase();
            buy.UpdateProduct(this);
            MessageBox.Show("Updated Succesfully!");
        }

        public void Delete(string id)
        {
            CustomerDatabase buy = new CustomerDatabase();
            buy.Delete(Id);
            MessageBox.Show("Deleted Succesfully!");
        }

        public void AddToCart(string id)
        {
            MessageBox.Show("The items you selected went to \"Cart\" go to cart to buy the items you selected!!");
        }
    }
}
