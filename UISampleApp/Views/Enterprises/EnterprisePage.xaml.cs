using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models;
using UISampleApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UISampleApp.Views.Enterprises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterprisePage : ContentPage , INotifyPropertyChanged
    {
        private EnterprisePageViewModel context;

        public EnterprisePageViewModel Context
        {
            get { return context; }
            set { context = value;
                OnPropertyChanged();
            }
        }


        public EnterprisePage(string category)
        {
            //Context 
             Context = new EnterprisePageViewModel(category);

            //Crear recurso en base a la categoria enviada


            InitializeComponent();

            lstEnterprises.BindingContext = Context;


            MessagingCenter.Subscribe<EnterprisePageViewModel>(this, "GotoInventario", (x) => {
                //Respuesta
                gotoInventario(((Empresa)lstEnterprises.SelectedItem).Nombre);

            });

        }

        private void SldStars_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private async void gotoInventario(string empresa)
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new UISampleApp.Views.Enterprises.InventarioPage(empresa));
        }

    }
}