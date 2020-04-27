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

        private Empresa _selectedEnterprise;

        public Empresa SelectedEnterprise
        {
            get { return _selectedEnterprise; }
            set { _selectedEnterprise = value; }
        }


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
            //Crear recurso en base a la categoria enviada

            Context = new EnterprisePageViewModel(category);

           
            InitializeComponent();

            lstEnterprises.BindingContext = Context;


            //Navegacion al inventario de la empresa seleccionada
            MessagingCenter.Subscribe<EnterprisePageViewModel>(this, "GotoInventario", (x) => {
                //Respuesta
                gotoInventario(((Empresa)lstEnterprises.SelectedItem).Nombre);
            });

        }

        private void SldStars_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            //var newStep = Math.Round(e.NewValue / 1.1);

            //sldStars.Value = newStep * 1.1;
        }

        private async void gotoInventario(string empresa)
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new UISampleApp.Views.Enterprises.InventarioPage(empresa));
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Context.filter(((SearchBar)sender).Text);
        }
    }
}