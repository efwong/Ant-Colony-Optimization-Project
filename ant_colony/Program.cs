using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ant_colony
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
            Application.Run(new ant_colony_s_path());
        }
    }
}