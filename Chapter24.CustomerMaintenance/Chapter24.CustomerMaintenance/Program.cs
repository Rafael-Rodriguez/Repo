using Chapter24.CustomerMaintenance.Perspectives;
using System;
using System.Windows.Forms;

namespace Chapter24.CustomerMaintenance
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
            Application.Run(new frmAddModifyCustomer());
        }
    }
}
