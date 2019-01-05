using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

namespace Energy
{
    [Activity(Label = "Energy", MainLauncher = true)]
    public class MainActivity : Activity 
    {
        private TextView txtBatteryLevel;
        int batteryLevel;
        int batteryScale;
        int batteryPercentage;
        BatteryReciever receiver;
        IntentFilter filter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            receiver = new BatteryReciever(this);
            filter = new IntentFilter(Intent.ActionBatteryChanged);
            var battery = RegisterReceiver(receiver, filter);
            txtBatteryLevel = FindViewById<TextView>(Resource.Id.batteryLevel);
            batteryLevel = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
            batteryScale = battery.GetIntExtra(BatteryManager.ExtraScale, -1);
            batteryPercentage = int.Parse(Math.Floor(batteryLevel * 100D / batteryScale).ToString());

            txtBatteryLevel.Text = $"Battery Level: {batteryPercentage}%";
        }

        protected override void OnResume()
        {
            base.OnResume();
            RegisterReceiver(receiver, filter);
            Console.WriteLine("registered!");
        }

        protected override void OnDestroy()
        {
            UnregisterReceiver(receiver);
            Console.WriteLine("Unregistered!");
            base.OnDestroy();
        }


    }
}