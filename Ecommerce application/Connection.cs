using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_application
{
    class Connection
    {
        public SqlConnection CreateConnection()
        {
            /*string constr = "Server=YEABS;   database=Ecommerce; integrated security=true;";
            SqlConnection con = new SqlConnection(constr);
            return con;

            /*string connect = "Server=DESKTOP-4370VSE;   database=Ecommerce; integrated security=true;";
            SqlConnection con = new SqlConnection(connect);
            return con;*/

            /*string connect = "Server=192.168.1.106;   database=Ecommerce; uid=sa; pwd=P@$$w0rd;";*/
            //string connect = "Server = LAPTOP-RS59N8IM; Database = Ecommerce; Integrated Security = true;";
            string connect = "Server=YEABS;   database=Ecommerce; integrated security=true;";
            SqlConnection con = new SqlConnection(connect);
            return con;
        }
    }
}
