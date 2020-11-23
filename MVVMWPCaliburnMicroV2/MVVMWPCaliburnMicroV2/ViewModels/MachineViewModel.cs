using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVMWPCaliburnMicroV2.ViewModels
{
    class MachineViewModel : Screen, IMainScreenTabItem
    {
        public MachineViewModel(string name)
        {
            Name = name;
            DisplayName = name;

        }
        public string Name { get; set; }

    }
}
