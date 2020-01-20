using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models;
using UISampleApp.Views.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UISampleApp.Views.Logins
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaGeraldLogin : ContentPage
	{
        RestClient proc = new RestClient();

		public PaginaGeraldLogin ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (txtPassword.Text != string.Empty && txtUser.Text != string.Empty)
            {
                proc = new RestClient();
                var response = await proc.PostToken("https://eecommerapi.conveyor.cloud/api/login/authenticateclient", new LoginClientRequest()
                {
                    Password = txtPassword.Text
                ,
                    User = txtUser.Text
                }, typeof(LoginClientRequest));

                ClientProfileResponse profileResponse = await proc.GetAuth<ClientProfileResponse>(
                    string.Format("https://eecommerapi.conveyor.cloud/api/clients/profileInfo?uniquename={0}",txtUser.Text), response); 

                if (response!=string.Empty)
                    await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new RootHomePage());
                else
                    await DisplayAlert("Error!", "Credenciales incorrectas", "OK");
            }
            else
            {
                await DisplayAlert("Error!", "Todos los datos son obligatorios", "OK");
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }
}