using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using UISampleApp.Models;
using System.ComponentModel;
using Xamarin.Forms;

namespace UISampleApp.ViewModels
{
   

    public class EnterprisePageViewModel : NotificationObject
    {
        private string lorem = "Su tienda de conveniencia mas surtida";

        private ObservableCollection<Empresa> empresas;

        public ObservableCollection<Empresa> Empresas
        {
            get { return empresas; }
            set { empresas = value;
                onPropertyChanged();
            }
        }

        private Empresa selectedEnterprise;

        public Empresa SelectedEnterprise
        {
            get { return selectedEnterprise; }
            set { selectedEnterprise = value;
                onPropertyChanged();
            }
        }


        public EnterprisePageViewModel(string categoria)
        {
            //Aqui se supone que vendria una query bien vergas,claro,si hubiera BD
            //Y api terminada

            Empresas = new ObservableCollection<Empresa>();

            Empresas.Add(new Empresa() { Estrellas=4.5,FechaAfiliacion = DateTime.Now, Ilustracion= "isoBuy.png",Nombre="Super express",Descripcion=lorem});
            Empresas.Add(new Empresa() { Estrellas=3.5,FechaAfiliacion = DateTime.Now, Ilustracion= "isoBuy.png", Nombre="Ferreteria jenny",Descripcion="Las herramientas que desee al mejor precio"});
            Empresas.Add(new Empresa() { Estrellas=2.5,FechaAfiliacion = DateTime.Now, Ilustracion= "isoBuy.png", Nombre="McDonald",Descripcion=lorem});
            Empresas.Add(new Empresa() { Estrellas=5.0,FechaAfiliacion = DateTime.Now, Ilustracion= "isoBuy.png", Nombre="GoDealer",Descripcion="Tu dealer 24/7,discrecion en nuestra operacion"});
            Empresas.Add(new Empresa() { Estrellas=1.5,FechaAfiliacion = DateTime.Now, Ilustracion= "isoBuy.png", Nombre="DevSocket",Descripcion="Las mejores soluciones de software al mejor precio"});

            PropertyChanged += EnterprisePageViewModel_PropertyChanged;
        }

        private void EnterprisePageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.SelectedEnterprise))
            {
                //Enviar mensaje para navegar
                MessagingCenter.Send(this,"GotoInventario");
            }
        }
    }
}
