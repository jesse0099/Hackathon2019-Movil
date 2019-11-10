using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISampleApp.Models
{
    public class Producto : NotificationObject
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value;
                onPropertyChanged();
            }
        }

        private string nombreProducto;

        public string NombreProducto
        {
            get { return nombreProducto; }
            set { nombreProducto = value;
                onPropertyChanged();
            }
        }

        private string empresa;

        public string Empresa
        {
            get { return empresa; }
            set { empresa = value;
                onPropertyChanged();
            }
        }

        private double precio;

        public double Precio
        {
            get { return precio; }
            set { precio = value;
                onPropertyChanged();
            }
        }


        private int existencias;

        public int Existencias
        {
            get { return existencias; }
            set { existencias = value;
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

        private DateTime fechVencimiento;

        public DateTime FechaVencimiento
        {
            get { return fechVencimiento; }
            set { fechVencimiento = value;
                onPropertyChanged();
            }
        }


    }
}
