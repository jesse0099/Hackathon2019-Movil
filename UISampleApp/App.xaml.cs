

namespace UISampleApp
{
    using UISampleApp.Logins;
    using Xamarin.Forms;
    using UISampleApp.Views.SignUps;
    using UISampleApp.Views.Logins;
    using UISampleApp.Views.UpdateInfoUser;
    using UISampleApp.Views.Home;
    using UISampleApp.Helpers;
    using UISampleApp.Services;

    public partial class App : Application
    {

        static TodoItemDatabase database;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new PaginaGeraldLogin());
            
        }

        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            if (Settings.IsRemembered & !Settings.SerializedToken.Equals(string.Empty))
                MainPage = new RootHomePage();
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
