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
using Firebase.Iid;
using Android.Util;

namespace Energy
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class BatteryFirebaseService : FirebaseInstanceIdService
    {
        const string TAG = "TestFirebaseIIDService";
        public override void OnTokenRefresh()
        {
            SendRegistrationToService(FirebaseInstanceId.Instance.Token);
            Console.WriteLine($"Token: {FirebaseInstanceId.Instance.Token}");
        }

        private void SendRegistrationToService(string token)
        {
            //SOME IMPLEMENTATION HERE
        }
    }
}