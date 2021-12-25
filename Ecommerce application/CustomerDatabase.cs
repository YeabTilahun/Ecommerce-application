using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_application
{
    class CustomerDatabase
    {
        string connection = "Server =  LAPTOP-RS59N8IM; Database = E-Commerce; integrated security = true;";

        public void AddToCart(CustomerClass Cc)
        {
            using (SqlConnection connect = new SqlConnection(connection))
            {
                connect.Open();
                string query = "INSERT INTO CustomerBuy VALUES ('" + Cc.Id + "', '" + Cc.ProductName + "','" + Cc.Price + "','" + Cc.Quantity + "')";
                SqlCommand cmd = new SqlCommand(query, connect);
            }
        }
    }
}
