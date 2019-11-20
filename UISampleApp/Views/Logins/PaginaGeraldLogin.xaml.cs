using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Views.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UISampleApp.Views.Logins
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaGeraldLogin : ContentPage
	{
		public PaginaGeraldLogin ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new RootHomePage());
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}