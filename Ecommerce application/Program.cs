using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new The_Wait_Form());
            //Application.Run(new Home());
            Application.Run(new CustomerPage("yeabsira"));
            //Application.Run(new Admin());
            //Application.Run(new SignIn());
            //Application.Run(new Merchant("yeabsira"));
        }
    }
}
