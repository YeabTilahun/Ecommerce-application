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
        public byte[] photo;

        public AdminClass()
        {

        }

        public AdminClass(string adminID, string firstName, string lastName, string sex, string birthday, string phoneNumber, string email, string userName, string password, string role, byte[] photo)
        {
            this.adminID = adminID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.sex = sex;
            this.birthday = birthday;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.userName = userName;
            this.password = password;
            this.role = role;
            this.photo = photo;
        }

        public AdminClass(string firstName, string lastName, string sex, string birthday, string phoneNumber, string email, string userName, string password, string role, byte[] photo)
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
            this.photo = photo;
        }

        public AdminClass(string adminID, string password)
        {
            this.adminID = adminID;
            this.password = password;
        }

        public void Save()
        {
            AdminDatabase adminD = new AdminDatabase();
            adminD.SaveAdmin(this);
        }

        public void UpdateAdmin()
        {
            AdminDatabase adminD = new AdminDatabase();
            adminD.UpdateAdmin(this);
        }

        public void ChangePassword()
        {
            AdminDatabase adminD = new AdminDatabase();
            adminD.ChangePassword(this);
        }

        public DataTable GetAdmin(string name)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetAdmin(name);
            return dt;
        }

        public DataTable GetAdminProfile()
        {
            AdminDatabase ad = new AdminDatabase();
            DataTable dt = ad.GetAdminProfile();
            return dt;
        }

        public DataTable GetProduct(string name, string category)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetProduct(name, category);
            return dt;
        }

        public DataTable GetLatestProduct(string name, string category)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetLatestProduct(name, category);
            return dt;
        }

        public DataTable GetMerchant(string name)
        {
            AdminDatabase AdminD = new AdminDatabase();
            DataTable dt = AdminD.GetMerchant(name);
            return dt;
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

        public string[] GetLatestCategory()
        {
            AdminDatabase AdminD = new AdminDatabase();
            string[] category;
            category = AdminD.GetLatestCategory();
            return category;
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

        public DataTable GetPermit(string userName)
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

        public void UpdateStatusActive(string userName)
        {
            AdminDatabase adminD = new AdminDatabase();
            adminD.UpdateStatus(userName, "Active");
        }

        public void UpdateStatusReject(string userName)
        {
            AdminDatabase adminD = new AdminDatabase();
            adminD.UpdateStatus(userName, "Rejected");
        }
    }
}
