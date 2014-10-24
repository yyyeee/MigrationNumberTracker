using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MigrationNumberTracker.Logging;

namespace MigrationNumberTracker.TrayApp
{
    static class Program
    {
        private static readonly Log Log = new Log();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (new MainIcon())
            {
                Application.Run();
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Error((Exception)e.ExceptionObject);
        }
    }
}
