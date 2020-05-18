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
using SQLite;
using UISampleApp.Interfaces;

namespace UISampleApp.Views.Logins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaGeraldLogin : ContentPage
    {
        RestServiceConsumer proc = new RestServiceConsumer();

        public PaginaGeraldLogin()
        {
            InitializeComponent();

        }



        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //Reconocimiento de Gestos 

        }
    }
}