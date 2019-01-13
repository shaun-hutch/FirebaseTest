using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;
using Android.Graphics;
using Firebase.Messaging;

namespace Energy
{
    [Activity(Label = "Energy", MainLauncher = true)]
    public class MainActivity : Activity 
    {
        private TextView txtBatteryLevel;
        private Switch switchBroadcast;
        int batteryLevel;
        int batteryScale;
        int batteryPercentage;
        BatteryReciever receiver;
        IntentFilter filter;

        internal static readonly string CHANNEL_ID = "test_channel";
        internal static readonly int NOTIFICATION_ID = 3;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            if (Intent.Extras != null)
            {
                foreach (var key in Intent.Extras.KeySet())
                {
                    Console.WriteLine($"Key: {key}, Value: {Intent.Extras.GetString(key)}, ");
                }
            }


            this.SetBarColours(Color.DarkGreen);
            receiver = new BatteryReciever(this);
            filter = new IntentFilter(Intent.ActionBatteryChanged);
            var battery = RegisterReceiver(receiver, filter);
            txtBatteryLevel = FindViewById<TextView>(Resource.Id.batteryLevel);
            switchBroadcast = FindViewById<Switch>(Resource.Id.switchBroadcast);
            switchBroadcast.CheckedChange += SwitchBroadcast_CheckedChange;


            batteryLevel = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
            batteryScale = battery.GetIntExtra(BatteryManager.ExtraScale, -1);
            batteryPercentage = int.Parse(Math.Floor(batteryLevel * 100D / batteryScale).ToString());

            txtBatteryLevel.Text = $"Battery Level: {batteryPercentage}%";

            bool playServicesAvailable = DroidHelper.IsPlayServicesAvailable(this);
            Toast.MakeText(this, $"Google Play Services Availability: {(playServicesAvailable ? "Yes" : "No")}", ToastLength.Long).Show();

            DroidHelper.CreateNotificationChannel(this, CHANNEL_ID);

            FirebaseMessaging.Instance.SubscribeToTopic("test");
        }

        private void SwitchBroadcast_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
            {
                RegisterReceiver(receiver, filter);
            }
            else
            {
                UnregisterReceiver(receiver);
            }
        }

        protected override void OnDestroy()
        {
            UnregisterReceiver(receiver);
            base.OnDestroy();
        }
    }
}