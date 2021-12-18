using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    class MerchantSellClass
    {
        //Declaring varibles to take value from the text box in MerchantSell
        public string id;
        public string productName;
        public string price;
        public string quantity;
        public string category;
        public string description;

        //creating multiple constractor to make life easy
       public MerchantSellClass()
        {

        }

        public MerchantSellClass(string id, string pname, string price, string qty, string cat, string desc)
        {
            this.id = id;
            this.productName = pname;
            this.quantity = qty;
            this.price = price;
            this.category = cat;
            this.description= desc;
        }

        public void Add()
        {
            MessageBox.Show(this.id + " " + this.productName + " " + this.price + " " + this.quantity + " " + this.category + " " + this.description + " ");
            MessageBox.Show("New Product added Sucessfully!");
            MerchantDatabase sell = new MerchantDatabase();
            sell.AddProduct(this);

        }

        public void Update()
        {
            MessageBox.Show(this.id + " " + this.productName + " " + this.price + " " + this.quantity + " " + this.category + " " + this.description + " ");
            MessageBox.Show("Product Updated Sucessfully!");
            MerchantDatabase sell = new MerchantDatabase();
            sell.UpdateProduct(this);
        }

        public void Delete(string id)
        {
            MessageBox.Show("Product Deleted Sucessfully!");
            MerchantDatabase sell = new MerchantDatabase();
            sell.Delete(id);

        }

    }
}
