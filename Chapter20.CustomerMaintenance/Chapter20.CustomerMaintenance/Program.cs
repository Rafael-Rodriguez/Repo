﻿using Chapter20.CustomerMaintenance.Presentation;
using System;
using System.Windows.Forms;

namespace Chapter20.CustomerMaintenance
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
            Application.Run(new frmCustomerMaintenance());
        }
    }
}
