using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecommerce_application
{
    public partial class The_Wait_Form : Form
    {
        public The_Wait_Form()
        {
            Thread t = new Thread(new ThreadStart(Splash));
            InitializeComponent();

            //Loading data
            string str = string.Empty;
            for(int i =0; i < 100000; i++)
            {
                str = str + i.ToString();
            }

            t.Abort();
        }

        void Splash()
        {
            SplashScreen.SplashForm form = new SplashScreen.SplashForm();
            form.AppName = "";
            Application.Run(form);
          //Application.Run(Home);
        }

        private void The_Wait_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
