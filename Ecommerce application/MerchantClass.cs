using System;
using System.Collections.Generic;
using System.Data;
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
        public string productName;
        public string price;
        public string quantity;
        public string category;
        public string description;
        public string stamp;
        public string exDate;
        public byte[] photo;
        public string user;
        //creating multiple constractor to make life easy
        public MerchantClass()
        {

        }

        public MerchantClass(string name, string price, string quantity, string category, string desc, string date, string stamp, byte[] photo,string user)
        {
            this.productName = name;
            this.price = price;
            this.quantity = quantity;
            this.category = category;
            this.description= desc;
            this.exDate = date;
            this.stamp = stamp;
            this.photo = photo;
            this.user = user;
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

        //my product
        public void Getproduct(string id)
        {
            MerchantDatabase sell = new MerchantDatabase();
           // sell.Getproduct(user);

        }
        public DataTable getUser()
        {
            MerchantDatabase dal = new MerchantDatabase();
            DataTable dt = dal.getUser();

            return dt;
        }

        public DataTable Selected_Cat(string category)
        {
            MerchantDatabase homeD = new MerchantDatabase();
            DataTable dt = homeD.Selected_Cat(category);
            return dt;
        }
    }
}
