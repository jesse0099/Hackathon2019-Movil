using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models;

namespace UISampleApp.ViewModels
{
    public class ProfileViewModel:NotificationObject
    {
        private ClientProfileResponse myClient;

        public ClientProfileResponse MyClient
        {
            get { return myClient; }
            set { myClient = value;
                onPropertyChanged();
            }
        }

        public ProfileViewModel() {
            //Obtencion de datos del perfil


        }


    }
}
