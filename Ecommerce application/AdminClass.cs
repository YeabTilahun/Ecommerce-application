using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    class AdminClass
    {
        string[] id;

        public AdminClass()
        {

        }

        public AdminClass(string[] id)
        {
            this.id = id;
        }
        public DataTable GetAdmin(string name)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetAdmin(name);
            return dt;
        }

        public string[] GetAdminProfile()
        {
            string[] profile;
            AdminDatabase ad = new AdminDatabase();
            profile = ad.GetAdminProfile();
            return profile;
        }

        public void DeleteProduct(string[] id)
        {
            AdminDatabase adminD = new AdminDatabase();
            adminD.DeleteProduct(id);
        }

        public DataTable GetProduct(string name, string category)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetProduct(name, category);
            return dt;
        }

        public void DeleteMerchants(string[] id)
        {
            AdminDatabase adminD = new AdminDatabase();
            adminD.DeleteMerchant(id);
        }

        public DataTable GetMerchant(string name)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetMerchant(name);
            return dt;
        }

        public void DeleteCustomers(string[] id)
        {
            AdminDatabase adminD = new AdminDatabase();
            adminD.DeleteCustomer(id);
        }

        public DataTable GetCustomer(string name)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetCustomer(name);
            return dt;
        }

        public DataTable GetTransaction()
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetTransaction();
            return dt;
        }
        public string[] GetCategory()
        {
            AdminDatabase AdminD = new AdminDatabase();
            string[] category;
            category = AdminD.GetCategory();
            return category;
        }

        public DataTable GetProductByCategory(string category)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetProductByCategory(category);
            return dt;
        }

        public string[] GetMonthlySold(int month)
        {
            AdminDatabase AdminD = new AdminDatabase();
            string[] product;
            product = AdminD.GetMonthlySold(month);
            return product;
        }

        public double GetMonthlyIncome()
        {
            AdminDatabase AdminD = new AdminDatabase();
            double income = AdminD.GetMonthlyIncome();
            return income;
        }

        public double GetYearlyIncome()
        {
            AdminDatabase AdminD = new AdminDatabase();
            double income = AdminD.GetYearlyIncome();
            return income;
        }
    }
}
