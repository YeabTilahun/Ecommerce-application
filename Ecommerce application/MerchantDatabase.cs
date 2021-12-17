using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Ecommerce_application
{
    class MerchantDatabase
    {
        public void AddProduct(MerchantSellClass sell)
        {
            try
            {
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Delete(String id)
        {
            try
            {
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void UpdateProduct(MerchantSellClass sell)
        {
            try
            {
                
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
