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
<<<<<<< HEAD
           Application.Run(new Admin());
=======
            Application.Run(new Admin());
>>>>>>> parent of 5d1ee64 (Merge branch 'master' of https://github.com/yeab-tilahun/Ecommerce-application)
            Application.Run(new SignIn());
        }
    }
}
