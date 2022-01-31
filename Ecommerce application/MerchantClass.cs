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

        public MerchantClass(string name, string price, string quantity, string category, string desc, string date, string stamp, byte[] photo, string user)
        {
            this.productName = name;
            this.price = price;
            this.quantity = quantity;
            this.category = category;
            this.description = desc;
            this.exDate = date;
            this.stamp = stamp;
            this.photo = photo;
            this.user = user;
        }

        //ADD PRODUCTS
        public void Add()
        {
            MerchantDatabase md = new MerchantDatabase();
            md.AddProduct(this);

        }

        //UPDATE PRODUCTS
        public void Update()
        {
            MerchantDatabase sell = new MerchantDatabase();
            sell.UpdateProduct(this);
        }

        //DELETE PRODUCTS
        public void Delete(string id)
        {
            MerchantDatabase sell = new MerchantDatabase();
            sell.Delete(id);

        }


        //GET ITEMS ACCORDING TO THE SELECTED CATEGORY
        public DataTable Selected_Cat(string category)
        {
            MerchantDatabase homeD = new MerchantDatabase();
            DataTable dt = homeD.Selected_Cat(category);
            return dt;
        }

        //Add transaction when buy clicked in the cart
        public void transaction()
        {
            MerchantDatabase sell = new MerchantDatabase();
            //sell.array();
            sell.Transaction1();
        }

        //check if merchant is valid or not
        public string check()
        {
            string check = null;

            MerchantDatabase a = new MerchantDatabase();
            check = a.check();

            return check;
        }


        //Fetch information about merchant from database and assign it to my profile page
        public void loadMyProfile()
        {
            MerchantDatabase a = new MerchantDatabase();
            a.loadMyProfile();
        }

        //display all products in datatbase
        public DataTable PopulateItem()
        {
            MerchantDatabase a = new MerchantDatabase();
            DataTable dt = a.PopulateItem();
            return dt;
        }

        //GET MY PRODUCT
        public DataTable Getproduct(string user)
        {
            MerchantDatabase a = new MerchantDatabase();
            DataTable dt = a.Getproduct(user);
            return dt;
        }

        //method that search the database 
        public DataTable search(string key)
        {
            DataTable dt = null;
            MerchantDatabase a = new MerchantDatabase();
            dt = a.search(key);
            return dt;
        }

        // Get the catagories that are available in the database
        public string[] GetCategory()
        {
            string[] cat = null;
            MerchantDatabase md = new MerchantDatabase();
            cat = md.GetCategory();
            return cat;
        }

        //Fetch old password nd return to check from the entered password
        public string GetOldPassword(string user)
        {
            string pass = null;
            MerchantDatabase md = new MerchantDatabase();
            pass = md.GetOldPassword(user);

            return pass;
        }

        //This will update the password if called
        public void UpdatePassword(string pass)
        {
            MerchantDatabase md = new MerchantDatabase();
            md.UpdatePassword(pass);
        }

        //This will update merchant database information when called
        public void UpdateProfile()
        {
            MerchantDatabase md = new MerchantDatabase();
            md.UpdateProfile();
        }

    }
}
