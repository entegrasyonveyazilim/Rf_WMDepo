using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KoctasWM_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Application.Run(new frm_WMLogin());
        }

        public static Boolean canli = false;

    }
}