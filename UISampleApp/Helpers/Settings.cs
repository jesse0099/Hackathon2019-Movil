using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UISampleApp.Models;

namespace UISampleApp.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string serializedToken = "SerializedToken";
        private const string logguedInfo = "LogguedInfo";
        private const string fullName = "FullName";
        private const string isRemenbered = "IsRemembered";
        private static readonly string stringDefault = string.Empty;
        private static readonly bool boolDefault = false;


        #endregion


        public static string SerializedToken
        {
            get
            {
                return AppSettings.GetValueOrDefault(serializedToken, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(serializedToken, value);
            }
        }

        public static bool IsRemembered {
            get {
                return AppSettings.GetValueOrDefault(isRemenbered, boolDefault);
            }
            set {
                AppSettings.AddOrUpdateValue(isRemenbered, value);
            }
        }

        public static string FullName{
            get {
                return AppSettings.GetValueOrDefault(fullName,stringDefault);
            }

            set {
                AppSettings.AddOrUpdateValue(fullName, value);
            }
        }



    }
}
