using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Util;
using Android.Gms.Common;

namespace Energy
{
    public static class DroidHelper
    {
        public static bool IsPlayServicesAvailable(Activity activity)
        {
            var resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(activity);

            return resultCode == ConnectionResult.Success;
        }

        public static void CreateNotificationChannel(Activity activity, string channelID)
        {
            //IF LESS THAN ANDROID 8, WE DO NOT NEED TO MAKE THIS
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                return;
            }

            NotificationChannel channel = new NotificationChannel(channelID, "Test Notifications", NotificationImportance.Default)
            {
                Description = "Test channel for Firebase Notifications"
            };
            NotificationManager manager = (NotificationManager)activity.GetSystemService(Context.NotificationService);
            manager.CreateNotificationChannel(channel);
        }
    }
}