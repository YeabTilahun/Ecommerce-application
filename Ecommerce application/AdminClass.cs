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

        public DataTable GetProduct(string name)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetProduct(name);
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
<<<<<<< HEAD

        public string[] GetMonth()
        {
            AdminDatabase AdminD = new AdminDatabase();
            string[] month = AdminD.GetMonth();
            return month;
        }

        public string[] GetCategoryTransaction()
        {
            AdminDatabase AdminD = new AdminDatabase();
            string[] category = AdminD.GetCategoryTransaction();
            return category;
        }

        public DataSet GetYearlyReport(string category)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataSet ds = AdminD.GetYearlyReport(category);
            return ds;
        }

        public DataSet GetMonthlyReport(string category, int month)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataSet ds = AdminD.GetMonthlyReport(category, month);
            return ds;
        }

        public DataSet GetWeeklyReport(string category)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataSet ds = AdminD.GetWeeklyReport(category);
            return ds;
        }

        public DataSet GetDailyReport(string category)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataSet ds = AdminD.GetDailyReport(category);
            return ds;
        }

        public DataTable GetProductImageAndName(string ID)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetProductImageAndName(ID);
            return dt;
        }

        public DataTable GetProductYearlyReport(string category)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetProductYearlyReport(category);
            return dt;
        }

        public DataTable GetProductMonthlyReport(string category, int month)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetProductMonthlyReport(category, month);
            return dt;
        }

        public DataTable GetProductWeeklyReport(string category)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetProductWeeklyReport(category);
            return dt;
        }

        public DataTable GetProductDailyReport(string category)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetProductDailyReport(category);
            return dt;
        }

        public DataTable GetPermit(string UserName)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetPermit(userName);
            return dt;
        }

        public DataTable GetValidMerchant(string name)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetValidMerchant(name);
            return dt;
        }

        public DataTable GetProgressMerchant(string name)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetProgressMerchant(name);
            return dt;
        }

        public void AddToAll(string userName, string password, string role)
        {
            AdminDatabase adminD = new AdminDatabase();
            adminD.AddToAll(userName, password, role);
        }

        public void DeleteMerchant(string userName)
        {
            AdminDatabase adminD = new AdminDatabase();
            adminD.DeleteMerchant(userName);
        }
=======
>>>>>>> parent of 5d1ee64 (Merge branch 'master' of https://github.com/yeab-tilahun/Ecommerce-application)
    }
}
