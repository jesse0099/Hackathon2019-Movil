using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Views.UpdateInfoUser;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using UISampleApp.Models;
using UISampleApp.ViewModels;

namespace UISampleApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootHomePage : Xamarin.Forms.TabbedPage
    {
        public RootHomePage ()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            this.SelectedTabColor = Color.White;
            this.UnselectedTabColor = Color.White;

            

            lblDateRegistered.Text = string.Format("{0:t}",DateTime.Now.ToString());

            //LecturaMensajes
            MessagingCenter.Subscribe<RootExplorePageViewModel>(this, "Goto",(a)=> {
                //Iniciar navegacion en el stack
                gotoEnterprise(((Categoria)lstCats.SelectedItem).NombreCategoria);
            });

            
        }

        private async void  gotoEnterprise(string categoria)
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new UISampleApp.Views.Enterprises.EnterprisePage(categoria));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new UISampleApp.Views.UpdateInfoUser.ActualizarInformacion());
        }




    }

}