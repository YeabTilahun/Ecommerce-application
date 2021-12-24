using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    class MerchantClass
    {
        //MerchantSell Layer 2

        //Declaring varibles to take value from the text box in MerchantSell
        public string id;
        public string productName;
        public string price;
        public string quantity;
        public string category;
        public string description;

        //creating multiple constractor to make life easy
       public MerchantClass()
        {

        }

        public MerchantClass(string id, string pname, string price, string qty, string cat, string desc)
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
            MerchantDatabase sell = new MerchantDatabase();
            sell.AddProduct(this);

        }

        public void Update()
        {
            MerchantDatabase sell = new MerchantDatabase();
            sell.UpdateProduct(this);
        }

        public void Delete(string id)
        {
            MerchantDatabase sell = new MerchantDatabase();
            sell.Delete(id);

        }

        //MerchantBuy Layer 2
        public void SelectedProduct(string [] id)
        {
            //this will add the selected items from buy in to the data grid view in the cart form
            MessageBox.Show("Go to cart to finish the transaction!");
        }

    }
}
