using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISampleApp.Models
{
    public class Item : NotificationObject
    {
        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value;
                onPropertyChanged();
            }
        }

        private string nombreItem;

        public string NombreItem
        {
            get { return nombreItem; }
            set { nombreItem = value;
                onPropertyChanged();
            }
        }


    }
}
