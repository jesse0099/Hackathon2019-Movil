using System;
using System.Collections.Generic;
using UISampleApp.Effects;
using UISampleApp.Views.Home;
using UISampleApp.Views.SignUps;
using Xamarin.Forms;

namespace UISampleApp.Logins
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SignUpPage());
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new RootHomePage());
        }
    }
}
