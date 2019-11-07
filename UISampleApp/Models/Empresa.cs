using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISampleApp.Models
{
    public class Empresa :  NotificationObject
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                onPropertyChanged();
            }
        }

        private string ilustracion;

        public string Ilustracion
        {
            get { return ilustracion; }
            set { ilustracion = value;
                onPropertyChanged();
            }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value;
                onPropertyChanged();
            }
        }



        private DateTime fechaAfilacion;

        public DateTime FechaAfiliacion
        {
            get { return fechaAfilacion; }
            set { fechaAfilacion = value;
                onPropertyChanged();
            }
        }

        private double estrellas;

        public double Estrellas
        {
            get { return estrellas; }
            set { estrellas = value;
                onPropertyChanged();
            }
        }




    }
}
