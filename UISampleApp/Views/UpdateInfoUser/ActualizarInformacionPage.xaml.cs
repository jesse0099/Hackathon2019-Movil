using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UISampleApp.Views.UpdateInfoUser
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarInformacion : ContentPage
    {
        public ActualizarInformacion()
        {
            InitializeComponent();
            aicImageLoad.Color = Color.FromHex("#3699de");
            aicImageLoad.IsVisible = false;
            aicImageLoad.IsRunning = false;
        }

        private async void BtnImg_Tapped(object sender, EventArgs e)
        {
            aicImageLoad.IsVisible = true;
            aicImageLoad.IsRunning = true;
            await CrossMedia.Current.Initialize();
            if(!CrossMedia.Current.IsTakePhotoSupported && !CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions {
                    Directory = "Images",
                    Name = DateTime.Now.ToString()+"_new.jpg"
                });
                if (file == null)
                    return;
                imgProfile.Source = ImageSource.FromStream(()=> {
                    var stream = file.GetStream();
                    return stream;
                });
            }
            aicImageLoad.IsVisible = false;
            aicImageLoad.IsRunning = false;
        }
    }
}