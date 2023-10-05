using ExcelAutomation.Formularios;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelAutomation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmListarDados());
        }

    }
}