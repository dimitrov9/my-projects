using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karavas_Stock_Management
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
            LoginForm login = new LoginForm();
            DialogResult result = login.ShowDialog();
            if(result == DialogResult.OK)
            {
                Application.Run(new Form1(false));
            }
            else
            {
                Application.Exit();
            }

        }
    }
}
