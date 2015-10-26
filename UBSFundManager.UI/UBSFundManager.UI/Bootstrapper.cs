using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Modularity;

namespace UBSFundManager.UI
{
    public class Bootstrapper:UnityBootstrapper
    {
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(FundsBlotter.FundsBlotterModule));
        }

        protected override DependencyObject CreateShell()
        {
            // Use the container to create an instance of the shell.
            Shell view = this.Container.TryResolve<Shell>();
            return view;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }


    }
}
