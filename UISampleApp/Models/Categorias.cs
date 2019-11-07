using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISampleApp.Models
{
    public class Categorias : NotificationObject
    {
        private ObservableCollection<Categoria> categoriaslist;

        public ObservableCollection<Categoria> CategoriasList
        {
            get { return categoriaslist; }
            set
            {
                categoriaslist = value;
                onPropertyChanged();
            }

        }
        private string categoriaSeleccionada;

        public string CategoriaSeleccionada
        {
            get { return categoriaSeleccionada; }
            set { categoriaSeleccionada = value;
                onPropertyChanged();
            }
        }


        public Categorias()
        {
            //Valores de testeo
            CategoriasList = new ObservableCollection<Categoria>();
            CategoriasList.Add(new Categoria(){ NombreCategoria="Farmacias",Vendedores=89,Portada="Drugs.png"});
            CategoriasList.Add(new Categoria(){ NombreCategoria="Restaurantes",Vendedores=79,Portada="restaurant.png"});
            CategoriasList.Add(new Categoria(){ NombreCategoria="Electronicos",Vendedores=29,Portada="Elec.png"});
        }


    }
}
