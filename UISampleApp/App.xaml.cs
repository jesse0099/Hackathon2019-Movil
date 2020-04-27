using UISampleApp.Logins;
using Xamarin.Forms;
using UISampleApp.Views.SignUps;
using UISampleApp.Views.Logins;
using UISampleApp.Views.Home;

namespace UISampleApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new RootHomePage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
