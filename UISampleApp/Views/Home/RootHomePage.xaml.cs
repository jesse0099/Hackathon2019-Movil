using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Views.UpdateInfoUser;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using UISampleApp.Models;
using UISampleApp.ViewModels;
using Rg.Plugins.Popup.Services;
using UISampleApp.Views.PopUps;
using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;

namespace UISampleApp.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootHomePage : Xamarin.Forms.TabbedPage
    {
        private Orden selectedOrder;

        public Orden SelectedOrder
        {
            get { return selectedOrder; }
            set { selectedOrder = value; }
        }


        public RootHomePage ()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            this.SelectedTabColor = Color.White;
            this.UnselectedTabColor = Color.White;

            

            lblDateRegistered.Text = string.Format("{0:t}",DateTime.Now.ToString());

            //LecturaMensajes
            MessagingCenter.Subscribe<RootExplorePageViewModel>(this, "Goto",(a)=> {
                //Iniciar navegacion en el stack
                gotoEnterprise(((Categoria)lstCats.SelectedItem).NombreCategoria);
            });


            lstOrders.ItemTapped += (object sender, ItemTappedEventArgs e) => {
                // don't do anything if we just de-selected the row.
                if (e.Item == null) return;

                // Optionally pause a bit to allow the preselect hint.
                Task.Delay(500);

                selectedOrder = ((Orden)lstOrders.SelectedItem);
                // Deselect the item.
                if (sender is Xamarin.Forms.ListView lv) lv.SelectedItem = null;

            };

            lstCarrito.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                if (e.Item == null) return;

                Task.Delay(500);

                // Deselect the item.
                if (sender is Xamarin.Forms.ListView lv) lv.SelectedItem = null;
            };

        }

        private async void  gotoEnterprise(string categoria)
        {
            lstCats.SelectedItem = null;
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new UISampleApp.Views.Enterprises.EnterprisePage(categoria));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new UISampleApp.Views.UpdateInfoUser.ActualizarInformacion());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (SelectedOrder != null)
            {
                var popupProperties = new PopUpOrderDetail(SelectedOrder.Items,SelectedOrder);
                var scaleAnimation = new ScaleAnimation
                {
                    PositionIn = MoveAnimationOptions.Right,
                    PositionOut = MoveAnimationOptions.Left
                };
                await PopupNavigation.PushAsync(popupProperties);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

    }

}