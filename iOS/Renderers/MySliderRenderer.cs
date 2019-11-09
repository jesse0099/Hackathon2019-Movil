using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using UISampleApp.Controls;
using UISampleApp.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof(CustomSlider),typeof(MySliderRenderer))]
namespace UISampleApp.iOS.Renderers
{
    public class MySliderRenderer : SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Slider> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;

            var view = (CustomSlider)Element;
            if (!string.IsNullOrEmpty(view.ThumbImage) ||
            view.ThumbColor != Xamarin.Forms.Color.Default ||
                view.MaxColor != Xamarin.Forms.Color.Default ||
                view.MinColor != Xamarin.Forms.Color.Default)
            {

                Control.SetThumbImage(UIImage.FromFile(view.ThumbImage), UIControlState.Normal);
            }

            Control.ThumbTintColor = view.ThumbColor.ToUIColor();

            Control.MinimumTrackTintColor = view.MinColor.ToUIColor();

            Control.MaximumTrackTintColor = view.MaxColor.ToUIColor();
        }
    }
}
