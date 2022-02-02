using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_application
{
    class CustomerPageClass
    {
        CustomerPageDatabase cd = new CustomerPageDatabase();
        public void Transaction1()
        {
            CustomerPageDatabase cd = new CustomerPageDatabase();
            cd.Transaction1();
        }

        public DataTable PopulateItem()
        {
            CustomerPageDatabase cd = new CustomerPageDatabase();
            DataTable dt = null;
            dt = cd.PopulateItem();
            return dt;
        }
    }
}
