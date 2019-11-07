using Syncfusion.XForms.iOS.BadgeView;
using Syncfusion.XForms.iOS.Core;
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace UISampleApp.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
global::Xamarin.Forms.Forms.Init();
SfBadgeViewRenderer.Init();
SfAvatarViewRenderer.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
