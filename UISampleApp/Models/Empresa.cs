using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        private string _categoria;

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }

        private ImageSource _logo;

        public ImageSource Logo
        {
            get { return _logo; }
            set { _logo = value; }
        }




    }
}
