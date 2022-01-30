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
            string constr = "Server = DESKTOP-4370VSE;   Database = Ecommerce; integrated security=true";
            SqlConnection con = new SqlConnection(constr);
            return con;
        }
    }
}
