using System;
using System.Windows.Forms;
using Autofac;

namespace Brit.UI
{
    public static class Program
    {
        public static IContainer Container { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Container = IoC.CreateContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmCalculator());
        }
    }
}
