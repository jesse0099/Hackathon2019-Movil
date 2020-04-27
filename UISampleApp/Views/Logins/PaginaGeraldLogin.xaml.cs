using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models;
using UISampleApp.Services;
using UISampleApp.Views.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UISampleApp.Views.Logins
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaGeraldLogin : ContentPage
	{
        RestServiceConsumer proc = new RestServiceConsumer();

		public PaginaGeraldLogin ()
		{
			InitializeComponent ();
		}



        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}