using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using UISampleApp.ViewModels;
using UISampleApp.Views.PopUps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UISampleApp.Views.Enterprises
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InventarioPage : ContentPage
    {
        private InventarioPageViewModel context;

        public InventarioPageViewModel Context
        {
            get { return context; }
            set { context = value;

            }
        }

        public InventarioPage(string empresa)
        {
            //Context 
            Context  = new InventarioPageViewModel(empresa);

            InitializeComponent();

            lstEnterprises.BindingContext = Context;

            //this.popupLoadingView.IsVisible = false;

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var popupProperties = new TestPop();
            var scaleAnimation = new ScaleAnimation
            {
                PositionIn = MoveAnimationOptions.Right,
                PositionOut = MoveAnimationOptions.Left
            };
            await PopupNavigation.PushAsync(popupProperties);
        }
    }
}