using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Interfaces;
using Xamarin.Forms;
using UISampleApp.Resources;

namespace UISampleApp.Models
{
    public class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture= ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Test => Resource.Test;

    }
}
