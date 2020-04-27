using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using UISampleApp.Models;
using System.ComponentModel;
using Xamarin.Forms;
using UISampleApp.Services;
using System.Windows.Input;
using System.IO;

namespace UISampleApp.ViewModels
{
   

    public class EnterprisePageViewModel : NotificationObject
    {
        #region Propiedades
        public string CurrentCategory { get; set; }

        public RestServiceConsumer proc { get; set; }

        private string lorem = "Su tienda de conveniencia mas surtida";

        private Boolean _isRefreshing;

        public Boolean IsRefreshing
        {
            get { return _isRefreshing; }
            set { _isRefreshing = value;
                onPropertyChanged();
            }
        }

        private ObservableCollection<Empresa> empresas;

        public ObservableCollection<Empresa> Empresas
        {
            get { return empresas; }
            set { empresas = value;
                onPropertyChanged();
            }
        }

        private ObservableCollection<Empresa> _unfilteredEnterprises;

        public ObservableCollection<Empresa> UnfilteredEnterprises
        {
            get { return _unfilteredEnterprises; }
            set { _unfilteredEnterprises = value; }
        }

        private Empresa selectedEnterprise;

        public Empresa SelectedEnterprise
        {
            get { return selectedEnterprise; }
            set { selectedEnterprise = value;
                onPropertyChanged();
            }
        }

        private  ICommand _refreshingCommand;

        public  ICommand RefreshingCommand
        {
            get { return _refreshingCommand; }
            set { _refreshingCommand = value;
                onPropertyChanged();
            }
        }


        #endregion

        public EnterprisePageViewModel() {

        }

        public EnterprisePageViewModel(string categoria)
        {
            proc = new RestServiceConsumer();
            Empresas = new ObservableCollection<Empresa>();
            UnfilteredEnterprises = new ObservableCollection<Empresa>();
            this.CurrentCategory = categoria;
            this.RefreshingCommand = new Command(refreshingExecute);
            loadBusiness(categoria);
            PropertyChanged += EnterprisePageViewModel_PropertyChanged;
        }


        #region Metodos,comandos y eventos
        public async void loadBusiness(string category)
        {
            Device.BeginInvokeOnMainThread(() => {
                this.IsRefreshing = true;
            });
            var response = await proc.GetList<List<Comercio>>(Constantes.BASEURL, Constantes.COMMEPREFIX, $"{Constantes.COMMEGETBYCAT}{category}");
            await Task.Delay(1000);
            if (!response.IsSuccesFull)
            {
                //Error
                this.IsRefreshing = false;
            }
            else
            {
                List<Comercio> returned = (List<Comercio>)response.Result;
                foreach (var item in returned)
                {
                    //Lectura del String en Base 64 entregado por el WebService
                    ImageSource imageSource;
                    var byteArrayLogo = Convert.FromBase64String(Convert.ToString(item.logo));
                    //Transformacion del array de bytes obtenido del String en Base64 a un ImageSource
                    
                    if (byteArrayLogo.Length != 0)
                        imageSource = ImageSource.FromStream(() => new MemoryStream(byteArrayLogo));
                    else
                        imageSource = ImageSource.FromFile("isoBuy.png");


                        this.Empresas.Add(new Empresa() { Categoria = item.categoria, Estrellas = item.estrellas, Descripcion = item.descripcion, Nombre = item.nombreComercio, Logo = imageSource, Ilustracion = "isoBuy.png", FechaAfiliacion = item.fechaAfiliacion });
                    
                }
                this.UnfilteredEnterprises = this.Empresas;

            }
            Device.BeginInvokeOnMainThread(() => {
                this.IsRefreshing = false;
            });
        }
        public void refreshingExecute() {
            this.Empresas.Clear();
            loadBusiness(this.CurrentCategory);
        }
        private void EnterprisePageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.SelectedEnterprise))
            {
                //Enviar mensaje para navegar
                MessagingCenter.Send(this, "GotoInventario");
            }
        }
        public void filter(string filter) {
            if (String.IsNullOrEmpty(filter))
            {
                this.Empresas= this.UnfilteredEnterprises;
                onPropertyChanged();
            }
            else
            {
                this.Empresas = this.UnfilteredEnterprises;
                this.Empresas = new ObservableCollection<Empresa>(this.Empresas.Where((x) => x.Nombre.ToLower().Trim().Contains(filter.Trim().ToLower()) ||
                x.FechaAfiliacion.ToString().Equals(filter) ||
                Convert.ToString(x.Estrellas).Equals(filter) || 
                x.Descripcion.Trim().ToLower().Contains(filter.Trim().ToLower())).ToList());
                onPropertyChanged();
            }
        }
        #endregion

    }
}
