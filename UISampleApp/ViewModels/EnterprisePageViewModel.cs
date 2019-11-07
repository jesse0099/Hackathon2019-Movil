using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using UISampleApp.Models;
using System.ComponentModel;

namespace UISampleApp.ViewModels
{
    public class EnterprisePageViewModel : NotificationObject
    {
        private ObservableCollection<Empresa> empresas;

        public ObservableCollection<Empresa> Empresas
        {
            get { return empresas; }
            set { empresas = value; }
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


            Empresas.Add(new Empresa() { Estrellas=4.5,FechaAfiliacion = DateTime.Now, Ilustracion="",Nombre="Super express" });

            PropertyChanged += EnterprisePageViewModel_PropertyChanged;
        }

        private void EnterprisePageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.SelectedEnterprise))
            {
                //Enviar mensaje para navegar

            }
        }
    }
}
