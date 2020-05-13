using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CurrentActivity;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Services;


namespace UISampleApp.Droid
{

    [Activity(Label = "UISampleApp.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            //Inicializacion de RG.Plugin
            Rg.Plugins.Popup.Popup.Init(this, bundle);

            //Cambio de color de la barra de estado
            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#0a0a0a"));
          
            LoadApplication(new App());
        }

        public override void OnBackPressed() {
            if (Popup.SendBackPressed(base.OnBackPressed))
            {
                //PopUps en el stack de de popups
                PopupNavigation.Instance.PopAllAsync();
            }
            else {
                //Nada en el stack de popups
            }
        }
    }
}
