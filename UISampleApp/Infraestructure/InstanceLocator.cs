using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.ViewModels;

namespace UISampleApp.Infraestructure
{
    public class InstanceLocator
    {
        public MainViewModel  Main{ get; set; }

        public InstanceLocator() {
            this.Main = new MainViewModel();
        }

    }
}
