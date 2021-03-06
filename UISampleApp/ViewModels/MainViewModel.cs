﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models;

namespace UISampleApp.ViewModels
{
    public class MainViewModel
    {
        public InventarioPageViewModel Inventario { get; set; }
        public RootExplorePageViewModel RootExplorer { get; set; }
        public EnterprisePageViewModel  Enterprises { get; set; }
        public LoginViewModel Login { get; set; }
        public RootExplorePageViewModel rootViewModel { get; set; }

        public MainViewModel() {

            this.Inventario = new InventarioPageViewModel();
            this.RootExplorer = new RootExplorePageViewModel();
            this.Login = new LoginViewModel();
            this.Enterprises = new EnterprisePageViewModel();
            this.rootViewModel = new RootExplorePageViewModel();

        }


    }
}
