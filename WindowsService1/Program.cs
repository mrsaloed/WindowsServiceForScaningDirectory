using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main( string[] args)
        {
            if (Environment.UserInteractive)
            {
                FolderScanningService service1 = new FolderScanningService();
                service1.TestStartupAndStop(args);
            }
            else
            {
                // Put the body of your old Main method here.  
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new FolderScanningService()
                };
                ServiceBase.Run(ServicesToRun);
            }

            
        }
    }
}
