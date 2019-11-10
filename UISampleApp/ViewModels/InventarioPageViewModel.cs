using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models;
using System.Collections.ObjectModel;

namespace UISampleApp.ViewModels
{
    public class InventarioPageViewModel : NotificationObject 
    {
        private ObservableCollection<Producto>  productos;

        public  ObservableCollection<Producto>  Productos
        {
            get { return  productos; }
            set { productos = value;
                onPropertyChanged();
            }
        }


        public InventarioPageViewModel(string empresa)
        {
            //Inicializacion en base a mi clase de constantes
            Productos = new ObservableCollection<Producto>();
            Productos.Add(new Producto() {NombreProducto= "Thermal Grizzly",Descripcion="Pasta termica",ID=1,Existencias=23,Precio = 12 });
            Productos.Add(new Producto() {NombreProducto= "Samsung-S10",Descripcion="Samsung S10 con todos sus accesorios",ID=2,Existencias=33,Precio=700});
            Productos.Add(new Producto() {NombreProducto= "RTX 2080", Descripcion="GPU generacion 2000 de Nvidia",ID=2,Existencias=33,Precio=900});
            Productos.Add(new Producto() {NombreProducto= "RTX 2070", Descripcion="GPU generacion 2000 de Nvidia",ID=2,Existencias=13,Precio=800});
        }

    }
}
