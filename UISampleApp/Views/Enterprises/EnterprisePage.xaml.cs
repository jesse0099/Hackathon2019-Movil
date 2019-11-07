using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UISampleApp.Views.Enterprises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterprisePage : ContentPage
    {
        public EnterprisePage(string category)
        {
            InitializeComponent();


            //Crear recurso en base a la categoria enviada
            this.BindingContext = new EnterprisePage(category);

        }
    }
}