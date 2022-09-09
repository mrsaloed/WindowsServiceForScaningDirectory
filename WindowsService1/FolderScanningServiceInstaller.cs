using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WindowsService1
{
    [RunInstaller(true)]
    public partial class FolderScanningServiceInstaller : Installer
    {

        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;

        public FolderScanningServiceInstaller()
        {
            InitializeComponent();
            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "FolderScanningService";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
