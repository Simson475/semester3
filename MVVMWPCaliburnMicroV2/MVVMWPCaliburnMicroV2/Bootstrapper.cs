using Caliburn.Micro;
using MVVMWPCaliburnMicroV2.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MVVMWPCaliburnMicroV2
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}
